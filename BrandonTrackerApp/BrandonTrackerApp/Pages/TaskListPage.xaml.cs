using System;
using System.Collections.ObjectModel;
using BrandonTrackerApp.Models;



namespace BrandonTrackerApp.Pages;

public partial class TaskListPage : ContentPage
{
    // task list
    public ObservableCollection<TaskItem> CompletedTasks { get; set; } = new();

    // Delivery Summary
    public int Total => CompletedTasks.Count;
    public int Completed => CompletedTasks.Count(t => t.Dropped == "Yes" && t.PickedUp == "Yes");
    public int InProgress => CompletedTasks.Count(t => t.Dropped == "Yes" && t.PickedUp == "No");
    public int Pending => CompletedTasks.Count(t => t.Dropped == "No");


    public TaskListPage()
    {
        InitializeComponent();
        BindingContext = this;
        LoadMockData();
    }

    private void LoadMockData()
    {
        CompletedTasks.Add(new TaskItem
        {
            Date = DateTime.Today,
            BusinessName = "Brandon's Boxes",
            Address = "123 Elm St, Suburb",
            Phone = "(000) 000-0000",
            JobType = "COLLECTION",
            BoxSize = "240L",
            Notes = "Transfer their paper into out 240L bin.",
            Dropped = "Yes",
            PickedUp = "Yes",
            Quantity = "3"
        });

    }
}


