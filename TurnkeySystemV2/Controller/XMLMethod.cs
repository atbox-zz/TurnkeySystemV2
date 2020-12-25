using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TurnkeySystemV2.Configuration;

namespace TurnkeySystemV2.Controller
{
    public  class XMLMethod
    {
        /// <summary>
        /// 移至路徑
        /// </summary>
        public  RemoveReportPathSetting RemoveReportPathSetting { get; set; }
        /// <summary>
        /// 狀態資訊
        /// </summary>
        public  Form1 Form1 { get; set; }
        /// <summary>
        /// 寫入文件
        /// </summary>
        private TextWriter txtWriter;

        #region A0101 開立發票
        /// <summary>
        /// 開立發票
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0101(List<Protocols.A0101.Invoice> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0101.Invoice), "urn:GEINV:eInvoiceMessage:A0101:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0101Path}\\{item.Main.InvoiceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
                txtWriter.Close();
            }
            //var xml = sww.ToString();
        }
        #endregion

        #region A0102 發票接收確認
        /// <summary>
        /// 發票接收確認
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0102(List<Protocols.A0102.InvoicConfirm> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0102.InvoicConfirm), "urn:GEINV:eInvoiceMessage:A0102:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0102Path}\\{item.InvoiceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
                txtWriter.Close();
            }
            //var xml = sww.ToString();
        }
        #endregion

        #region A0201 作廢發票
        /// <summary>
        /// 作廢發票
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0201(List<Protocols.A0201.CancelInvoice> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0201.CancelInvoice), "urn:GEINV:eInvoiceMessage:A0201:3.1");//宣告XML框架
            //StringWriter sww = new StringWriter();//字串物件
            foreach (var item in values)
            {
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0201Path}\\{item.CancelInvoiceNumber}.xml", false);
                //xs.Serialize(sww, item, ns);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region A0202 作廢發票接收確認
        /// <summary>
        /// 作廢發票接收確認
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0202(List<Protocols.A0202.CancelInvoiceConfirm> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0202.CancelInvoiceConfirm), "urn:GEINV:eInvoiceMessage:A0202:3.1");//宣告XML框架
            //StringWriter sww = new StringWriter();//字串物件
            foreach (var item in values)
            {
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0202Path}\\{item.CancelInvoiceNumber}.xml", false);
                //xs.Serialize(sww, item, ns);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region A0301 退回發票
        /// <summary>
        /// 退回發票
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0301(List<Protocols.A0301.RejectInvoice> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0301.RejectInvoice), "urn:GEINV:eInvoiceMessage:A0301:3.1");//宣告XML框架
            //StringWriter sww = new StringWriter();//字串物件
            foreach (var item in values)
            {
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0301Path}\\{item.RejectInvoiceNumber}.xml", false);
                //xs.Serialize(sww, item, ns);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region A0302 退回發票接收確認
        /// <summary>
        /// 退回發票接收確認
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0302(List<Protocols.A0302.RejectInvoiceConfirm> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0302.RejectInvoiceConfirm), "urn:GEINV:eInvoiceMessage:A0302:3.1");//宣告XML框架
            //StringWriter sww = new StringWriter();//字串物件
            foreach (var item in values)
            {
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0302Path}\\{item.RejectInvoiceNumber}.xml", false);
                //xs.Serialize(sww, item, ns);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region A0401 開立發票(存證)
        /// <summary>
        /// 開立發票(存證)
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0401(List<Protocols.A0401.Invoice> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0401.Invoice), "urn:GEINV:eInvoiceMessage:A0401:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0401Path}\\{item.Main.InvoiceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
                txtWriter.Close();
            }
            //var xml = sww.ToString();
        }
        #endregion

        #region A0501 作廢發票(存證)
        /// <summary>
        /// 作廢發票(存證)
        /// </summary>
        /// <param name="values"></param>
        public void Save_A0501(List<Protocols.A0501.CancelInvoice> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.A0501.CancelInvoice), "urn:GEINV:eInvoiceMessage:A0501:3.1");//宣告XML框架
            //StringWriter sww = new StringWriter();//字串物件
            foreach (var item in values)
            {
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.A0501Path}\\{item.CancelInvoiceNumber}.xml", false);
                //xs.Serialize(sww, item, ns);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region B0101 開立折讓證明單
        /// <summary>
        ///  開立折讓證明單
        /// </summary>
        /// <param name="values"></param>
        public void Save_B0101(List<Protocols.B0101.Allowance> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.B0101.Allowance), "urn:GEINV:eInvoiceMessage:B0101:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.B0101Path}\\{item.Main.AllowanceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region B0102 開立折讓證明/通知單接收確認
        /// <summary>
        ///  開立折讓證明/通知單接收確認
        /// </summary>
        /// <param name="values"></param>
        public void Save_B0102(List<Protocols.B0102.AllowanceConfirm> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.B0102.AllowanceConfirm), "urn:GEINV:eInvoiceMessage:B0102:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.B0102Path}\\{item.AllowanceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region B0201 作廢折讓證明單
        /// <summary>
        ///  作廢折讓證明單
        /// </summary>
        /// <param name="values"></param>
        public void Save_B0201(List<Protocols.B0201.CancelAllowance> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.B0201.CancelAllowance), "urn:GEINV:eInvoiceMessage:B0201:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.B0201Path}\\{item.CancelAllowanceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region B0202 作廢折讓證明單接收確認
        /// <summary>
        ///  作廢折讓證明單接收確認
        /// </summary>
        /// <param name="values"></param>
        public void Save_B0202(List<Protocols.B0202.CancelAllowanceConfirm> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.B0202.CancelAllowanceConfirm), "urn:GEINV:eInvoiceMessage:B0202:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.B0202Path}\\{item.CancelAllowanceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region B0401 平台存證開立折讓證明/通知單
        /// <summary>
        ///  平台存證開立折讓證明/通知單
        /// </summary>
        /// <param name="values"></param>
        public void Save_B0401(List<Protocols.B0401.Allowance> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.B0401.Allowance), "urn:GEINV:eInvoiceMessage:B0401:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.B0401Path}\\{item.Main.AllowanceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region B0501 平台存證作廢發票
        /// <summary>
        /// 平台存證作廢發票
        /// </summary>
        /// <param name="values"></param>
        public void Save_B0501(List<Protocols.B0501.CancelInvoice> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.B0501.CancelInvoice), "urn:GEINV:eInvoiceMessage:B0501:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.B0501Path}\\{item.CancelAllowanceNumber}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion

        #region E0402 空白未使用字軌檔
        /// <summary>
        /// 空白未使用字軌檔
        /// </summary>
        /// <param name="values"></param>
        public void Save_E0402(List<Protocols.E0402.BranchTrackBlank> values)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();//宣告空間區域
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlSerializer xs = new XmlSerializer(typeof(Protocols.E0402.BranchTrackBlank), "urn:GEINV:eInvoiceMessage:E0402:3.1");//宣告XML框架
            foreach (var item in values)
            {
                //StringWriter sww = new StringWriter();//字串物件
                //xs.Serialize(sww, item, ns);
                txtWriter = new StreamWriter(@"" + $"{RemoveReportPathSetting.E0402Path}\\{item.Main.HeadBan}.xml", false);
                xs.Serialize(txtWriter, item, ns);
            }
            txtWriter.Close();
            //var xml = sww.ToString();
        }
        #endregion
    }
}
