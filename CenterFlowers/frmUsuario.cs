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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Las variables de tipo VAR se adaptan al tipo de variable que definimos Ejemplo dataset, datatable.
            // Variable Dataset: Variable en memoria que guarda una estructura de datos que nosotros le vayamos aponer a la variable. Guarda mas tablas y sus relaciones
            //Datatable: Guarda una sola tabla
            var ds = new DataSet();
            var dt = new DataTable();
            // Declaro una variable que sea de clase UsuarioMetodos, 
            var UM = new UsuariosMetodos();
            dt = UM.Consultar();// la tabla que voy a cargar es la de usuariometodos
            if (dt.Rows.Count != 0)// Si la cantidad de filas es diferente de 0 (vino mas de una fila ), lleno el datagridview  con los datos que vienen del datatable
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Confirmar la grabacion", "Grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            var usu = new Usuarios();
            var perfil = new Perfil_usuario();
            var dom = new Domicilios();
            var tele = new Telefonos();
            var mail = new Emails();
            if ((resp == DialogResult.Yes))
            {

                usu.ID_dni = txtDNI.Text;//Conector de tablas.
                usu.contraseña = txtContraseña.Text;
                usu.Nombre = txtNombre.Text;
                usu.Apellido = txtApellido.Text;
                perfil.Id_perfil = txtDNI.Text;//Conector de tablas.
                usu.Estado = cboEstado.Text;
                perfil.permiso = cboPermiso.Text;
                perfil.Tipo_Vendedor = cboVendedor.Text;
                dom.Calle = txtCalle.Text;
                dom.Altura = txtAltura.Text;
                dom.Piso = txtPiso.Text;
                dom.Pais = txtPais.Text;
                dom.Provincia = txtProvincia.Text;
                dom.Localidad = txtLocalidad.Text;
                dom.Id_dni = txtDNI.Text;//Conector de tablas.
                tele.Fijo = txtTFijo.Text;
                tele.Celular = txtTCelular.Text;
                tele.ID_dni = txtDNI.Text; //Conector de tablas.
                mail.Id_dni_usuario = txtDNI.Text;//Conector de tablas.
                mail.Personal = txtEPersonal.Text;
                mail.Laboral = txtELaboral.Text;

                //Agregar si los campos DNI, MAIL, TELEFONOS, PERMISO, ESTAN VACIOS QUE LOS LLENE PARA CREAR EL USUARIO CLASE 7 CELIZ.

                var UsusMetod = new LoginMetodo(); // creo un objeto de la clase loginmetodo, que es donde estan las consultas.
                Boolean Agregar = UsusMetod.AgregarUsuario(usu, perfil, dom, tele, mail);

                if (Agregar == false)
                {
                    MessageBox.Show("Error: No se pudo agregar el usuario");
                }
                else
                {
                    MessageBox.Show("Usuario agregado");
                }

            }






        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Confirmar la eliminacion","Eliminar", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if ((respuesta== DialogResult.Yes))
            {
                var UsuMetodos = new LoginMetodo();
                bool borro = UsuMetodos.borrarUsuario(txtDNI.Text);
                if (borro == false)
                {
                    MessageBox.Show("Error para borrar", "Verifique");
                }
                else
                {
                    MessageBox.Show("Borrado con exito");
                }
            }




        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Confirmar cambios en el usuario", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            var usu = new Usuarios();
            var perfil = new Perfil_usuario();
            var dom = new Domicilios();
            var tele = new Telefonos();
            var mail = new Emails();
            if ((respuesta == DialogResult.Yes))
            {
                usu.ID_dni = txtDNI.Text;//Conector de tablas.
                usu.contraseña = txtContraseña.Text;
                usu.Nombre = txtNombre.Text;
                usu.Apellido = txtApellido.Text;
                usu.Estado = cboEstado.Text;
                perfil.Id_perfil = txtDNI.Text;//Conector de tablas.
                usu.Estado = cboEstado.Text;
                perfil.permiso = cboPermiso.Text;
                perfil.Tipo_Vendedor = cboVendedor.Text;
                dom.Calle = txtCalle.Text;
                dom.Altura = txtAltura.Text;
                dom.Piso = txtPiso.Text;
                dom.Pais = txtPais.Text;
                dom.Provincia = txtProvincia.Text;
                dom.Localidad = txtLocalidad.Text;
                dom.Id_dni = txtDNI.Text;//Conector de tablas.
                tele.Fijo = txtTFijo.Text;
                tele.Celular = txtTCelular.Text;
                tele.ID_dni = txtDNI.Text; //Conector de tablas.
                mail.Id_dni_usuario = txtDNI.Text;//Conector de tablas.
                mail.Personal = txtEPersonal.Text;
                mail.Laboral = txtELaboral.Text;
                var UsuMetodos = new LoginMetodo();
                UsuMetodos.ModificarUsuario(usu,perfil,dom,tele,mail);               
                }
                else
                {
                    
                    MessageBox.Show("Error para borrar", "Verifique");
                }
            }
       
        private void btnSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtDNI.Text = dataGridView1.CurrentRow.Cells["ID_dni"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();              
                txtContraseña.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
                cboPermiso.Text = dataGridView1.CurrentRow.Cells["Permiso"].Value.ToString();
                cboVendedor.Text = dataGridView1.CurrentRow.Cells["Tipo_vendedor"].Value.ToString();
                txtAltura.Text = dataGridView1.CurrentRow.Cells["Altura"].Value.ToString();
                txtCalle.Text = dataGridView1.CurrentRow.Cells["Calle"].Value.ToString();
                txtPiso.Text = dataGridView1.CurrentRow.Cells["Piso"].Value.ToString();
                txtLocalidad.Text = dataGridView1.CurrentRow.Cells["Localidad"].Value.ToString();
                txtProvincia.Text = dataGridView1.CurrentRow.Cells["Provincia"].Value.ToString();
                txtPais.Text = dataGridView1.CurrentRow.Cells["Pais"].Value.ToString();
                txtELaboral.Text = dataGridView1.CurrentRow.Cells["Laboral"].Value.ToString();
                txtEPersonal.Text = dataGridView1.CurrentRow.Cells["Personal"].Value.ToString();
                txtTFijo.Text = dataGridView1.CurrentRow.Cells["Fijo"].Value.ToString();
                txtTCelular.Text = dataGridView1.CurrentRow.Cells["Celular"].Value.ToString();
                cboEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
            }
        }
    }
}
