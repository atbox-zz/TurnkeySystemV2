using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.B0102
{
    public class B0102Protocol : B0102Data
    {
        public override void ReadData()
        {
            List<AllowanceConfirm> B0102 = new List<AllowanceConfirm>();
            var Value = SQLMethod.Count_B0102();
            if (Value != null)
            {
                Form1.B0102Num = Value.Count;
                foreach (var B0102Data in Value)
                {
                    AllowanceConfirm data = new AllowanceConfirm();
                    data.AllowanceNumber = B0102Data.AllowanceNumber.Trim();
                    data.AllowanceDate = B0102Data.AllowanceDate.Trim();
                    data.BuyerId = B0102Data.BuyerID.Trim();
                    data.SellerId = B0102Data.SellerID.Trim();
                    data.ReceiveDate = B0102Data.ReceiveDate.Trim();
                    data.ReceiveTime = B0102Data.ReceiveTime.Substring(0, 2) + ":" + B0102Data.ReceiveTime.Substring(2, 2) + ":00";
                    data.AllowanceType = B0102Data.AllowanceType.Trim();
                    B0102.Add(data);
                }
                AllowanceConfirm = B0102;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_B0102(AllowanceConfirm);
                }
            }
            else
            {
                Form1.B0102Num = 0;
            }
        }
    }
}
