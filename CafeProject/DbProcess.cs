using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeProject
{
    public class DbProcess
    {
        private string dbName = "CafeProject";
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        /// <summary>
        /// parametresiz constructor(boş kurucu method)
        /// </summary>
        public DbProcess()
        {

        }
        /// <summary>
        /// parametreli constructor (parametreli kurucu method)
        /// </summary>
        /// <param name="dbName">Bağlanılacak olan veritabanının ismini alır.</param>
        public DbProcess(string dbName)
        {
            this.dbName = dbName;
        }
        /// <summary>
        /// Veritabanına olan bağlantıyı açmak için kullanılan method.
        /// </summary>
        public SqlConnection dbConnect()
        {
            string connectionInfo = "Data Source=.;Initial Catalog=" + dbName + ";Integrated Security=true";
            try
            {
                con = new SqlConnection(connectionInfo);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlantı hatası: " + ex.Message);
            }
            return con;

        }
        /// <summary>
        /// farklı serverda bulunan veri tabanı için bağlantıyı açar.
        /// </summary>
        /// <param name="ip">veritabanının bulunduğu serverın ip adresi</param>
        public SqlConnection dbConnect(string ip)
        {
            string connectionInfo = "DataSource=" + ip + ";" + "Initial Catalog=" + dbName + "Integrated Security=true";

            try
            {
                using (con = new SqlConnection(connectionInfo))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlantı hatası: " + ex.Message);
            }
            return con;
        }
        /// <summary>
        /// açık olan veritabanı bağlantısını kapatır.
        /// </summary>
        public void dbClose()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        /// <summary>
        /// Veritabanından DataReader ile veri okumak için kullanılan method.
        /// </summary>
        /// <param name="query">veritabanından değer okumak için yollanması gereken sorgu</param>
        /// <returns></returns>
        public SqlDataReader getData(string query)
        {
            SqlCommand com = new SqlCommand(query, con);
            dr = com.ExecuteReader();
            return dr;
        }
        /// <summary>
        /// Veritabanından DataAdapter le veri okumak için kullanılan method.
        /// </summary>
        /// <param name="query">veritabanından değer okumak için yollanması gereken sorgu</param>
        /// <returns></returns>
        public SqlDataAdapter getData1(string query)
        {
            SqlCommand com = new SqlCommand(query, con);
            dt = new DataTable();
            dt.Load(com.ExecuteReader());
            da.Fill(dt);
            return da;
        }
        /// <summary>
        /// DataReader kullanarak prosedür ile parametresiz veri çekmek için kullanılan method.
/// </summary>
/// <param name="procName">prosedürün adı</param>
/// <returns></returns>
        public SqlDataReader procExecRead(string procName)
        {
            SqlCommand com = new SqlCommand(procName);
            com.CommandType = CommandType.StoredProcedure;
            dr = com.ExecuteReader();
            return dr;        
        }
        /// <summary>
        /// dataAdapter kullanarak prosedür ile parametresiz veri çekmek için kullanılan method.
        /// </summary>
        /// <param name="procName">prosedür adı</param>
        /// <returns></returns>
        public SqlDataAdapter procExecRead1(string procName)
        {
            dt = new DataTable();
            SqlCommand com = new SqlCommand(procName, con);
            com.CommandType = CommandType.StoredProcedure;
            dr = com.ExecuteReader();
            dt.Load(dr);
            da.Fill(dt);          
            return da;
        }
    /// <summary>
    /// girilen bilgiyi şifrelemek için kullanılan method
    /// </summary>
    /// <param name="stringToEncrypt">şifrelenicek girdi</param>
    /// <returns></returns>
        public static string md5Encrypt(string stringToEncrypt) {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(stringToEncrypt);
            array = md5.ComputeHash(array);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in array) {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString(); 
        }


    }
}
