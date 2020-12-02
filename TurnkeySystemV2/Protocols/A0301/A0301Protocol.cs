using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0301
{
    public class A0301Protocol : A0301Data
    {
        public override void ReadData()
        {
            List<RejectInvoice> A0301 = new List<RejectInvoice>();
            var Value = SQLMethod.Count_A0301();
            if (Value != null)//檢查退回發票數量
            {
                Form1.A0301Num = Value.Count;
                foreach (var A0301Data in Value)
                {
                    RejectInvoice data = new RejectInvoice();
                    data.RejectInvoiceNumber = A0301Data.RejectInvoiceNumber.Trim();
                    data.InvoiceDate = A0301Data.InvoiceDate.Trim();
                    data.BuyerId = A0301Data.BuyerId.Trim();
                    data.SellerId = A0301Data.SellerId.Trim();
                    data.RejectDate = A0301Data.RejectDate.Trim();
                    data.RejectTime = A0301Data.RejectTime.Substring(0, 2) + ":" + A0301Data.RejectTime.Substring(2, 2) + ":00";
                    data.RejectReason = A0301Data.RejectReason.Trim();
                    A0301.Add(data);
                }
                RejectInvoice = A0301;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_A0301(RejectInvoice);
                }
            }
            else
            {
                Form1.A0301Num = 0;
            }
        }
    }
}
