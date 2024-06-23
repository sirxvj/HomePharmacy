using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePharmacy.Models
{
    public class Medicine
    {
        public string name { get; set; }

        public bool IsChecked { get; set; }
        //оранжевое поле под названием рецепта
        public string mainSubstance { get; set; }

        public DateTime bestBeforeDate { get; set; }

        public string quantity { get; set; }

        public Medicine(string name,string mainSubstance,DateTime bestBeforeDate,string quantity)
        {
            this.name = name;
            IsChecked = false;
            this.mainSubstance = mainSubstance;
            this.bestBeforeDate = bestBeforeDate;
            this.quantity = quantity;
        }


    }
}
