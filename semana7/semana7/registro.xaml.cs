using System;
using System.Collections.Generic;
using SQLite;


using Xamarin.Forms;

namespace semana7
{
    public partial class registro : ContentPage
    {
        private SQLiteAsyncConnection con;

        public registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        void btnRegistrar_Clicked(System.Object sender, System.EventArgs e)
        {
            var datos = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
            con.InsertAsync(datos);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            Navigation.PushAsync(new login());
        }
    }
}

