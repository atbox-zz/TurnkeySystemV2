using System.Collections.Generic;
using System.Xml.Serialization;
using TurnkeySystemV2.Protocols.A0201;

namespace TurnkeySystemV2.Protocols.B0501
{
    /// <summary>
    /// 平台存證作廢發票
    /// </summary>
    public abstract class B0501Data:AbsProtocol
    {
        /// <summary>
        /// 平台存證作廢發票
        /// </summary>
        public List<CancelAllowance> CancelAllowance { get; set; }
    }
    public class CancelAllowance
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:B0501:3.1 B0501.xsd";
        /// <summary>
        /// 作廢發票號碼
        /// </summary>
        public string CancelAllowanceNumber { get; set; }
        /// <summary>
        /// 發票日期
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
        /// 發票作廢日期
        /// </summary>
        public string CancelDate { get; set; }
        /// <summary>
        /// 發票作廢時間
        /// </summary>
        public string CancelTime { get; set; }
        /// <summary>
        /// 發票作廢原因
        /// </summary>
        public string CancelReason { get; set; }
    }
}
