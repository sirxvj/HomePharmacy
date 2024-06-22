using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePharmacy.Models
{
    public class Recept
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateOnly Date { get; set; }

        public ObservableCollection<Medicine> Medicines { get; set; }

        public Recept() 
        {
            Name = string.Empty;
            Status = string.Empty;
            Date = new DateOnly();
            Medicines = new();
        }
    }
}
