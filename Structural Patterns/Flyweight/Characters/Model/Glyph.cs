using System.Windows.Forms;
using System.Drawing;

namespace Characters.Model
{
    /// <summary>
    /// Flyweight object.
    /// Determines an interface through which flyweights can receive and acto on extrinsic state.
    /// </summary>
    public abstract class Glyph : IContainer
    {
        public int Margin { get; private set; }
        public int Padding { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        protected Glyph() { }

        // Operations all depend on extrinsic state:

        public virtual void Draw(Control target, GlyphContext context) { }
        public virtual Font GetFont(GlyphContext context) { return null; }
        public virtual void First(GlyphContext context) { }
        public virtual void Next(GlyphContext context) { }
        public virtual bool IsDone(GlyphContext context) { return true; }
        public virtual Glyph Current(GlyphContext context) { return null; }
        public virtual void Insert(Glyph glyph, GlyphContext context) { }
        public virtual void Remove(GlyphContext context) { }
        public virtual bool Intersects(Point point, GlyphContext context) { return false; }
    }
}
