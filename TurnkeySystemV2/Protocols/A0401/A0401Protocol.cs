using System;
using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0401
{
    public class A0401Protocol:A0401Data
    {
        public override void ReadData()
        {
            List<Invoice> A0401 = new List<Invoice>();
            var Value = SQLMethod.Count_A0401();
            if (Value != null)//檢查開立發票數量
            {
                Form1.A0401Num = Value.Count;
                var Item = SQLMethod.Count_A0401_detail();
                if (Item != null)//檢查開立發票細項
                {
                    foreach (var A0401Data in Value)
                    {
                        Invoice data = new Invoice();
                        data.Main.InvoiceNumber = A0401Data.InvoiceNumber.Trim();
                        data.Main.InvoiceDate = A0401Data.InvoiceDate.Trim();
                        data.Main.InvoiceTime = A0401Data.InvoiceTime.Substring(0, 2) + ":" + A0401Data.InvoiceTime.Substring(2, 2) + ":00";
                        data.Main.Seller.Identifier = A0401Data.SellerID.Trim();
                        data.Main.Seller.Name = A0401Data.SellerName.Trim();
                        data.Main.Buyer.Identifier = A0401Data.BuyerID.Trim();
                        data.Main.Buyer.Name = A0401Data.BuyerName.Trim();
                        data.Main.InvoiceType = A0401Data.InvoiceType.Trim();
                        data.Main.DonateMark = A0401Data.DonateMark.Trim();
                        foreach (var a0401Data in Item)
                        {
                            if (a0401Data.InvoiceNumber == A0401Data.InvoiceNumber)
                            {
                                ProductItem Productitem = new ProductItem();
                                Productitem.Description = a0401Data.Description.Trim();
                                Productitem.Quantity = Convert.ToDecimal(a0401Data.Quantity);
                                Productitem.Unit = a0401Data.Unit.Trim();
                                Productitem.UnitPrice = Convert.ToDecimal(a0401Data.UniPrice);
                                Productitem.Amount = Convert.ToDecimal(a0401Data.Amount);
                                Productitem.SequenceNumber = a0401Data.SequenceNumber.Trim();
                                data.Details.Add(Productitem);
                            }
                        }
                        data.Amount.SalesAmount = Convert.ToDecimal(A0401Data.SalesAmount);
                        data.Amount.TaxType = A0401Data.TaxType.Trim();
                        data.Amount.TaxAmount = Convert.ToDecimal(A0401Data.TaxAmount);
                        data.Amount.TotalAmount = Convert.ToDecimal(A0401Data.TotalAmount);
                        A0401.Add(data);
                    }
                    Invoice = A0401;
                    if (Value.Count > 0)
                    {
                        XMLMethod.Save_A0401(Invoice);
                    }
                }
            }
            else
            {
                Form1.A0401Num = 0;
            }
        }
    }
}
