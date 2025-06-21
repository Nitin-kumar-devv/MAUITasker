using MauiAppTasker.MVVM.Models;
using MauiAppTasker.MVVM.ViewModels;

namespace MauiAppTasker.MVVM.Views;

public partial class TaskerHome : ContentPage
{
	private TaskerViewModel _taskerViewModel=new TaskerViewModel();
    public TaskerHome()
	{
		InitializeComponent();
		BindingContext =_taskerViewModel;
	}

    private void CheckBoxRef_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		_taskerViewModel.UpdateData()
;    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = _taskerViewModel.Tasks,
                Categories = _taskerViewModel.CategoryList
            }
        };
        Navigation.PushAsync(taskView);
    }
}