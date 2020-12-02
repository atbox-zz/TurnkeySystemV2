using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.A0302
{
    /// <summary>
    /// 退回發票接收確認
    /// </summary>
    public abstract class A0302Data : AbsProtocol
    {
        /// <summary>
        /// 退回發票接收確認
        /// </summary>
        public List<RejectInvoiceConfirm> RejectInvoiceConfirm { get; set; }
    }
    public class RejectInvoiceConfirm
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:A0302:3.1 A0302.xsd";
        /// <summary>
        /// 退回(拒收)發票號碼
        /// </summary>
        public string RejectInvoiceNumber { get; set; }
        /// <summary>
        /// 發票日期
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
        /// 退回(拒收)日期
        /// </summary>
        public string RejectDate { get; set; }
        /// <summary>
        /// 退回(拒收)時間
        /// </summary>
        public string RejectTime { get; set; }
    }
}
