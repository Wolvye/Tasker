using System.Threading.Tasks;
using Tasker.MVVM.ViewModels;
using Tasker.MVVM.Models;

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
			vm.Categories.Where(x=>x.IsSelected == true).FirstOrDefault();

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
}