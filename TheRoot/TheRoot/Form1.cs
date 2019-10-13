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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["TheRoot.Properties.Settings.therootConnectionString"].ConnectionString

        );
        //BDConexion Connexion = new BDConexion();
        //SqlConnection con = new SqlConnection(@"Data Source = A19A16538; Initial Catalog =theroot; Integrated Security = True");

        public void Logear(String Usuario, String Password)
        {
            try
            {
                //Connexion.Open();
                //BDConexion.ObtenerConexion().Open();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select nombre, tipo from Usuarios where usuario = @usuario and pass = @pass ", con);
                cmd.Parameters.AddWithValue("Usuario", Usuario);
                cmd.Parameters.AddWithValue("pass", Password);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();

                    if (dt.Rows[0][1].ToString() == "Admin")
                    {
                        new Admin(dt.Rows[0][0].ToString()).Show();

                    }
                    else if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        new Usuario(dt.Rows[0][0].ToString()).Show();
                    }

                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña son incorrectos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               // Connexion.Close();
                 con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Logear(this.txtUsu.Text, this.txtPass.Text);
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
