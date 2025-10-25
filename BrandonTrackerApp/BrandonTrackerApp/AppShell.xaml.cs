namespace BrandonTrackerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("home", typeof(Pages.HomePage));
            Routing.RegisterRoute("tasks", typeof(Pages.TaskListPage));
            Routing.RegisterRoute("history", typeof(Pages.TaskDetailPage));
            Routing.RegisterRoute("settings", typeof(Pages.SettingsPage));
        }
    }
}

