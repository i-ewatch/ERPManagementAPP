using DevExpress.XtraReports.UI;
using ERPManagementAPP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERPManagementAPP.Report
{
    public partial class OrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public OrderReport()
        {
            InitializeComponent();
        }
        public void Create_View(List<CompanySetting> companySettings, CompanyDirectorySetting companyDirectorySetting, EmployeeSetting employeeSetting, ProjectSetting projectSetting, OrderSetting orderSetting)
        {
            xlbl_OrderNumber.Text = orderSetting.OrderNumber;
            xlbl_OrderDate.Text = orderSetting.OrderDate.ToString("yyyy年MM月dd日");
            var companySetting = companySettings.SingleOrDefault(g => g.CompanyNumber == orderSetting.OrderCompanyNumber);
            if (companySetting != null)
            {
                xlbl_CompanyName.Text = companySetting.CompanyName;
                xlbl_CompanyDirectoryName.Text = companyDirectorySetting.DirectoryName;
                xlbl_Phone.Text = companySetting.Phone;
                xlbl_Fax.Text = companySetting.Fax;
                xlbl_Email.Text = companyDirectorySetting.Email;
            }
            if (orderSetting.Address == "")
            {
                xlbl_Address.Text = "新北市三重區重新路五段525號2樓之2";
            }
            else
            {
                xlbl_Address.Text = orderSetting.Address;
            }
            if (projectSetting != null)
            {
                xlbl_ProjectName.Text = projectSetting.ProjectName;
            }
            if (employeeSetting != null)
            {
                xlbl_OrderEmployeeNumber.Text = employeeSetting.EmployeeName;
                xlbl_OrderEmployeePhone.Text = employeeSetting.Phone;
                xlbl_OrderEmployeeEmail.Text = employeeSetting.Address;
            }

            XRTable xRTable = new XRTable();
            Detail.Controls.Add(xRTable);
            int numRows = orderSetting.OrderSub.Count;
            xRTable.BeginInit();
            for (int i = 0; i < numRows; i++)
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
                xRTable.Rows[i].Cells.Add(xRTableCell1);
                xRTable.Rows[i].Cells.Add(xRTableCell2);
                xRTable.Rows[i].Cells.Add(xRTableCell3);
                xRTable.Rows[i].Cells.Add(xRTableCell4);
                xRTable.Rows[i].Cells.Add(xRTableCell5);
                xRTable.Rows[i].Cells.Add(xRTableCell6);
                xRTableCell1.Text = orderSetting.OrderSub[i].OrderNo.ToString();
                xRTableCell2.Text = orderSetting.OrderSub[i].ProductName;
                xRTableCell3.Text = orderSetting.OrderSub[i].ProductUnit.ToString();
                xRTableCell4.Text = orderSetting.OrderSub[i].ProductQty.ToString();
                xRTableCell5.Text = orderSetting.OrderSub[i].ProductPrice.ToString("N0");
                xRTableCell6.Text = orderSetting.OrderSub[i].ProductTotal.ToString("N0");
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
            xlbl_Total.Text = orderSetting.Total.ToString("N0");
            xlbl_Tax.Text = orderSetting.Tax.ToString("N0");
            xlbl_TotalTax.Text = orderSetting.TotalTax.ToString("N0");
            xlbl_Remark.Text = orderSetting.Remark;
            string[] Note = orderSetting.OrderNote.Split(',');
            foreach (var item in Note)
            {
                switch (item)
                {
                    case "0":
                        {
                            xrCheckBox1.CheckBoxState = DevExpress.XtraPrinting.CheckBoxState.Checked;
                        }
                        break;
                    case "1":
                        {
                            xrCheckBox2.CheckBoxState = DevExpress.XtraPrinting.CheckBoxState.Checked;
                        }
                        break;
                    case "2":
                        {
                            xrCheckBox3.CheckBoxState = DevExpress.XtraPrinting.CheckBoxState.Checked;
                        }
                        break;
                    case "11":
                        {
                            xlbl_OrderNote.Text = "貨到現金付款(T/T)";
                        }
                        break;
                    case "12":
                        {
                            xlbl_OrderNote.Text = "預付現金(T/T)";
                        }
                        break;
                    case "13":
                        {
                            xlbl_OrderNote.Text = "月結 60 天";
                        }
                        break;
                    case "14":
                        {
                            xlbl_OrderNote.Text = "月結 30 天";
                        }
                        break;
                }
            }
        }
    }
}
