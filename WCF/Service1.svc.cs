using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
       
        public Resultado Suma()
        {

            Resultado resultado = new Resultado();

            //MySqlConnection conectar = new MySqlConnection();
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=bj_gimnasio;Persist Security Info=True;User ID=usuario;Password=Solaris2014;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            conectar.Open();

            string query = "select STRNOMBREUSUARIO, STRCONTRASENA, STRNOMBRE, STRROL from bj.Usuario";


            SqlCommand cmd = new SqlCommand(query, conectar);

            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable dt = new DataTable();


            dt.Load(dataReader);

            List<ArrayList> rows = new List<ArrayList>();
            ArrayList row = null;

            foreach (DataRow row1 in dt.Rows)
            {
                row = new ArrayList();

                for (int i = 0; i != row1.ItemArray.Length; i++)
                {
                    row.Add(row1.ItemArray.GetValue(i));
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;

        }

        public Resultado Login(String a, String b)
        {

            Resultado resultado = new Resultado();

           
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=bj_gimnasio;Persist Security Info=True;User ID=usuario;Password=Solaris2014;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            conectar.Open();        

            SqlCommand cmd = new SqlCommand("bj.usp_login", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@user", SqlDbType.VarChar);
            cmd.Parameters.Add("@password", SqlDbType.VarChar);

            cmd.Parameters["@user"].Value = a;
            cmd.Parameters["@password"].Value = b;

            cmd.ExecuteNonQuery();

            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable dt = new DataTable();


            dt.Load(dataReader);

            List<ArrayList> rows = new List<ArrayList>();
            ArrayList row = null;

            foreach (DataRow row1 in dt.Rows)
            {
                row = new ArrayList();

                for (int i = 0; i != row1.ItemArray.Length; i++)
                {
                    row.Add(row1.ItemArray.GetValue(i));
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;
        }

        public Resultado Horario(string valor)
        {

            Resultado resultado = new Resultado();

            //MySqlConnection conectar = new MySqlConnection();
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=bj_gimnasio;Persist Security Info=True;User ID=usuario;Password=Solaris2014;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            conectar.Open();        

            SqlCommand cmd = new SqlCommand("bj.usp_get_horario", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VALOR", SqlDbType.VarChar);

            cmd.Parameters["@VALOR"].Value = valor;

            cmd.ExecuteNonQuery();

            SqlDataReader dataReader = cmd.ExecuteReader();

            DataTable dt = new DataTable();


            dt.Load(dataReader);

            List<ArrayList> rows = new List<ArrayList>();
            ArrayList row = null;

            foreach (DataRow row1 in dt.Rows)
            {
                row = new ArrayList();

                for (int i = 0; i != row1.ItemArray.Length; i++)
                {
                    row.Add(row1.ItemArray.GetValue(i));
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;
        }
    
    }
}
