using GEDCOM.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class FactEntity
    {

        public FactEntity()
        {
            this.SourceIds = new List<string>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Facts Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the shares fact with.
        /// </summary>
        /// <value>
        /// The shares fact with.
        /// </value>
        public List<string> SharesFactWith { get; set; }

        /// <summary>
        /// Gets or sets the sources.
        /// </summary>
        /// <value>
        /// The sources.
        /// </value>
        public List<string> SourceIds { get; set; }

        /// <summary>
        /// Gets or sets the foot note.
        /// </summary>
        /// <value>
        /// The foot note.
        /// </value>
        public string FootNote { get; set; }
    }
}
