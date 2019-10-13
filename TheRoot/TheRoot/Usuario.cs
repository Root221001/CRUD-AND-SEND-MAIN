using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheRoot
{
    public partial class Usuario : Form
    {
        public Usuario(String nombre)
        {
            InitializeComponent();
            lblmensajeUsuario.Text = nombre;
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void lblmensajeUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if ( tvNombre.Text== "")
            {

                MessageBox.Show("Llene el nombre");


            }
            else
              if (tvDe.Text == "")
            {

                MessageBox.Show("Llene el remitente");


            }
            else
                  if ( tvContras.Text == "")
            {
                MessageBox.Show("Llene la contraseña");
               

            }
            else
                      if (tvParaD.Text == "")
            {
                MessageBox.Show("Llene el destinatario");
                


            }
            else
                      if (tvAsusnto.Text == "")
            {
                MessageBox.Show("Llene el asunto");
                


            }
            else
                      if (tvContenido.Text == "")
            {
                MessageBox.Show("Llene el contenido");



            }
            else
            {

                using (SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587))
                {

                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential(tvDe.Text, tvContras.Text);
                    MailMessage mensaje = new MailMessage(tvDe.Text, tvParaD.Text, tvAsusnto.Text, tvContenido.Text);

                    try
                    {
                        cliente.Send(mensaje);
                        MessageBox.Show("Enviado con Exito Gracias: " + tvNombre.Text);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);

                    }
                }

            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tvNombre.Text = "";
            tvDe.Text = "";
            tvParaD.Text = "";
            tvContras.Text = "";
            tvAsusnto.Text = "";
            tvContenido.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
