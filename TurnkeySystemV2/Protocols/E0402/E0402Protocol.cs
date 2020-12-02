using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.E0402
{
    public class E0402Protocol : E0402Data
    {
        public override void ReadData()
        {
            List<BranchTrackBlank> E0402 = new List<BranchTrackBlank>();
            var Value = SQLMethod.Count_E0402();
            if (Value != null)//檢查開立發票數量
            {
                Form1.E0402Num = Value.Count;
                var Item = SQLMethod.Count_E0402_detail();
                if (Item != null)//檢查開立發票細項
                {
                    foreach (var E0401Data in Value)
                    {
                        BranchTrackBlank data = new BranchTrackBlank();
                        data.Main.HeadBan = E0401Data.Headban.Trim();
                        data.Main.BranchBan = E0401Data.Branchban.Trim();
                        data.Main.InvoiceType= E0401Data.Invoicetype.Trim();
                        data.Main.YearMonth = E0401Data.Yearmonth.Trim();
                        data.Main.InvoiceTrack = E0401Data.Invoicetrack.Trim();
                        foreach (var e0402Data in Item)
                        {
                            BranchTrackBlankItem ProductItem = new BranchTrackBlankItem();
                            ProductItem.InvoiceBeginNo = e0402Data.Invoicebeginno.Trim();
                            ProductItem.InvoiceEndNo = e0402Data.Invoiceendno.Trim();
                            data.Details.Add(ProductItem);
                        }
                        E0402.Add(data);
                    }
                    BranchTrackBlank = E0402;
                    if (Value.Count > 0)
                    {
                        XMLMethod.Save_E0402(BranchTrackBlank);
                    }
                }
            }
            else
            {
                Form1.E0402Num = 0;
            }
        }
    }
}
