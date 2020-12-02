using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.A0202
{
    public class A0202Protocol : A0202Data
    {
        public override void ReadData()
        {
            List<CancelInvoiceConfirm> A0202 = new List<CancelInvoiceConfirm>();
            var Value = SQLMethod.Count_A0202();
            if (Value != null)//檢查作廢發票接收確認數量
            {
                Form1.A0202Num = Value.Count;
                foreach (var A0202Data in Value)
                {
                    CancelInvoiceConfirm data = new CancelInvoiceConfirm();
                    data.CancelInvoiceNumber = A0202Data.CancelInvoiceNumber.Trim();
                    data.InvoiceDate = A0202Data.InvoiceDate.Trim();
                    data.BuyerId = A0202Data.Buyerid.Trim();
                    data.SellerId = A0202Data.Sellerid.Trim();
                    data.CancelDate = A0202Data.CancelDate.Trim();
                    data.CancelTime = A0202Data.CancelTime.Substring(0, 2) + ":" + A0202Data.CancelTime.Substring(2, 2) + ":00";
                    A0202.Add(data);
                }
                CancelInvoiceConfirm = A0202;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_A0202(CancelInvoiceConfirm);
                }
            }
            else
            {
                Form1.A0202Num = 0;
            }
        }
    }
}
