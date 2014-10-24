using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Enums
{
    public enum Genders
    {
        [Description("Male")]
        M = 1,
        [Description("Female")]
        F = 2,
        [Description("Unknown")]
        U = 3
    }
}
