using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.OrderMaintainForm
{
    public partial class OrderEditForm : BaseEditForm
    {
        /// <summary>
        /// 聚焦表身資訊
        /// </summary>
        private OrderSubSetting FocuseOrderSubSetting { get; set; } = new OrderSubSetting();
        /// <summary>
        /// 表身資訊
        /// </summary>
        private List<OrderSubSetting> OrderSubSettings { get; set; } = new List<OrderSubSetting>();
        /// <summary>
        /// 進貨資訊
        /// </summary>
        private OrderSetting OrderSetting { get; set; } = new OrderSetting();
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        /// <summary>
        /// 公司員工編號
        /// </summary>
        private List<CompanyDirectorySetting> CompanyDirectorySettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 被選擇的公司資訊
        /// </summary>
        private CompanyDirectorySetting SelectCompanyDirectorySetting { get; set; }
        /// <summary>
        /// 被選擇的產品資訊
        /// </summary>
        private ProductSetting SelectProductSetting { get; set; }
        /// <summary>
        /// 被選擇的專案資訊
        /// </summary>
        private ProjectSetting SelectProjectSetting { get; set; }
        /// <summary>
        /// 訂購需知
        /// </summary>
        private string OrderNote = "";
        /// <summary>
        /// 產品數量
        /// </summary>
        private double ProductQty = 0;
        /// <summary>
        /// 產品單價
        /// </summary>
        private double ProductPrice = 0;
        /// <summary>
        /// 數量合計
        /// </summary>
        private double TotalQty = 0;
        /// <summary>
        /// 合計
        /// </summary>
        private double Total = 0;
        /// <summary>
        /// 稅金
        /// </summary>
        private double Tax = 0;
        /// <summary>
        /// 稅後總計
        /// </summary>
        private double TotalTax = 0;
        public OrderEditForm(List<CompanySetting> companySettings, List<CompanyDirectorySetting> companyDirectorySettings, List<EmployeeSetting> employeeSettings, List<ProductSetting> productSettings, List<ProjectSetting> projectSettings, OrderSetting orderSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            action1.Commands.Add(FlyoutCommand.Yes);
            action1.Commands.Add(FlyoutCommand.Cancel);
            CompanySettings = companySettings;
            CompanyDirectorySettings = companyDirectorySettings;
            EmployeeSettings = employeeSettings;
            ProductSettings = productSettings;
            OrderSetting = orderSetting;
            ProjectSettings = projectSettings;
            Create_slt_OrdercompanyNumber();
            Create_cbt_EmployeeNumber_cbt();
            Create_cbt_ProductName_cbt();
            Create_slt_ProjectNumber();
            if (orderSetting != null)
            {
                txt_OrderNumber.Text = orderSetting.OrderNumber;
                det_OrderDate.Text = orderSetting.OrderDate.ToString("yyyy年MM月dd日");
                cbt_InvalidFlag.SelectedIndex = Convert.ToInt32(orderSetting.InvalidFlag);
                Show_ProductCompanyNumber_Index();
                Show_ProjectNumber_Index();
                Show_EmployeeNumber_Index();
                CheckEdit_Show(orderSetting.OrderNote);
                cbt_OrderTax.SelectedIndex = orderSetting.OrderTax;
                txt_Address.Text = orderSetting.Address;
                mmt_Remark.Text = orderSetting.Remark;
                OrderSubSettings = orderSetting.OrderSub;
            }
            else
            {
                det_OrderDate.EditValue = DateTime.Now;
                if (Form1.EmployeeSetting != null)
                {
                    Show_EmployeeNumber_Index(Form1.EmployeeSetting.EmployeeName);
                }
            }
            CacalculateData();
            RefreshData();
            First_FocuseMainGrid();
            cbt_OrderTax.SelectedIndexChanged += (s, e) =>
            {
                CacalculateData();
            };
            #region 載入檔案按鈕
            btn_LoadFile.Click += (s, e) =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        AttachmentFilePath = openFileDialog.FileName;
                        txt_FileName.Text = Path.GetFileName(openFileDialog.FileName);
                    }
                }
            };
            #endregion
            #region 清除載入檔案
            btn_ClearFile.Click += (s, e) =>
            {
                AttachmentFilePath = "";
                txt_FileName.Text = "";
            };
            #endregion
            #region 產品小計計算功能
            gridView1.CellValueChanging += (s, e) =>
            {
                if (e.Column.FieldName == "ProductQty")
                {
                    if (e.Value.ToString() != "")
                    {
                        ProductQty = Convert.ToDouble(e.Value.ToString());
                        ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice"));
                        gridView1.SetFocusedRowCellValue("ProductTotal", (ProductQty * ProductPrice).ToString());
                        CacalculateData();
                    }
                    else
                    {
                        gridView1.SetFocusedRowCellValue("ProductTotal", 0);
                    }
                }
                else if (e.Column.FieldName == "ProductPrice")
                {
                    if (e.Value.ToString() != "")
                    {
                        try
                        {
                            ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty"));
                            ProductPrice = Convert.ToDouble(e.Value.ToString());
                            gridView1.SetFocusedRowCellValue("ProductTotal", (ProductQty * ProductPrice).ToString());
                            CacalculateData();
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        gridView1.SetFocusedRowCellValue("ProductTotal", 0);
                    }
                }
                else
                {
                    return;
                }
            };
            #endregion
            #region 報表聚焦功能
            gridView1.FocusedRowChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 細項新增
            btn_Add.Click += (s, e) =>
            {
                if (SelectProductSetting != null)
                {
                    OrderSubSettings.Add(new OrderSubSetting()
                    {
                        OrderNumber = "",
                        OrderNo = OrderSubSettings.Count() + 1,
                        ProductName = SelectProductSetting.ProductName,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    slt_ProductName.EditValue = null;
                    SelectProductSetting = null;
                    txt_productQty.Text = "0";
                    txt_productPrice.Text = "0";
                    txt_ProductName.Text = "";
                    CacalculateData();
                    RefreshData();
                    //FocuseMainGrid();
                }
                else if (!string.IsNullOrEmpty(txt_ProductName.Text))
                {
                    OrderSubSettings.Add(new OrderSubSetting()
                    {
                        OrderNumber = "",
                        OrderNo = OrderSubSettings.Count() + 1,
                        ProductName = txt_ProductName.Text,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    slt_ProductName.EditValue = null;
                    SelectProductSetting = null;
                    txt_productQty.Text = "0";
                    txt_productPrice.Text = "0";
                    txt_ProductName.Text = "";
                    CacalculateData();
                    RefreshData();
                }
                else
                {
                    action.Caption = "細項新增錯誤";
                    action.Description = "請確認資料是否完整";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 表身輸入框清除
            btn_Clear.Click += (s, e) =>
            {
                slt_ProductName.EditValue = null;
                SelectProductSetting = null;
                txt_ProducUnit.Text = "";
                txt_productQty.Text = "0";
                txt_productPrice.Text = "0";
                txt_ProductName.Text = "";
            };
            #endregion
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                for (int i = 0; i < OrderSubSettings.Count; i++)
                {
                    if (OrderSubSettings[i].OrderNo == FocuseOrderSubSetting.OrderNo)
                    {
                        OrderSubSettings.RemoveAt(i);
                    }
                }
                RefraeshPurchaseNo();
                CacalculateData();
                RefreshData();
                //FocuseMainGrid();
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(orderSetting, apiMethod);
            };
            #endregion
            #region 另存按鈕
            btn_SaveAs.Click += (s, e) =>
            {
                CheckNumber_New(apiMethod);
            };
            #endregion
            #region 列印
            btn_Export.Click += (s, e) =>
            {
                if (orderSetting != null)
                {
                    action1.Caption = "訂購單儲存並預覽";
                    if (FlyoutDialog.Show(Form1, action1) == DialogResult.Yes)
                    {
                        string response = "";
                        Checked_Note();
                        orderSetting.OrderNumber = txt_OrderNumber.Text;
                        orderSetting.ProjectNumber = Get_slt_ProjectNumber();
                        orderSetting.OrderDate = Convert.ToDateTime(det_OrderDate.Text);
                        orderSetting.OrderCompanyNumber = SelectCompanyDirectorySetting.DirectoryCompany;
                        orderSetting.OrderDirectoryNumber = SelectCompanyDirectorySetting.DirectoryNumber;
                        orderSetting.Address = txt_Address.Text;
                        orderSetting.OrderEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                        orderSetting.Remark = mmt_Remark.Text;
                        orderSetting.TotalQty = Convert.ToDouble(txt_TotalQty.EditValue);
                        orderSetting.OrderSub = OrderSubSettings;
                        orderSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                        orderSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                        orderSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                        orderSetting.OrderNote = OrderNote;
                        foreach (var item in orderSetting.OrderSub)
                        {
                            item.OrderNumber = txt_OrderNumber.Text;
                        }
                        string value = JsonConvert.SerializeObject(orderSetting);
                        response = apiMethod.Put_Order(value);
                        if (response == "200")
                        {
                            if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                            {
                                List<OrderSetting> settings = JsonConvert.DeserializeObject<List<OrderSetting>>(apiMethod.ResponseDataMessage);
                                Thread.Sleep(80);
                                response = apiMethod.Post_OrderAttachmentFile(settings[0].OrderDate, settings[0].OrderNumber, AttachmentFilePath);
                                if (response != "200")
                                {
                                    action.Description = response;
                                    FlyoutDialog.Show(Form1, action);
                                }
                            }
                        }
                        OrderReportForm purchaseEdit = new OrderReportForm(CompanySettings, SelectCompanyDirectorySetting, EmployeeSettings[cbt_EmployeeNumber.SelectedIndex], SelectProjectSetting, orderSetting);
                        if (purchaseEdit.ShowDialog() == DialogResult.Cancel) { }
                    }
                    //else
                    //{
                    //    OrderReportForm purchaseEdit = new OrderReportForm(CompanySettings, SelectCompanyDirectorySetting, EmployeeSettings[cbt_EmployeeNumber.SelectedIndex], SelectProjectSetting, orderSetting);
                    //    if (purchaseEdit.ShowDialog() == DialogResult.Cancel) { }
                    //}
                }
                else
                {
                    action1.Caption = "訂購單儲存並預覽";
                    if (FlyoutDialog.Show(Form1, action1) == DialogResult.Yes)
                    {
                        if (!string.IsNullOrEmpty(det_OrderDate.Text) && SelectCompanyDirectorySetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                        {
                            string response = "";
                            Checked_Note();
                            OrderSetting OrderSetting = new OrderSetting()
                            {
                                OrderNumber = txt_OrderNumber.Text,
                                ProjectNumber = Get_slt_ProjectNumber(),
                                OrderDate = Convert.ToDateTime(det_OrderDate.Text),
                                OrderCompanyNumber = SelectCompanyDirectorySetting.DirectoryCompany,
                                OrderDirectoryNumber = SelectCompanyDirectorySetting.DirectoryNumber,
                                Address = txt_Address.Text,
                                OrderEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                                Remark = mmt_Remark.Text,
                                TotalQty = Convert.ToDouble(txt_TotalQty.EditValue),
                                OrderNote = OrderNote,
                                Total = Convert.ToDouble(txt_Total.EditValue),
                                Tax = Convert.ToDouble(txt_Tax.EditValue),
                                TotalTax = Convert.ToDouble(txt_TotalTax.EditValue),
                                OrderSub = OrderSubSettings
                            };
                            string value = JsonConvert.SerializeObject(OrderSetting);
                            response = apiMethod.Post_Order(value);
                            if (response == "200")
                            {
                                if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                                {
                                    List<OrderSetting> settings = JsonConvert.DeserializeObject<List<OrderSetting>>(apiMethod.ResponseDataMessage);
                                    Thread.Sleep(80);
                                    response = apiMethod.Post_OrderAttachmentFile(settings[0].OrderDate, settings[0].OrderNumber, AttachmentFilePath);
                                    if (response != "200")
                                    {
                                        action.Description = response;
                                        FlyoutDialog.Show(Form1, action);
                                    }
                                }
                            }
                            if (apiMethod.ResponseDataMessage != null)
                            {
                                var ordersetting = JsonConvert.DeserializeObject<List<OrderSetting>>(apiMethod.ResponseDataMessage);
                                txt_OrderNumber.Text = ordersetting[0].OrderNumber;
                                OrderReportForm purchaseEdit = new OrderReportForm(CompanySettings, SelectCompanyDirectorySetting, EmployeeSettings[cbt_EmployeeNumber.SelectedIndex], SelectProjectSetting, ordersetting[0]);
                                if (purchaseEdit.ShowDialog() == DialogResult.Cancel) { }
                            }
                        }
                    }
                }
            };
            #endregion
        }
        #region 聚焦主資料表功能
        /// <summary>
        /// 聚焦主資料表功能
        /// </summary>
        private void FocuseMainGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocuseOrderSubSetting.OrderNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNumber").ToString();
                FocuseOrderSubSetting.OrderNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNo").ToString());
                FocuseOrderSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocuseOrderSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocuseOrderSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocuseOrderSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocuseOrderSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());
            }
            else
            {
                FocuseOrderSubSetting = new OrderSubSetting();
            }
        }
        private void First_FocuseMainGrid()
        {
            if (gridView1.DataRowCount > 0)
            {
                FocuseOrderSubSetting.OrderNumber = gridView1.GetRowCellValue(0, "OrderNumber").ToString();
                FocuseOrderSubSetting.OrderNo = Convert.ToInt32(gridView1.GetRowCellValue(0, "OrderNo").ToString());
                FocuseOrderSubSetting.ProductName = gridView1.GetRowCellValue(0, "ProductName").ToString();
                FocuseOrderSubSetting.ProductUnit = gridView1.GetRowCellValue(0, "ProductUnit").ToString();
                FocuseOrderSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(0, "ProductQty").ToString());
                FocuseOrderSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(0, "ProductPrice").ToString());
                FocuseOrderSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(0, "ProductTotal").ToString());
            }
            else
            {
                FocuseOrderSubSetting = new OrderSubSetting();
            }
        }
        #endregion
        #region 刷新細項編號
        /// <summary>
        /// 刷新細項編號
        /// </summary>
        private void RefraeshPurchaseNo()
        {
            for (int i = 0; i < OrderSubSettings.Count; i++)
            {
                OrderSubSettings[i].OrderNo = i + 1;
            }
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl1.DataSource = OrderSubSettings;
            gridControl1.RefreshDataSource();
        }
        #endregion
        #region 刷新計算數值
        /// <summary>
        /// 刷新計算數值
        /// </summary>
        private void CacalculateData()
        {
            TotalQty = 0;
            Total = 0;
            Tax = 0;
            TotalTax = 0;
            if (OrderSubSettings.Count > 0)
            {
                foreach (var item in OrderSubSettings)
                {
                    Total += item.ProductTotal;
                    TotalQty += item.ProductQty;
                }
            }
            if (cbt_OrderTax.SelectedIndex == 0)
            {
                Total = Math.Round(Total, 0, MidpointRounding.AwayFromZero);
                Tax = Math.Round(Total * 0.05, 0, MidpointRounding.AwayFromZero);
            }
            TotalTax = Total + Tax;
            txt_Total.EditValue = Total.ToString();
            txt_Tax.EditValue = Tax.ToString();
            txt_TotalTax.EditValue = $"{TotalTax.ToString()}";
            txt_TotalQty.Text = TotalQty.ToString();
        }
        #endregion
        #region 廠商員工編號功能
        /// <summary>
        /// 創建廠商員工下拉選單
        /// </summary>
        private void Create_slt_OrdercompanyNumber()
        {
            slt_OrdercompanyNumber.Properties.DataSource = CompanyDirectorySettings;
            slt_OrdercompanyNumber.Properties.DisplayMember = "DirectoryName";
            slt_OrdercompanyNumber.CustomDisplayText += (s, e) =>
            {
                if (OrderSetting != null)
                {
                    if (SelectCompanyDirectorySetting != null)
                    {
                        if (e.Value.ToString() != "")
                        {
                            SelectCompanyDirectorySetting = e.Value as CompanyDirectorySetting;
                            e.DisplayText = SelectCompanyDirectorySetting.DirectoryName;
                        }
                        else
                        {
                            e.DisplayText = SelectCompanyDirectorySetting.DirectoryName;
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
                else
                {
                    SelectCompanyDirectorySetting = e.Value as CompanyDirectorySetting;
                }
            };
            searchLookUpEdit1View.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "DirectoryCompany")
                {
                    string Index = e.DisplayText.ToString();
                    CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CompanyName;
                    }
                }
            };
        }
        /// <summary>
        /// 顯示廠商員工選單項目
        /// </summary>
        private void Show_ProductCompanyNumber_Index()
        {
            for (int i = 0; i < CompanyDirectorySettings.Count; i++)
            {
                if (CompanyDirectorySettings[i].DirectoryCompany == OrderSetting.OrderCompanyNumber && CompanyDirectorySettings[i].DirectoryNumber == OrderSetting.OrderDirectoryNumber)
                {
                    SelectCompanyDirectorySetting = CompanyDirectorySettings[i];
                    break;
                }
                else
                {
                    SelectCompanyDirectorySetting = null;
                }
            }
        }
        #endregion
        #region 員工編號功能
        /// <summary>
        /// 創建員工編號下拉選單
        /// </summary>
        /// <param name="companySettings"></param>
        private void Create_cbt_EmployeeNumber_cbt()
        {
            if (cbt_EmployeeNumber.Properties.Items.Count > 0)
            {
                cbt_EmployeeNumber.Properties.Items.Clear();
            }
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    cbt_EmployeeNumber.Properties.Items.Add(item.EmployeeName);
                }
            }
        }
        /// <summary>
        /// 取得員工編號
        /// </summary>
        /// <returns></returns>
        private string Get_cbt_EmployeeNumber_Number()
        {
            string value = "";
            if (EmployeeSettings != null)
            {
                if (EmployeeSettings.Count > 0)
                {
                    value = EmployeeSettings[cbt_EmployeeNumber.SelectedIndex].EmployeeNumber;
                }
            }
            return value;
        }
        /// <summary>
        /// 顯示員工名稱
        /// </summary>
        private void Show_EmployeeNumber_Index()
        {
            int Index = -1;
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    if (item.EmployeeNumber == OrderSetting.OrderEmployeeNumber)
                    {
                        Index++;
                        cbt_EmployeeNumber.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
                }
            }
        }
        private void Show_EmployeeNumber_Index(string Name)
        {
            int Index = -1;
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    if (item.EmployeeName == Name)
                    {
                        Index++;
                        cbt_EmployeeNumber.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
                }
            }
        }
        #endregion
        #region 產品編號功能
        /// <summary>
        /// 創建產品編號下拉選單
        /// </summary>
        /// <param name="companySettings"></param>
        private void Create_cbt_ProductName_cbt()
        {
            slt_ProductName.Properties.DataSource = ProductSettings;
            slt_ProductName.Properties.DisplayMember = "ProductName";
            gridView2.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "ProductCompanyNumber")
                {
                    if (CompanySettings != null)
                    {
                        foreach (var item in CompanySettings)
                        {
                            if (item.CompanyNumber == e.Value.ToString())
                            {
                                e.DisplayText = item.CompanyName;
                            }
                        }
                    }
                }
            };
            slt_ProductName.CustomDisplayText += (s, e) =>
            {
                SelectProductSetting = e.Value as ProductSetting;
                if (SelectProductSetting != null)
                {
                    e.DisplayText = SelectProductSetting.ProductName;
                }
                else
                {
                    e.DisplayText = "";
                }
            };
        }
        /// <summary>
        /// 取得產品編號
        /// </summary>
        /// <returns></returns>
        private string Get_cbt_ProductName_Number()
        {
            string value = "";
            if (SelectProductSetting != null)
            {
                value = SelectProductSetting.ProductNumber;
            }
            return value;
        }
        #endregion
        #region 專案代碼功能
        /// <summary>
        /// 創建專案代碼下拉選單
        /// </summary>
        private void Create_slt_ProjectNumber()
        {
            slt_ProjectNumber.Properties.DataSource = ProjectSettings;
            slt_ProjectNumber.Properties.DisplayMember = "ProjectName";
            slt_ProjectNumber.CustomDisplayText += (s, e) =>
            {
                if (OrderSetting != null)
                {
                    if (SelectProjectSetting != null)
                    {
                        if (e.Value == null)
                        {
                            SelectProjectSetting = null;
                            e.DisplayText = "";
                        }
                        else if (e.Value.ToString() != "")
                        {
                            SelectProjectSetting = e.Value as ProjectSetting;
                            e.DisplayText = SelectProjectSetting.ProjectName;
                        }
                        else
                        {
                            e.DisplayText = SelectProjectSetting.ProjectName;
                        }
                    }
                    else
                    {
                        SelectProjectSetting = e.Value as ProjectSetting;
                    }
                }
                else
                {
                    SelectProjectSetting = e.Value as ProjectSetting;
                }
            };
        }
        /// <summary>
        /// 顯示專案代碼項目
        /// </summary>
        private void Show_ProjectNumber_Index()
        {
            for (int i = 0; i < ProjectSettings.Count; i++)
            {
                if (ProjectSettings[i].ProjectNumber == OrderSetting.ProjectNumber)
                {
                    SelectProjectSetting = ProjectSettings[i];
                    break;
                }
                else
                {
                    SelectProjectSetting = null;
                }
            }
        }
        /// <summary>
        /// 取得專案代碼
        /// </summary>
        /// <returns></returns>
        private string Get_slt_ProjectNumber()
        {
            string value = null;
            if (SelectProjectSetting != null)
            {
                value = SelectProjectSetting.ProjectNumber;
            }
            return value;
        }
        #endregion
        #region 檢查資料問題
        private void CheckNumber(OrderSetting orderSetting, APIMethod apiMethod)
        {
            string response = "";
            Checked_Note();
            if (orderSetting != null && orderSetting.OrderNumber != null)
            {
                foreach (var item in OrderSubSettings)
                {
                    item.OrderNumber = txt_OrderNumber.Text;
                }
                action.Caption = "訂購修改錯誤";
                orderSetting.InvalidFlag = Convert.ToBoolean(cbt_InvalidFlag.SelectedIndex);
                orderSetting.OrderNumber = txt_OrderNumber.Text;
                orderSetting.ProjectNumber = Get_slt_ProjectNumber();
                orderSetting.OrderDate = Convert.ToDateTime(det_OrderDate.Text);
                orderSetting.OrderCompanyNumber = SelectCompanyDirectorySetting.DirectoryCompany;
                orderSetting.OrderDirectoryNumber = SelectCompanyDirectorySetting.DirectoryNumber;
                orderSetting.Address = txt_Address.Text;
                orderSetting.OrderEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                orderSetting.Remark = mmt_Remark.Text;
                orderSetting.OrderTax = cbt_OrderTax.SelectedIndex;
                orderSetting.TotalQty = Convert.ToDouble(txt_TotalQty.EditValue);
                orderSetting.OrderSub = OrderSubSettings;
                orderSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                orderSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                orderSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                orderSetting.OrderNote = OrderNote;
                foreach (var item in orderSetting.OrderSub)
                {
                    item.OrderNumber = txt_OrderNumber.Text;
                }
                string value = JsonConvert.SerializeObject(orderSetting);
                response = apiMethod.Put_Order(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        Thread.Sleep(80);
                        response = apiMethod.Post_OrderAttachmentFile(orderSetting.OrderDate, orderSetting.OrderNumber, AttachmentFilePath);
                        if (response == "200")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            action.Description = response;
                            FlyoutDialog.Show(Form1, action);
                        }
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    action.Description = response;
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(det_OrderDate.Text) && SelectCompanyDirectorySetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    OrderSetting OrderSetting = new OrderSetting()
                    {
                        InvalidFlag = Convert.ToBoolean(cbt_InvalidFlag.SelectedIndex),
                        OrderNumber = txt_OrderNumber.Text,
                        ProjectNumber = Get_slt_ProjectNumber(),
                        OrderDate = Convert.ToDateTime(det_OrderDate.Text),
                        OrderCompanyNumber = SelectCompanyDirectorySetting.DirectoryCompany,
                        OrderDirectoryNumber = SelectCompanyDirectorySetting.DirectoryNumber,
                        Address = txt_Address.Text,
                        OrderEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        OrderTax = cbt_OrderTax.SelectedIndex,
                        TotalQty = Convert.ToDouble(txt_TotalQty.EditValue),
                        OrderNote = OrderNote,
                        Total = Convert.ToDouble(txt_Total.EditValue),
                        Tax = Convert.ToDouble(txt_Tax.EditValue),
                        TotalTax = Convert.ToDouble(txt_TotalTax.EditValue),
                        OrderSub = OrderSubSettings
                    };
                    string value = JsonConvert.SerializeObject(OrderSetting);
                    response = apiMethod.Post_Order(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<OrderSetting> settings = JsonConvert.DeserializeObject<List<OrderSetting>>(apiMethod.ResponseDataMessage);
                            Thread.Sleep(80);
                            response = apiMethod.Post_OrderAttachmentFile(settings[0].OrderDate, settings[0].OrderNumber, AttachmentFilePath);
                            if (response == "200")
                            {
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                action.Description = response;
                                FlyoutDialog.Show(Form1, action);
                            }
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        action.Description = response;
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Description = "資料未填選完整";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
        #endregion
        #region 另存檢查資料問題
        private void CheckNumber_New(APIMethod apiMethod)
        {
            string response = "";
            Checked_Note();
            if (!string.IsNullOrEmpty(det_OrderDate.Text) && SelectCompanyDirectorySetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
            {
                OrderSetting OrderSetting = new OrderSetting()
                {
                    InvalidFlag = Convert.ToBoolean(cbt_InvalidFlag.SelectedIndex),
                    OrderNumber = txt_OrderNumber.Text,
                    ProjectNumber = Get_slt_ProjectNumber(),
                    OrderDate = Convert.ToDateTime(det_OrderDate.Text),
                    OrderCompanyNumber = SelectCompanyDirectorySetting.DirectoryCompany,
                    OrderDirectoryNumber = SelectCompanyDirectorySetting.DirectoryNumber,
                    Address = txt_Address.Text,
                    OrderEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                    Remark = mmt_Remark.Text,
                    OrderTax = cbt_OrderTax.SelectedIndex,
                    TotalQty = Convert.ToDouble(txt_TotalQty.EditValue),
                    OrderNote = OrderNote,
                    Total = Convert.ToDouble(txt_Total.EditValue),
                    Tax = Convert.ToDouble(txt_Tax.EditValue),
                    TotalTax = Convert.ToDouble(txt_TotalTax.EditValue),
                    OrderSub = OrderSubSettings
                };
                string value = JsonConvert.SerializeObject(OrderSetting);
                response = apiMethod.Post_Order(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                    {
                        List<OrderSetting> settings = JsonConvert.DeserializeObject<List<OrderSetting>>(apiMethod.ResponseDataMessage);
                        Thread.Sleep(80);
                        response = apiMethod.Post_OrderAttachmentFile(settings[0].OrderDate, settings[0].OrderNumber, AttachmentFilePath);
                        if (response == "200")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            action.Description = response;
                            FlyoutDialog.Show(Form1, action);
                        }
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    action.Description = response;
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                action.Description = "資料未填選完整";
                FlyoutDialog.Show(Form1, action);
            }
        }
        #endregion
        #region 訂購需知
        private void Checked_Note()
        {
            OrderNote = "";

            if (clbl_File.Items[0].CheckState == CheckState.Checked)//出貨/銷貨單
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_File.Items[0].Value.ToString();
            }
            if (clbl_File.Items[1].CheckState == CheckState.Checked)//發票
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_File.Items[1].Value.ToString();
            }
            if (clbl_File.Items[2].CheckState == CheckState.Checked)//回郵信封
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_File.Items[2].Value.ToString();
            }
            if (clbl_pay.Items[0].CheckState == CheckState.Checked)//貨到現金付款(T/T)
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_pay.Items[0].Value.ToString();
            }
            if (clbl_pay.Items[1].CheckState == CheckState.Checked)//預付現金(T/T)
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_pay.Items[1].Value.ToString();
            }
            if (clbl_pay.Items[2].CheckState == CheckState.Checked)//月結60天
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_pay.Items[2].Value.ToString();
            }
            if (clbl_pay.Items[3].CheckState == CheckState.Checked)//月結30天
            {
                if (OrderNote != "")
                {
                    OrderNote += ",";
                }
                OrderNote += clbl_pay.Items[3].Value.ToString();
            }
        }
        private void CheckEdit_Show(string OrderNote)
        {
            string[] Note = OrderNote.Split(',');
            foreach (var item in Note)
            {
                switch (item)
                {
                    case "0":
                        {
                            clbl_File.Items[0].CheckState = CheckState.Checked;
                        }
                        break;
                    case "1":
                        {
                            clbl_File.Items[1].CheckState = CheckState.Checked;
                        }
                        break;
                    case "2":
                        {
                            clbl_File.Items[2].CheckState = CheckState.Checked;
                        }
                        break;
                    case "11":
                        {
                            clbl_pay.Items[0].CheckState = CheckState.Checked;
                        }
                        break;
                    case "12":
                        {
                            clbl_pay.Items[1].CheckState = CheckState.Checked;
                        }
                        break;
                    case "13":
                        {
                            clbl_pay.Items[2].CheckState = CheckState.Checked;
                        }
                        break;
                    case "14":
                        {
                            clbl_pay.Items[3].CheckState = CheckState.Checked;
                        }
                        break;
                }
            }
        }
        #endregion
    }
}