using System.Collections.Generic;

namespace TurnkeySystemV2.Protocols.B0201
{
    public class B0201Protocol : B0201Data
    {
        public override void ReadData()
        {
            List<CancelAllowance> B0201 = new List<CancelAllowance>();
            var Value = SQLMethod.Count_B0201();
            if (Value != null)
            {
                Form1.B0201Num = Value.Count;
                foreach (var B0201Data in Value)
                {
                    CancelAllowance data = new CancelAllowance();
                    data.CancelAllowanceNumber = B0201Data.CancelAllowanceNumber.Trim();
                    data.AllowanceDate = B0201Data.AllowanceDate.Trim();
                    data.BuyerId = B0201Data.BuyerId.Trim();
                    data.SellerId = B0201Data.SellerId.Trim();
                    data.CancelDate = B0201Data.CancelDate.Trim();
                    data.CancelTime = B0201Data.CancelTime.Substring(0, 2) + ":" + B0201Data.CancelTime.Substring(2, 2) + ":00";
                    data.CancelReason = B0201Data.CancelReason.Trim();
                    B0201.Add(data);
                }
                CancelAllowance = B0201;
                if (Value.Count > 0)
                {
                    XMLMethod.Save_B0201(CancelAllowance);
                }
            }
            else
            {
                Form1.B0201Num = 0;
            }
        }
    }
}
