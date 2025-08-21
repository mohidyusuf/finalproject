using Entities;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dal
{
    public class DalBusDropDown
    {
        public static EntBusDropDown GetAllDropdownData()
        {
            var json = File.ReadAllText("wwwroot/data/BusDropDownData.json");
            return JsonSerializer.Deserialize<EntBusDropDown>(json);
        }
    }


}
