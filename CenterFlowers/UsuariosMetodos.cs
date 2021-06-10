using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CenterFlowers
{
    class UsuariosMetodos : conexion // el (:conexion) sirve para heredar el metodo  que esta en la CLASE conexion. 
    {
        public DataTable Consultar()
        {
            string Query = "Select Nombre,Apellido,usuario.ID_dni,Contraseña,Estado,Permiso,Tipo_Vendedor, Calle,Altura,Piso,Localidad,Provincia,Pais,Celular,Fijo,Laboral,Personal from Usuario,Perfil_usuario, domicilios,Telefonos,Emails where Usuario.ID_dni = Perfil_usuario.Id_perfil and Usuario.ID_dni= Domicilios.Id_dni and Usuario.ID_dni = Telefonos.ID_dni and Usuario.ID_dni = Emails.Id_dni_usuario ";
            var da = new SqlDataAdapter(Query, conectar()); //conectar es el metodo heredado de la clase conexion. Que ese metodo es para conectar la base.
            var ds = new DataSet();
            da.Fill(ds);                // llenar el dataset con lo que tiene el data adapter, que seria la consulta y la conexion.
            DataTable dt = ds.Tables[0];// Al datatable lo lleno con el elemento de la primera fila.

            return dt;              //Devuelve el Datetable lleno con los datos de la consulta de SQL.


        }



    }
}
