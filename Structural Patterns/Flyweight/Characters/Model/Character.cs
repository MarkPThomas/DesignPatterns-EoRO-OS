using System;
using System.Drawing;
using System.Windows.Forms;

namespace Characters.Model
{
    /// <summary>
    /// Concrete shared flyweight object.
    /// Implements Flyweight interface and adds storage for intrinsic state, if any.
    /// Must be sharable.
    /// Any state stored must be intrinsic - i.e. it must be independent of the ConcreteFlyweight object's context.
    /// </summary>
    public class Character : Glyph
    {
        /// <summary>
        /// Intrinsic state.
        /// </summary>
        private char _charCode;

        public Character(char charCode)
        {
            _charCode = charCode;
        }

        /// <summary>
        /// Operation based on extrinsic state.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="context"></param>
        public override void Draw(Control target, GlyphContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Operation based on extrinsic state.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool Intersects(Point point, GlyphContext context)
        {
            return base.Intersects(point, context);
        }
    }
}
