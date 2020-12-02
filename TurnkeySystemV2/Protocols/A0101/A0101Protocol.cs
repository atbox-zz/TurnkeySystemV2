using System;
using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0101
{
    public class A0101Protocol : A0101Data
    {
        public override void ReadData()
        {
            List<Invoice> A0101 = new List<Invoice>();
            var Value = SQLMethod.Count_A0101();
            if (Value != null)//檢查開立發票數量
            {
                Form1.A0101Num = Value.Count;
                var Item = SQLMethod.Count_A0101_detail();
                if (Item != null)//檢查開立發票細項
                {
                    foreach (var A0101Data in Value)
                    {
                        Invoice data = new Invoice();
                        data.Main.InvoiceNumber = A0101Data.InvoiceNumber.Trim();
                        data.Main.InvoiceDate = A0101Data.InvoiceDate.Trim();
                        data.Main.InvoiceTime = A0101Data.InvoiceTime.Substring(0, 2) + ":" + A0101Data.InvoiceTime.Substring(2, 2) + ":00";
                        data.Main.Seller.Identifier = A0101Data.SellerID.Trim();
                        data.Main.Seller.Name = A0101Data.SellerName.Trim();
                        data.Main.Buyer.Identifier = A0101Data.BuyerID.Trim();
                        data.Main.Buyer.Name = A0101Data.BuyerName.Trim();
                        data.Main.InvoiceType = A0101Data.InvoiceType.Trim();
                        data.Main.DonateMark = A0101Data.DonateMark.Trim();
                        foreach (var a0101Data in Item)
                        {
                            if (a0101Data.InvoiceNumber == A0101Data.InvoiceNumber)
                            {
                                ProductItem Productitem = new ProductItem();
                                Productitem.Description = a0101Data.Description.Trim();
                                Productitem.Quantity = Convert.ToDecimal(a0101Data.Quantity);
                                Productitem.Unit = a0101Data.Unit.Trim();
                                Productitem.UnitPrice = Convert.ToDecimal(a0101Data.UnitPrice);
                                Productitem.Amount = Convert.ToDecimal(a0101Data.Amount);
                                Productitem.SequenceNumber = a0101Data.SequenceNumber.Trim();
                                data.Details.Add(Productitem);
                            }
                        }
                        data.Amount.SalesAmount = Convert.ToDecimal(A0101Data.SalesAmount);
                        data.Amount.TaxType = A0101Data.TaxType.Trim();
                        data.Amount.TaxAmount = Convert.ToDecimal(A0101Data.TaxAmount);
                        data.Amount.TotalAmount = Convert.ToDecimal(A0101Data.TotalAmount);
                        A0101.Add(data);
                    }
                    Invoice = A0101;
                    if (Value.Count > 0)
                    {
                        XMLMethod.Save_A0101(Invoice);
                    }
                }                
            }
            else
            {
                Form1.A0101Num = 0;
            }
        }
    }
}
