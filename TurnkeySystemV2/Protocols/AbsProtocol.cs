using TurnkeySystemV2.Controller;

namespace TurnkeySystemV2.Protocols
{
    public abstract class AbsProtocol
    {
        /// <summary>
        /// 狀態資訊
        /// </summary>
        public Form1 Form1 { get; set; }
        /// <summary>
        /// 資料庫方法
        /// </summary>
        public SQLMethod SQLMethod { get; set; }
        /// <summary>
        /// XML格式
        /// </summary>
        public XMLMethod XMLMethod { get; set; }
        /// <summary>
        /// 讀取資料
        /// </summary>
        public virtual void ReadData() { }
    }
}
