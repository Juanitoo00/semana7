using System;
using System.Collections.Generic;
using SQLite;
using System.IO;

using Xamarin.Forms;

namespace semana7
{
    public partial class elemento : ContentPage

    {
        private SQLiteAsyncConnection con;
        private int IdSeleccionado;
        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;

        public elemento(int Id, string Nombre, string Usuario, string Contrasena)
        {
            InitializeComponent();
            txtnombre.Text = Nombre;
            txtUsuario.Text = Usuario;
            txtContrasena.Text = Contrasena;
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante WHERE Id=?", id);
        
        }
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int Id, string Nombre, string Usuario, string Contrasena)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre=? , Usuario=? , Contrasena=id=?", Nombre,Usuario,Contrasena, Id);

        }


        void btnActualzar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
             var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rActualizar = Update(db, IdSeleccionado, txtnombre.Text, txtUsuario.Text, txtContrasena.Text);
                Navigation.PushAsync(new ConsultarRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, IdSeleccionado);
                Navigation.PushAsync(new ConsultarRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}

