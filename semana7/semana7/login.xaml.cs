using System;
using System.Collections.Generic;
using SQLite;
using System.IO;

using Xamarin.Forms;
using System.Linq;

namespace semana7
{
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection con;

        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();

        }
        public static IEnumerable<Estudiante> Select_where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);
        }

        void btnIniciar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_where(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count()>0)
                {
                    Navigation.PushAsync(new ConsultarRegistro());

                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o contraseña Incorrectos", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        void btnRegistrar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new registro());
        }
    }
}

