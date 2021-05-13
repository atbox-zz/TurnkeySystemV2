using System;

namespace TurnkeySystemV2.EF_Module
{
    public partial class B0401_detail
    {
        public string AllowanceNumber { get; set; }
        public string Productitem { get; set; }
        public string OriginalInvoiceDate { get; set; }
        public string OriginalInvoiceNumber { get; set; }
        public Nullable<decimal> OriginalSequenceNumber { get; set; }
        public string OriginalDescription { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string AllowanceSequenceNumber { get; set; }
        public string TaxType { get; set; }
    }
}
