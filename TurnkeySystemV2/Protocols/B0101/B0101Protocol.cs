using System;
using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.B0101
{
    public class B0101Protocol:B0101Data
    {
        public override void ReadData()
        {
            List<Allowance> B0101 = new List<Allowance>();
            var Value = SQLMethod.Count_B0101();
            if (Value != null)//檢查開立發票數量
            {
                Form1.B0101Num = Value.Count;
                var Item = SQLMethod.Count_B0101_detail();
                if (Item != null)//檢查開立發票細項
                {
                    foreach (var B0101Data in Value)
                    {
                        Allowance data = new Allowance();
                        data.Main.AllowanceNumber = B0101Data.AllowanceNumber.Trim();
                        data.Main.AllowanceDate = B0101Data.AllowanceDate.Trim();
                        data.Main.Seller.Identifier = B0101Data.SellerID.Trim();
                        data.Main.Seller.Name = B0101Data.SellerName.Trim();
                        data.Main.Buyer.Identifier = B0101Data.BuyerID.Trim();
                        data.Main.Buyer.Name = B0101Data.BuyerName.Trim();
                        data.Main.AllowanceType = B0101Data.AllowanceType.Trim();
                        foreach (var b0101Data in Item)
                        {
                            if (b0101Data.AllowanceNumber == B0101Data.AllowanceNumber)
                            {
                                ProductItem ProductItem = new ProductItem();
                                ProductItem.OriginalInvoiceDate = b0101Data.OriginalInvoiceDate.Trim();
                                ProductItem.OriginalInvoiceNumber = b0101Data.OriginalInvoiceNumber.Trim();
                                ProductItem.OriginalDescription = b0101Data.OriginalDescription.Trim();
                                ProductItem.Quantity = Convert.ToDecimal(b0101Data.Quantity);
                                ProductItem.Unit = b0101Data.Unit.Trim();
                                ProductItem.UnitPrice = Convert.ToDecimal(b0101Data.UnitPrice);
                                ProductItem.Amount = Convert.ToDecimal(b0101Data.Amount);
                                ProductItem.Tax = Convert.ToDecimal(b0101Data.Tax);
                                ProductItem.AllowanceSequenceNumber = b0101Data.AllowanceSequenceNumber.Trim();
                                ProductItem.TaxType = b0101Data.TaxType.Trim();
                                data.Details.Add(ProductItem);
                            }
                        }
                        data.Amount.TaxAmount = Convert.ToDecimal(B0101Data.taxamount);
                        data.Amount.TotalAmount = Convert.ToDecimal(B0101Data.Totalamount);
                        B0101.Add(data);
                    }
                    Allowance = B0101;
                    if (Value.Count > 0)
                    {
                        XMLMethod.Save_B0101(Allowance);
                    }
                }
            }
            else
            {
                Form1.B0101Num = 0;
            }
        }
    }
}
