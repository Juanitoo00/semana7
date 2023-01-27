using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

using Xamarin.Forms;

namespace semana7
{
    public partial class ConsultarRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tEstudiante;


        public ConsultarRegistro()
        {
            InitializeComponent();

            con = DependencyService.Get<DataBase>().GetConnection();
            
            Listar();
        }

        public async void Listar()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaEstudiantes.ItemsSource = tEstudiante;

        }

        public void OnSelection(object serder, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var Id = Convert.ToInt32(item);
            var Nombre = obj.Nombre.ToString();
            var Usuario = obj.Contrasena.ToString();
        var Contrasena = obj.Contrasena.ToString();

            Navigation.PushAsync(new elemento(Id, Nombre, Usuario, Contrasena));
        }

        void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {

        }
    }
}

