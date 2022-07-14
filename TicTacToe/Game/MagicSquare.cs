using System;
using System.Collections.Generic;

namespace TicTacToe.Game
{
    /// <summary>
    /// Данный класс реализует работу с магическим квадратом.
    /// </summary>
    public class MagicSquare
    {
        /// <summary>
        /// Свойство предоставляющее доступ к чтению магического квадрата.
        /// </summary>
        public string[][] Square { get; } = 
        {
            new string[Constants.MagicNumbers.Length],
            new string[Constants.MagicNumbers.Length],
            new string[Constants.MagicNumbers.Length],
            new string[Constants.MagicNumbers.Length],
            new string[Constants.MagicNumbers.Length]
        };
        

        private readonly string expectedSymbol;

        public MagicSquare(string expectedSymbol)
        {
            this.expectedSymbol = expectedSymbol;
        }


        public void InputSymbol(int index, string symbol)
        {
            (int x, int y) symbolIndex = IndexOf(Constants.MagicNumbers, index);
            Square[symbolIndex.x][symbolIndex.y] = symbol;
        }

        /// <summary>
        /// Данный метод высчитывает индекс числа в массиве.
        /// </summary>
        /// <param name="array">Массив, в котором надо найти индекс числа.</param>
        /// <param name="value">Число, индекс которого надо найти в массиве.</param>
        /// <returns>Индекс искомого числа.</returns>
        private static (int, int) IndexOf(int[][] array, int value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length; j++)
                {
                    if (array[i][j] == value)
                    {
                        return (i, j);
                    }
                }
            }
            //Числа -1 будут всегда за пределами массива.
            return (-1, -1);
        }

        
        private List<bool> LeftDiagonalRow(string[][] array)
        {
            var symbolsCount = new List<bool>();
            for (var x = 0; x < array.Length; x ++)
            {
                var list = new List<bool>();
                for (var y = 0; y < array.Length; y++)
                {
                    try
                    {
                        if (array[x][y] == expectedSymbol && array[x-1][y-1] == expectedSymbol && array[x+1][y+1] == expectedSymbol)
                        {
                            list.Add(true);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }
                }
                symbolsCount.AddRange(list);
            }
            return symbolsCount;
        }

        
        private List<bool> RightDiagonalSum(string[][] array)
        {
            var symbolsCount = new List<bool>();
            for (var x = 0; x < array.Length; x ++)
            {
                var list = new List<bool>();
                for (var y = array.Length - 1; y >= 0; y--)
                {
                    try
                    {
                        if (array[x][y] == expectedSymbol && array[x-1][y+1] == expectedSymbol && array[x+1][y-1] == expectedSymbol)
                        {
                            list.Add(true);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }
                }
                symbolsCount.AddRange(list);
            }
            return symbolsCount;
        }
        

        
        private List<bool> RowsSum(string[][] array)
        {
            var symbolsCount = new List<bool>();
            foreach (var symbol in array)
            {
                var list = new List<bool>();
                for (var y = 0; y < array.Length; y++)
                {
                    try
                    {
                        if (symbol[y] == expectedSymbol && symbol[y-1] == expectedSymbol && symbol[y+1] == expectedSymbol)
                        {
                            list.Add(true);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }
                }
                symbolsCount.AddRange(list);
            }
            return symbolsCount;
        }

        
        private List<bool> ColumnsSum(string[][] array)
        {
            var symbolsCount = new List<bool>();
            for (var x = 0; x < array.Length; x ++)
            {
                var list = new List<bool>();
                for (var y = 0; y < array.Length; y++)
                {
                    try
                    {
                        if (array[x][y] == expectedSymbol && array[x-1][y] == expectedSymbol && array[x+1][y] == expectedSymbol)
                        {
                            list.Add(true);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    { }
                }
                symbolsCount.AddRange(list);
            }
            return symbolsCount;
        }
        
        
        private List<bool> GetSums()
        {
            var sums = new List<bool>();
            sums.AddRange(LeftDiagonalRow(Square));
            sums.AddRange(RightDiagonalSum(Square));
            sums.AddRange(RowsSum(Square));
            sums.AddRange(ColumnsSum(Square));
            return sums;
        }

        
        public bool IsWinConditionAchieved(int expectedSymbolCount)
        {
            var realSums = GetSums();
            return realSums.Contains(true);
        }
    }
}