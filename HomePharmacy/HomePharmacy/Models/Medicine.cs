using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePharmacy.Models
{
    public class Medicine
    {
        string name;

        //оранжевое поле под названием рецепта
        string mainSubstance;

        string bestBeforeDate;

        string quantity;

        public Medicine(string name,string mainSubstance,string bestBeforeDate,string quantity)
        {
            this.name = name;
            this.mainSubstance = mainSubstance;
            this.bestBeforeDate = bestBeforeDate;
            this.quantity = quantity;
        }


    }
}
