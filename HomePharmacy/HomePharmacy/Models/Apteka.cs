using System.Collections.ObjectModel;

namespace HomePharmacy.Models
{
    public class Apteka
    {
        public string Name { get;set; }
        public ObservableCollection<Medicine> Medicines { get; set; }

        public int QuantityMedicines {  get; set; }
        public Apteka() 
        {
            Name = string.Empty;
            Medicines = new();
            QuantityMedicines = 0;
        }

        public void AddMedicine(Medicine medicine)
        {
            Medicines.Add(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            Medicines.Remove(medicine);
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public int CountMedicines()
        {
            if(Medicines.Count!= 0)
            {
                return Medicines.Count;
            }
            return 0;
        }
    }
}
