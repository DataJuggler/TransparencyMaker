

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataJuggler.Core.UltimateHelper.Objects;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class WordParser
    /// <summary>
    /// This class is used to parse out words
    /// </summary>
    public class WordParser
    {  
        
        #region Methods
            
            #region GetTextLines(string originalText)
            /// <summary>
            /// This method returns a list of TextLine objects.
            /// </summary>
            /// <param name="sourceText"></param>
            /// <returns></returns>
            public static List<TextLine> GetTextLines(string sourceText)
            {
                // initial value
                List<TextLine> textLines = new List<TextLine>();

                // typical delimiter characters
                char[] delimiterChars = Environment.NewLine.ToCharArray();

                // local
                int counter = -1;

                // verify the sourceText exists
                if (!String.IsNullOrEmpty(sourceText))
                {
                    // Get the list of strings
                    string[] linesOfText = sourceText.Split(delimiterChars);

                    // now iterate the strings
                    foreach (string lineOfText in linesOfText)
                    {
                        // local
                        string text = lineOfText;

                        // increment the counter
                        counter++;

                        // add every other row
                        if ((counter % 2) == 0)
                        {
                            // Create a new TextLine
                            TextLine textLine = new TextLine(text);

                            // now add this textLine to textLines collection
                            textLines.Add(textLine);
                        }
                    }
                }

                // return value
                return textLines;
            }
            #endregion
            
            #region GetWords(string originalText, char[] delimeter = null)
            /// <summary>
            /// This method returns all of the words in a list of strings
            /// </summary>
            /// <param name="sourceText"></param>
            /// <returns></returns>
            public static List<Word> GetWords(string sourceText, char[] delimeters = null)
            {
                // initial value
                List<Word> words = new List<Word>();
                
                // typical delimiter characters
                char[] delimiterChars = { ' ','-','/', ',', '.', '\t' };

                // if the delimter exists
                if (NullHelper.Exists(delimeters))
                {
                    // use these delimters
                    delimiterChars = delimeters;
                }

                // verify the sourceText exists
                if (!String.IsNullOrEmpty(sourceText))
                {
                    // Get the list of strings
                    string[] strings = sourceText.Split(delimiterChars);

                    // now iterate the strings
                    foreach(string stringWord in strings)
                    {
                        // verify the word is not an empty string or a space
                        if (!String.IsNullOrEmpty(stringWord))
                        {
                            // Create a new Word
                            Word word = new Word(stringWord);

                            // now add this word to words collection
                            words.Add(word);
                        }
                    }
                }

                // return value
                return words;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
