using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web;
using System.IO;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        // servicio para obtener rutina
        //int a = idUser

        public Resultado UpdatePerfil(int Id_Usuario, string Telefono, string Ocupacion, string Email)
        {
            // Conexión
            SqlConnection conectar = new SqlConnection();
            //conectar.ConnectionString = @"Data Source=localhost;Initial Catalog=bj_gimnasio;Integrated Security=True";
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
            conectar.Open();
            // Formar SP

            SqlCommand cmd = new SqlCommand("bj.usp_PostInfoUser", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@INT_NUMERO_CLIENTE", SqlDbType.VarChar); // parametros
            cmd.Parameters["@INT_NUMERO_CLIENTE"].Value = Id_Usuario;

            cmd.Parameters.Add("@STR_TELEFONO1", SqlDbType.VarChar); // parametros
            cmd.Parameters["@STR_TELEFONO1"].Value = Telefono;


            cmd.Parameters.Add("@STR_PROFESION", SqlDbType.VarChar); // parametros
            cmd.Parameters["@STR_PROFESION"].Value = Ocupacion;

            cmd.Parameters.Add("@STR_EMAIL", SqlDbType.VarChar); // parametros
            cmd.Parameters["@STR_EMAIL"].Value = Email;


            cmd.ExecuteNonQuery();

            Resultado resultado = new Resultado();

            List<ArrayList> rows = new List<ArrayList>();
            ArrayList row = new ArrayList();
            row.Add("Correcto");
            rows.Add(row);
            resultado.setResult(rows);
            return resultado;
        }
        //Id_Usuario, Telefono, Ocupacion,Email,Imagen
        public Resultado Rutina(int a)
        {
            //  info para JSON
            Resultado resultado = new Resultado();


            // Conexión
            SqlConnection conectar = new SqlConnection();
            //conectar.ConnectionString = @"Data Source=localhost;Initial Catalog=bj_gimnasio;Integrated Security=True";
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
            conectar.Open();

            // Formar SP

            SqlCommand cmd = new SqlCommand("bj.usp_ObtenerRutina", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@INT_NUMERO_CLIENTE", SqlDbType.VarChar); // parametros

            cmd.Parameters["@INT_NUMERO_CLIENTE"].Value = a;

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
                    if (!row1.IsNull(i))
                    {
                        string var = row1.ItemArray.GetValue(i).ToString();
                        row.Add(row1.ItemArray.GetValue(i).ToString());
                    }
                    else
                    {
                        row.Add(" ");
                    }
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;
       
       }

        // servicio para obtener Perfil d usuario 
        //int a = idUser
        public Resultado Perfil(int NUMERO_CLIENTE)
        {
            //  info para JSON
            Resultado resultado = new Resultado();

            // Conexión
            SqlConnection conectar = new SqlConnection();
            //conectar.ConnectionString = @"Data Source=localhost;Initial Catalog=bj_gimnasio;Integrated Security=True";
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
            conectar.Open();

            // Formar SP

            SqlCommand cmd = new SqlCommand("bj.usp_ObtenerPerfil", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@INT_NUMERO_CLIENTE", SqlDbType.Int); // parametros

            cmd.Parameters["@INT_NUMERO_CLIENTE"].Value = NUMERO_CLIENTE;
            
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
                    if (!row1.IsNull(i))
                    {
                        if (i == 4) {

                            var base64 = Convert.ToBase64String((byte[]) row1.ItemArray.GetValue(i));

                            row.Add(base64);
                        }
                        else { 
                        row.Add(row1.ItemArray.GetValue(i).ToString());
                        }
                    }
                    else
                    {
                        row.Add(" ");
                    }
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;

        }
        public Resultado Suma()
        {

            Resultado resultado = new Resultado();

            //MySqlConnection conectar = new MySqlConnection();
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
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
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
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
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
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
//// Método GetPago
        public Resultado GetPago(int Id_Usuario)
        {
            Resultado resultado = new Resultado();

            // Conexión
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
            conectar.Open();

            // Formar SP

            SqlCommand cmd = new SqlCommand("bj.usp_GetDiaPago", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@INT_NUMERO_CLIENTE", SqlDbType.Int); // parametros

            cmd.Parameters["@INT_NUMERO_CLIENTE"].Value = Id_Usuario;

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
                    if (!row1.IsNull(i))
                    {
                        string var = row1.ItemArray.GetValue(i).ToString();
                        row.Add(row1.ItemArray.GetValue(i).ToString());
                    }
                    else
                    {
                        row.Add(" ");
                    }
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;

        }

//// método getMedidas
        public Resultado GetMedidas(int Id_Usuario)
        {
            Resultado resultado = new Resultado();

            // Conexión
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
            conectar.Open();

            // Formar SP

            SqlCommand cmd = new SqlCommand("bj.usp_GetMedidas", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@INT_NUMERO_CLIENTE", SqlDbType.Int); // parametros

            cmd.Parameters["@INT_NUMERO_CLIENTE"].Value = Id_Usuario;

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
                    if (!row1.IsNull(i))
                    {
                        string var = row1.ItemArray.GetValue(i).ToString();
                        row.Add(row1.ItemArray.GetValue(i).ToString());
                    }
                    else
                    {
                        row.Add(" ");
                    }
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;

        }

        ////  GetNotificaciones
        public Resultado GetNotificaciones(int Id_Usuario)
        {
            //  info para JSON
            Resultado resultado = new Resultado();

            // Conexión
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = @"Data Source=hthzpk82kp.database.windows.net,1433;Initial Catalog=basedatos_bjgym;User ID=usuario@hthzpk82kp;Password=Solaris2014;Persist Security Info=True;TrustServerCertificate=True";
            conectar.Open();

            // Formar SP

            SqlCommand cmd = new SqlCommand("bj.usp_Notificaciones", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@INT_NUMERO_CLIENTE", SqlDbType.VarChar); // parametros

            cmd.Parameters["@INT_NUMERO_CLIENTE"].Value = Id_Usuario;

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
                    if (!row1.IsNull(i))
                    {
                        string var = row1.ItemArray.GetValue(i).ToString();
                        row.Add(row1.ItemArray.GetValue(i).ToString());
                    }
                    else
                    {
                        row.Add(" ");
                    }
                }
                rows.Add(row);
            }

            resultado.setResult(rows);

            return resultado;

        }
    
    }
}
