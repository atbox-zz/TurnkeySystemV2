using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.B0201
{
    /// <summary>
    /// 作廢折讓證明單
    /// </summary>
    public abstract class B0201Data : AbsProtocol
    {
        public List<CancelAllowance> CancelAllowance { get; set; }
    }
    public class CancelAllowance
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:B0201:3.1 B0201.xsd";
        /// <summary>
        /// 作廢折讓證明單號碼
        /// </summary>
        public string CancelAllowanceNumber { get; set; }
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
        /// 折讓證明單作廢日期
        /// </summary>
        public string CancelDate { get; set; }
        /// <summary>
        /// 折讓證明單作廢時間
        /// </summary>
        public string CancelTime { get; set; }
        /// <summary>
        /// 折讓證明單作廢原因
        /// </summary>
        public string CancelReason { get; set; }
    }
}
