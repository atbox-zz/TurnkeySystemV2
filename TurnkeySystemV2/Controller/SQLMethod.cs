using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TurnkeySystemV2.Configuration;
using TurnkeySystemV2.EF_Module;

namespace TurnkeySystemV2.Controller
{
    public class SQLMethod
    {
        /// <summary>
        /// 目前執行狀態
        /// </summary>
        public Form1 Form1 { get; set; }
        /// <summary>
        /// 資料庫連結資訊
        /// </summary>
        public SqlConnectionStringBuilder scsb;
        /// <summary>
        /// 資料庫JSON
        /// </summary>
        public SqlDBSetting setting { get; set; }

        #region 資料庫連結
        /// <summary>
        /// EF資料庫連結
        /// </summary>
        /// <param name="DataBaseType">資料庫類型</param>
        public void SQLConnect()
        {
            scsb = new SqlConnectionStringBuilder()
            {
                DataSource = setting.DataSource,
                InitialCatalog = setting.InitialCatalog,
                UserID = setting.UserID,
                Password = setting.Password
            };
        }
        #endregion

        #region  A0101 開立發票
        /// <summary>
        /// 開立發票
        /// </summary>
        /// <returns></returns>
        public List<A0101> Count_A0101()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0101]";
                    var values = conn.Query<A0101>(sql).ToList();
                    if (values != null)
                    {
                        foreach (var item in values)
                        {
                            try
                            {
                                sql = "INSERT INTO BACKA0101(InvoiceNumber,InvoiceDate,InvoiceTime,SellerID,SellerName,BuyerID," +
                                 "BuyerName,InvoiceType,DonateMark,SalesAmount,TaxType,TaxRate,TaxAmount,TotalAmount)" +
                                 "VALUES(@InvoiceNumber,@InvoiceDate,@InvoiceTime,@SellerID,@SellerName,@BuyerID," +
                                 "@BuyerName,@InvoiceType,@DonateMark,@SalesAmount,@TaxType,@TaxRate,@TaxAmount,@TotalAmount)";
                                conn.Execute(sql, item);
                                try
                                {
                                    sql = $"DELETE FROM A0101 WHERE InvoiceNumber = '{item.InvoiceNumber}'";
                                    conn.Execute(sql);
                                }
                                catch (Exception ex) { Log.Error(ex, "A0101刪除失敗"); }
                            }
                            catch (Exception ex) { Log.Error(ex, "BakA0101備份失敗"); }
                        }
                        return values;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢A0101失敗");
                return null;
            }
        }
        /// <summary>
        /// 開立發票細項
        /// </summary>
        /// <returns></returns>
        public List<A0101_detail> Count_A0101_detail()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0101-detail]";
                    var values = conn.Query<A0101_detail>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO [BACKA0101-detail](InvoiceNumber,Description,Quantity,Unit,UnitPrice,Amount,SequenceNumber)" +
                                "VALUES(@InvoiceNumber,@Description,@Quantity,@Unit,@UnitPrice,@Amount,@SequenceNumber)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM [A0101-detail] WHERE InvoiceNumber = '{item.InvoiceNumber}' AND SequenceNumber = {item.SequenceNumber}";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0101_detail刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0101_detail備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢A0101_detail失敗");
                return null;
            }
        }
        #endregion

        #region A0102 發票接收確認
        /// <summary>
        /// 發票接收確認
        /// </summary>
        /// <returns></returns>
        public List<A0102> Count_A0102()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0102]";
                    var values = conn.Query<A0102>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKA0102(InvoiceNumber,InvoiceDate,BuyerID,SellerID,ReceiveDate,ReceiveTime)" +
                                "VALUES(@InvoiceNumber,@InvoiceDate,@BuyerID,@SellerID,@ReceiveDate,@ReceiveTime)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM A0102 WHERE InvoiceNumber = '{item.InvoiceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0102刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0102備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢A0102失敗"); return null; }
        }
        #endregion

        #region A0201 作廢發票
        /// <summary>
        /// 作廢發票
        /// </summary>
        /// <returns></returns>
        public List<A0201> Count_A0201()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0201]";
                    var values = conn.Query<A0201>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKA0201(CancelInvoiceNumber,InvoiceDate,Buyerid,Sellerid,CancelDate,CancelTime,CancelReason)" +
                                "VALUES(@CancelInvoiceNumber,@InvoiceDate,@Buyerid,@Sellerid,@CancelDate,@CancelTime,@CancelReason)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM A0201 WHERE CancelInvoiceNumber ='{item.CancelInvoiceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0201刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0201備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢A0201失敗"); return null; }
        }
        #endregion

        #region A0202 作廢發票接收確認
        /// <summary>
        /// 作廢發票接收確認
        /// </summary>
        /// <returns></returns>
        public List<A0202> Count_A0202()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0202]";
                    var values = conn.Query<A0202>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKA0202(CancelInvoiceNumber,InvoiceDate,Buyerid,Sellerid,CancelDate,CancelTime)" +
                                "VALUES(@CancelInvoiceNumber,@InvoiceDate,@Buyerid,@Sellerid,@CancelDate,@CancelTime)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM A0202 WHERE CancelInvoiceNumber = '{item.CancelInvoiceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0202刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0202備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢A0202失敗"); return null; }
        }
        #endregion

        #region A0301 退回發票
        /// <summary>
        /// 退回發票
        /// </summary>
        /// <returns></returns>
        public List<A0301> Count_A0301()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0301]";
                    var values = conn.Query<A0301>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKA0301(RejectInvoiceNumber,InvoiceDate,BuyerId,SellerId,RejectDate,RejectTime,RejectReason)" +
                                "VALUES(@RejectInvoiceNumber,@InvoiceDate,@BuyerId,@SellerId,@RejectDate,@RejectTime,@RejectReason)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM A0301 WHERE RejectInvoiceNumber = '{item.RejectInvoiceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0301刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0301備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢A0301失敗"); return null; }
        }
        #endregion

        #region A0302 退回發票接收確認
        /// <summary>
        /// 退回發票
        /// </summary>
        /// <returns></returns>
        public List<A0302> Count_A0302()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0302]";
                    var values = conn.Query<A0302>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKA0302(RejectInvoiceNumber,InvoiceDate,BuyerId,SellerId,RejectDate,RejectTime)" +
                                "VALUES(@RejectInvoiceNumber,@InvoiceDate,@BuyerId,@SellerId,@RejectDate,@RejectTime)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM A0302 WHERE RejectInvoiceNumber = '{item.RejectInvoiceNumber}'";
                                conn.Execute(sql, item.RejectInvoiceNumber);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0302刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0302備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢A0302失敗"); return null; }
        }
        #endregion

        #region  A0401 平台存證開立發票
        /// <summary>
        /// 平台存證開立發票
        /// </summary>
        /// <returns></returns>
        public List<A0401> Count_A0401()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0401]";
                    var values = conn.Query<A0401>(sql).ToList();
                    if (values != null)
                    {
                        foreach (var item in values)
                        {
                            try
                            {
                                sql = "INSERT INTO BACKA0401(InvoiceNumber,InvoiceDate,InvoiceTime,SellerID,SellerName,BuyerID," +
                                 "BuyerName,InvoiceType,DonateMark,SalesAmount,TaxType,TaxRate,TaxAmount,TotalAmount)" +
                                 "VALUES(@InvoiceNumber,@InvoiceDate,@InvoiceTime,@SellerID,@SellerName,@BuyerID," +
                                 "@BuyerName,@InvoiceType,@DonateMark,@SalesAmount,@TaxType,@TaxRate,@TaxAmount,@TotalAmount)";
                                conn.Execute(sql, item);
                                try
                                {
                                    sql = $"DELETE FROM A0401 WHERE InvoiceNumber = '{item.InvoiceNumber}'";
                                    conn.Execute(sql);
                                }
                                catch (Exception ex) { Log.Error(ex, "A0401刪除失敗"); }
                            }
                            catch (Exception ex) { Log.Error(ex, "BakA0401備份失敗"); }
                        }
                        return values;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢A0401失敗");
                return null;
            }
        }
        /// <summary>
        /// 平台存證開立發票細項
        /// </summary>
        /// <returns></returns>
        public List<A0401_detail> Count_A0401_detail()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0401-detail]";
                    var values = conn.Query<A0401_detail>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO [BACKA0401-detail](InvoiceNumber,Description,Quantity,Unit,UnitPrice,Amount,SequenceNumber)" +
                                "VALUES(@InvoiceNumber,@Description,@Quantity,@Unit,@UnitPrice,@Amount,@SequenceNumber)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM [A0401-detail] WHERE InvoiceNumber = '{item.InvoiceNumber}' AND SequenceNumber = {item.SequenceNumber}";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0401_detail刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0401_detail備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢A0401_detail失敗");
                return null;
            }
        }
        #endregion

        #region A0501 平台存證作廢發票
        /// <summary>
        /// 平台存證作廢發票
        /// </summary>
        /// <returns></returns>
        public List<A0501> Count_A0501()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[A0501]";
                    var values = conn.Query<A0501>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKA0501(CancelInvoiceNumber,InvoiceDate,Buyerid,Sellerid,CancelDate,CancelTime,CancelReason)" +
                                "VALUES(@CancelInvoiceNumber,@InvoiceDate,@Buyerid,@Sellerid,@CancelDate,@CancelTime,@CancelReason)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM A0501 WHERE CancelInvoiceNumber = '{item.CancelInvoiceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "A0501刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakA0501備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢A0501失敗"); return null; }
        }
        #endregion

        #region B0101 開立折讓證明單|傳送折讓證明單通知
        /// <summary>
        /// B0101 開立折讓證明單|傳送折讓證明單通知
        /// </summary>
        /// <returns></returns>
        public List<B0101> Count_B0101()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0101]";
                    var values = conn.Query<B0101>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKB0101(AllowanceNumber,AllowanceDate,SellerID,SellerName,BuyerID,BuyerName,AllowanceType,taxamount,Totalamount)" +
                                   "VALUES(@AllowanceNumber,@AllowanceDate,@SellerID,@SellerName,@BuyerID,@BuyerName,@AllowanceType,@taxamount,@Totalamount)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM B0101 WHERE AllowanceNumber = '{item.AllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0101刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "B0101刪除失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢B0101失敗"); return null; }
        }
        /// <summary>
        /// 開立折讓證明單|傳送折讓證明單通知細項
        /// </summary>
        /// <returns></returns>
        public List<B0101_detail> Count_B0101_detail()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0101-detail]";
                    var values = conn.Query<B0101_detail>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO [BACKB0101-detail](AllowanceNumber,Productitem,OriginalInvoiceDate,OriginalInvoiceNumber,OriginalSequenceNumber" +
                                ",OriginalDescription,Quantity,Unit,UnitPrice,Amount,Tax,AllowanceSequenceNumber,TaxType)" +
                                "VALUES(@AllowanceNumber,@Productitem,@OriginalInvoiceDate,@OriginalInvoiceNumber,@OriginalSequenceNumber,@OriginalDescription" +
                                ",@Quantity,@Unit,@UnitPrice,@Amount,@Tax,@AllowanceSequenceNumber,@TaxType)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM [B0101-detail] WHERE AllowanceNumber = '{item.AllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0101_detail刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakB0101_detail備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢B0101_detail失敗");
                return null;
            }
        }
        #endregion

        #region B0102 開立折讓證明/通知單接收確認
        /// <summary>
        /// 開立折讓證明/通知單接收確認
        /// </summary>
        /// <returns></returns>
        public List<B0102> Count_B0102()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0102]";
                    var values = conn.Query<B0102>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKB0102(AllowanceNumber,AllowanceDate,BuyerID,SellerID,ReceiveDate,ReceiveTime,AllowanceType)" +
                                "VALUES(@AllowanceNumber,@AllowanceDate,@BuyerID,@SellerID,@ReceiveDate,@ReceiveTime,@AllowanceType)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM B0102 WHERE AllowanceNumber = '{item.AllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0102刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakB0102備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢B0102失敗"); return null; }
        }
        #endregion

        #region B0201 作廢折讓證明單
        /// <summary>
        ///作廢折讓證明單
        /// </summary>
        /// <returns></returns>
        public List<B0201> Count_B0201()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0201]";
                    var values = conn.Query<B0201>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKB0201(CancelAllowanceNumber,AllowanceDate,BuyerId,SellerId,CancelDate,CancelTime,CancelReason)" +
                                "VALUES(@CancelAllowanceNumber,@AllowanceDate,@BuyerId,@SellerId,@CancelDate,@CancelTime,@CancelReason)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM B0201 WHERE CancelAllowanceNumber = '{item.CancelAllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0201刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakB0201備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢B0201失敗"); return null; }
        }
        #endregion

        #region B0202 作廢折讓證明單接收確認
        /// <summary>
        ///作廢折讓證明單接收確認
        /// </summary>
        /// <returns></returns>
        public List<B0202> Count_B0202()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0202]";
                    var values = conn.Query<B0202>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKB0202(CancelAllowanceNumber,AllowanceDate,BuyerId,SellerId,CancelDate,CancelTime)" +
                                "VALUES(@CancelAllowanceNumber,@AllowanceDate,@BuyerId,@SellerId,@CancelDate,@CancelTime)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM B0202 WHERE CancelAllowanceNumber ='{item.CancelAllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0202刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakB0202備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢B0202失敗"); return null; }
        }
        #endregion

        #region B0401 平台存證開立折讓證明/通知單
        /// <summary>
        /// B0401 平台存證開立折讓證明/通知單
        /// </summary>
        /// <returns></returns>
        public List<B0401> Count_B0401()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0401]";
                    var values = conn.Query<B0401>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKB0401(AllowanceNumber,AllowanceDate,SellerID,SellerName,BuyerID,BuyerName,AllowanceType)" +
                                   "VALUES(@AllowanceNumber,@AllowanceDate,@SellerID,@SellerName,@BuyerID,@BuyerName,@AllowanceType)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM B0401 WHERE AllowanceNumber = '{item.AllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0401刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "B0401刪除失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢B0401失敗"); return null; }
        }
        /// <summary>
        /// 平台存證開立折讓證明/通知單細項
        /// </summary>
        /// <returns></returns>
        public List<B0401_detail> Count_B0401_detail()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0401-detail]";
                    var values = conn.Query<B0401_detail>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO [BACKB0401-detail](AllowanceNumber,Productitem,OriginalInvoiceDate,OriginalInvoiceNumber,OriginalSequenceNumber" +
                                ",OriginalDescription,Quantity,Unit,UnitPrice,Amount,Tax,AllowanceSequenceNumber,TaxType,Taxamount,Totalamount)" +
                                "VALUES(@AllowanceNumber,@Productitem,@OriginalInvoiceDate,@OriginalInvoiceNumber,@OriginalSequenceNumber,@OriginalDescription" +
                                ",@Quantity,@Unit,@UnitPrice,@Amount,@Tax,@AllowanceSequenceNumber,@TaxType,@Taxamount,@Totalamount)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM [B0401-detail] WHERE AllowanceNumber = '{item.AllowanceNumber}' AND Productitem = {item.Productitem}";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0401_detail刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakB0401_detail備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢B0401_detail失敗");
                return null;
            }
        }
        #endregion

        #region B0501 平台存證作廢發票
        /// <summary>
        ///平台存證作廢發票
        /// </summary>
        /// <returns></returns>
        public List<B0501> Count_B0501()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[B0501]";
                    var values = conn.Query<B0501>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKB0501(CancelAllowanceNumber,AllowanceDate,BuyerId,SellerId,CancelDate,CancelTime,Cancelreason)" +
                                "VALUES(@CancelAllowanceNumber,@AllowanceDate,@BuyerId,@SellerId,@CancelDate,@CancelTime,@Cancelreason)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM B0501 WHERE CancelAllowanceNumber = '{item.CancelAllowanceNumber}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "B0501刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "BakB0501備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢B0501失敗"); return null; }
        }
        #endregion

        #region E0402 空白未使用字軌檔
        /// <summary>
        /// E0402 空白未使用字軌檔
        /// </summary>
        /// <returns></returns>
        public List<E0402> Count_E0402()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[E0402]";
                    var values = conn.Query<E0402>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO BACKE0401(Headban,Branchban,Invoicetype,Yearmonth,Invoicetrack)" +
                                   "VALUES(@Headban,@Branchban,@Invoicetype,@Yearmonth,@Invoicetrack)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM E0401 WHERE Headban = '{item.Headban}'";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "E0402刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "E0402刪除失敗"); }
                    return values;
                }
            }
            catch (Exception ex) { Log.Error(ex, "查詢E0402失敗"); return null; }
        }
        /// <summary>
        /// 空白未使用字軌檔細項
        /// </summary>
        /// <returns></returns>
        public List<E0402_detail> Count_E0402_detail()
        {
            try
            {
                using (var conn = new SqlConnection(scsb.ConnectionString))
                {
                    string sql = "SELECT * FROM [Turnkeydb]..[E0402-detail]";
                    var values = conn.Query<E0402_detail>(sql).ToList();
                    try
                    {
                        foreach (var item in values)
                        {
                            sql = "INSERT INTO [BACKE0402-detail](Branchtrackitem,Invoicebeginno,Invoiceendno)" +
                                "VALUES(@Branchtrackitem,@Invoicebeginno,@Invoiceendno)";
                            conn.Execute(sql, item);
                            try
                            {
                                sql = $"DELETE FROM [E0402-detail] WHERE Branchtrackitem = {item.Branchtrackitem}";
                                conn.Execute(sql);
                            }
                            catch (Exception ex) { Log.Error(ex, "E0402_detail刪除失敗"); }
                        }
                    }
                    catch (Exception ex) { Log.Error(ex, "E0402_detail備份失敗"); }
                    return values;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢E0402_detail失敗");
                return null;
            }
        }
        #endregion
    }
}
