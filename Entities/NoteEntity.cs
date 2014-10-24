using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    public class NoteEntity
    {
        public static NoteEntity Create(string[] elements)
        {
            var entity = new NoteEntity();

            entity.Id = elements[0].Replace("0 @", "").Replace("@ NOTE", "").Replace("@","").Trim();

            for (var index = 1; index < elements.Length; index++ )
            {
                entity.Note = string.Format("{0}{2}{1}", entity.Note, elements[index].Replace("1 CONC", "").Replace("1 CONT", "").Trim(), entity.Note.Length > 0 ? " " : "");
            }
            entity.Note = entity.Note.Trim();

            return entity;

        }

        public NoteEntity()
        {
            Note = "";
        }

        public string Id { get; set; }

        public string Note { get; set; }
    }
}
