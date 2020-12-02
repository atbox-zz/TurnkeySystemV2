using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TurnkeySystemV2.Configuration;
using TurnkeySystemV2.Controller;
using TurnkeySystemV2.Protocols;
using TurnkeySystemV2.Protocols.A0101;
using TurnkeySystemV2.Protocols.A0102;
using TurnkeySystemV2.Protocols.A0201;
using TurnkeySystemV2.Protocols.A0202;
using TurnkeySystemV2.Protocols.A0301;
using TurnkeySystemV2.Protocols.A0302;
using TurnkeySystemV2.Protocols.A0401;
using TurnkeySystemV2.Protocols.A0501;
using TurnkeySystemV2.Protocols.B0101;
using TurnkeySystemV2.Protocols.B0102;
using TurnkeySystemV2.Protocols.B0201;
using TurnkeySystemV2.Protocols.B0202;
using TurnkeySystemV2.Protocols.B0401;
using TurnkeySystemV2.Protocols.B0501;
using TurnkeySystemV2.Protocols.E0402;

namespace TurnkeySystemV2
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 各發票類型數量
        /// </summary>
        public int A0101Num, A0102Num, A0201Num, A0202Num, A0301Num, A0302Num, A0401Num, A0501Num, B0101Num, B0102Num, B0201Num, B0202Num, B0401Num, B0501Num, E0402Num;
        /// <summary>
        /// 檔案存取路徑
        /// </summary>
        private RemoveReportPathSetting RemoveReportPathSetting { get; set; }
        /// <summary>
        /// 資料庫
        /// </summary>
        private SqlDBSetting SqlDBSetting { get; set; }
        /// <summary>
        /// SQL解析
        /// </summary>
        private SQLMethod SQLMethod;
        /// <summary>
        /// XML解析
        /// </summary>
        private XMLMethod XMLMethod;
        #region Protocols
        /// <summary>
        /// 通訊
        /// </summary>
        private List<AbsProtocol> absProtocols = new List<AbsProtocol>();
        #endregion
        public Form1()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\log-.txt",
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();        //宣告Serilog初始化

            RemoveReportPathSetting = InitialMethod.RemoveReportPath();
            SqlDBSetting = InitialMethod.SqlDB();

            SQLMethod = new SQLMethod() { Form1 = this, setting = SqlDBSetting };
            SQLMethod.SQLConnect();

            XMLMethod = new XMLMethod() { Form1 = this, RemoveReportPathSetting = RemoveReportPathSetting };

            A0101Protocol a0101Protocol = new A0101Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0101Protocol);
            A0102Protocol a0102Protocol = new A0102Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0102Protocol);
            A0201Protocol a0201Protocol = new A0201Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0201Protocol);
            A0202Protocol a0202Protocol = new A0202Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0202Protocol);
            A0301Protocol a0301Protocol = new A0301Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0301Protocol);
            A0302Protocol a0302Protocol = new A0302Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0302Protocol);
            A0401Protocol a0401Protocol = new A0401Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0401Protocol);
            A0501Protocol a0501Protocol = new A0501Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(a0501Protocol);
            B0101Protocol b0101Protocol = new B0101Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(b0101Protocol);
            B0102Protocol b0102Protocol = new B0102Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(b0102Protocol);
            B0201Protocol b0201Protocol = new B0201Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(b0201Protocol);
            B0202Protocol b0202Protocol = new B0202Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(b0202Protocol);
            B0401Protocol b0401Protocol = new B0401Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(b0401Protocol);
            B0501Protocol b0501Protocol = new B0501Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(b0501Protocol);
            E0402Protocol e0402Protocol = new E0402Protocol() { SQLMethod = SQLMethod, Form1 = this, XMLMethod = XMLMethod };
            absProtocols.Add(e0402Protocol);
        }

        private void CreateFilebutton_Click(object sender, EventArgs e)
        {
            foreach (var item in absProtocols)
            {
                item.ReadData();
            }
            string LogString = $"檔案產生完成 " +
                               $"\r A0101-開立發票: {A0101Num} 張" +
                               $"\r A0102-發票接收確認: {A0102Num} 張" +
                               $"\r A0201-作廢發票: {A0201Num} 張" +
                               $"\r A0202-作廢發票接收確認: {A0202Num} 張" +
                               $"\r A0301-退回發票: {A0301Num} 張" +
                               $"\r A0302-退回發票接收確認: {A0302Num} 張" +
                               $"\r A0401-平台存證開立發票: {A0401Num} 張" +
                               $"\r A0501-平台存證作廢發票: {A0501Num} 張" +
                               $"\r B0101-開立折讓證明單|傳送折讓證明單通知: {B0101Num} 張" +
                               $"\r B0102-開立折讓證明/通知單接收確認: {B0102Num} 張" +
                               $"\r B0201-作廢折讓證明單: {B0201Num} 張" +
                               $"\r B0202-作廢折讓證明單接收確認: {B0201Num} 張" +
                               $"\r B0401-平台存證開立折讓證明/通知單: {B0401Num} 張" +
                               $"\r B0501-平台存證作廢發票: {B0501Num} 張" +
                               $"\r E0402-空白未使用字軌檔: {E0402Num} 張";
             MessageBox.Show($"{LogString}");
        }
    }
}
