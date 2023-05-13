using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jguandinangos6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
        
            Navigation.PushAsync(new MainPage());
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                client.UploadValues("http://192.168.1.2/moviles/post.php", "POST", parametros);
                DisplayAlert("ALERTA", "usuario correctamente insertado", "cerrar");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}