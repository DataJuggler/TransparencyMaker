

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransparencyMaker.Enumerations;
using TransparencyMaker.Objects;

#endregion

namespace TransparencyMaker.Util
{

    #region class PixelQueryParser
    /// <summary>
    /// This class is used to parse querries into PixelQuery objects
    /// </summary>
    public class PixelQueryParser
    {
        
        #region Methods

            #region CreatePixelCriteria(string text, ActionTypeEnum actionType, int lineNumber, PixelCriteria existingCriteria = null)
            /// <summary>
            /// This method returns the Pixel Criteria
            /// </summary>
            public static PixelCriteria CreatePixelCriteria(string text, ActionTypeEnum actionType, int lineNumber, PixelCriteria existingCriteria = null)
            {
                // initial value
                PixelCriteria pixelCriteria = null;

                // only use a space as a delimiter character
                char[] delimiterChars = { ' '};

                // If the text string exists
                if (TextHelper.Exists(text))
                {
                    // Set the BackColor
                    if (actionType == ActionTypeEnum.SetBackColor)
                    {
                        // Create a new instance of a 'PixelCriteria' object.
                        pixelCriteria = new PixelCriteria();

                        // Get the words
                        List<Word> words = WordParser.GetWords(text, delimiterChars);

                        // If the words collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(words))
                        {
                            // if there are 3 words
                            if (words.Count == 3)
                            {
                                // if the third word is null
                                if (words[2].Text.ToLower() == "null")
                                {
                                    // Set the value for the property 'RemoveBackColor' to true
                                    pixelCriteria.RemoveBackColor = true;
                                }
                                else
                                {
                                    // Set the BackColor
                                    pixelCriteria.BackColor = Color.FromName(words[2].Text);
                                }
                            }
                            else if (words.Count == 5)
                            {
                                // set the value for Red, Green & Blue
                                int red = NumericHelper.ParseInteger(words[2].Text, -1, -1);
                                int green = NumericHelper.ParseInteger(words[3].Text, -1, -1);
                                int blue = NumericHelper.ParseInteger(words[4].Text, -1, -1);

                                // if all the RGB values are set
                                if ((red >= 0) && (green >= 0) && (blue >= 0))
                                {
                                    // Set the BackColor
                                    pixelCriteria.BackColor = Color.FromArgb(red, green, blue);
                                }
                            }
                        }
                    }
                    // if this is a draw line
                    else if (actionType == ActionTypeEnum.DrawLine)
                    {
                        // if the existingCriteria 
                        if (NullHelper.IsNull(existingCriteria))
                        {
                            // Create a new instance of a 'PixelCriteria' object.
                            pixelCriteria = new PixelCriteria();
                        }
                        else
                        {
                            // use the existing criteria so more properties can be set on it
                            pixelCriteria = existingCriteria;
                        }

                        // Set to DrawLine
                        pixelCriteria.PixelType = PixelTypeEnum.DrawLine;

                        // if this is the first line
                        if (lineNumber == 1)
                        {
                            // Get the words
                            List<Word> words = WordParser.GetWords(text, delimiterChars);

                            // If the words collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(words))
                            {
                                // Get the lastWord
                                Word lastWord = words[words.Count - 1];

                                // Set the thickness
                                pixelCriteria.Thickness = NumericHelper.ParseInteger(lastWord.Text, -1000, -1001);
                            }
                        }
                        else if (lineNumber == 3)
                        {
                            // Set the RepeatType and the repeating attributes
                            pixelCriteria.RepeatType = SetRepeatType(text);

                            // if the repeat type was found
                            if (pixelCriteria.RepeatType != RepeatTypeEnum.NoRepeat)
                            {
                                // get the text after the repeat 
                                string repeatText = GetRepeatText(text, pixelCriteria.RepeatType);

                                // get the words
                                List<Word> words = WordParser.GetWords(repeatText);

                                // if there are exactly two words
                                if ((ListHelper.HasOneOrMoreItems(words)) && (words.Count == 2))
                                {  
                                    // set the repititions
                                    pixelCriteria.Repititions = NumericHelper.ParseInteger(words[0].Text, 0, -1);

                                    // set the Distance
                                    pixelCriteria.Distance = NumericHelper.ParseInteger(words[1].Text, 0, -1);
                                }
                            }
                        }
                    }
                    else if (lineNumber > 1)
                    {
                        // Create a new instance of a 'PixelCriteria' object.
                        pixelCriteria = new PixelCriteria();

                        // if this text contains bluegreen
                        if (text.Contains("x"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.X;
                        }
                        else if (text.Contains("y"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.Y;
                        }
                        else if (text.Contains("bluegreen"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.BlueGreen;
                        }
                        // if this text contains bluered
                        else if (text.Contains("bluered"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.BlueRed;
                        }
                        // if this text contains greenred
                        else if (text.Contains("greenred"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.GreenRed;
                        }
                        else if (text.Contains("red"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.Red;
                        }
                        else if (text.Contains("green"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.Green;
                        }
                        else if (text.Contains("blue"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.Blue;
                        }
                        else if (text.Contains("total"))
                        {
                            // Set the PixelType
                            pixelCriteria.PixelType = PixelTypeEnum.Total;
                        }
                    }
                }
                
                // return value
                return pixelCriteria;
            }
            #endregion
            
            #region GetRepeatText(string text, RepeatTypeEnum repeatType)
            /// <summary>
            /// This method returns the text after Repeat Left, Repeat Right, etc. 
            /// </summary>
            public static string GetRepeatText(string text, RepeatTypeEnum repeatType)
            {
                // initial value
                string repeatText = "";

                // local
                string lineStart = "repeat ";

                // If the strings text and repeatType both exist
                if ((TextHelper.Exists(text)) && (repeatType != RepeatTypeEnum.NoRepeat))
                {
                    // set the lineStart text
                    lineStart += repeatType.ToString().ToLower();

                    // if the text was found
                    if (text.Contains(lineStart))
                    {
                        // get the repeatText
                        repeatText = text.Substring(lineStart.Length).Trim();
                    }
                }
                
                // return value
                return repeatText;
            }
            #endregion
            
            #region ParseActionType(string queryText)
            /// <summary>
            /// This method returns the Action Type
            /// </summary>
            public static ActionTypeEnum ParseActionType(string queryText)
            {
                // initial value
                ActionTypeEnum actionType = ActionTypeEnum.Unknown;

                // If the queryText string exists
                if (TextHelper.Exists(queryText))
                {  
                    // determine the action type
                    if (queryText.Contains("show"))
                    {
                        // set the actionType to ShowPixels
                        actionType = ActionTypeEnum.ShowPixels;
                    }
                    else if (queryText.Contains("hide from"))
                    {
                        // set the actionType to ShowPixels
                        actionType = ActionTypeEnum.HideFrom;
                    }
                    else if (queryText.Contains("hide"))
                    {
                        // set the actionType to HidePixels
                        actionType = ActionTypeEnum.HidePixels;
                    }
                    else if (queryText.Contains("draw line"))
                    {
                        // set the actionType to DrawLine
                        actionType = ActionTypeEnum.DrawLine;
                    }
                    else if (queryText.Contains("set backcolor"))
                    {
                        // set the actionType to DrawLine
                        actionType = ActionTypeEnum.SetBackColor;
                    }
                    else if (queryText.Contains("update"))
                    {
                        // Set to Update
                        actionType = ActionTypeEnum.Update;
                    }
                }
                                
                // return value
                return actionType;
            }
            #endregion
            
            #region ParseCriteria(string queryText, ActionTypeEnum actionType)
            /// <summary>
            /// This method returns a list of Criteria
            /// </summary>
            public static List<PixelCriteria> ParseCriteria(string queryText, ActionTypeEnum actionType)
            {
                // initial value
                List<PixelCriteria> criteria = null;

                // locals
                int count = 0;
                string text = "";
                PixelCriteria pixelCriteria = null;

                // If the queryText string exists
                if (TextHelper.Exists(queryText))
                {   
                    // Get the lines of text
                    List<TextLine> lines = WordParser.GetTextLines(queryText);

                    // If the lines collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(lines))
                    {
                        // Create a new collection of 'PixelCriteria' objects.
                        criteria = new List<PixelCriteria>();

                        // parse the text lines
                        foreach (TextLine textLine in lines)
                        {
                            // Increment the value for count
                            count++;
                            
                            // Get the text
                            text = textLine.Text.ToLower();

                            // verify the line has text in case the user hit enter at the end of the line
                            if (TextHelper.Exists(text))
                            {  
                                // if this is DrawLine
                                if (actionType == ActionTypeEnum.DrawLine)
                                {
                                    // if this is the first line
                                    if (count == 1)
                                    {
                                        // Create the pixelCriteria based upon this text
                                        pixelCriteria = CreatePixelCriteria(text, actionType, count);

                                        // verify the pixelCriteria exists before adding
                                        if (pixelCriteria != null)
                                        {
                                            // Add this criteria
                                            criteria.Add(pixelCriteria);
                                        }
                                    }
                                    else if (count == 2)
                                    {
                                        // Set the ComparisonText
                                        SetComparisonType(text, ref pixelCriteria);
                                    }
                                    else
                                    {
                                        // Create the pixelCriteria based upon this text
                                        pixelCriteria = CreatePixelCriteria(text, actionType, count, pixelCriteria);
                                    }
                                }
                                else
                                {  
                                    // Create the pixelCriteria based upon this text
                                    pixelCriteria = CreatePixelCriteria(text, actionType, count);

                                    // verify the pixelCriteria exists before adding
                                    if (pixelCriteria != null)
                                    {
                                        // Set the ComparisonText
                                        SetComparisonType(text, ref pixelCriteria);

                                        // Add this criteria
                                        criteria.Add(pixelCriteria);
                                    }
                                }
                            }
                        }
                    }
                }
                
                // return value
                return criteria;
            }
            #endregion
            
            #region ParseDirections(string directionsText)
            /// <summary>
            /// This method parses the Directions given. 
            /// </summary>
            public static Directions ParseDirections(string directionsText)
            {
                // initial value
                Directions directions = null;

                // If the directionsText string exists
                if (TextHelper.Exists(directionsText))
                {
                    // Create a new instance of a 'Directions' object.
                    directions = new Directions();

                    // only use a space as a delimiter character
                    char[] delimiterChars = { ' '};

                    // if the words exists
                    List<Word> words = WordParser.GetWords(directionsText, delimiterChars);

                    // If the words collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(words))
                    {
                        // Iterate the collection of Word objects
                        foreach (Word word in words)
                        {
                            switch (word.Text)
                            {
                                case "left":
                                    
                                    // update the directions object
                                    directions.Left = true;
                                
                                    // required
                                    break;

                                case "right":

                                    // set to Right
                                    directions.Right  = true;
                                
                                    // required
                                    break;

                                case "top":

                                    // set to Top
                                    directions.Top = true;
                                
                                    // required
                                    break;

                                case "bottom":

                                    // Set to Bottom
                                    directions.Bottom = true;
                                
                                    // required
                                    break;

                                case "all":

                                    // set all directions to true
                                    directions.Left = true;
                                    directions.Top = true;
                                    directions.Bottom = true;
                                    directions.Right = true;
                                
                                    // required
                                    break;
                            }
                        }
                    }
                }
                
                // return value
                return directions;
            }
            #endregion
            
            #region ParseNumbers(string text, ref int number1, ref int number2)
            /// <summary>
            /// This method Parse Numbers
            /// </summary>
            public static void ParseNumbers(string text, ref int number1, ref int number2)
            {
                // locals
                int count = 0;

                // only use a space as a delimiter character
                char[] delimiterChars = { ' '};

                // if the words exists
                List<Word> words = WordParser.GetWords(text, delimiterChars);

                // If the words collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(words))
                {
                    // Iterate the collection of Word objects
                    foreach (Word word in words)
                    {
                        // if this word is a number
                        if (NumericHelper.IsNumeric(word.Text))
                        {
                            // Increment the value for count
                            count++;  

                            // if this is the firstNumber
                            if (count == 1)
                            {
                                // set number1
                                number1 = NumericHelper.ParseInteger(word.Text, -1000, -1001);
                            }
                            else if (count == 2)
                            {
                                // set number2
                                number2 = NumericHelper.ParseInteger(word.Text, -1000, -1001);

                                // we are done
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            #region ParseNumbers(string text, ref int number1, ref int number2, ref int number3, ref int number4)
            /// <summary>
            /// This method Parse Numbers
            /// </summary>
            public static void ParseNumbers(string text, ref int number1, ref int number2, ref int number3, ref int number4)
            {
                // locals
                int count = 0;

                // only use a space as a delimiter character
                char[] delimiterChars = { ' ' };

                // if the words exists
                List<Word> words = WordParser.GetWords(text, delimiterChars);

                // If the words collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(words))
                {
                    // Iterate the collection of Word objects
                    foreach (Word word in words)
                    {
                        // if this word is a number
                        if (NumericHelper.IsNumeric(word.Text))
                        {
                            // Increment the value for count
                            count++;  

                            // if this is the firstNumber
                            if (count == 1)
                            {
                                // set number1
                                number1 = NumericHelper.ParseInteger(word.Text, -1000, -1001);
                            }
                            else if (count == 2)
                            {
                                // set number2
                                number2 = NumericHelper.ParseInteger(word.Text, -1000, -1001);
                            }
                            else if (count == 3)
                            {
                                // set number3
                                number3 = NumericHelper.ParseInteger(word.Text, -1000, -1001);
                            }
                            else if (count == 4)
                            {
                                // set number4
                                number4 = NumericHelper.ParseInteger(word.Text, -1000, -1001);
                            }                            
                        }
                    }
                }
            }
            #endregion
            
            #region ParsePixelQuery(string queryText)
            /// <summary>
            /// This class is used to parse querries from the queryText given
            /// </summary>
            public static PixelQuery ParsePixelQuery(string queryText)
            {
                // initial value
                PixelQuery pixelQuery = new PixelQuery();

                // locals
                int count = 0;
                StringBuilder sb = null;
                string criteriaText = String.Empty;
                string updateText = String.Empty;

                // If the queryText string exists
                if (TextHelper.Exists(queryText))
                {
                    // get the lowercase version of the text
                    queryText = queryText.ToLower().Trim();

                    // parse the ActionType (Show Pixels, Hide Pixels, Draw Line, Update)
                    pixelQuery.ActionType = ParseActionType(queryText);

                    // if we are doing an update query, we have to modify this a little
                    if (pixelQuery.ActionType == ActionTypeEnum.Update)
                    {
                        // for an update query, the second line sets the color values to update to
                        // and the third line starts the where clause.

                        // Get the text lines
                        List<TextLine> lines = WordParser.GetTextLines(queryText);

                        // If the lines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // Create a string builder
                            sb = new StringBuilder();

                            // Iterate the collection of TextLine objects
                            foreach (TextLine line in lines)
                            {
                                // Increment the value for count
                                count++;

                                // skip the first line, as it is not really needed
                                if (count > 2)
                                {
                                    // Add this lines test
                                    sb.Append(line.Text + Environment.NewLine);
                                }

                                // if the value of count equals 2
                                if (count == 2)
                                {
                                    // Set the UpdateText
                                    updateText = line.Text;
                                }
                            }

                            // Set the criteria text
                            criteriaText = sb.ToString();

                            // Parse the Criteria (this is the matching part)
                            pixelQuery.Criteria = ParseCriteria(criteriaText, pixelQuery.ActionType);

                            // If the updateText string exists
                            if (TextHelper.Exists(updateText))
                            {
                                // Set the update values
                                SetUpdateParameters(updateText, ref pixelQuery);
                            }
                        }
                    }
                    else if (pixelQuery.ActionType == ActionTypeEnum.HideFrom)
                    {
                        // hide from (Left, Right, Up, Down, All)

                        // set the directionsText
                        string directionsText = queryText.Substring(10).Trim();

                        // Parse the directions 
                        pixelQuery.Directions = ParseDirections(directionsText);
                    }
                    else
                    {
                        // This is a Hide or Show Query or DrawLine
                        // and the second line starts the where clause.

                        // Parse the Criteria (this is the matching part)
                        pixelQuery.Criteria = ParseCriteria(queryText, pixelQuery.ActionType);
                    }
                }

                // return value
                return pixelQuery;
            }
            #endregion
            
            #region SetColorToAdjust()
            /// <summary>
            /// This method returns the Color To Adjust
            /// </summary>
            public static RGBColor SetColorToAdjust(string colorWord)
            {
                // initial value
                RGBColor colorToAdjust = RGBColor.NotSet;
                
                // If the colorWord string exists
                if (TextHelper.Exists(colorWord))
                {
                    // determine the action by the text of the word                    
                    switch(colorWord.ToLower())
                    {
                        case "red":

                            // set the value
                            colorToAdjust = RGBColor.Red;

                            // required
                            break;

                        case "green":

                            // set the value
                            colorToAdjust = RGBColor.Green;

                            // required
                            break;

                        case "blue":

                            // set the value
                            colorToAdjust = RGBColor.Blue;

                            // required
                            break;

                        case "all":

                            // set the value
                            colorToAdjust = RGBColor.All;

                            // required
                            break;
                    }
                }

                // return value
                return colorToAdjust;
            }
            #endregion
            
            #region SetComparisonType(string text, ref PixelCriteria pixelCriteria)
            /// <summary>
            /// This method returns the Comparison Type
            /// </summary>
            public static ComparisonTypeEnum SetComparisonType(string text, ref PixelCriteria pixelCriteria)
            {
                // initial value
                ComparisonTypeEnum comparisonType = ComparisonTypeEnum.Unknown;

                // locals
                int number1 = -1000;
                int number2 = -1000;
                int number3 = -1000;
                int number4 = -1000;
                
                // if the text exists
                if ((TextHelper.Exists(text)) && (NullHelper.Exists(pixelCriteria)))
                {
                    // drawing is different for DrawLine
                    if (pixelCriteria.PixelType == PixelTypeEnum.DrawLine)
                    {
                        // Parse out the numbers from the text
                        ParseNumbers(text, ref number1, ref number2, ref number3, ref number4);

                        // Set the Start and End Point
                        pixelCriteria.StartPoint = new Point(number1, number2);
                        pixelCriteria.EndPoint = new Point(number3, number4);
                    }
                    else
                    {
                        // Parse out the numbers from the text
                        ParseNumbers(text, ref number1, ref number2);

                        // if the text contains less than
                        if (text.Contains("<"))
                        {
                            // Set to Less Than
                            comparisonType = ComparisonTypeEnum.LessThan;

                            // Set the MaxValue
                            pixelCriteria.MaxValue = number1;
                        }
                        // if the text contains between
                        else if (text.Contains("between"))
                        {
                            // Set to Between
                            comparisonType = ComparisonTypeEnum.Between;

                            // Set the MinValue
                            pixelCriteria.MinValue = number1;

                            // Set the MaxValue
                            pixelCriteria.MaxValue = number2;
                        }
                        // if the text contains greater than
                        else if (text.Contains(">"))
                        {
                            // Set to Greater Than
                            comparisonType = ComparisonTypeEnum.GreaterThan;

                            // Set the MinValue
                            pixelCriteria.MinValue = number1;
                        }
                        else if (text.Contains("="))
                        {
                            // Set to Equals
                            comparisonType = ComparisonTypeEnum.Equals;

                            // Set the TargetValue
                            pixelCriteria.TargetValue = number1;
                        }
                    }

                    // set the comparisonType on the object passed in
                    pixelCriteria.ComparisonType = comparisonType;
                }
                
                // return value
                return comparisonType;
            }
            #endregion

            #region SetRepeatType(string text)
            /// <summary>
            /// This method returns the Repeat Type
            /// </summary>
            public static RepeatTypeEnum SetRepeatType(string text)
            {
                // initial value
                RepeatTypeEnum repeatType = RepeatTypeEnum.NoRepeat;

                // determine the repeat type by the text
                if (text.Contains("repeat left"))
                {
                    // Set the RepeatType
                    repeatType = RepeatTypeEnum.Left;
                }
                else if (text.Contains("repeat up"))
                {
                    // Set the RepeatType
                    repeatType = RepeatTypeEnum.Up;
                }
                else if (text.Contains("repeat right"))
                {
                    // Set the RepeatType
                    repeatType = RepeatTypeEnum.Right;
                }
                else if (text.Contains("repeat down"))
                {
                    // Set the RepeatType
                    repeatType = RepeatTypeEnum.Down;
                }

                // return value
                return repeatType;
            }
            #endregion
            
            #region SetUpdateParameters(string updateText, ref PixelQuery pixelQuery)
            /// <summary>
            /// This method Set Update Parameters
            /// </summary>
            public static void SetUpdateParameters(string updateText, ref PixelQuery pixelQuery)
            {
                // if the updateText exists and the pixelQuery object exists                
                if ((TextHelper.Exists(updateText)) && (NullHelper.Exists(pixelQuery)))
                {
                    // if the updateText starts with the word set (else this is not a proper BQL Update query).
                    if (updateText.StartsWith("set"))    
                    {
                        // only use a space as a delimiter character
                        char[] delimiterChars = { ' ' };

                        // Get a list of words from this text
                        List<Word> words = WordParser.GetWords(updateText, delimiterChars);

                        // If the words collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(words))
                        {
                            // if there are six words. 
                            // Example: Set Color 100 150 200 40 - (Red = 100, Green = 150, Blue = 200, Alpha = 40)
                            if (words.Count == 6)
                            {  
                                // Set to red
                                pixelQuery.Red = NumericHelper.ParseInteger(words[2].Text, -1, -2);
                                pixelQuery.Green = NumericHelper.ParseInteger(words[3].Text, -1, -2);
                                pixelQuery.Blue = NumericHelper.ParseInteger(words[4].Text, -1, -2);
                                pixelQuery.Alpha = NumericHelper.ParseInteger(words[5].Text, -1, -2);

                                // verify everything is valid
                                if ((pixelQuery.Red >= 0) && (pixelQuery.Green >= 0) && (pixelQuery.Red >= 0) && (pixelQuery.Alpha >= 0))
                                {
                                    // Set the Color
                                    pixelQuery.Color = Color.FromArgb(pixelQuery.Alpha, pixelQuery.Red, pixelQuery.Green, pixelQuery.Blue);
                                }
                            }
                            // if there are 5 words
                            // Example: Set Color 100 150 200 - (Red = 100, Green = 150, Blue = 200, Alpha = 255 default value)
                            else if (words.Count == 5)
                            {
                                // Set to red
                                pixelQuery.Red = NumericHelper.ParseInteger(words[2].Text, -1, -2);
                                pixelQuery.Green = NumericHelper.ParseInteger(words[3].Text, -1, -2);
                                pixelQuery.Blue = NumericHelper.ParseInteger(words[4].Text, -1, -2);
                                pixelQuery.Alpha = 255;

                                // verify everything is valid
                                if ((pixelQuery.Red >= 0) && (pixelQuery.Green >= 0) && (pixelQuery.Red >= 0) && (pixelQuery.Alpha >= 0))
                                {
                                    // Set the Color
                                    pixelQuery.Color = Color.FromArgb(pixelQuery.Alpha, pixelQuery.Red, pixelQuery.Green, pixelQuery.Blue);
                                }

                                // Set the Color
                                pixelQuery.Color = Color.FromArgb(pixelQuery.Alpha, pixelQuery.Red, pixelQuery.Green, pixelQuery.Blue);
                            }
                            // If there are 4 words
                            // Example: Set Adjust Red 25 (every pixel gets 25 more red)
                            else if (words.Count == 4)
                            {
                                // Adjustment

                                // if the second word is adjust
                                if (TextHelper.IsEqual(words[1].Text, "adjust"))
                                {
                                    // AdjustColor is true
                                    pixelQuery.AdjustColor = true;

                                    // get the text of the third word
                                    string colorWord = words[2].Text;

                                    // set the Color to Adjust
                                    pixelQuery.ColorToAdjust = SetColorToAdjust(colorWord);

                                    // Set the adjustment amount
                                    pixelQuery.Adjustment = NumericHelper.ParseInteger(words[3].Text, -1000, -1001);
                                }
                            }
                            // if there are 3 words
                            // Example: Set Color Orchid (the color must be a named color)
                            else if (words.Count == 3)
                            {
                                // Set the Color
                                pixelQuery.Color = Color.FromName(words[2].Text);
                                pixelQuery.Alpha = 255;
                            }
                        }
                    }
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
