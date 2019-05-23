using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_clases_curso_sql
{
    public class Clientes:Conexion
    {
        public Boolean hola()
        {
            return true;
        }
        public Boolean guardarClientes()
        {
            return true;
        }
        public Boolean guaClientes(string nombre, string apePaterno, string apeMaterno, 
            int edad, double telefono, string email, string fechaNacimiento, string fechaHoraIngreso,
            string horaDesayuno, string sexo)
        {
            SqlCommand insertar = new SqlCommand("guaClientes", cadenaConexion);
            insertar.CommandType = CommandType.StoredProcedure;
            insertar.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            insertar.Parameters.Add("@apePaterno", SqlDbType.NVarChar).Value = apePaterno;
            insertar.Parameters.Add("@apeMAterno", SqlDbType.NVarChar).Value = apeMaterno;
            insertar.Parameters.Add("@edad", SqlDbType.Int).Value = edad;
            insertar.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
            insertar.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            insertar.Parameters.Add("@fechaNacimiento", SqlDbType.NVarChar).Value = fechaNacimiento;
            insertar.Parameters.Add("@fechaHoraIngreso", SqlDbType.NVarChar).Value = fechaHoraIngreso;
            insertar.Parameters.Add("@horaDesayuno", SqlDbType.NVarChar).Value = horaDesayuno;
            insertar.Parameters.Add("@sexo", SqlDbType.NChar).Value = sexo;
            /*como ya agregue todos mis parametros, ahora solo lo voy a ejecutar este comando*/
            try
            {
                cadenaConexion.Open();
                insertar.ExecuteNonQuery();
                cadenaConexion.Close();
                return true;
            }
            catch (Exception)
            {
                cadenaConexion.Close();
                return false;
            }
        }
        //función que traera todas las categorias y se mostraran un datagrid
        public DataSet busClientes()
        {
            //comando para ejecutar busqueda con el procedimiento almacenado
            SqlCommand buscar = new SqlCommand("selClientes", cadenaConexion);
            buscar.CommandType = CommandType.StoredProcedure;
            //adaptador donde se almacenaran los datos encontrados
            SqlDataAdapter traer = new SqlDataAdapter();
            traer.SelectCommand = buscar;
            //dataset donde se alamcenara la informacion
            DataSet conjunto = new DataSet();
            try
            {
                cadenaConexion.Open();
                traer.Fill(conjunto, "Datos Generales");
                cadenaConexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                cadenaConexion.Close();
                return conjunto;
            }

            
        }

        public DataSet busIDClientes(int ID)
        {
            //comando para ejecutar la busqueda con el sp
            SqlCommand buscarID = new SqlCommand("selIDCliente", cadenaConexion);
            buscarID.CommandType = CommandType.StoredProcedure;
            //genero adaptador donde se almacenan los datos encontrados
            SqlDataAdapter traer = new SqlDataAdapter();
            traer.SelectCommand = buscarID;
            //dataset donde se almacenanrá la información
            DataSet conjunto = new DataSet();
            try
            {
                buscarID.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cadenaConexion.Open();
                traer.Fill(conjunto, "Datos Generales");
                cadenaConexion.Close();
                return conjunto;
            }
            catch (Exception)
            {
                cadenaConexion.Close();
                return conjunto;
            }
        }
        public Boolean actClientes(int id, string nombre, string apePaterno, string apeMaterno,
            int edad, double telefono, string email, string fechaNacimiento, string fechaHoraIngreso,
            string horaDesayuno, string sexo)
        {
            SqlCommand actualizar = new SqlCommand("actTodosClientes", cadenaConexion);
            actualizar.CommandType = CommandType.StoredProcedure;
            actualizar.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            actualizar.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            actualizar.Parameters.Add("@apePaterno", SqlDbType.NVarChar).Value = apePaterno;
            actualizar.Parameters.Add("@apeMAterno", SqlDbType.NVarChar).Value = apeMaterno;
            actualizar.Parameters.Add("@edad", SqlDbType.Int).Value = edad;
            actualizar.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
            actualizar.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            actualizar.Parameters.Add("@fechaNacimiento", SqlDbType.NVarChar).Value = fechaNacimiento;
            actualizar.Parameters.Add("@fechaHoraIngreso", SqlDbType.NVarChar).Value = fechaHoraIngreso;
            actualizar.Parameters.Add("@horaDesayuno", SqlDbType.NVarChar).Value = horaDesayuno;
            actualizar.Parameters.Add("@sexo", SqlDbType.NChar).Value = sexo;
            try
            {
                cadenaConexion.Open();
                actualizar.ExecuteNonQuery();
                cadenaConexion.Close();
                return true;
            }
            catch (Exception)
            {
                cadenaConexion.Close();
                return false;
            }
        }
        public Boolean eliClientes(int ID)
        {
            SqlCommand eliminar = new SqlCommand("delIDClientes", cadenaConexion);
            eliminar.CommandType = CommandType.StoredProcedure;
            eliminar.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                cadenaConexion.Open();
                eliminar.ExecuteNonQuery();
                cadenaConexion.Close();
                return true;
            }
            catch (Exception)
            {
                cadenaConexion.Close();
                return false;
            }
        }
    }
}
