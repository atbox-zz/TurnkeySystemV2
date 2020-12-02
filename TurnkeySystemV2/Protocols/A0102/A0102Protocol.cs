using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0102
{
    public class A0102Protocol : A0102Data
    {
        public override void ReadData()
        {
            List<InvoicConfirm> A0102 = new List<InvoicConfirm>();
            var Value = SQLMethod.Count_A0102();
            if (Value != null)//檢查發票接收確認數量
            {
                Form1.A0102Num = Value.Count;
                foreach (var A0102Data in Value)
                {
                    InvoicConfirm data = new InvoicConfirm();
                    data.InvoiceNumber = A0102Data.InvoiceNumber.Trim();
                    data.InvoiceDate = A0102Data.InvoiceDate.Trim();
                    data.BuyerId = A0102Data.BuyerID.Trim();
                    data.SellerId = A0102Data.SellerID.Trim();
                    data.ReceiveDate = A0102Data.ReceiveDate.Trim();
                    data.ReceiveTime = A0102Data.ReceiveTime.Substring(0, 2)+":" + A0102Data.ReceiveTime.Substring(2, 2)+":00";
                    A0102.Add(data);
                }
                InvoicConfirm = A0102;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_A0102(InvoicConfirm);
                }
            }
            else
            {
                Form1.A0102Num = 0;
            }
        }
    }
}
