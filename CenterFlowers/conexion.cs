using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CenterFlowers
{
   internal class conexion
    {
        private SqlConnection Sqlconexion = new SqlConnection();
        private string ConsultaConexion = "Data source=DESKTOP-OJTKK35\\SQLEXPRESS;Integrated Security=SSPI;Initial catalog=Center.flowers";

        public SqlConnection conectar()
        {
            try // Se ejecuta todo esto si es que no hay error.
            {
                Sqlconexion = new SqlConnection(ConsultaConexion);
                if (Sqlconexion.State.Equals(ConnectionState.Open))// Si sqlconexion tiene un estado abierto, se cierra.
                {
                    Sqlconexion.Close();
                }
                else 
                {
                    Sqlconexion.Open();
                }
            }
            catch(Exception Ex) // Si se produce un error, mostra el error.
            {
                MessageBox.Show(Ex.Message);
            }

            return Sqlconexion;
        }




    }
}
