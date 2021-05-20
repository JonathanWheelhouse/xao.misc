using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using MySql.Data.MySqlClient;

namespace IndexSimulator
{
    public partial class frmIndexSimulator : Form
    {

        public frmIndexSimulator()
        {
            InitializeComponent();
        }

        string XAOConnStr = ConfigurationManager.ConnectionStrings["XAOGameDBstring"].ToString();
        string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
        Thread thIndex;
        string strIndexCode = string.Empty;
        IndexCalc CalcIndex;

        private void btnStart_Click(object sender, EventArgs e)
        {
            int intLoopCnt = 0;
            Int32 intDelayMillisecs = 0;

            if (txtIndexCode.Text.Length < 3)
            {
                MessageBox.Show("Please enter 3 character Index code.");
                txtIndexCode.Focus();
                return;
            }

            txtIndexCode.Text.ToUpper();
            strIndexCode = txtIndexCode.Text;

            if (txtInterval.Text.Length < 1)
            {
                MessageBox.Show("Please enter a time interval in seconds");
                txtInterval.Focus();
                return;
            }

            if (txtInterval.Text.Length > 0)
            {
                if (!Int32.TryParse(txtInterval.Text, out intDelayMillisecs))
                {
                    MessageBox.Show("Please enter a numeric value");
                    txtInterval.Focus();
                    return;
                }
                intDelayMillisecs = intDelayMillisecs * 1000;
            }

            if (txtLoopCnt.Text.Length > 0)
            {
                if (!int.TryParse(txtLoopCnt.Text, out intLoopCnt))
                {
                    MessageBox.Show("Please enter a numeric value");
                    txtLoopCnt.Focus();
                    return;
                }
            }

            CalcParamsEntity CalcParams = new CalcParamsEntity();
            CalcParams.intDelayMilliseconds = intDelayMillisecs;
            CalcParams.intLoopCnt = intLoopCnt;
            CalcParams.strIndexCode = strIndexCode;

            CalcIndex = new IndexCalc(CalcParams);
            // Create the thread object, passing in the CalcIndex.IndexGenLoop method
            // via a ThreadStart delegate. This does not start the thread.
            thIndex = new Thread(new ThreadStart(CalcIndex.IndexGenLoop));
            thIndex.IsBackground = true; // this sets the thread so that it dies when the application is closed.

            // CalcIndex.inForm(this);

            // Start the thread
            thIndex.Start();
        }

        private void btnMktOpen_Click(object sender, EventArgs e)
        {
            StringBuilder sbQuery = null;

            sbQuery = new StringBuilder();

            // sql that will update database to set market to open.
            sbQuery.Append("Update XAO_INDEX_GAME.SYSTEM_STATUS set market_open_Flag = 'T',   ");
            sbQuery.Append(" market_open_timestamp = str_to_date('" + dtpMktOpen.Text.Trim() + "'");
            sbQuery.Append(",'%d-%b-%Y %H:%i:%s') where node_name = 'DOIP203' ");

            Console.WriteLine("sbQuery = " + sbQuery.ToString());


            try
            {
                // DataSet that will hold the returned results		
                int recCnt = ExecuteNonQryMySql(sbQuery.ToString());

                if (recCnt > 0)
                {
                    MessageBox.Show("Market set to Open.");
                }
                else // 
                {
                    MessageBox.Show("Something went wrong.");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error in btnMktOpen_Click : " + exp.Message);
            }

        }

        private int ExecuteNonQryMySql(string strSQL)
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
                return insertCnt;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (thIndex != null && thIndex.IsAlive)
                thIndex.Abort();
            this.Close();
        }


        public class IndexCalc
        {
            CalcParamsEntity lclParams;
            bool calcValues;
            string strClosePrice = string.Empty;
            string strLastPrice = string.Empty;
            frmIndexSimulator myForm;

            public IndexCalc(CalcParamsEntity par)
            {
                this.calcValues = true;
                this.lclParams = par;
            }

            public bool SetCalc(bool calc)
            {
                bool retVal = this.calcValues;

                this.calcValues = calc;

                return retVal;
            }

            //public void inForm(frmIndexSimulator formObj)
            //{
            //    myForm = formObj;
            //}

            public void IndexGenLoop()
            {
                int intLoopCnt = lclParams.intLoopCnt;
                int intDelayMillisecs = lclParams.intDelayMilliseconds;
                string strIndexCode = lclParams.strIndexCode;

                if (intLoopCnt > 0)
                {
                    for (int i = 0; i < intLoopCnt; i++)
                    {
                        if (this.calcValues)
                        {
                            GenerateIndexValue(strIndexCode);
                        }
                        else
                        {
                            Console.WriteLine("No calc performed");
                        }
                        //txtLoopNum.Text = Convert.ToString(i + 1);
                        System.Threading.Thread.Sleep(intDelayMillisecs);
                    }
                }
            }


            private void GenerateIndexValue(string strIndexCode)
            {
                // ResponseMessage RespObj = new ResponseMessage();
                double dblRandNum = 0;
                double dblClosePrice = 0;
                // string strLastPrice = string.Empty;
                // string strClosePrice = string.Empty;

                Random RandNum = new Random();
                double dblLow = 600000;
                dblRandNum = dblLow + (RandNum.NextDouble() * 500);
                strLastPrice = dblRandNum.ToString("0.0");
                //txtIndexValue.Text = strLastPrice;
                Random rndClose = new Random();
                dblLow = -5000;
                dblClosePrice = dblLow + (rndClose.NextDouble() * 10000);
                strClosePrice = dblClosePrice.ToString("0.0");
                // txtIndexMove.Text = strClosePrice;
                // this.Refresh();
                string strReturn = string.Empty;

                try
                {
                    // myForm.txtIndexValue.Text = strLastPrice;
                    // myForm.txtIndexMove.Text = strClosePrice;
                    // myForm.Refresh();

                    strReturn = SecurityMasterStore.FnUpsertSecurityMaster(strIndexCode, strClosePrice, strLastPrice);

                    /*                    if (!RespObj.blnSuccess)
                                        {

                                            MessageBox.Show("Error saving Pick. Problem was : " + RespObj.OperationMessage);
                                        }
                                        else
                                        {
                                            //MessageBox.Show("Index successfully entered!", CommonStuff.cntAppName);
                                        }  */

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error in FrmIndexSimulator.GenerateIndexValue : " + exp.Message);
                    //this.Close();
                }
            }
        }

        private void btnCloseMkt_Click(object sender, EventArgs e)
        {
            StringBuilder sbQuery = null;

            sbQuery = new StringBuilder();

            sbQuery.Append("Update XAO_INDEX_GAME.SYSTEM_STATUS set market_open_Flag = 'F',   ");
            sbQuery.Append(" market_close_timestamp = str_to_date('" +  dtpCloseMkt.Text.Trim() + "'");
            sbQuery.Append(",'%d-%b-%Y %H:%i:%s') where node_name = 'DOIP203' ");

            Console.WriteLine("sbQuery = " + sbQuery.ToString());


            try
            {
                // DataSet that will hold the returned results		
                int recCnt = ExecuteNonQryMySql(sbQuery.ToString());


                if (recCnt > 0)
                {
                    MessageBox.Show("Market set to Close.");
                }
                else // 
                {
                    MessageBox.Show("Something went wrong.");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error in btnCloseMkt_Click : " + exp.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CalcIndex.SetCalc(false);
            MessageBox.Show("Index Stimulator has been paused.");
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            CalcIndex.SetCalc(true);
            MessageBox.Show("Index Stimulator has been resumed.");
        }
    }
}
