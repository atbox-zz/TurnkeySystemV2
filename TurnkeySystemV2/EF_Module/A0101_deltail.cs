using System;

namespace TurnkeySystemV2.EF_Module
{
    public partial class A0101_detail
    {
        public string InvoiceNumber { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string SequenceNumber { get; set; }
    }
}
