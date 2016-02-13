using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.Models
{
    public class Example3Model
    {
        public IEnumerable<object> Patients
        {
            get
            {
                return new List<object>
                {
                    new { InsuranceCode="11111", Name="Fred Bloggs", Address="Main Street", Telephone="555 1234 123" },
                    new { InsuranceCode="22222", Name="Fred West", Address="Cromwell Street", Telephone="666 666 666" },
                    new { InsuranceCode="33333", Name="Fred Mercury", Address="Over The Rainbow", Telephone="555 321 0987" },
                    new { InsuranceCode="44444", Name="Fred Forsyth", Address="Blimp Street", Telephone="555 111 2222" },
                    new { InsuranceCode="55555", Name="Fred Douglass", Address="Talbot County, Maryland", Telephone="N/A" }
                };
            }
        }

        public IEnumerable<object> Hospitals
        {
            get
            {
                return new List<object>
                {
                    new { Code="AAAAA", Name="Saint Thomas", Address="Westminster Bridge Road, SE1 7EH", Telephone="020 7188 7188" },
                    new { Code="BBBBB", Name="Queen's Medical Centre", Address="Derby Road, NG7 2UH", Telephone="0115 924 9924" },
                    new { Code="CCCCC", Name="Saint Bartholomew", Address="West Smithfield, EC1A 7BE", Telephone="020 7377 7000" },
                    new { Code="DDDDD", Name="Royal London", Address="Whitechapel, E1 1BB", Telephone="020 7377 7000" }
                };
            }
        }
    }
}