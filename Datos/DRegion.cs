using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
    public class DRegion
    {
        private string connectionString= "Data Source=LAB707-07\\SQLEXPRESS02;Initial Catalog=dbproduct;Integrated Security=True;";

       
        public   List<Product> Listar()
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Product> productos = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_SeleccionProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@Description";
                //param.SqlDbType = SqlDbType.VarChar;
                //param.Value = description;

                //command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                productos = new List<Product>();


                while (reader.Read())
                {

                    Product producto = new Product();
                    producto.IdProducto = (int)reader["id"];
                    producto.Nombre = reader["nombre"].ToString();
                    producto.Precio = Convert.ToDouble(reader["precio"]);

                    productos.Add(producto);

                }

                connection.Close();

                //Muestro la información
                return productos;


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            {
                connection = null;
                command = null;
                param = null;
                productos = null;

            }


        }

        public void Insertar(Product producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("USP_InsertarProducto", connection); // Nombre del procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado                
                    command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
