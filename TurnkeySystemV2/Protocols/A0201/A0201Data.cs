using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.A0201
{
    /// <summary>
    /// 作廢發票
    /// </summary>
    public abstract class A0201Data : AbsProtocol
    {
        /// <summary>
        /// 作廢發票
        /// </summary>
        public List<CancelInvoice> CancelInvoice { get; set; }
    }

    #region 作廢發票
    /// <summary>
    /// 作廢發票
    /// </summary>
    public class CancelInvoice
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:A0201:3.1 A0201.xsd";
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
        /// <summary>
        /// 作廢原因
        /// </summary>
        public string CancelReason { get; set; }
    }
    #endregion
}
