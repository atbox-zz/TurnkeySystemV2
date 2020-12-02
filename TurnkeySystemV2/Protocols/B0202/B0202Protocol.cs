using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.B0202
{
    public class B0202Protocol:B0202Data
    {
        public override void ReadData()
        {
            List<CancelAllowanceConfirm> B0202 = new List<CancelAllowanceConfirm>();
            var Value = SQLMethod.Count_B0202();
            if (Value != null)
            {
                Form1.B0202Num = Value.Count;
                foreach (var B0202Data in Value)
                {
                    CancelAllowanceConfirm data = new CancelAllowanceConfirm();
                    data.CancelAllowanceNumber = B0202Data.CancelAllowanceNumber.Trim();
                    data.AllowanceDate = B0202Data.AllowanceDate.Trim();
                    data.BuyerId = B0202Data.BuyerId.Trim();
                    data.SellerId = B0202Data.SellerId.Trim();
                    data.CancelDate = B0202Data.CancelDate.Trim();
                    data.CancelTime = B0202Data.CancelTime.Substring(0,2)+":"+ B0202Data.CancelTime.Substring(2, 2)+":00";
                    B0202.Add(data);
                }
                CancelAllowanceConfirm = B0202;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_B0202(CancelAllowanceConfirm);
                }
            }
            else
            {
                Form1.B0202Num = 0;
            }
        }
    }
}
