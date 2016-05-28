using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Model
{
    public class Document
    {
        public int RowSpacing { get; private set; } = 2;
        public int ColSpacing { get; private set; } = 2;

        
        public List<Column> Columns { get; private set; } = new List<Column>();
    }
}
