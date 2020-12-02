using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurnkeySystemV2.Protocols.E0402
{
    /// <summary>
    /// 空白未使用字軌檔
    /// </summary>
    public abstract class E0402Data : AbsProtocol
    {
        /// <summary>
        /// 空白未使用字軌檔
        /// </summary>
        public List<BranchTrackBlank> BranchTrackBlank { get; set; }
    }
    public class BranchTrackBlank
    {
        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "urn:GEINV:eInvoiceMessage:E0402:3.1 E0402.xsd";
        /// <summary>
        ///  檔頭
        /// </summary>
        public Main Main { get; set; } = new Main();
        /// <summary>
        /// 明細
        /// </summary>
        public List<BranchTrackBlankItem> Details { get; set; } = new List<BranchTrackBlankItem>();
    }
    /// <summary>
    /// 檔頭
    /// </summary>
    public class Main
    {
        /// <summary>
        /// 總公司統一編號
        /// </summary>
        public string HeadBan { get; set; }
        /// <summary>
        /// 分支機構統一編號
        /// </summary>
        public string BranchBan { get; set; }
        /// <summary>
        /// 發票類別
        /// </summary>
        public string InvoiceType { get; set; }
        /// <summary>
        /// 發票期別
        /// </summary>
        public string YearMonth { get; set; }
        /// <summary>
        /// 空白字軌
        /// </summary>
        public string InvoiceTrack { get; set; }
    }
    /// <summary>
    /// 明細
    /// </summary>
    public class BranchTrackBlankItem
    {
        /// <summary>
        /// 空白發票起號
        /// </summary>
        public string InvoiceBeginNo { get; set; }
        /// <summary>
        /// 空白發票迄號
        /// </summary>
        public string InvoiceEndNo { get; set; }
    }
}
