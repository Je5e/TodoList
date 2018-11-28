using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodList.Views
{
    public partial class ToDoListView : ContentPage
    {
        List<Model.ToDoItem> Tareas = new List<Model.ToDoItem>();
        public ToDoListView()
        {
            InitializeComponent();


        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var R = new Model.Repositorio();
            var Result = R.GetToDoItemsAsync();
            var r = await Result;
            Tareas = r.ToList();
            ListViewItems.ItemsSource = Tareas;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoItemView
            { BindingContext = new Model.ToDoItem() });
        }

        private async void ListViewItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var TodoItem = e.SelectedItem as Model.ToDoItem;
            if (TodoItem != null)
            {
                await Navigation.PushAsync(new ToDoItemView { BindingContext = TodoItem });
            }
        }
    }
}
