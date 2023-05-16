using jguandinangos6.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jguandinangos6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentanaAct : ContentPage
    {
        public VentanaAct(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            string codigoE = codigo.ToString();
            string edadE = edad.ToString();
            txtCodigo.Text = codigoE;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edadE;

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.1.2/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                DisplayAlert("Alerta", "Dato Actualizado", "Salir");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Salir");

            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                byte[] res =client.UploadValues("http://192.168.1.2/moviles/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);
                var r = System.Text.ASCIIEncoding.UTF8.GetString(res);
                DisplayAlert("ALERTA", "usuario correctamente eliminado", "cerrar");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}