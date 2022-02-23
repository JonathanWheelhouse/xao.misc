using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Security.Cryptography;
using System.IO;

namespace TestMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string XAOConnStr = ConfigurationManager.ConnectionStrings["XAOGameDBstring"].ToString();
        string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();


        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
                string strUsers = "select windows_logon, display_name, password, start_date, sound_file_name from USERS order by user_id";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                BindingSource bindingSauce = new BindingSource();

                dataAdapter = new MySqlDataAdapter(strUsers, myConnStr);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSauce.DataSource = table;
                dgvUsers.DataSource = bindingSauce;
                var key = "b14ca5898a4e4133bbce2ea2315a1916";

                foreach (DataRow dr in table.Rows)
                {
                    Console.WriteLine("pwd " + dr[2].ToString() + " = " + DecryptString(key, dr[2].ToString()) );
                }
                    /*
                    using (var mySqlConnection = new MySqlConnection(myConnStr))
                    {

                        mySqlConnection.Open();
                        MySqlCommand mySqlCmd = new MySqlCommand(strUsers, mySqlConnection);
                        // mySqlCmd.ExecuteNonQuery();

                        using (var dbread = mySqlCmd.ExecuteReader())
                        {
                            if (dbread.Read())
                            {

                            }
                        }

                    }
                    */
                }
            catch (Exception exp)
            {
                Console.WriteLine("exp = " + exp.ToString());
                MessageBox.Show("exp = " + exp.ToString(), "btnGet_Click");
                throw;
            }
        }

        private void InsertMySql(string strSQL)
        {
            // string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            MySqlConnection con = new MySqlConnection(myConnStr);
            MySqlCommand myCmd = new MySqlCommand(strSQL, con);
            MySqlDataAdapter sda = new MySqlDataAdapter();
            myCmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                int insertCnt = myCmd.ExecuteNonQuery();
                Console.WriteLine("insert count = " + insertCnt.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }

        }
        private DataTable GetOracleData(OracleCommand cmd, string constr)
        {
            DataTable dt = new DataTable();

            OracleConnection con = new OracleConnection(constr);
            OracleDataAdapter sda = new OracleDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        private void btnMigrate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtUser = new DataTable();
            string strUsers = "select user_id, windows_logon, display_name, password, last_logon_date, sound_file_name, picture_file_name, start_date, end_date, first_name, admin_flag, avatar_file_name from USERS order by windows_logon";
            OracleCommand cmd = new OracleCommand(strUsers);
            dtUser = GetOracleData(cmd, XAOConnStr);

            BindingSource bindingSauce = new BindingSource();
            DataTable table = new DataTable();
            bindingSauce.DataSource = dtUser;
            dgvOracleUsers.DataSource = bindingSauce;

            StringBuilder sbSQL = new StringBuilder();
            MySqlCommand myCmd = new MySqlCommand();
            string strLastDate = string.Empty;
            string strStartDate = string.Empty;
            string strEndDate = string.Empty;
            string strPwd = string.Empty;
            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            Int32 iCnt = 0;
            foreach (DataRow row in dtUser.Rows)
            {
                if (!CheckUserExistsMySql(Convert.ToInt32(row[0]), row[1].ToString()))
                {
                    strLastDate = format_to_str(row[4].ToString());
                    strStartDate = format_to_str(row[7].ToString());
                    strEndDate = format_to_str(row[8].ToString());
                    strPwd = EncryptString(key,  row[3].ToString());
                    sbSQL = new StringBuilder();
                    sbSQL.Append("Insert into XAO_INDEX_GAME.USERS (USER_ID,WINDOWS_LOGON,DISPLAY_NAME,PASSWORD,LAST_LOGON_DATE, ");
                    sbSQL.Append("  SOUND_FILE_NAME,PICTURE_FILE_NAME,START_DATE,END_DATE,FIRST_NAME,ADMIN_FLAG,AVATAR_FILE_NAME) values (");
                    sbSQL.Append(row[0] + ",'" + row[1] + "','");
                    sbSQL.Append(row[2].ToString().Replace("'", "''") + "','" + strPwd + "', " + strLastDate + ",'");
                    sbSQL.Append(row[5].ToString().Replace("'", "''") + "','"); // the replace is to handle embedded single quotes
                    sbSQL.Append(row[6].ToString().Replace("'", "''") + "', ");
                    sbSQL.Append(strStartDate + " , " + strEndDate + ",'" + row[9] + "','" + row[10] + "','" + row[11] + "')");

                    InsertMySql(sbSQL.ToString());
                }
                iCnt++;
                Console.Write("iCnt = " + iCnt.ToString() + " column1 = " + row[0].ToString());

                Console.Write(" column2 = " + row[1].ToString());
                Console.Write(" column3 = " + row[2].ToString());
                Console.WriteLine(" column4 = " + row[3].ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        private string format_to_str(string inStr)
        {
            string outStr = "str_to_date('" + inStr + "','%d/%m/%Y %H:%i:%s')";
            return outStr;
        }

        private bool CheckUserExistsMySql(Int32 user_id, string strUsername)
        {
            string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            string strUsers = "select user_id from USERS where user_id = " + user_id + " and windows_logon = '" + strUsername + "'";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            BindingSource bindingSauce = new BindingSource();

            dataAdapter = new MySqlDataAdapter(strUsers, myConnStr);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;

        }

        private void btnPicks_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtUser = new DataTable();
            string strUsers = "select pick_id, user_id, windows_logon, display_name, pick, winner_flag, jackpot_flag, jackpot_amount, pick_date from PICKS order by pick_id";
            OracleCommand cmd = new OracleCommand(strUsers);
            dtUser = GetOracleData(cmd, XAOConnStr);

            BindingSource bindingSauce = new BindingSource();
            DataTable table = new DataTable();
            bindingSauce.DataSource = dtUser;
            dgvOracleUsers.DataSource = bindingSauce;

            StringBuilder sbSQL = new StringBuilder();
            MySqlCommand myCmd = new MySqlCommand();
            string strPickDate = string.Empty;

            Int32 iCnt = 0;
            foreach (DataRow row in dtUser.Rows)
            {
                if (!CheckPickExistsMySql(Convert.ToInt32(row[1]), Convert.ToInt32( row[0])))
                {
                    strPickDate = format_to_str(row[8].ToString());
                    sbSQL = new StringBuilder();
                    sbSQL.Append("Insert into XAO_INDEX_GAME.PICKS (PICK_ID,USER_ID,WINDOWS_LOGON,DISPLAY_NAME,PICK,WINNER_FLAG, ");
                    sbSQL.Append("  JACKPOT_FLAG,JACKPOT_AMOUNT,PICK_DATE) values (");
                    sbSQL.Append(row[0] + "," + row[1] + ",'");
                    sbSQL.Append(row[2].ToString().Replace("'", "''") + "','" + row[3].ToString().Replace("'", "''") + "', " + row[4] + ",'");
                    sbSQL.Append(row[5].ToString() + "','"); // winner flag
                    sbSQL.Append(row[6] + "', "); // jackpot flag
                    sbSQL.Append(row[7] + ", ");
                    sbSQL.Append(strPickDate + ")");

                    InsertMySql(sbSQL.ToString());
                }
                iCnt++;
                if(iCnt % 6 > 4)
                    Application.DoEvents();
                Console.Write("iCnt = " + iCnt.ToString() + " column1 = " + row[0].ToString());

                Console.Write(" column2 = " + row[2].ToString());
                Console.Write(" column3 = " + row[3].ToString());
                Console.WriteLine(" column4 = " + row[8].ToString());  
            }

            Cursor.Current = Cursors.Default;
        }

        private bool CheckPickExistsMySql(Int32 user_id, Int32 pick_id)
        {
            string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            string strUsers = "select user_id from PICKS where user_id = " + user_id + " and pick_id = " + pick_id;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            BindingSource bindingSauce = new BindingSource();

            dataAdapter = new MySqlDataAdapter(strUsers, myConnStr);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;

        }


        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void btnMySqlPicks_Click(object sender, EventArgs e)
        {

        }

        private void btnMiscData_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtUser = new DataTable();
            string strUsers = "select parameter_name, parameter_value1, parameter_value2, parameter_date, parameter_description from MISC ";
            OracleCommand cmd = new OracleCommand(strUsers);
            dtUser = GetOracleData(cmd, XAOConnStr);

            BindingSource bindingSauce = new BindingSource();
            DataTable table = new DataTable();
            bindingSauce.DataSource = dtUser;
            dgvOracleUsers.DataSource = bindingSauce;

            StringBuilder sbSQL = new StringBuilder();
            MySqlCommand myCmd = new MySqlCommand();
            string strParamDate = string.Empty;

            Int32 iCnt = 0;
            foreach (DataRow row in dtUser.Rows)
            {
                if (!CheckMiscExistsMySql(row[0].ToString()))
                {
                    strParamDate = format_to_str(row[3].ToString());
                    sbSQL = new StringBuilder();
                    sbSQL.Append("Insert into XAO_INDEX_GAME.MISC (PARAMETER_NAME, PARAMETER_VALUE1, PARAMETER_VALUE2, PARAMETER_DATE,  ");
                    sbSQL.Append("  PARAMETER_DESCRIPTION) values ('");
                    sbSQL.Append(row[0].ToString() + "','" + row[1].ToString() + "','");
                    sbSQL.Append(row[2].ToString() + "'," + strParamDate + ", '" + row[4].ToString() + "')");

                    InsertMySql(sbSQL.ToString());
                }
                iCnt++;
                if (iCnt % 6 > 4)
                    Application.DoEvents();
                Console.Write("iCnt = " + iCnt.ToString() + " column1 = " + row[0].ToString());

                Console.Write(" column2 = " + row[2].ToString());
                Console.Write(" column3 = " + row[3].ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        private bool CheckMiscExistsMySql(string strParamName)
        {
            string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            string strUsers = "select parameter_name from MISC where parameter_name = '" + strParamName + "'";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            BindingSource bindingSauce = new BindingSource();

            dataAdapter = new MySqlDataAdapter(strUsers, myConnStr);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;

        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtIndex = new DataTable();
            string strUsers = "select ASX_CODE, LAST_PRICE, MESSAGE_RECEIPT_TIME, MOVEMENT from INDEX_HISTORY_EOD ";
            OracleCommand cmd = new OracleCommand(strUsers);
            dtIndex = GetOracleData(cmd, XAOConnStr);

            BindingSource bindingSauce = new BindingSource();
            DataTable table = new DataTable();
            bindingSauce.DataSource = dtIndex;
            dgvOracleUsers.DataSource = bindingSauce;

            StringBuilder sbSQL = new StringBuilder();
            MySqlCommand myCmd = new MySqlCommand();
            string strParamDate = string.Empty;

            Int32 iCnt = 0;
            foreach (DataRow row in dtIndex.Rows)
            {
                string strDate = row[2].ToString();
                DateTime dtDate = Convert.ToDateTime(strDate);

                if (!CheckIndexExistsMySql( dtDate.ToString("yyyy-MM-dd") ))
                {
                    strParamDate = format_to_str(row[2].ToString());
                    sbSQL = new StringBuilder();
                    sbSQL.Append("Insert into XAO_INDEX_GAME.INDEX_HISTORY_EOD (ASX_CODE, LAST_PRICE, MESSAGE_RECEIPT_TIME, MOVEMENT  ");
                    sbSQL.Append(" ) values ('");
                    sbSQL.Append(row[0].ToString() + "','" + row[1].ToString() + "',");
                    sbSQL.Append(strParamDate + ", '" + row[3].ToString() + "')");

                    InsertMySql(sbSQL.ToString());
                }
                iCnt++;
                if (iCnt % 6 > 4)
                    Application.DoEvents();
                Console.Write("iCnt = " + iCnt.ToString() + " column1 = " + row[0].ToString());

                Console.Write(" column2 = " + row[2].ToString());
                Console.Write(" column3 = " + row[3].ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        private bool CheckIndexExistsMySql(string strDate)
        {
            string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();

            try
            {
                string strUsers = "select MESSAGE_RECEIPT_TIME from INDEX_HISTORY_EOD where MESSAGE_RECEIPT_TIME = '" + strDate + "'";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                BindingSource bindingSauce = new BindingSource();

                dataAdapter = new MySqlDataAdapter(strUsers, myConnStr);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                if (table.Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception exp)
            {
                Console.WriteLine("Error in CheckIndexExistsMySql : " + exp.ToString());
                return false;
            }


        }

    }
}

