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
                    if(charItem != '\0')
                    {
                        _charMatrix[ind / _squareSize, ind % _squareSize] = charItem;
                        ind++;
                    }
                }
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {

            IEnumerable<(string, int)> result = wordstream.Select( x => (x, Frequency(x))).OrderByDescending( t => t.Item2).Take(10);

            if(result.All( x => x.Item2 == 0))
                return new List<string>();
            
            return result.Select( x => x.Item1);
        }

        public int GetMatrixSize()
        {
            return _squareSize;
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
    }

}
