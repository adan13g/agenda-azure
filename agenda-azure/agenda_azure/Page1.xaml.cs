using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace agenda_azure
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

            MobileServiceClient client;
            IMobileServiceTable<Agenda> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<Agenda>();
           // tabla.InsertAsync;
            //tabla.UpdateAsync;
            //tabla.DeleteAsync;


            var datos = new Agenda { Name = nombre1.Text ,Lastname=apellido1.Text,Cellphone=telefono1.Text };




        }

        public async void enviardatos(object sender, object args)
        {
            MobileServiceClient client;
            IMobileServiceTable<Agenda> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<Agenda>();

            var datos = new Agenda { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };

            IEnumerable<Agenda> items = await tabla.ToEnumerableAsync();
            string[] arreglo = new string[items.Count()];
            string[] arreglo2 = new string[items.Count()];

            int i = 0;
            foreach (var x in items)
            {
                arreglo[i] = x.Name;
                arreglo2[i] = x.Lastname;
                if (datos.Id == null)
                {
                    await tabla.InsertAsync(datos);
                }
                i++;

                lista.ItemsSource = arreglo.Concat(arreglo2);
               // lista2.ItemsSource = arreglo2;
            }
          
        }

        public async void actualizardatos(object sender, object args)
        {
            MobileServiceClient client;
            IMobileServiceTable<Agenda> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<Agenda>();

            var datos = new Agenda { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };

            IEnumerable<Agenda> items = await tabla.ToEnumerableAsync();
            string[] arreglo = new string[items.Count()];
            string[] arreglo2 = new string[items.Count()];
            string[] arreglo3 = new string[items.Count()];
            string[] arreglo4 = new string[items.Count()];

            int i = 0;
            foreach (var x in items)
            {
                arreglo[i] = x.Name;
                arreglo2[i] = x.Lastname;
                arreglo3[i] = x.Id;
                arreglo4[i] = x.Cellphone;
                               
                if (x.Cellphone == telefono1.Text)
                {
                    if (x.Name != nombre1.Text)
                    {
                        x.Name = nombre1.Text;
                    }
                    if (x.Lastname != apellido1.Text)
                    {
                        x.Lastname = apellido1.Text;
                    }

                    await tabla.UpdateAsync(x);
                }
                i++;
            }
            lista.ItemsSource = arreglo;
            lista2.ItemsSource = arreglo2;

        }

        public async void mostrardatos(object sender, object args)
        {
            MobileServiceClient client;
            IMobileServiceTable<Agenda> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<Agenda>();

            var datos = new Agenda { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };

            IEnumerable<Agenda> items = await tabla.ToEnumerableAsync();
            string[] arreglo = new string[items.Count()];
            string[] arreglo2 = new string[items.Count()];
            string[] arreglo3 = new string[items.Count()];
            string[] arreglo4 = new string[items.Count()];

            int i = 0;
            foreach (var x in items)
            {
                arreglo[i] = x.Name;
                arreglo2[i] = x.Lastname;
                arreglo3[i] = x.Id;
                arreglo4[i] = x.Cellphone;
                i++;

                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            }
            }
        public async void eliminardatos(object sender, object args)
        {

            MobileServiceClient client;
            IMobileServiceTable<Agenda> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<Agenda>();

            var datos = new Agenda { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };

            IEnumerable<Agenda> items = await tabla.ToEnumerableAsync();
            string[] arreglo = new string[items.Count()];
            string[] arreglo2 = new string[items.Count()];
            string[] arreglo3 = new string[items.Count()];
            string[] arreglo4 = new string[items.Count()];

            int i = 0;
            foreach (var x in items)
            {
                arreglo[i] = x.Name;
                arreglo2[i] = x.Lastname;
                arreglo3[i] = x.Id;
                arreglo4[i] = x.Cellphone;
               

                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
                if (x.Cellphone == telefono1.Text)
                {
                   
                    await tabla.DeleteAsync(x);

                }
                i++;

            }


        }


        }
}
