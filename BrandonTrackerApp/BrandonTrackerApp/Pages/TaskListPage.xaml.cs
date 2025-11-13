using System;
using System.Collections.ObjectModel;
using BrandonTrackerApp.Models;

namespace BrandonTrackerApp.Pages;

public partial class TaskListPage : ContentPage
{
    // Lista de tareas completadas
    public ObservableCollection<TaskItem> CompletedTasks { get; set; } = new();

    // Resumen de entregas
    public int Total => CompletedTasks.Count;

    public int Completed => CompletedTasks.Count(t =>
        t.Dropped != "Nothing" &&
        t.PickedUp != "Nothing" &&
        !string.IsNullOrWhiteSpace(t.DroppedQuantity) &&
        !string.IsNullOrWhiteSpace(t.PickedQuantity));

    public int InProgress => CompletedTasks.Count(t =>
        t.Dropped != "Nothing" &&
        string.IsNullOrWhiteSpace(t.PickedQuantity));

    public int Pending => CompletedTasks.Count(t =>
        t.Dropped == "Nothing" &&
        string.IsNullOrWhiteSpace(t.DroppedQuantity));

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
            Address = "4/5 Parkes Street, Cockburn Central, WA 6164",
            Phone = "(000) 000-0000",
            JobType = "COLLECTION",
            BoxSize = "240L",
            Notes = "Transfer their paper into our 240L bin.",
            Dropped = "240L",
            DroppedQuantity = "3",
            PickedUp = "100L",
            PickedQuantity = "1",
            DriverNotes = "Client requested bin swap from 100L to 240L."
        });

        CompletedTasks.Add(new TaskItem
        {
            Date = DateTime.Today,
            BusinessName = "New Client",
            Address = "12 Sample Road, Fremantle, WA 6160",
            Phone = "(000) 111-2222",
            JobType = "DELIVERY",
            BoxSize = "Corporate",
            Notes = "Initial bin delivery.",
            Dropped = "Corporate",
            DroppedQuantity = "2",
            PickedUp = "Nothing",
            PickedQuantity = "",
            DriverNotes = "First-time delivery, no pickup required."
        });

        CompletedTasks.Add(new TaskItem
        {
            Date = DateTime.Today,
            BusinessName = "Pending Client",
            Address = "88 NoBin St, Perth, WA 6000",
            Phone = "(000) 333-4444",
            JobType = "INSPECTION",
            BoxSize = "Archive",
            Notes = "Client not ready for delivery.",
            Dropped = "Nothing",
            DroppedQuantity = "",
            PickedUp = "Nothing",
            PickedQuantity = "",
            DriverNotes = "No bins delivered or picked up."
        });
    }
}


