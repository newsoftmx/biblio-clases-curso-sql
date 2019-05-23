using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_clases_curso_sql
{
    public class Conexion
    {
        //public SqlConnection cadenaConexion = new SqlConnection("Data Source=vibecohack\\SQLEXPRESS; Initial Catalog=curso_sql_newsoft; User ID=sa; Password=spartaco17;");
        public SqlConnection cadenaConexion = new SqlConnection("Data Source=vibeco_hack; Initial Catalog=curso_sql_newsoft; Integrated Security=true;");
        //public SqlConnection cadenaConexion = new SqlConnection("Data Source=vibeco_hack\\MSSQLSERVER; Initial Catalog=curso_sql_newsoft; Integrated Security=true;");
    }
}
