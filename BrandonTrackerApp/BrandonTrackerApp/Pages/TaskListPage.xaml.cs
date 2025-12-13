using BrandonTrackerApp.ViewModels;

namespace BrandonTrackerApp.Pages;

public partial class TaskListPage : ContentPage
{
    private readonly TaskListViewModel _viewModel = new();

    public TaskListPage()
    {
        InitializeComponent();
        BindingContext = _viewModel;

        // Load data from API when page appears
        Loaded += async (_, _) => await _viewModel.LoadDataAsync();
    }
}



