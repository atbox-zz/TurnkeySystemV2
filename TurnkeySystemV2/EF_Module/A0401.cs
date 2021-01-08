using System;

namespace TurnkeySystemV2.EF_Module
{
    public partial class A0401
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceTime { get; set; }
        public string SellerID { get; set; }
        public string SellerName { get; set; }
        public string BuyerID { get; set; }
        public string BuyerName { get; set; }
        public string InvoiceType { get; set; }
        public string DonateMark { get; set; }
        public Nullable<decimal> SalesAmount { get; set; }
        public string TaxType { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string SellerAddress { get; set; }
        public string SellerPersonInCharge { get; set; }
        public string SellerTelephoneNumber { get; set; }
    }
}
