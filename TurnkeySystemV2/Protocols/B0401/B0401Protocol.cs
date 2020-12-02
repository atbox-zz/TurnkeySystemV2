using System;
using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.B0401
{
    public class B0401Protocol:B0401Data
    {
        public override void ReadData()
        {
            List<Allowance> B0401 = new List<Allowance>();
            var Value = SQLMethod.Count_B0401();
            if (Value != null)//檢查開立發票數量
            {
                Form1.B0401Num = Value.Count;
                var Item = SQLMethod.Count_B0401_detail();
                if (Item != null)//檢查開立發票細項
                {
                    foreach (var B0401Data in Value)
                    {
                        Allowance data = new Allowance();
                        data.Main.AllowanceNumber = B0401Data.AllowanceNumber.Trim();
                        data.Main.AllowanceDate = B0401Data.AllowanceDate;
                        data.Main.Seller.Identifier = B0401Data.SellerID;
                        data.Main.Seller.Name = B0401Data.SellerName.Trim();
                        data.Main.Buyer.Identifier = B0401Data.BuyerID;
                        data.Main.Buyer.Name = B0401Data.BuyerName.Trim();
                        data.Main.AllowanceType = B0401Data.AllowanceType;
                        foreach (var b0401Data in Item)
                        {
                            if (b0401Data.AllowanceNumber == B0401Data.AllowanceNumber)
                            {
                                ProductItem ProductItem = new ProductItem();
                                ProductItem.OriginalInvoiceDate = b0401Data.OriginalInvoiceDate;
                                ProductItem.OriginalInvoiceNumber = b0401Data.OriginalInvoiceNumber;
                                ProductItem.OriginalDescription = b0401Data.OriginalDescription.Trim();
                                ProductItem.Quantity = Convert.ToDecimal(b0401Data.Quantity);
                                ProductItem.Unit = b0401Data.Unit.Trim();
                                ProductItem.UnitPrice = Convert.ToDecimal(b0401Data.UnitPrice);
                                ProductItem.Amount = Convert.ToDecimal(b0401Data.Amount);
                                ProductItem.Tax = Convert.ToDecimal(b0401Data.Tax);
                                ProductItem.AllowanceSequenceNumber = b0401Data.AllowanceSequenceNumber;
                                ProductItem.TaxType = b0401Data.TaxType;
                                data.Details.Add(ProductItem);
                            }
                        }
                        data.Amount.TaxAmount = Convert.ToDecimal(Item[0].Taxamount);
                        data.Amount.TotalAmount = Convert.ToDecimal(Item[0].Totalamount);
                        B0401.Add(data);
                    }
                    Allowance = B0401;
                    if (Value.Count > 0)
                    {
                        XMLMethod.Save_B0401(Allowance);
                    }
                }
            }
            else
            {
                Form1.B0401Num = 0;
            }
        }
    }
}
