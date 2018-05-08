using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.Mysql.DAL
{
    public class MySqlHelper
    {
        private static readonly string connectionString = "server=localhost;port=3306;user=root;password=libaoping; database=jucheapcore;";
        MySqlConnection conn = new MySqlConnection(connectionString);
        //返回受影响的行数
        public static int ExecuteNonQuery(string sqlStr, params MySqlParameter[] paras)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = sqlStr;
                    //是否需要对参数有无进行判断
                    cmd.Parameters.AddRange(paras);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        //返回第一行的第一列
        public static object ExecuteScalar(string sqlStr, params MySqlParameter[] paras)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(paras);
                    return cmd.ExecuteScalar();
                }
            }

        }
        //使用DataReader但是需要close,没问题。
        public static DataTable ExecuteDataTable(string sqlStr, params MySqlParameter[] paras)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(paras);
                    DataTable dt = new DataTable();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();                  
                    return dt;
                }
            }

        }

    }
}
