using GEDCOM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.DataSource
{
    public class Data
    {
        public Data()
        {
            this.Individuals = new List<PersonEntity>();
            this.Families = new List<FamilyEntity>();
            this.Notes = new List<NoteEntity>();
            this.Sources = new List<SourceEntity>();
            this.Repositories = new List<RepositoryEntity>();
            this.Objects = new List<FileEntity>();
           
        }

        public List<PersonEntity> Individuals { get; set; }

        public List<FamilyEntity> Families { get; set; }

        public List<NoteEntity> Notes { get; set; }

        public List<SourceEntity> Sources { get; set; }

        public List<RepositoryEntity> Repositories { get; set; }

        public List<FileEntity> Objects { get; set; }
    }
}
