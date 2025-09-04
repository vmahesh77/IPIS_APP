using ArecaIPIS.Classes;
using System;
using System.Windows.Forms;

namespace ArecaIPIS.DAL
{
    public delegate void UpdatePageLabelDelegate(int currentPage, int totalPages);
    class DataGridManager
    {
        private readonly DataGridView dataGridView;
        private readonly DbConnection dbConnection;
        private readonly Action<bool> enablePreviousNavigation;
        private readonly Action<bool> enableNextNavigation;
        private int pageSize = 5;// Number of rows to fetch per page
        private int currentPage = 1; // Current page number
        private int totalRows = 0; // Total rows in the database
        private readonly UpdatePageLabelDelegate updatePageLabel;
        public DataGridManager(DataGridView dataGridView, DbConnection dbConnection, Action<bool> enablePreviousNavigation, Action<bool> enableNextNavigation, UpdatePageLabelDelegate updatePageLabel)
        {
            this.dataGridView = dataGridView;
            this.dbConnection = dbConnection;
            this.enablePreviousNavigation = enablePreviousNavigation;
            this.enableNextNavigation = enableNextNavigation;
            this.updatePageLabel = updatePageLabel;
        }


        public void PopulateDataGridView(DataGridView dataGridView)
        {
            try
            {
                // Calculate total rows
                totalRows = dataGridView.Rows.Count;

                // Calculate total pages
                int totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

                // Calculate current page
                int startIndex = (currentPage - 1) * pageSize;
                int endIndex = Math.Min(startIndex + pageSize - 1, totalRows - 1);

                // Hide all rows
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    //row.Visible = false;
                }

                // Show rows for current page
                for (int i = startIndex; i <= endIndex; i++)
                {
                    dataGridView.Rows[i].Visible = true;
                }

                // Update navigation buttons
                UpdateNavigationButtons();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        public void PopulateDataGridView(DataGridView dataGridView, int currentPage, int pageSize, int totalRows)
        {
            try
            {
                // Calculate the starting index for the current page
                int startIndex = (currentPage - 1) * pageSize;

                // Calculate the ending index for the current page
                int endIndex = Math.Min(startIndex + pageSize - 1, totalRows - 1);

                // Hide all rows
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Visible = false;
                }

                // Show rows for the current page
                for (int i = startIndex; i <= endIndex; i++)
                {
                    dataGridView.Rows[i].Visible = true;
                }

                // Update navigation buttons
                UpdateNavigationButtons();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
                // Handle any exceptions that might occur during data population
                // MessageBox.Show($"Error populating DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateNavigationButtons()
        {
            try
            {


                int totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
                enablePreviousNavigation(currentPage > 1);
                enableNextNavigation(currentPage < totalPages);
                // Update the page label
                updatePageLabel(currentPage, totalPages);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        public void PreviousPage(DataGridView dataGridView)
        {
            try
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    PopulateDataGridView(dataGridView);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }

        public void NextPage(DataGridView dataGridView)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
                if (currentPage < totalPages)
                {
                    currentPage++;
                    PopulateDataGridView(dataGridView);
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.ToString());
            }
        }


    }
}
