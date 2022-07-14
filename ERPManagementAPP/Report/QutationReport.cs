using DevExpress.XtraReports.UI;
using ERPManagementAPP.Models;
using System.Drawing;
using System.Linq;

namespace ERPManagementAPP.Report
{
    public partial class QutationReport : DevExpress.XtraReports.UI.XtraReport
    {
        public QutationReport()
        {
            InitializeComponent();
        }
        public void Create_View(CustomerSetting customerSetting, EmployeeSetting employeeSetting, ProjectSetting projectSetting, QuotationSetting quotationSetting)
        {
            xlbl_QuotationNumber.Text = quotationSetting.QuotationNumber;
            xlbl_QuotationDate.Text = quotationSetting.QuotationDate.ToString("yyyy年MM月dd日");
            if (customerSetting != null)
            {
                xlbl_CustomerName.Text = customerSetting.CustomerName;
                xlbl_Phone.Text = customerSetting.Phone;
                xlbl_Fax.Text = customerSetting.Fax;
                xlbl_UniformNumbers.Text = customerSetting.UniformNumbers;
            }
            if (employeeSetting != null)
            {
                xlbl_QuotationEmployeeNumber.Text = employeeSetting.EmployeeName;
                xlbl_QuotationEmployeePhone.Text = employeeSetting.Phone;
                xlbl_QuotationEmployeeEmail.Text = employeeSetting.Address;
            }
            if (quotationSetting.Address == "")
            {
                //xlbl_Address.Text = "新北市三重區重新路五段525號2樓之2";
            }
            else
            {
                xlbl_Address.Text = quotationSetting.Address;
            }
            if (projectSetting != null)
            {
                xlbl_ProjectName.Text = projectSetting.ProjectName;
            }
        
            XRTable xRTable = new XRTable();
            Detail.Controls.Add(xRTable);
            int numRows = quotationSetting.QuotationSub.Count;
            var quotationSub = quotationSetting.QuotationSub.OrderBy(g => g.QuotationNo).ToList();
            xRTable.BeginInit();
            for (int i = 0; i < numRows; i++)
            {
                if (quotationSub[i].LineFlag == 0)//大項
                {
                    XRTableRow xRTableRow = new XRTableRow();
                    xRTable.Rows.Add(xRTableRow);
                    xRTableRow.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                    XRTableCell xRTableCell1 = new XRTableCell();
                    xRTableCell1.WidthF = 56.26f;
                    xRTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    XRTableCell xRTableCell2 = new XRTableCell();
                    xRTableCell2.WidthF = 327.77f + 82.09f + 90.71f + 115.09f + 115.09f;
                    xRTableCell2.Multiline = true;
                    //XRTableCell xRTableCell3 = new XRTableCell();
                    //xRTableCell3.WidthF = 82.09f;
                    //xRTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    //XRTableCell xRTableCell4 = new XRTableCell();
                    //xRTableCell4.WidthF = 90.71f;
                    //xRTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    //XRTableCell xRTableCell5 = new XRTableCell();
                    //xRTableCell5.WidthF = 115.09f;
                    //xRTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    //XRTableCell xRTableCell6 = new XRTableCell();
                    //xRTableCell6.WidthF = 115.09f;
                    //xRTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    xRTableCell1.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    xRTableCell2.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    //xRTableCell3.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    //xRTableCell4.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    //xRTableCell5.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    //xRTableCell6.Font = new Font("微軟正黑體", 12, FontStyle.Bold);

                    xRTableCell1.BackColor = Color.FromArgb(231, 230, 230);
                    xRTableCell2.BackColor = Color.FromArgb(231, 230, 230);
                    //xRTableCell3.BackColor = Color.FromArgb(231, 230, 230);
                    //xRTableCell4.BackColor = Color.FromArgb(231, 230, 230);
                    //xRTableCell5.BackColor = Color.FromArgb(231, 230, 230);
                    //xRTableCell6.BackColor = Color.FromArgb(231, 230, 230);

                    xRTableCell1.Text = quotationSub[i].QuotationNoStr.ToString();
                    xRTableCell2.Text = quotationSub[i].ProductName;
                    //xRTableCell3.Text = quotationSub[i].ProductUnit.ToString();
                    //xRTableCell4.Text = quotationSub[i].ProductQty.ToString();
                    //xRTableCell5.Text = quotationSub[i].ProductPrice.ToString("N0");
                    //xRTableCell6.Text = quotationSub[i].ProductTotal.ToString("N0");
                    xRTable.Rows[i].Cells.Add(xRTableCell1);
                    xRTable.Rows[i].Cells.Add(xRTableCell2);
                    //xRTable.Rows[i].Cells.Add(xRTableCell3);
                    //xRTable.Rows[i].Cells.Add(xRTableCell4);
                    //xRTable.Rows[i].Cells.Add(xRTableCell5);
                    //xRTable.Rows[i].Cells.Add(xRTableCell6);
                }
                else if (quotationSub[i].LineFlag == 1)//中項
                {
                    XRTableRow xRTableRow = new XRTableRow();
                    xRTable.Rows.Add(xRTableRow);
                    xRTableRow.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                    XRTableCell xRTableCell1 = new XRTableCell();
                    xRTableCell1.WidthF = 56.26f;
                    xRTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    XRTableCell xRTableCell2 = new XRTableCell();
                    xRTableCell2.WidthF = 327.77f;
                    xRTableCell2.Multiline = true;
                    XRTableCell xRTableCell3 = new XRTableCell();
                    xRTableCell3.WidthF = 82.09f;
                    xRTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    XRTableCell xRTableCell4 = new XRTableCell();
                    xRTableCell4.WidthF = 90.71f;
                    xRTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    XRTableCell xRTableCell5 = new XRTableCell();
                    xRTableCell5.WidthF = 115.09f;
                    xRTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    XRTableCell xRTableCell6 = new XRTableCell();
                    xRTableCell6.WidthF = 115.09f;
                    xRTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    xRTableCell1.Font = new Font("微軟正黑體", 10);
                    xRTableCell2.Font = new Font("微軟正黑體", 10);
                    xRTableCell3.Font = new Font("微軟正黑體", 10);
                    xRTableCell4.Font = new Font("微軟正黑體", 10);
                    xRTableCell5.Font = new Font("微軟正黑體", 10);
                    xRTableCell6.Font = new Font("微軟正黑體", 10);
                    xRTableCell1.Text = quotationSub[i].QuotationNoStr.ToString();
                    xRTableCell2.Text = quotationSub[i].ProductName;
                    xRTableCell3.Text = quotationSub[i].ProductUnit.ToString();
                    xRTableCell4.Text = quotationSub[i].ProductQty.ToString();
                    xRTableCell5.Text = quotationSub[i].ProductPrice.ToString("N0");
                    xRTableCell6.Text = quotationSub[i].ProductTotal.ToString("N0");
                    xRTable.Rows[i].Cells.Add(xRTableCell1);
                    xRTable.Rows[i].Cells.Add(xRTableCell2);
                    xRTable.Rows[i].Cells.Add(xRTableCell3);
                    xRTable.Rows[i].Cells.Add(xRTableCell4);
                    xRTable.Rows[i].Cells.Add(xRTableCell5);
                    xRTable.Rows[i].Cells.Add(xRTableCell6);
                }
                else//小項
                {
                    XRTableRow xRTableRow = new XRTableRow();
                    xRTable.Rows.Add(xRTableRow);
                    xRTableRow.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                    XRTableCell xRTableCell1 = new XRTableCell();
                    xRTableCell1.WidthF = 56.26f;
                    xRTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    XRTableCell xRTableCell2 = new XRTableCell();
                    xRTableCell2.WidthF = 327.77f + 82.09f + 90.71f + 115.09f + 115.09f;
                    xRTableCell2.Multiline = true;
                    //XRTableCell xRTableCell3 = new XRTableCell();
                    //xRTableCell3.WidthF = 82.09f;
                    //xRTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    //XRTableCell xRTableCell4 = new XRTableCell();
                    //xRTableCell4.WidthF = 90.71f;
                    //xRTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    //XRTableCell xRTableCell5 = new XRTableCell();
                    //xRTableCell5.WidthF = 115.09f;
                    //xRTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    //XRTableCell xRTableCell6 = new XRTableCell();
                    //xRTableCell6.WidthF = 115.09f;
                    //xRTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    //xRTableCell1.Text = quotationSub[i].QuotationNoStr.ToString();
                    xRTableCell1.Font = new Font("微軟正黑體", 8);
                    xRTableCell2.Font = new Font("微軟正黑體", 8);
                    //xRTableCell3.Font = new Font("微軟正黑體", 8);
                    //xRTableCell4.Font = new Font("微軟正黑體", 8);
                    //xRTableCell5.Font = new Font("微軟正黑體", 8);
                    //xRTableCell6.Font = new Font("微軟正黑體", 8);
                    xRTableCell2.Text = quotationSub[i].ProductName;
                    //xRTableCell3.Text = quotationSub[i].ProductUnit.ToString();
                    //xRTableCell4.Text = quotationSub[i].ProductQty.ToString();
                    //xRTableCell5.Text = quotationSub[i].ProductPrice.ToString("N0");
                    //xRTableCell6.Text = quotationSub[i].ProductTotal.ToString("N0");
                    xRTable.Rows[i].Cells.Add(xRTableCell1);
                    xRTable.Rows[i].Cells.Add(xRTableCell2);
                    //xRTable.Rows[i].Cells.Add(xRTableCell3);
                    //xRTable.Rows[i].Cells.Add(xRTableCell4);
                    //xRTable.Rows[i].Cells.Add(xRTableCell5);
                    //xRTable.Rows[i].Cells.Add(xRTableCell6);
                }
            }
            XRTableRow xRTableRow_Empty = new XRTableRow();
            xRTable.Rows.Add(xRTableRow_Empty);
            XRTableCell xRTableCell_Empty = new XRTableCell();
            xRTableCell_Empty.WidthF = 787.01f;
            xRTableCell_Empty.Text = "--------------------------------------------------   以   下   空   白   --------------------------------------------------";
            xRTableCell_Empty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xRTable.Rows[xRTable.Rows.Count - 1].Cells.Add(xRTableCell_Empty);
            xRTable.HeightF = 30.88f * numRows;
            xRTable.WidthF = 787.01f;
            xRTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            xRTable.EndInit();

            xlbl_Total.Text = quotationSetting.Total.ToString("N0");
            xlbl_Tax.Text = quotationSetting.Tax.ToString("N0");
            xlbl_TotalTax.Text = quotationSetting.TotalTax.ToString("N0");
            xlbl_Remark.Text = quotationSetting.Remark;
        }
    }
}
