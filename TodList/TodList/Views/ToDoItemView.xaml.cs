using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoItemView : ContentPage
    {
        public ToDoItemView()
        {
            InitializeComponent();
        }

        // Guardar un nuevo intem
        private async void OnToDoItemAdded_Clicked(object sender, EventArgs e)
        {
            var NewToDoItem = (Model.ToDoItem)BindingContext;

            // Insertar una tarea en la BD
            //var R = new Model.Repositorio();
            var Resultado = await App.DataBase.CreateToDoItemAsync(NewToDoItem);

            if (Resultado == 1)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Info", $"Registro guardado, ID:{NewToDoItem.ID}", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Info", "Error al guardar", "Ok");
                await Navigation.PopAsync();
            }
        }

        private async void ButtonEliminar_Clicked(object sender, EventArgs e)
        {
            var ItemToDelete = (Model.ToDoItem)BindingContext;

            await App.DataBase.DeleteToDoItemAsyn(ItemToDelete);
            await Navigation.PopAsync();
        }

        private async void ButtonActualizar_Clicked(object sender, EventArgs e)
        {
            var item = (Model.ToDoItem)BindingContext;

            await App.DataBase.UpdateToDoItemAsync(item);
            await Navigation.PopAsync();
        }

        private async void ButtonCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}