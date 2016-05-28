
using Sop.Collections.Generic.BTree;
using System.Drawing;

namespace Characters.Model
{
    public class GlyphContext
    {
        private int _index;
        private BTreeDictionary<int, Font> _fonts = new BTreeDictionary<int, Font>();

        public int Margin { get; private set; } = 1;
        public int Padding { get; private set; } = 1;

        public GlyphContext()
        {
            
        }

        /// <summary>
        /// Increments the current location to the next index.
        /// </summary>
        /// <param name="step">Number of steps to increment next.</param>
        public virtual void Next(int step = 1)
        {
            _index += step;
        }

        /// <summary>
        /// Inserts blanks entries before the current location.
        /// The current location becomes the first inserted item.
        /// </summary>
        /// <param name="quantity">Number of entries to insert.</param>
        public virtual void Insert(int quantity = 1)
        {
            // Shifts current indices
            if (_fonts.MoveLast())
            {
                do
                {
                    if (_fonts.CurrentKey >= _index)
                    {
                        Font currentFont = _fonts.CurrentValue;
                        int newKey = _fonts.CurrentKey + quantity;
                        _fonts.Remove();
                        _fonts.Add(newKey, currentFont);
                    }
                } while (_fonts.MovePrevious());
            }
            
            // Adds blank spaces
            for (int i = _index; i < _index + quantity; i++)
            {
                _fonts.Add(_index, null);
            }
        }

        /// <summary>
        /// Get font at current location.
        /// </summary>
        /// <returns></returns>
        public virtual Font GetFont()
        {
            Font currentFont;
            _fonts.TryGetValue(_index, out currentFont);
            return currentFont;
        }

        /// <summary>
        /// Assigns a font to a set of glyphs, starting at the current location.
        /// </summary>
        /// <param name="font">Font to assing to glyphs.</param>
        /// <param name="span">Number of characters to assign the font to.</param>
        public virtual void SetFont(Font font, int span = 1)
        {
            for (int i = _index; i < _index + span; i++)
            {
                _fonts.Remove(i);
                _fonts.Add(i, font);
            }
        }

    }
}