namespace TurnkeySystemV2.Configuration
{
    #region 移動報表資料夾路徑
    /// <summary>
    /// 移動報表資料夾路徑
    /// </summary>
    public class RemoveReportPathSetting
    {
        /// <summary>
        /// 開立發票路徑
        /// </summary>
        public string A0101Path { get; set; }
        /// <summary>
        /// 發票接收確認路徑
        /// </summary>
        public string A0102Path { get; set; }
        /// <summary>
        /// 作廢發票路徑
        /// </summary>
        public string A0201Path { get; set; }
        /// <summary>
        /// 作廢發票接收確認路徑
        /// </summary>
        public string A0202Path { get; set; }
        /// <summary>
        /// 退回發票路徑
        /// </summary>
        public string A0301Path { get; set; }
        /// <summary>
        /// 退回發票接收確認路徑
        /// </summary>
        public string A0302Path { get; set; }
        /// <summary>
        /// 平台存證開立發票路徑
        /// </summary>
        public string A0401Path { get; set; }
        /// <summary>
        /// 平台存證作廢發票路徑
        /// </summary>
        public string A0501Path { get; set; }
        /// <summary>
        /// 開立折讓證明路徑
        /// </summary>
        public string B0101Path { get; set; }
        /// <summary>
        /// 開立折讓證明/通知單接收確認路徑
        /// </summary>
        public string B0102Path { get; set; }
        /// <summary>
        /// 作廢折讓證明路徑
        /// </summary>
        public string B0201Path { get; set; }
        /// <summary>
        /// 作廢折讓證明單接收確認路徑
        /// </summary>
        public string B0202Path { get; set; }
        /// <summary>
        /// 平台存證開立折讓證明/通知單路徑
        /// </summary>
        public string B0401Path { get; set; }
        /// <summary>
        /// 平台存證開立折讓證明單路徑
        /// </summary>
        public string B0501Path { get; set; }
        /// <summary>
        /// 空白未使用字軌路徑
        /// </summary>
        public string E0402Path { get; set; }
    }
    #endregion
}
