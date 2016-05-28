using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Model
{
    /// <summary>
    /// Flyweight factory.
    /// Creates and manages flyweight objects.
    /// Ensures that flyweights are shared properly.
    /// When a client requests a flyweight, the FlyweightFactory object supplies an existing instance or creates one, if none exists.
    /// </summary>
    public class GlyphFactory
    {
        private const int N_CHAR_CODES = 128;

        /// <summary>
        /// Pool of flyweights.
        /// Only one of each flyweight is created.
        /// </summary>
        private Character[] _character;

        public GlyphFactory()
        {
            _character = new Character[N_CHAR_CODES];
        }


        /// <summary>
        /// Gets the flyweight object by key.
        /// </summary>
        /// <param name="charCode">Flyweight key.</param>
        /// <returns></returns>
        public Character CreateCharacter(char charCode)
        {
            if (_character[charCode] == null)
            {
                _character[charCode] = new Character(charCode);
            }

            return _character[charCode];
        }

        public Row CreateRow()
        {
            return new Row();
        }

        /// <summary>
        /// Ensures that each column always contains one row.
        /// </summary>
        /// <returns></returns>
        public Column CreateColumn(int rows = 1)
        {
            Column column = new Column();
            for (int i = 0; i < rows; i++)
            {
                column.AddRow(new Row());
            }
            return column;
        }


     
    }
}
