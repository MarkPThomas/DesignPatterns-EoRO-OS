using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Characters.Model
{
    /// <summary>
    /// Unshared concrete flyweight.
    /// </summary>
    public class Column : Glyph, IContainerRelative
    {
        public List<Row> Rows { get; private set; } = new List<Row>();
        public int Spacing { get; private set; } = 2;

        private double _widthRatio = 1;
        public double WidthRatio { get { return _widthRatio; } }

        private double _heightRatio = 1;
        public double HeightRatio { get { return _heightRatio; } }


        public Column()
        {

        }

        public override void Draw(Control target, GlyphContext context)
        {
            throw new NotImplementedException();
        }

        public override bool Intersects(Point point, GlyphContext context)
        {
            return base.Intersects(point, context);
        }

        public void AddRow(Row row)
        {
            Rows.Add(row);
        }
    }
}
