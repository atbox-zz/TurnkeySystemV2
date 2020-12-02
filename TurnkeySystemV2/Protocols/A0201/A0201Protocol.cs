using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0201
{
    public class A0201Protocol : A0201Data
    {
        public override void ReadData()
        {
            List<CancelInvoice> A0201 = new List<CancelInvoice>();
            var Value = SQLMethod.Count_A0201();
            if (Value != null)//檢查作廢發票數量
            {
                Form1.A0201Num = Value.Count;
                foreach (var A0201Data in Value)
                {
                    CancelInvoice data = new CancelInvoice();
                    data.CancelInvoiceNumber = A0201Data.CancelInvoiceNumber.Trim();
                    data.InvoiceDate = A0201Data.InvoiceDate.Trim();
                    data.BuyerId = A0201Data.Buyerid.Trim();
                    data.SellerId = A0201Data.Sellerid.Trim();
                    data.CancelDate = A0201Data.CancelDate.Trim();
                    data.CancelTime = A0201Data.CancelTime.Substring(0, 2) + ":" + A0201Data.CancelTime.Substring(2, 2) + ":00";
                    data.CancelReason = A0201Data.CancelReason.Trim();
                    A0201.Add(data);
                }
                CancelInvoice = A0201;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_A0201(CancelInvoice);
                }
            }
            else
            {
                Form1.A0201Num = 0;
            }
        }
    }
}
