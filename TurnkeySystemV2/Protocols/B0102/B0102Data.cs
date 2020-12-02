using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.B0102
{
    /// <summary>
    /// 開立折讓證明/通知單接收確認
    /// </summary>
    public abstract class B0102Data :AbsProtocol
    {
        public List<AllowanceConfirm> AllowanceConfirm { get; set; }
    }
    public class AllowanceConfirm
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:B0102:3.1 B0102.xsd";
        /// <summary>
        /// 折讓證明單號碼
        /// </summary>
        public string AllowanceNumber { get; set; }
        /// <summary>
        /// 折讓證明單日期
        /// </summary>
        public string AllowanceDate { get; set; }
        /// <summary>
        /// 買方統一編號
        /// </summary>
        public string BuyerId { get; set; }
        /// <summary>
        /// 賣方統一編號
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// 折讓證明單接收日
        /// </summary>
        public string ReceiveDate { get; set; }
        /// <summary>
        /// 折讓證明單接收時間
        /// </summary>
        public string ReceiveTime { get; set; }
        /// <summary>
        /// 折讓種類
        /// </summary>
        public string AllowanceType { get; set; }
    }
}
