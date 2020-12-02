using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.B0401
{
    /// <summary>
    ///  平台存證開立折讓證明/通知單
    /// </summary>
    public abstract class B0401Data : AbsProtocol
    {
        /// <summary>
        ///  平台存證開立折讓證明/通知單
        /// </summary>
        public List<Allowance> Allowance { get; set; }
    }
    #region  平台存證開立折讓證明/通知單
    /// <summary>
    ///  平台存證開立折讓證明/通知單
    /// </summary>
    public class Allowance
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:B0401:3.1 B0401.xsd";
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
        /// 折讓證明單號碼
        /// </summary>
        public string AllowanceNumber { get; set; }
        /// <summary>
        /// 折讓證明單開立日期
        /// </summary>
        public string AllowanceDate { get; set; }
        /// <summary>
        /// 賣方
        /// </summary>
        public Seller Seller { get; set; } = new Seller();
        /// <summary>
        /// 買方
        /// </summary>
        public Buyer Buyer { get; set; } = new Buyer();
        /// <summary>
        /// 折讓種類
        /// </summary>
        public string AllowanceType { get; set; }
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
        /// 原發票日期
        /// </summary>
        public string OriginalInvoiceDate { get; set; }
        /// <summary>
        /// 原發票號碼
        /// </summary>
        public string OriginalInvoiceNumber { get; set; }
        /// <summary>
        /// 原品名
        /// </summary>
        public string OriginalDescription { get; set; }
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
        /// 營業稅額
        /// </summary>
        public decimal Tax { get; set; }
        /// <summary>
        /// 折讓證明單明細排列序號
        /// </summary>
        public string AllowanceSequenceNumber { get; set; }
        /// <summary>
        /// 課稅別
        /// </summary>
        public string TaxType { get; set; }
    }
    #endregion

    #region 彙總
    /// <summary>
    /// 彙總
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// 營業稅額合計
        /// </summary>
        public decimal TaxAmount { get; set; }
        /// <summary>
        /// 金額合計(不含稅之進貨額合計)
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
    #endregion
}
