using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CenterFlowers
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            var Empleado = new LoginMetodo();
            var usuario = txtUser.Text;
            var contraseña = txtPass.Text;
            dt = Empleado.ConsultarLogin(usuario, contraseña); // Lleno el datatable con el metodo Consultarlogin con los parametros definidos, que son las variables puestas arriba que tienen el valor del textbox!.

            if (dt.Rows.Count ==1)
            {
                
                MessageBox.Show("Ingreso correcto");
                this.Hide();
                frmUsuario ofrmUsuario = new frmUsuario();              
                ofrmUsuario.Show();
                // Si el ingreso es correcto, mostrar el menu dependiendo si es Administrador,Encargado o vendedor.
                //Para eso tengo que comparar el DNI, del usuario que ingreso, con el ID_Perfil, y preguntar cual es el PERMISO.
                //Si  oPerfil.Permiso = Administrador Del usuario ingresado, cuyo ID perfil es = al DNI.


            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta.");

            }


             
        }
    }
}
