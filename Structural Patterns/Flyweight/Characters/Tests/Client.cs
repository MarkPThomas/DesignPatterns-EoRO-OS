using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Characters.Model;

namespace Characters.Tests
{
    public class Client
    {
        Font _currentFont;

        /// <summary>
        /// Computes or stores the extrinsic state of flyweights.
        /// </summary>
        GlyphContext extrinsicState = new GlyphContext();

        /// <summary>
        /// Maintains a reference to flyweights, which are pooled within a factory.
        /// </summary>
        GlyphFactory flyweightFactory = new GlyphFactory();

        Document doc = new Document();
        
        public void CreateDocument()
        {
            GenerateLayout();
            GenerateText();
        }

        public void GenerateLayout()
        {
            // ===== Generate empty document =====
            // Create one full-width column composed of n-rows
            Column outerColumn = flyweightFactory.CreateColumn(20);
            doc.Columns.Add(outerColumn);

            // For row 5, give it 2 columns, one with 3 rows and another with 2 rows
            Row rowWithColumns = outerColumn.Rows[4];
            rowWithColumns.AddColumn(flyweightFactory.CreateColumn(3));
            rowWithColumns.AddColumn(flyweightFactory.CreateColumn(2));
        }

        public void GenerateText()
        {
            // ===== Generated Fonts to Use =====
            Font times24 = new Font("Times New Roman", 24);
            Font times12 = new Font("Times New Roman", 12);
            Font timesItalic12 = new Font("Times New Roman", 12, FontStyle.Italic);
            Font timesBold12 = new Font("Times New Roman", 12, FontStyle.Bold);
            Font courier12 = new Font("Courier", 12);

            // ===== Add Text =====         
            // Add single character, as if from keypress.
            AddText('O', times24);

            // Add bulk of text, as if from copy/paste
            _currentFont = times12;
            AddText("bject-oriented programming ...", _currentFont);
            AddText("people ", _currentFont);

            string text = "expect";
            int rewindCursor = text.Length;
            AddText(text, timesItalic12);

            text = " to change ...";
            rewindCursor += text.Length;
            AddText(text, _currentFont);

            text = "an ";
            rewindCursor += text.Length;
            AddText(text, _currentFont);

            text = "iterator";
            rewindCursor += text.Length;
            AddText(text, timesBold12);

            rewindCursor++;
            AddText(' ', _currentFont);

            text = "Foo";
            rewindCursor += text.Length;
            AddText(text, courier12);

            text = " can do ...";
            rewindCursor += text.Length;
            AddText(text, _currentFont);

            // ===== Modify Text =====
            // Move cursor to just before 'expect'
            extrinsicState.Next(-1 * rewindCursor);

            // Change font of the word based on the current location and length
            extrinsicState.SetFont(times12, 6);

            // ===== Insert Text =====
            // Text is added at current position, which is always inserted.
            // Pure adding only occurs at the last index position.
            AddText("don't ", timesItalic12);
        }

        private void AddText(char character, Font font)
        {
            char[] characters = new char[1];
            characters[0] = character;
            AddText(characters, font);
        }

        private void AddText(string text, Font font)
        {
            char[] characters = text.ToCharArray();
            AddText(characters, font);
        }

        private void AddText(char[] characters, Font font)
        {
            // Add to flyweight pool if not currently existing
            int length = characters.Length;
            for (int i = 0; i < length; i++)
            {
                flyweightFactory.CreateCharacter(characters[i]);
            }

            // Add text to extrinsic state
            extrinsicState.Insert(length);
            extrinsicState.SetFont(font, length);
            extrinsicState.Next(length);
        }
    }
}
