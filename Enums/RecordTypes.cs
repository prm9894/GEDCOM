using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Enums
{
    public enum RecordTypes
    {
        [Description("Individual")]
        INDI = 0,
        [Description("Family")]
        FAM = 1,
        [Description("Note")]
        NOTE = 2,
        [Description("Source")]
        SOUR = 3,
        [Description("Repository")]
        REPO = 4,
        [Description("Object")]
        OBJE = 5
    }
}
