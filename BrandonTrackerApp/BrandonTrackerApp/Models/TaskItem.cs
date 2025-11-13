using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BrandonTrackerApp.Models
{
    public class TaskItem
    {
        public DateTime Date { get; set; }
        public string JobType { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BoxSize { get; set; }
        public string Notes { get; set; }
        public string Dropped { get; set; }
        public string PickedUp { get; set; }
        public string Quantity { get; set; }

        public List<string> DropOptions => new() { "Yes", "No" };
        public List<string> PickupOptions => new() { "Yes", "No" };

        public string DriverNotes { get; set; }

        public ICommand CompleteCommand => new Command(() =>
        {
            // Guardar DriverNotes en la hoja o base de datos
            Console.WriteLine($"Driver notes: {DriverNotes}");

            // Aquí iría la lógica para enviar a Google Sheets o guardar localmente
        });

        public ICommand OpenMapCommand => new Command(() =>
        {
            var url = $"https://maps.app.goo.gl/vDRoxgpht2nqeTXi7{Uri.EscapeDataString(Address)}";
            Launcher.OpenAsync(new Uri(url));
        });
    }
}
