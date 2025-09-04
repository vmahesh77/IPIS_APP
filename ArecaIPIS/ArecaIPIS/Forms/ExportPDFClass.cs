using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;





namespace ArecaIPIS.Forms
{
    class ExportPDFClass
    {

        //public void ExportToPDF(string fileName, string headerText, System.Data.DataTable Report)
        //{
        //    try
        //    {
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 50f, 10f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(fileName, FileMode.Create));


        //        pdfDoc.AddHeader("Header", headerText);
        //        //HeaderFooter header = new HeaderFooter(new Phrase(headerText, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.BLUE)), false);
        //        //header.Alignment = Element.ALIGN_CENTER;
        //        //header.Border = Rectangle.NO_BORDER;
        //        //pdfDoc.Header = header;
        //        pdfDoc.Open();

        //        PdfPTable pdfTable = new PdfPTable(Report.Columns.Count);
        //        pdfTable.DefaultCell.Padding = 3;
        //        pdfTable.WidthPercentage = 100;
        //        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

        //        foreach (DataColumn column in Report.Columns)
        //        {
        //            PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
        //            cell.BackgroundColor = BaseColor.ORANGE;
        //            pdfTable.AddCell(cell);
        //        }

        //        foreach (DataRow row in Report.Rows)
        //        {
        //            foreach (object item in row.ItemArray)
        //            {
        //                pdfTable.AddCell(item?.ToString());
        //            }
        //        }

        //        pdfDoc.Add(pdfTable);

        //        pdfDoc.Close();

        //        MessageBox.Show("Data Exported Successfully as PDF!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error exporting data to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        public static void ExportToPDF(string fileName, string headerText, System.Data.DataTable Report)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 50f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(fileName, FileMode.Create));

                pdfDoc.Open();

                if (!string.IsNullOrEmpty(headerText))
                {
                    PdfContentByte cb = writer.DirectContent;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb.SaveState();

                    cb.SetColorFill(BaseColor.BLUE);
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 16);

                    float textWidth = bf.GetWidthPoint(headerText, 16);
                    float pageWidth = pdfDoc.PageSize.Width;
                    float centerX = (pageWidth - textWidth) / 2;


                    cb.ShowTextAligned(Element.ALIGN_LEFT, headerText, centerX, pdfDoc.PageSize.Height - 20, 0);
                    //cb.EndText();

                    string currentDateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                    float dateTimeWidth = bf.GetWidthPoint(currentDateTime, 8);

                    float rightX = pageWidth - dateTimeWidth - 25;
                    cb.SetFontAndSize(bf, 8);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, currentDateTime, rightX, pdfDoc.PageSize.Height - 38, 0);

                    cb.EndText();


                    cb.RestoreState();
                }

                PdfPTable pdfTable = new PdfPTable(Report.Columns.Count);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


                float[] columnWidths = new float[Report.Columns.Count];
                for (int i = 0; i < Report.Columns.Count; i++)
                {

                    columnWidths[i] = 1f;
                }
                if (Report.Columns.Count == 3)
                {
                    columnWidths[0] = 0.3f;
                    columnWidths[1] = 0.5f;
                }
                else
                {
                    columnWidths[0] = 0.5f;
                }
                pdfTable.SetWidths(columnWidths);



                foreach (DataColumn column in Report.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                    cell.BackgroundColor = BaseColor.ORANGE;
                    pdfTable.AddCell(cell);
                }

                foreach (DataRow row in Report.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        pdfTable.AddCell(item?.ToString());
                    }
                }

                pdfDoc.Add(pdfTable);


                pdfDoc.Close();

                MessageBox.Show("Data Exported Successfully as PDF!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //public static void ExportToExcel(string filePath, string header, System.Data.DataTable reportData)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //    using (ExcelPackage package = new ExcelPackage())
        //    {

        //        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

        //        // Add header
        //        worksheet.Cells[1, 1].Value = header;

        //        // Load data into the worksheet starting from cell A2
        //        worksheet.Cells["A2"].LoadFromDataTable(reportData, true);

        //        using (var range = worksheet.Cells[1, 1, 1, reportData.Columns.Count])
        //        {
        //            range.Style.Font.Bold = true;
        //            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        //        }

        //        // Save the package to the specified file path
        //        FileInfo excelFile = new FileInfo(filePath);
        //        package.SaveAs(excelFile);
        //    }
        //}


        public static void ExportToExcel(string filePath, string header, System.Data.DataTable reportData)
        {
            try
            {

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

                    worksheet.Cells["A2"].LoadFromDataTable(reportData, true);


                    int totalColumns = reportData.Columns.Count;
                    worksheet.Cells[1, 1, 1, totalColumns].Merge = true;
                    worksheet.Cells[1, 1].Value = header;


                    worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                    worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);


                    for (int i = 0; i < reportData.Columns.Count; i++)
                    {
                        if (reportData.Columns[i].DataType == typeof(DateTime))
                        {
                            // Format the Excel cells in the date column
                            worksheet.Column(i + 1).Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                        }
                    }

                    FileInfo excelFile = new FileInfo(filePath);
                    package.SaveAs(excelFile);
                    MessageBox.Show("Data Exported Successfully as ExcelFile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}


