using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Characters.Model
{
    /// <summary>
    /// Unshared concrete flyweight.
    /// </summary>
    public class Row : Glyph, IContainerRelative
    {
        // Original implementation: Each character is stored as an object.
        //public List<Character> Characters { get; private set; } = new List<Character>();

        // New implementation: Only the index size contained is needed. 
        /// <summary>
        /// Only used if one column exists, which spans the row.
        /// </summary>
        public int IndexSize { get; }

        public List<Column> Columns { get; private set; } = new List<Column>();

        private double _widthRatio = 1;
        public double WidthRatio { get { return _widthRatio; } }

        private double _heightRatio = 1;
        public double HeightRatio { get { return _heightRatio; } }

        public Row()
        {
            
        }

        public void AddColumn(Column column)
        {
            Columns.Add(column);
        }

        public override void Draw(Control target, GlyphContext context)
        {
            throw new NotImplementedException();
        }

        public override bool Intersects(Point point, GlyphContext context)
        {
            return base.Intersects(point, context);
        }
    }
}
