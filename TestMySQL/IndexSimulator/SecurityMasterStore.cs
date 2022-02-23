﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;



namespace IndexSimulator
{
    class SecurityMasterStore
    {
        public static string FnUpsertSecurityMaster(string strIndexCode, string strClosePrice, string strLastPrice)
        {
            // bool blnStatus = false;
            string myConnStr = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();

            string strReturn = string.Empty;

            // str_to_date('14/12/2007 00:00:00','%d/%m/%Y %H:%i:%s'),
            string strDateTime = DateTime.Now.ToString();
            //  string strDate = str_to_date('14/12/2007 00:00:00', '%d/%m/%Y %H:%i:%s');

            //using (MySqlConnection lconn = new MySqlConnection(myConnStr))
            //{

            //    lconn.Open();
            //    using (MySqlCommand cmd = new MySqlCommand())
            //    {
            //        cmd.Connection = lconn;
            //        cmd.CommandText = "XAO_INDEX_GAME.store_security_master"; // The name of the Stored Proc
            //        cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc

            //        // Two parameters below. An IN and an OUT (myNum and theProduct, respectively)
            //        cmd.Parameters.AddWithValue("@in_asx_code", strIndexCode); // lazy, not specifying ParameterDirection.Input;
            //        cmd.Parameters.AddWithValue("@in_security_description", "");
            //        cmd.Parameters.AddWithValue("@in_security_type_code", "");
            //        cmd.Parameters.AddWithValue("@in_last_price", strLastPrice);
            //        cmd.Parameters.AddWithValue("@in_close_price", strClosePrice);
            //        cmd.Parameters.AddWithValue("@in_asxcodeattribute", "");
            //        cmd.Parameters.AddWithValue("@in_receipt_datetime", "");

            //        cmd.Parameters.AddWithValue("@ret_status", MySqlDbType.String);

            //        cmd.Parameters["@ret_status"].Direction = ParameterDirection.Output; // from System.Data

            //        cmd.ExecuteNonQuery(); // let it rip
            //        Object obj = cmd.Parameters["@ret_status"].Value;
            //        // strReturn = (string)obj;    // more useful datatype
            //    }

            //}


            using (var connection = new MySqlConnection(myConnStr))
            {
                MySqlCommand command = new MySqlCommand("XAO_INDEX_GAME.store_security_master", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new MySqlParameter("in_asx_code", strIndexCode));
                command.Parameters.Add(new MySqlParameter("in_security_description", ""));
                command.Parameters.Add(new MySqlParameter("in_security_type_code", ""));
                command.Parameters.Add(new MySqlParameter("in_last_price", strLastPrice));
                command.Parameters.Add(new MySqlParameter("in_close_price", strClosePrice));
                command.Parameters.Add(new MySqlParameter("in_asxcodeattribute", ""));
                command.Parameters.Add(new MySqlParameter("in_receipt_datetime", ""));

                command.Parameters.AddWithValue("@ret_status", MySqlDbType.String).Direction = ParameterDirection.Output;

                // var returnParameter = command.Parameters.Add("@ret_status", SqlDbType.Int);

                // returnParameter.Direction = ParameterDirection.ReturnValue;

                command.Connection.Open();
                var result = command.ExecuteNonQuery();
                command.Connection.Close();
            }


            return strReturn;
        }

    }
}
