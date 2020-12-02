using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0501
{
    public class A0501Protocol : A0501Data
    {
        public override void ReadData()
        {
            List<CancelInvoice> A0501 = new List<CancelInvoice>();
            var Value = SQLMethod.Count_A0501();
            if (Value != null)
            {
                Form1.A0501Num = Value.Count;
                foreach (var A0501Data in Value)
                {
                    CancelInvoice data = new CancelInvoice();
                    data.CancelInvoiceNumber = A0501Data.CancelInvoiceNumber.Trim();
                    data.InvoiceDate = A0501Data.InvoiceDate.Trim();
                    data.BuyerId = A0501Data.Buyerid.Trim();
                    data.SellerId = A0501Data.Sellerid.Trim();
                    data.CancelDate = A0501Data.CancelDate.Trim();
                    data.CancelTime = A0501Data.CancelTime.Substring(0,2)+":"+ A0501Data.CancelTime.Substring(2, 2)+":00";
                    data.CancelReason = A0501Data.CancelReason.Trim();
                    A0501.Add(data);
                }
                CancelInvoice = A0501;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_A0501(CancelInvoice);
                }
            }
            else
            {
                Form1.A0501Num = 0;
            }
        }
    }
}
