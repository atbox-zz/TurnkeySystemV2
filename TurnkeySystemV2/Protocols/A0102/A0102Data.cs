using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.A0102
{
    /// <summary>
    /// 發票接收確認
    /// </summary>
    public abstract class A0102Data : AbsProtocol
    {
       public List<InvoicConfirm> InvoicConfirm { get; set; } 
    }
    public class InvoicConfirm
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:A0102:3.1 A0102.xsd";
        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNumber { get; set; }
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
        /// 發票接收日期
        /// </summary>
        public string ReceiveDate { get; set; }
        /// <summary>
        /// 發票接收時間
        /// </summary>
        public string ReceiveTime { get; set; }
    }
}
