
using MauiAppTasker.MVVM.Models;
using MauiAppTasker.MVVM.ViewModels;

namespace MauiAppTasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private void AddTaskClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;
		var selectedCategory = vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();
		if (selectedCategory == null)
		{
			DisplayAlert("Invalid Category","Please Select A Valid Category","Ok");
		}
		else if (vm.Task == null)
		{
            DisplayAlert("Empty Task", "Please Enter A Valid Task", "Ok");
        }
		else
		{

			var task = new MyTaskModel
			{
				CategoryId = selectedCategory.Id,
				TaskName = vm.Task

			};

			vm.Tasks.Add(task);
			Navigation.PopAsync();
		}
			
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;
		var category = await DisplayPromptAsync("Add Category","Enter category name" ,maxLength:15);
		var r = new Random();
		if (!string.IsNullOrEmpty(category))
		{
			vm.Categories.Add(new TaskerModel
			{
				CategoryName = category,
				Id = vm.Categories.Max(x => x.Id) + 1,
				Color = Color.FromRgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)).ToHex().ToString()
			});
		}
    }
}