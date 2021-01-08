using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.A0401
{
    /// <summary>
    /// 平台存證開立發票
    /// </summary>
    public abstract class A0401Data : AbsProtocol
    {
        /// <summary>
        /// 平台存證開立發票
        /// </summary>
        public List<Invoice> Invoice { get; set; }
    }
    #region 開立發票
    /// <summary>
    /// 開立發票
    /// </summary>
    public class Invoice
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:A0401:3.1 A0401.xsd";
        /// <summary>
        ///  檔頭
        /// </summary>
        public Main Main { get; set; } = new Main();
        /// <summary>
        /// 明細
        /// </summary>
        public List<ProductItem> Details { get; set; } = new List<ProductItem>();
        /// <summary>
        /// 彙總
        /// </summary>
        public Amount Amount { get; set; } = new Amount();
    }
    #endregion

    #region 檔頭
    /// <summary>
    /// 檔頭
    /// </summary>
    public class Main
    {
        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 發票開立日期
        /// </summary>
        public string InvoiceDate { get; set; }
        /// <summary>
        /// 發票開立時間
        /// </summary>
        public string InvoiceTime { get; set; }
        /// <summary>
        /// 賣方
        /// </summary>
        public Seller Seller { get; set; } = new Seller();
        /// <summary>
        /// 買方
        /// </summary>
        public Buyer Buyer { get; set; } = new Buyer();
        /// <summary>
        /// 發票類別
        /// </summary>
        public string InvoiceType { get; set; }
        /// <summary>
        /// 捐贈註記
        /// </summary>
        public string DonateMark { get; set; }
    }
    /// <summary>
    /// 賣方
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// 識別碼
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 負責人
        /// </summary>
        public string PersonInCharge { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        public string TelephoneNumber { get; set; }
    }
    /// <summary>
    /// 買方
    /// </summary>
    public class Buyer
    {
        /// <summary>
        /// 識別碼
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
    }
    #endregion

    #region 明細
    /// <summary>
    /// 明細內容
    /// </summary>
    public class ProductItem
    {
        /// <summary>
        /// 品名
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// /單價
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 明細排列序號
        /// </summary>
        public string SequenceNumber { get; set; }
    }
    #endregion

    #region 彙總
    /// <summary>
    /// 彙總
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// 銷售額合計
        /// </summary>
        public decimal SalesAmount { get; set; }
        /// <summary>
        /// 課稅別
        /// </summary>
        public string TaxType { get; set; }
        /// <summary>
        /// 稅率
        /// </summary>
        public decimal TaxRate { get; set; } = Convert.ToDecimal(0.05);
        /// <summary>
        /// 營業稅額
        /// </summary>
        public decimal TaxAmount { get; set; }
        /// <summary>
        /// 總計
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
    #endregion
}
