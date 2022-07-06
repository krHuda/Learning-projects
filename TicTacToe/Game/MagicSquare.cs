using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Game
{
    public class MagicSquare
    {
        private int[][] square =
        {
            new int[3],
            new int[3],
            new int[3],
        };

        public void InputNumber(int index)
        {
            var a = IndexOf(Constants.MagicNumbers, index);
            square[a.Item1][a.Item2] = index;
        }

        private static (int, int) IndexOf(int[][] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i][j] == value)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        private int LeftDiagonalSum(int[][] array)
        {
            int sum = default;
            for (int x = 0; x < array.Length; x++)
            {
                sum += array[x][x];
            }
            return sum;
        }

        private int RightDiagonalSum(int[][] array)
        {
            int sum = default;
            for (int x = 0, y = array.Length - 1; x < array.Length; x ++, y--)
            {
                sum += array[x][y];
            }
            return sum;
        }

        private List<int> RowsSum(int[][] array)
        {
            var sums = new List<int>();
            for (int x = 0; x < array.Length; x ++)
            {
                int sum = default;
                for (int y = 0; y < array.Length; y++)
                {
                    sum += array[x][y];
                }
                sums.Add(sum);
            }
            return sums;
        }

        private List<int> ColumnsSum(int[][] array)
        {
            var sums = new List<int>();
            for (int x = 0; x < array.Length; x ++)
            {
                int sum = default;
                for (int y = 0; y < array.Length; y++)
                {
                    sum += array[y][x];
                }
                sums.Add(sum);
            }
            return sums;
        }

        public bool IsAllIdentical()
        {
            if (IsSquareFilledByDefault()) return false;
            var expectedSums = new List<int>()
            {
                LeftDiagonalSum(Constants.MagicNumbers),
                RightDiagonalSum(Constants.MagicNumbers),
            };
            expectedSums.AddRange(RowsSum(Constants.MagicNumbers));
            expectedSums.AddRange(ColumnsSum(Constants.MagicNumbers));
            var sums = new List<int>()
            {
                LeftDiagonalSum(square),
                RightDiagonalSum(square)
            };
            sums.AddRange(RowsSum(square));
            sums.AddRange(ColumnsSum(square));
            return sums.Any(t => t == expectedSums[0]);
        }

        private bool IsSquareFilledByDefault()
        {
            var result = square.SelectMany(line => line).ToList();
            return result.All(i => i == 0);
        }
    }
}