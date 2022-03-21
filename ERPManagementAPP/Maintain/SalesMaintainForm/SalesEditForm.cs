﻿using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.SalesMaintainForm
{
    public partial class SalesEditForm : BaseEditForm
    {
        /// <summary>
        /// 聚焦表身資訊
        /// </summary>
        private SalesSubSetting FocuseSalesSubSetting { get; set; } = new SalesSubSetting();
        /// <summary>
        /// 表身資訊
        /// </summary>
        private List<SalesSubSetting> SalesSubSettings { get; set; } = new List<SalesSubSetting>();
        /// <summary>
        /// 進貨資訊
        /// </summary>
        private SalesSetting SalesSetting { get; set; } = new SalesSetting();
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CustomerSetting> CustomerSettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 產品數量
        /// </summary>
        private double ProductQty = 0;
        /// <summary>
        /// 產品單價
        /// </summary>
        private double ProductPrice = 0;
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
        public SalesEditForm(List<CustomerSetting> customerSettings, List<EmployeeSetting> employeeSettings, List<ProductSetting> productSettings, SalesSetting salesSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            CustomerSettings = customerSettings;
            EmployeeSettings = employeeSettings;
            ProductSettings = productSettings;
            SalesSetting = salesSetting;
            Create_cbt_SalescustomerNumber_cbt();
            Create_cbt_EmployeeNumber_cbt();
            Create_cbt_ProductName_cbt();
            if (salesSetting != null)
            {
                cbt_SalesFlag.SelectedIndex = salesSetting.SalesFlag - 3;
                txt_SalesNumber.Text = salesSetting.SalesNumber;
                det_SalesDate.Text = salesSetting.SalesDate.ToString("yyyy年MM月dd日");
                Show_ProductCustomerNumber_Index();
                cbt_SalesTax.SelectedIndex = salesSetting.SalesTax;
                txt_SalesInvoiceNo.Text = salesSetting.SalesInvoiceNo;
                Show_EmployeeNumber_Index();
                mmt_Remark.Text = salesSetting.Remark;
                cbt_Posting.SelectedIndex = salesSetting.Posting;
                SalesSubSettings = salesSetting.SalesSub;
            }
            else
            {
                det_SalesDate.EditValue = DateTime.Now;
            }
            CacalculateData();
            RefreshData();
            cbt_SalesTax.SelectedIndexChanged += (s, e) =>
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
                        ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty"));
                        ProductPrice = Convert.ToDouble(e.Value.ToString());
                        gridView1.SetFocusedRowCellValue("ProductTotal", (ProductQty * ProductPrice).ToString());
                        CacalculateData();
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
                if (cbt_ProductName.SelectedIndex > -1 && !string.IsNullOrEmpty(txt_ProducUnit.Text) && !string.IsNullOrEmpty(txt_productPrice.Text))
                {
                    SalesSubSettings.Add(new SalesSubSetting()
                    {
                        SalesFlag = cbt_SalesFlag.SelectedIndex + 3,
                        SalesNumber = "",
                        SalesNo = SalesSubSettings.Count() + 1,
                        ProductNumber = Get_cbt_ProductName_Number(),
                        ProductName = cbt_ProductName.Text,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    cbt_ProductName.SelectedIndex = -1;
                    //txt_ProducUnit.Text = "";
                    txt_productQty.Text = "";
                    txt_productPrice.Text = "";
                    CacalculateData();
                    RefreshData();
                    FocuseMainGrid();
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
                cbt_ProductName.SelectedIndex = -1;
                txt_ProducUnit.Text = "";
                txt_productQty.Text = "";
                txt_productPrice.Text = "";
            };
            #endregion
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                for (int i = 0; i < SalesSubSettings.Count; i++)
                {
                    if (SalesSubSettings[i].SalesNo == FocuseSalesSubSetting.SalesNo)
                    {
                        SalesSubSettings.RemoveAt(i);
                    }
                }
                RefraeshSalesNo();
                CacalculateData();
                RefreshData();
                FocuseMainGrid();
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
                CheckNumber(salesSetting, apiMethod);
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
                FocuseSalesSubSetting.SalesFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesFlag").ToString()) - 1;
                FocuseSalesSubSetting.SalesNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesNumber").ToString();
                FocuseSalesSubSetting.SalesNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesNo").ToString());
                FocuseSalesSubSetting.ProductNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductNumber").ToString();
                FocuseSalesSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocuseSalesSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocuseSalesSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocuseSalesSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocuseSalesSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocuseSalesSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());
            }
            else
            {
                FocuseSalesSubSetting = new SalesSubSetting();
            }
        }
        #endregion
        #region 刷新細項編號
        /// <summary>
        /// 刷新細項編號
        /// </summary>
        private void RefraeshSalesNo()
        {
            for (int i = 0; i < SalesSubSettings.Count; i++)
            {
                SalesSubSettings[i].SalesNo = i + 1;
            }
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl1.DataSource = SalesSubSettings;
            gridControl1.RefreshDataSource();
        }
        #endregion
        #region 刷新計算數值
        /// <summary>
        /// 刷新計算數值
        /// </summary>
        private void CacalculateData()
        {
            Total = 0;
            Tax = 0;
            TotalTax = 0;
            if (SalesSubSettings.Count > 0)
            {
                foreach (var item in SalesSubSettings)
                {
                    Total += item.ProductTotal;
                }
            }
            if (cbt_SalesTax.SelectedIndex == 0)
            {
                Tax = Math.Round(Total * 0.05, 0);
            }
            TotalTax = Total + Tax;
            txt_Total.EditValue = Total.ToString();
            txt_Tax.EditValue = Tax.ToString();
            txt_TotalTax.EditValue = TotalTax.ToString();
        }
        #endregion
        #region 客戶編號功能
        /// <summary>
        /// 創建客戶編號下拉選單
        /// </summary>
        /// <param name="companySettings"></param>
        private void Create_cbt_SalescustomerNumber_cbt()
        {
            if (cbt_SalesCustomerNumber.Properties.Items.Count > 0)
            {
                cbt_SalesCustomerNumber.Properties.Items.Clear();
            }
            if (CustomerSettings != null)
            {
                foreach (var item in CustomerSettings)
                {
                    cbt_SalesCustomerNumber.Properties.Items.Add(item.CustomerName);
                }
            }
        }
        /// <summary>
        /// 取得客戶編號
        /// </summary>
        /// <returns></returns>
        private string Get_ProductCustomerNumber_Number()
        {
            string value = "";
            if (CustomerSettings != null)
            {
                if (CustomerSettings.Count > 0)
                {
                    value = CustomerSettings[cbt_SalesCustomerNumber.SelectedIndex].CustomerNumber;
                }
            }
            return value;
        }
        /// <summary>
        /// 顯示客戶名稱
        /// </summary>
        private void Show_ProductCustomerNumber_Index()
        {
            int Index = -1;
            if (CustomerSettings != null)
            {
                foreach (var item in CustomerSettings)
                {
                    if (item.CustomerNumber == SalesSetting.SalesCustomerNumber)
                    {
                        Index++;
                        cbt_SalesCustomerNumber.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
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
                    if (item.EmployeeNumber == SalesSetting.SalesEmployeeNumber)
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
            if (cbt_ProductName.Properties.Items.Count > 0)
            {
                cbt_ProductName.Properties.Items.Clear();
            }
            if (ProductSettings != null)
            {
                foreach (var item in ProductSettings)
                {
                    cbt_ProductName.Properties.Items.Add(item.ProductName);
                }
            }
        }
        /// <summary>
        /// 取得產品編號
        /// </summary>
        /// <returns></returns>
        private string Get_cbt_ProductName_Number()
        {
            string value = "";
            if (ProductSettings != null)
            {
                if (ProductSettings.Count > 0)
                {
                    value = ProductSettings[cbt_ProductName.SelectedIndex].ProductNumber;
                }
            }
            return value;
        }
        #endregion
        #region 檢查資料問題
        private void CheckNumber(SalesSetting salesSetting, APIMethod apiMethod)
        {
            string response = "";
            if (salesSetting != null && salesSetting.SalesNumber != null)
            {
                foreach (var item in SalesSubSettings)
                {
                    item.SalesNumber = txt_SalesNumber.Text;
                }
                action.Caption = "進貨修改錯誤";
                salesSetting.SalesFlag = cbt_SalesFlag.SelectedIndex + 3;
                salesSetting.SalesNumber = txt_SalesNumber.Text;
                salesSetting.SalesDate = Convert.ToDateTime(det_SalesDate.Text);
                salesSetting.SalesCustomerNumber = Get_ProductCustomerNumber_Number();
                salesSetting.SalesTax = cbt_SalesTax.SelectedIndex;
                salesSetting.SalesInvoiceNo = txt_SalesInvoiceNo.Text;
                salesSetting.SalesEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                salesSetting.Remark = mmt_Remark.Text;
                salesSetting.Posting = cbt_Posting.SelectedIndex;
                salesSetting.SalesSub = SalesSubSettings;
                salesSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                salesSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                salesSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                string value = JsonConvert.SerializeObject(salesSetting);
                response = apiMethod.Put_Sales(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_SalesAttachmentFile(salesSetting.SalesFlag, salesSetting.SalesCustomerNumber, salesSetting.SalesDate, salesSetting.SalesNumber, AttachmentFilePath);
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
                if (!string.IsNullOrEmpty(det_SalesDate.Text) && cbt_SalesCustomerNumber.SelectedIndex > -1 && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    SalesSetting SalesSetting = new SalesSetting()
                    {
                        SalesFlag = cbt_SalesFlag.SelectedIndex + 3,
                        SalesNumber = txt_SalesNumber.Text,
                        SalesDate = Convert.ToDateTime(det_SalesDate.Text),
                        SalesCustomerNumber = Get_ProductCustomerNumber_Number(),
                        SalesTax = cbt_SalesTax.SelectedIndex,
                        SalesInvoiceNo = txt_SalesInvoiceNo.Text,
                        SalesEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        Posting = cbt_Posting.SelectedIndex,
                        SalesSub = SalesSubSettings
                    };
                    string value = JsonConvert.SerializeObject(SalesSetting);
                    response = apiMethod.Post_Sales(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<SalesSetting> settings = JsonConvert.DeserializeObject<List<SalesSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_SalesAttachmentFile(settings[0].SalesFlag, settings[0].SalesCustomerNumber, settings[0].SalesDate, settings[0].SalesNumber, AttachmentFilePath);
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
            }
        }
        #endregion
    }
}