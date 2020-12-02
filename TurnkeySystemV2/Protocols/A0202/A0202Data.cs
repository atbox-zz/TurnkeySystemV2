using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.A0202
{
    /// <summary>
    /// 作廢發票接收確認
    /// </summary>
    public abstract class A0202Data : AbsProtocol
    {
        /// <summary>
        /// 作廢發票接收確認
        /// </summary>
        public List<CancelInvoiceConfirm> CancelInvoiceConfirm { get; set; }
    }
    public class CancelInvoiceConfirm
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:A0202:3.1 A0202.xsd";
        /// <summary>
        /// 作廢發票號碼
        /// </summary>
        public string CancelInvoiceNumber { get; set; }
        /// <summary>
        /// 發票開立日期
        /// </summary>
        public string InvoiceDate { get; set; }
        /// <summary>
        /// 買方統一編號
        /// </summary>
        public string BuyerId { get; set; }
        /// <summary>
        /// 賣方統一編號
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// 發票作廢日期
        /// </summary>
        public string CancelDate { get; set; }
        /// <summary>
        /// 發票作廢時間
        /// </summary>
        public string CancelTime { get; set; }
    }
}
