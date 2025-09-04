using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace ArecaIPIS.Forms
{
    class PaginationHelperClass
    {

        private DataTable originalDataTable;
        private int pageSize;
        private int currentPage;
        private decimal recordCount;

        public PaginationHelperClass(DataTable dataTable, int pageSize)
        {
            this.originalDataTable = dataTable;
            this.pageSize = pageSize;
            this.currentPage = 1;

            this.recordCount = originalDataTable.Rows.Count;
            LoadDataForPage(currentPage);
        }

        public DataTable GetCurrentPageData()
        {


            int startIndex = (currentPage - 1) * pageSize;


            DataTable displayDataTable = originalDataTable.Clone();
            try
            {



                for (int i = startIndex; i < Math.Min(startIndex + pageSize, originalDataTable.Rows.Count); i++)
                {
                    displayDataTable.ImportRow(originalDataTable.Rows[i]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return displayDataTable;
        }

        public void LoadDataForPage(int page)
        {
            currentPage = page;
        }

        public void UpdatePaginationControls(Panel pnlPagination, Action<int> onPageChanged)
        {
            try
            {


                List<Page> pages = new List<Page>();
                int startIndex, endIndex;
                int pagerSpan = 6;

                double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
                int pageCount = (int)Math.Ceiling(dblPageCount);
                startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
                endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
                if (currentPage > pagerSpan % 2)
                {
                    if (currentPage == 2)
                    {
                        endIndex = 5;
                    }
                    else
                    {
                        endIndex = currentPage + 2;
                    }
                }
                else
                {
                    endIndex = (pagerSpan - currentPage) + 1;
                }

                if (endIndex - (pagerSpan - 1) > startIndex)
                {
                    startIndex = endIndex - (pagerSpan - 1);
                }

                if (endIndex > pageCount)
                {
                    endIndex = pageCount;
                    startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
                }

                if (currentPage > 1)
                {
                    pages.Add(new Page { Text = "|<", Value = "1" });
                }

                if (currentPage > 1)
                {
                    pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
                }

                for (int i = startIndex; i <= endIndex; i++)
                {
                    pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
                }

                if (currentPage < pageCount)
                {
                    pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
                }

                if (currentPage != pageCount)
                {
                    pages.Add(new Page { Text = ">|", Value = pageCount.ToString() });
                }

                pnlPagination.Controls.Clear();

                int count = 0;
                int panelWidth = pnlPagination.Width;
                int totalButtonWidth = pages.Count * 38;
                int startingPosition = (panelWidth - totalButtonWidth) / 2;


                List<Button> paginationButtons = new List<Button>();

                foreach (Page page in pages)
                {
                    Button btnPage = new Button();
                    btnPage.Size = new System.Drawing.Size(45, 22);
                    btnPage.Name = page.Value;
                    btnPage.Text = page.Text;
                    btnPage.Font = new Font(btnPage.Font, FontStyle.Bold);
                    btnPage.ForeColor = Color.White;
                    btnPage.FlatStyle = FlatStyle.Flat;
                    btnPage.BackColor = Color.LightSeaGreen;
                    btnPage.Enabled = !page.Selected;
                    if (page.Selected)
                    {
                        btnPage.ForeColor = Color.White;
                        btnPage.BackColor = Color.LightPink;
                    }
                    btnPage.Click += (sender, e) =>
                    {
                        Button btnPager = (sender as Button);
                        int pageIndex = int.Parse(btnPager.Name);
                        onPageChanged(pageIndex);
                    };

                    int xCoordinate = startingPosition + (38 * count);
                    btnPage.Location = new System.Drawing.Point(xCoordinate, 10);
                    pnlPagination.Controls.Add(btnPage);
                    count++;
                }

                int verticalPadding = 5;
                int labelYCoordinate = pnlPagination.Controls.Count > 0 ? pnlPagination.Controls[0].Bottom + verticalPadding : 10;

                int recordStartIndex = (currentPage - 1) * pageSize + 1;
                int recordEndIndex = (int)Math.Min(currentPage * pageSize, recordCount);
                string pageInfoText = $"{recordStartIndex}-{recordEndIndex} out of {recordCount}";

                Label lblPageInfo = new Label();
                lblPageInfo.Text = pageInfoText;
                lblPageInfo.AutoSize = true;
                lblPageInfo.ForeColor = Color.Black;
                lblPageInfo.BackColor = Color.White;
                lblPageInfo.Font = new Font(lblPageInfo.Font, FontStyle.Bold);
                lblPageInfo.Location = new Point((pnlPagination.Width - lblPageInfo.Width) / 2, labelYCoordinate);
                pnlPagination.Controls.Add(lblPageInfo);


                //foreach (Button btn in paginationButtons)
                //{
                //    pnlPagination.Controls.Add(btn);
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

    }
}
