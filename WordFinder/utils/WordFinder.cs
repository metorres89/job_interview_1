using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFinder{
    public class WordFinder
    {
        private IEnumerable<string> _matrix;

        private static int _squareSize = 64;

        private char[,] _charMatrix = null;

        public WordFinder(IEnumerable<string> matrix) 
        {
            _matrix = matrix;

            _charMatrix = new char[_squareSize,_squareSize];

            int ind;
            
            //clean _charMatrix
            for(ind = 0; ind < _squareSize * _squareSize; ind++)
                _charMatrix[ind / _squareSize, ind % _squareSize] = '\0';

            //store strings in matrix
            ind = 0;
            foreach(string item in _matrix)
            {
                foreach(char charItem in item.ToCharArray())
                {
                    int row = ind / _squareSize;
                    int col = ind % _squareSize;

                    if(row > _charMatrix.GetUpperBound(0))
                        return;

                    if(charItem != '\0')
                    {
                        _charMatrix[row, col] = charItem;
                        ind++;
                    }
                }
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {

            IEnumerable<(string, int)> result = wordstream.Select( x => (x, Frequency(x))).OrderByDescending( t => t.Item2).Take(10);

            foreach((string,int) element in result)
                Console.WriteLine($"({element.Item1},{element.Item2})");

            if(result.All( x => x.Item2 == 0))
                return new List<string>();
            
            return result.Select( x => x.Item1);
        }

        public IEnumerable<string> Find2(IEnumerable<string> wordstream)
        {

            IEnumerable<(string, int)> result = wordstream.Select( x => (x, Frequency2(x))).OrderByDescending( t => t.Item2).Take(10);

            foreach((string,int) element in result)
                Console.WriteLine($"({element.Item1},{element.Item2})");

            if(result.All( x => x.Item2 == 0))
                return new List<string>();
            
            return result.Select( x => x.Item1);
        }

        public int GetMatrixSize()
        {
            return _squareSize;
        }

        public void PrintMatrix()
        {
            Console.WriteLine("_charMatrix[,] Content:");
            for(int row = 0; row < _squareSize; row++)
            {
                for(int col = 0; col < _squareSize; col++)
                {
                    Console.Write(_charMatrix[row,col]);
                }
                Console.Write("\n");
            }
        }

        private int Frequency(string word)
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

        private int Frequency2(string word)
        {
            char[] charsInWord = word.ToCharArray();
            int total = 0;
            int ind;

            for(ind = 0; ind < _squareSize; ind++)
            {
                if(_charMatrix[ind, 0] != '\0')
                {
                    for(int col = 0; col < _squareSize; col++)
                    {
                        int charPos = 0;
                        
                        while(
                            charPos <= charsInWord.GetUpperBound(0) && 
                            (col + charPos) <= _charMatrix.GetUpperBound(1) && 
                            charsInWord[charPos] == _charMatrix[ind, col + charPos]
                        )
                            charPos++;
                        
                        if(charPos > charsInWord.GetUpperBound(0)) total++; //found a complete word (horizontal)
                    }
                }

                if(_charMatrix[0, ind] != '\0')
                {
                    for(int row = 0; row < _squareSize; row++)
                    {
                        int charPos = 0;
                        
                        while(
                            charPos <= charsInWord.GetUpperBound(0) && 
                            (row + charPos) <= _charMatrix.GetUpperBound(0) && 
                            charsInWord[charPos] == _charMatrix[row + charPos, ind]
                        )
                            charPos++;

                        if(charPos > charsInWord.GetUpperBound(0)) total++; //found a complete word (vertical)
                    }
                }
            }

            return total;
        }
    }

}
