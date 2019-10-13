using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TheRoot
{
    public partial class Admin : Form
    {
        public Admin(String nombre)
        {
            InitializeComponent();
            lblmensajeAdmin.Text = nombre;
        }

        SqlConnection conexion = new SqlConnection(
         ConfigurationManager.ConnectionStrings["TheRoot.Properties.Settings.therootConnectionString"].ConnectionString

         );

        public static string id;
        public static string nombre;
        public static string usuario;
        public static string pass;
        public static string tipo;

        // SqlConnection Connexion = BDConexion.ObtenerConexion();

        //@"Data Source= A19A16538; Initial Catalog = theroot; Integrated Security = true"
        //SqlConnection conexion = new SqlConnection(@"Data Source= A19A16538; Initial Catalog = theroot; Integrated Security = true");
        SqlCommand consulta;
        SqlDataAdapter adapter;
        DataSet dt;
        DataTable tb;
        public void Datos()
        {

            //Connexion.Open();
             conexion.Open();
           // BDConexion.ObtenerConexion().Open();
            string ComandoTxt = "Select * From Usuarios";

            adapter = new SqlDataAdapter(ComandoTxt, conexion);
            dt = new DataSet();
            dt.Reset();
            adapter.Fill(dt);
            tb = dt.Tables[0];
            GridView.Refresh();

            GridView.DataSource = tb;
            conexion.Close();

        }

        //LIMPIAR CAMPOS

        private void LimpiarCampos()
        {
            txtNom.Text = string.Empty;
            txtUsu.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtTipo.Text = string.Empty;

        }
        // REGISTRAR

        private void Admin_Load(object sender, EventArgs e)
        {
            Datos();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {

            if (txtNom.Text == "")
            {

                txtNom.Text = "Llene los campos";


            }
            else
                if (txtUsu.Text == "")
            {

                txtUsu.Text = "Llene los campos";


            }
            else
                    if (txtPass.Text == "")
            {

                txtPass.Text = "Llene los campos";


            }
            else
                        if (txtTipo.Text == "")
            {

                txtTipo.Text = "Llene los campos";


            }
            else
            {
                conexion.Open();

                consulta = new SqlCommand("INSERT INTO Usuarios (nombre, usuario, pass, tipo) VALUES('" + txtNom.Text + "', '" + txtUsu.Text + "', '" + txtPass.Text + "', '" + txtTipo.Text + "')", conexion);
                consulta.ExecuteNonQuery();

                conexion.Close();
                Datos();
                LimpiarCampos();



            }
        }
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            id = GridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
            nombre = GridView.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            usuario = GridView.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
            pass = GridView.Rows[e.RowIndex].Cells["pass"].Value.ToString();
            tipo = GridView.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
            // txtID.Text = GridView.SelectedCells[0].Value.ToString();

        }
      
      

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {

                txtNom.Text = "Llene los campos";


            }
            else
               if (txtUsu.Text == "")
            {

                txtUsu.Text = "Llene los campos";


            }
            else
                   if (txtPass.Text == "")
            {

                txtPass.Text = "Llene los campos";


            }
            else
                       if (txtTipo.Text == "")
            {

                txtTipo.Text = "Llene los campos";


            }
            else
            {
                conexion.Open();


                consulta = new SqlCommand("UPDATE Usuarios SET nombre='" + txtNom.Text + "', " +
                "usuario='" + txtUsu.Text + "'" + ", pass='" + txtPass.Text + "', tipo='" +
                txtTipo.Text + "' WHERE id = '" + txtID.Text + "'", conexion);
                consulta.ExecuteNonQuery();
                conexion.Close();
                Datos();
                LimpiarCampos();

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            conexion.Open();

            consulta = new SqlCommand("DELETE FROM Usuarios WHERE id ='" + txtID.Text + "'", conexion);
            consulta.ExecuteNonQuery();
            conexion.Close();
            Datos();
            LimpiarCampos();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerraSession_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void GridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
                GridView.CurrentRow.Selected = true;
                txtID.Text = GridView.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                txtNom.Text= GridView.Rows[e.RowIndex].Cells["nombre"].FormattedValue.ToString();
                txtUsu.Text= GridView.Rows[e.RowIndex].Cells["usuario"].FormattedValue.ToString();
                txtPass.Text= GridView.Rows[e.RowIndex].Cells["pass"].FormattedValue.ToString();
                txtTipo.Text= GridView.Rows[e.RowIndex].Cells["tipo"].FormattedValue.ToString();
            }
        }
    }
    }
