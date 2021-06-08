using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CenterFlowers
{
    class LoginMetodo : conexion
    {
        public DataTable ConsultarLogin(string Usuario, string contraseña)
        {
            string query = "Select ID_dni, contraseña from Usuario where ID_dni = '" + Usuario + "' and contraseña ='" + contraseña + "'";
            var da = new SqlDataAdapter(query, conectar());
            var ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
        }

        public Boolean AgregarUsuario(Usuarios Usu, Perfil_usuario perfil, Domicilios Dom, Telefonos Tele, Emails Mail)
        {
            try
            {
                var query = "INSERT INTO Usuario(ID_dni,Contraseña,Nombre,Apellido) Values ('" + Usu.ID_dni + "','" + Usu.contraseña + "','" + Usu.Nombre + "','" + Usu.Apellido + "')" +
                            "Insert into Perfil_Usuario(Id_perfil,Descripcion_perfil,permiso,Tipo_vendedor) Values ('" + perfil.Id_perfil + "','" + perfil.Descripcion_Perfil + "','" + perfil.permiso + "','" + perfil.Tipo_Vendedor + "')" +
                            "Insert into Domicilios(Calle,Altura,Piso,Localidad,Provincia,Pais,ID_dni)Values ('" + Dom.Calle + "','" + Dom.Altura + "','" + Dom.Piso + "','" + Dom.Localidad + "','" + Dom.Provincia + "','" + Dom.Pais + "','" + Dom.Id_dni + "')" +
                            "Insert into Telefonos(Fijo,Celular,Id_dni)Values ('" + Tele.Fijo + "','" + Tele.Celular + "','" + Tele.ID_dni + "')" +
                            "Insert into Emails(Personal,Laboral,id_dni_usuario)Values('" + Mail.Personal + "','" + Mail.Laboral + "','" + Mail.Id_dni_usuario + "')";
                SqlCommand Comando = new SqlCommand(query, conectar());
                Comando.ExecuteNonQuery();// Lo que ejecuto no es una consulta, es un COMANDO. (Comandos: Update, Insert y delete.)

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public void ModificarUsuario(Usuarios Usu, Perfil_usuario perfil, Domicilios Dom, Telefonos Tele, Emails Mail)     
        {//Clase 9 minuto 28.
            try
            {
                var query = "";
            }
            catch
            {

            }
        }

        public Boolean borrarUsuario(string DNI)
        {   
            try
            {
                var Query = "delete from Perfil_Usuario where (Id_perfil='" + DNI + "')" +
                            "delete from Domicilios where (Id_dni='" + DNI + "')" +
                            "delete from Telefonos where (ID_dni='" + DNI + "')" +
                            "delete from Emails where (id_dni_usuario ='" + DNI + "')" +
                            "delete from usuario where (ID_dni ='" + DNI + "')";
                SqlCommand comando = new SqlCommand(Query,conectar());
                var i = comando.ExecuteNonQuery(); // Si es igual al comando, es porque borro
                if (i == 0) return false;// Si la variable I es 0 es porque no me borro ninguna fila. Por eso regresa false.
                return true;
            }
            catch(Exception Ex)
            {
                return false;
            }
        }







    }
}
