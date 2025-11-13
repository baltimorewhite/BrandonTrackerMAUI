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
        public string DroppedQuantity { get; set; }
        public string PickedQuantity { get; set; }

        public List<string> DropOptions => new() { "Small", "Big", "100L", "Corporate", "240L", "240 Corp", "Archive", "Nothing" };
        public List<string> PickupOptions => new() { "Small", "Big", "100L", "Corporate", "240L", "240 Corp", "Archive", "Nothing" };

        public string DriverNotes { get; set; }

        public bool CanComplete =>  !string.IsNullOrWhiteSpace(Dropped) ||
                                    !string.IsNullOrWhiteSpace(PickedUp) ||
                                    !string.IsNullOrWhiteSpace(DroppedQuantity) ||
                                    !string.IsNullOrWhiteSpace(PickedQuantity);


        public ICommand CompleteCommand => new Command(() =>
        {
            if (!CanComplete)
            {
                Application.Current.MainPage.DisplayAlert("Incomplete", "Please enter at least one bin type or quantity before completing.", "OK");
                return;
            }

            // Guardar datos
            Console.WriteLine($"Dropped: {Dropped} ({DroppedQuantity})");
            Console.WriteLine($"Picked Up: {PickedUp} ({PickedQuantity})");
            Console.WriteLine($"Driver Notes: {DriverNotes}");


            // Aquí iría la lógica para enviar a Google Sheets o guardar localmente
        });

        public ICommand OpenMapCommand => new Command(() =>
        {
            var url = $"https://maps.app.goo.gl/vDRoxgpht2nqeTXi7{Uri.EscapeDataString(Address)}";
            Launcher.OpenAsync(new Uri(url));
        });
    }
}
