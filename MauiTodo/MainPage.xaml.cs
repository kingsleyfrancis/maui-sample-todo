using MauiTodo.Data;
using MauiTodo.Models;
using System.Collections.ObjectModel;

namespace MauiTodo
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;

        public ObservableCollection<TodoItem> Todos { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();

            _database = new Database();

            _ = Initialise();
        }

        private async Task Initialise()
        {
            var todos = await _database.GetTodos();

            foreach (var todosItem in todos)
            {
                Todos.Add(todosItem);
            }
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TodoTitleEntry.Text))
                return;

            var todo = new TodoItem
            {
                Due = DueDatepicker.Date,
                Title = TodoTitleEntry.Text,
            };

            var inserted = await _database.AddTodo(todo);
            if(inserted != 0)
            {
                TodoTitleEntry.Text = string.Empty;
                DueDatepicker.Date = DateTime.Now;
                Todos.Add(todo);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void DoneSwipe_Invoked(object sender, EventArgs e)
        {

            var item = sender as SwipeItem;
            await App.Current.MainPage.DisplayAlert(item.Text, $"You invoked the {item.Text} action.", "OK");
        }

        private async void DeleteSwipe_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            await App.Current.MainPage.DisplayAlert(item.Text, $"You invoked the {item.Text} action.", "OK");
        }
    }
}