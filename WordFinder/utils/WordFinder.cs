using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFinder{
    
    /// <summary>
    /// Search for words in a char matrix.
    /// </summary>
    public class WordFinder
    {
        private static int _squareSize = 64; //square matrix size
        private char[,] _charMatrix = null; //char matrix to store the words
        
        /// <summary>
        /// It initializes a WordFinder instance with a string collection received as argument.
        /// </summary>
        /// <param name="matrix">A collection of strings representing the words that you want to store in a square matrix.</param>
        public WordFinder(IEnumerable<string> matrix) 
        {
            _charMatrix = new char[_squareSize,_squareSize];

            int ind;
            
            //Clean _charMatrix with \0 since this value is used to end every string and it's not printable
            for(ind = 0; ind < _squareSize * _squareSize; ind++)
                _charMatrix[ind / _squareSize, ind % _squareSize] = '\0';

            //Store every char in the words inside the _charMatrix
            ind = 0;
            foreach(string word in matrix)
            {
                foreach(char charItem in word.ToCharArray())
                {
                    int row = ind / _squareSize;
                    int col = ind % _squareSize;

                    if(row > _charMatrix.GetUpperBound(0))
                        return; //if we exceed the size of _charMatrix then we no longer need to retrieve any chars from argument matrix.

                    if(charItem != '\0')
                    {
                        _charMatrix[row, col] = charItem;
                        ind++;
                    }
                }
            }
        }

        /// <summary>
        /// It searches matching words in a square char matrix. Horizontally (left to right) and vertically (top to bottom).
        /// The occurrence checker algorithm is based on simple char comparisson.
        /// </summary>
        /// <returns>
        /// The top 10 most repeated words from the wordstream found in the matrix. 
        /// If there are no repeated words in the wordstream it returns an empty set of strings.
        /// </returns>
        /// <param name="wordstream">A collection of strings representing the words that you want to search in the matrix.</param>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            //Creates a collection of tuples (string, int) which contains every word with the frequency of that word in the matrix.
            //Sort that collection by the frequency in a descending order and then takes the first 10 elements.
            IEnumerable<(string, int)> result = wordstream.Distinct().Select( x => (x, CharBasedFrequency(x))).OrderByDescending( t => t.Item2).Take(10);

            foreach((string,int) element in result)
                Console.WriteLine($"\t({element.Item1},{element.Item2})");

            //if all the words in the wordstream are not present in the matrix then we return an empty set of strings.
            if(result.All( x => x.Item2 == 0))
                return Enumerable.Empty<string>();
            
            //if there are words with frequency > 0 then return those words.
            return result.Select( x => x.Item1);
        }
        
        /// <summary>
        /// It searches matching words in a square char matrix. Horizontally (left to right) and vertically (top to bottom).
        /// The occurrence checker algorithm is based on regular expressions and uses Regex class.
        /// </summary>
        /// <returns>
        /// The top 10 most repeated words from the wordstream found in the matrix. 
        /// If there are no repeated words in the wordstream it returns an empty set of strings.
        /// </returns>
        /// <param name="wordstream">A collection of strings representing the words that you want to search in the matrix.</param>
        public IEnumerable<string> Find2(IEnumerable<string> wordstream)
        {

            IEnumerable<(string, int)> result = wordstream.Distinct().Select( x => (x, RegExBasedFrequency(x))).OrderByDescending( t => t.Item2).Take(10);

            foreach((string,int) element in result)
                Console.WriteLine($"\t({element.Item1},{element.Item2})");

            if(result.All( x => x.Item2 == 0))
                return new List<string>();
            
            return result.Select( x => x.Item1);
        }
        
        /// <summary>
        /// Returns the size of the internal square matrix
        /// </summary>
        public int GetMatrixSize()
        {
            return _squareSize;
        }

        /// <summary>
        /// Prints the content of the internal matrix.
        /// </summary>
        public void PrintMatrix()
        {
            for(int row = 0; row < _squareSize; row++)
            {
                for(int col = 0; col < _squareSize; col++)
                {
                    Console.Write(_charMatrix[row,col]);
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// Returns the frequency of occurrence of a word in the matrix based on Regular Expressions.
        /// </summary>
        private int RegExBasedFrequency(string word)
        {
            int total = 0;
            int ind;
            
            var regex = new Regex(word);

            for(ind = 0; ind < _squareSize; ind++)
            {
                if(_charMatrix[ind, 0] != '\0')
                {
                    string horizontalLine = new string(Enumerable.Range(0, _squareSize).Select(x => _charMatrix[ind, x]).ToArray());
                    //Console.WriteLine($"h:{horizontalLine}");
                    total += regex.Matches(horizontalLine).Count;
                }

                if(_charMatrix[0, ind] != '\0')
                {
                    string verticalLine = new string(Enumerable.Range(0, _squareSize).Select(x => _charMatrix[x, ind]).ToArray());
                    //Console.WriteLine($"v:{verticalLine}");
                    total += regex.Matches(verticalLine).Count;
                }
            }

            return total;
        }

        /// <summary>
        /// Returns the frequency of occurrence of a word in the matrix based on simple char comparisson.
        /// </summary>
        private int CharBasedFrequency(string word)
        {
            char[] charsInWord = word.ToCharArray();
            int wordUpperBound = charsInWord.GetUpperBound(0);
            int total = 0;
            
            for(int ind1 = 0; ind1 < _squareSize; ind1++)
            {
                for(int ind2 = 0; ind2 < _squareSize; ind2++)
                {
                    if(ind2 + wordUpperBound + 1 > _squareSize)
                        break; //breaks if word doesn't fit in the remaining positions of the array
                    
                    int charPos = 0;
                    while(
                        charPos <= wordUpperBound && 
                        (ind2 + charPos) < _squareSize && 
                        charsInWord[charPos].Equals(_charMatrix[ind1, ind2 + charPos])
                    )
                        charPos++;
                
                    if(charPos > wordUpperBound) total++; //found a complete word (horizontal)

                    charPos = 0;
                    while(
                        charPos <= wordUpperBound && 
                        (ind2 + charPos) < _squareSize && 
                        charsInWord[charPos].Equals(_charMatrix[ind2 + charPos, ind1])
                    )
                        charPos++;

                    if(charPos > wordUpperBound) total++; //found a complete word (vertical)
                }
                
            }

            return total;
        }
        
    }

}
