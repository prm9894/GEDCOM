using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Enums
{
    public enum Facts
    {
        [Description("Event")]
        EVEN = 0,
        [Description("Birth")]
        BIRT = 1,
        [Description("Baptism")]
        BAPL = 2,
        [Description("Marriage")]
        MARR = 3,
        [Description("Death")]
        DEAT = 4,
        [Description("Occupation")]
        OCCU = 5,
        [Description("Burial")]
        BURI = 6,
        [Description("Residence")]
        RESI = 7,
        [Description("Data")]
        DATA = 99,
        [Description("Height")]
        _HEIG = 100,
        [Description("Weight")]
        _WEIG = 101,
        [Description("Medical Condition")]
        _MDCL  = 102,
        [Description("Also Known As")]
        ALIA = 20
    }
}
