using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using ERPManagementAPP.Maintain.PurchaseMainTainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class PurchaseMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 聚焦進貨表頭
        /// </summary>
        private PurchaseMainSetting FocusePurchaseMainSetting { get; set; } = new PurchaseMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<PurchaseMainSetting> PurchaseMainSettings { get; set; } = new List<PurchaseMainSetting>();
        /// <summary>
        /// 總進貨資訊
        /// </summary>
        private List<PurchaseSetting> PurchaseSettings { get; set; } = new List<PurchaseSetting>();
        public PurchaseMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_PurchaseDate.Text = DateTime.Now.ToString("yyyy/MM");
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            #region 進貨資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 進貨資訊報表按鈕
            RepositoryItemButtonEdit Purchaseedit = new RepositoryItemButtonEdit();
            Purchaseedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocusePurchaseMainSetting.FileName != null)
                    {
                        if (FocusePurchaseMainSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_PurchaseAttachmentFile(FocusePurchaseMainSetting.PurchaseCompanyNumber, FocusePurchaseMainSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Purchaseedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Purchaseedit.Buttons[0].Caption = "下載";
            Purchaseedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            PurchasegridControl.RepositoryItems.Add(Purchaseedit);
            gridView1.Columns["FileName"].ColumnEdit = Purchaseedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 進貨聚焦功能
            gridView1.FocusedRowChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 關鍵字搜尋
            gridView1.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 報表修改字串功能
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "PurchaseFlag")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "1":
                            {
                                e.DisplayText = "進貨";
                            }
                            break;
                        case "2":
                            {
                                e.DisplayText = "進貨退出";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "PurchaseCompanyNumber")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CompanyName;
                    }
                }
                else if (e.Column.FieldName == "PurchaseTax")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "應稅";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "零稅";
                            }
                            break;
                        case "2":
                            {
                                e.DisplayText = "免稅";
                            }
                            break;
                        case "3":
                            {
                                e.DisplayText = "二聯";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "Posting")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "未過帳";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "過帳";
                            }
                            break;
                    }
                }
            };
            #endregion
            #region 新增進貨資訊
            btn_Purchase_Add.Click += (s, e) =>
            {
                Refresh_API();
                PurchaseEditForm purchaseEdit = new PurchaseEditForm(CompanySettings, EmployeeSettings, ProductSettings, null, apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改進貨資訊
            btn_Purchase_Edit.Click += (s, e) =>
            {
                Refresh_API();
                PurchaseSettings = APIMethod.Get_Purchase(FocusePurchaseMainSetting);
                PurchaseEditForm purchaseEdit = new PurchaseEditForm(CompanySettings, EmployeeSettings, ProductSettings, PurchaseSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改進貨資訊
            PurchasegridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                PurchaseSettings = APIMethod.Get_Purchase(FocusePurchaseMainSetting);
                PurchaseEditForm purchaseEdit = new PurchaseEditForm(CompanySettings, EmployeeSettings, ProductSettings, PurchaseSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除進貨資訊
            btn_Purchase_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string response = APIMethod.Delete_Purchase(FocusePurchaseMainSetting.PurchaseFlag, FocusePurchaseMainSetting.PurchaseNumber);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除進貨資訊成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除進貨資訊失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品類別資料查詢
            btn_Purchase_Search.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion
        }
        #region 聚焦主資料表功能
        private void FocuseMainGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocusePurchaseMainSetting.PurchaseFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseFlag").ToString());
                FocusePurchaseMainSetting.PurchaseNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseNumber").ToString();
                FocusePurchaseMainSetting.PurchaseDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseDate").ToString());
                FocusePurchaseMainSetting.PurchaseCompanyNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseCompanyNumber").ToString();
                FocusePurchaseMainSetting.PurchaseTax = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseTax").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseInvoiceNo") != null)
                {
                    FocusePurchaseMainSetting.PurchaseInvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseInvoiceNo").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.PurchaseInvoiceNo = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseEmployeeNumber") != null)
                {
                    FocusePurchaseMainSetting.PurchaseEmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseEmployeeNumber").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.PurchaseEmployeeNumber = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocusePurchaseMainSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.Remark = "";
                }
                FocusePurchaseMainSetting.Total = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString());
                FocusePurchaseMainSetting.Tax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tax").ToString());
                FocusePurchaseMainSetting.TotalTax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalTax").ToString());
                FocusePurchaseMainSetting.Posting = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Posting").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocusePurchaseMainSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.FileName = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate") != null)
                {
                    FocusePurchaseMainSetting.PostingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate").ToString());
                }
                else
                {
                    FocusePurchaseMainSetting.PostingDate = null;
                }
            }
            else
            {
                FocusePurchaseMainSetting = new PurchaseMainSetting();
            }
        }
        #endregion
        #region 下載檔案功能
        private void SaveFile(byte[] File, int Index)
        {
            if (File != null)
            {
                apiMethod.ClientFlag = true;
                if (File.Length > 147)
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = FocusePurchaseMainSetting.FileName;
                    saveFileDialog.Title = "Save File Path";
                    saveFileDialog.Filter = "All|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream data = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            data.Write(File, 0, File.Length);
                            data.Close();
                        }
                        action.Caption = "下載檔案成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Caption = "下載檔案錯誤";
                    action.Description = "伺服器找不到此檔案";
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                apiMethod.ClientFlag = false;
                action.Caption = "下載檔案錯誤";
                action.Description = apiMethod.ErrorStr;
                FlyoutDialog.Show(Form1, action);
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            Refresh_API();
            PurchaseMainSettings = apiMethod.Get_Purchase(det_PurchaseDate.Text.Replace("/", ""));
            PurchasegridControl.DataSource = PurchaseMainSettings;
        }
        private void Refresh_API()
        {
            CompanySettings = apiMethod.Get_Company();
            EmployeeSettings = apiMethod.Get_Employee();
            ProductSettings = apiMethod.Get_Product();
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Purchase_Delete.Visible = false;
            }
            else
            {
                btn_Purchase_Delete.Visible = true;
            }
        }
    }
}
