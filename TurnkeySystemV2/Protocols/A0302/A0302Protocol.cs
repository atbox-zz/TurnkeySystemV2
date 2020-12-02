using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0302
{
    public class A0302Protocol : A0302Data
    {
        public override void ReadData()
        {
            List<RejectInvoiceConfirm> A0301 = new List<RejectInvoiceConfirm>();
            var Value = SQLMethod.Count_A0302();
            if (Value != null)//檢查退回發票數量
            {
                Form1.A0302Num = Value.Count;
                foreach (var A0302Data in Value)
                {
                    RejectInvoiceConfirm data = new RejectInvoiceConfirm();
                    data.RejectInvoiceNumber = A0302Data.RejectInvoiceNumber.Trim();
                    data.InvoiceDate = A0302Data.InvoiceDate.Trim();
                    data.BuyerId = A0302Data.BuyerId.Trim();
                    data.SellerId = A0302Data.SellerId.Trim();
                    data.RejectDate = A0302Data.RejectDate.Trim();
                    data.RejectTime = A0302Data.RejectTime.Substring(0, 2) + ":" + A0302Data.RejectTime.Substring(2, 2) + ":00";
                    A0301.Add(data);
                }
                RejectInvoiceConfirm = A0301;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_A0302(RejectInvoiceConfirm);
                }
            }
            else
            {
                Form1.A0302Num = 0;
            }
        }
    }
}
