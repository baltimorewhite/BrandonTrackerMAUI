using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BrandonTrackerApp.Models;
using BrandonTrackerApp.Services;

namespace BrandonTrackerApp.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private readonly RandomUserService _service = new();

        public ObservableCollection<TaskItem> CompletedTasks { get; set; } = new();

        public async Task LoadDataAsync()
        {
            var tasks = await _service.GetRandomTaskItemsAsync(10);
            CompletedTasks.Clear();
            foreach (var task in tasks)
                CompletedTasks.Add(task);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

