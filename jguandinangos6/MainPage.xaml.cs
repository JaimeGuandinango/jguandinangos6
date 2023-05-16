using jguandinangos6.WS;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jguandinangos6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.2/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<jguandinangos6.WS.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<jguandinangos6.WS.Datos> posts = JsonConvert.DeserializeObject<List<jguandinangos6.WS.Datos>>(content);
            _post = new ObservableCollection<jguandinangos6.WS.Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var mensaje = "Bienvenido";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Insertar());
        }

         void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var datos = (WS.Datos)e.SelectedItem;
            var codigo = datos.codigo;
            var nombre = datos.nombre;
            var apellido = datos.apellido;
            var edad = datos.edad;
            Navigation.PushAsync(new VentanaAct(codigo, nombre, apellido, edad));
        }
    }
}
