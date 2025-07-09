using System.Threading.Tasks;
using Tasker.MVVM.ViewModels;
using Tasker.MVVM.Models;
using Microsoft.Maui.Graphics;

namespace Tasker.MVVM.Views;

public partial class NewTasksView : ContentPage
{
    public NewTasksView()
    {
        InitializeComponent();
    }

    private async void AddTaskClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;
        var selectedCategory =
            vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id
            };
            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
        }
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string category =
            await DisplayPromptAsync("New Category",
            "Write the new category name",
            maxLength: 15,
            keyboard: Keyboard.Text);

        var r = new Random();

        if (!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(new Category
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(
                r.Next(0, 255),
                r.Next(0, 255),
                r.Next(0, 255)
                ).ToArgbHex(),

                CategoryName = category

            });
        }

    }
}