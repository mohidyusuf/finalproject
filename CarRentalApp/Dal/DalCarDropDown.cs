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
    public  class DalCarDropDown
    {
        public static EntCarDropDown GetAllDropdownData()
        {
            var json = File.ReadAllText("wwwroot/data/CarDropDownData.json");
            return JsonSerializer.Deserialize<EntCarDropDown>(json);
        }
    }


}
