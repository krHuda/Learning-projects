using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Game
{
    /// <summary>
    /// Данный класс реализует работу с магическим квадратом.
    /// </summary>
    public class MagicSquare
    {
        /// <summary>
        /// Инициализация пустового массива для последующего заполнения цифрами в соответствии с эталонным магическим квадратом.
        /// </summary>
        private int[][] square =
        {
            new int[Constants.MagicNumbers.Length],
            new int[Constants.MagicNumbers.Length],
            new int[Constants.MagicNumbers.Length],
        };

        /// <summary>
        /// Свойство предоставляющее доступ к чтению магического квадрата.
        /// </summary>
        public int[][] Square => square;

        /// <summary>
        /// Данный метод заполняет магический квадрат ходящего числом нажатой кнопки.
        /// </summary>
        /// <param name="index">Уникальный индекс присвоенный каждой кнопке поля в соответствии с эталонным магическим квадратом.</param>
        public void InputNumber(int index)
        {
            var a = IndexOf(Constants.MagicNumbers, index);
            square[a.Item1][a.Item2] = index;
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

        /// <summary>
        /// Данный метод суммирует числа, расположенные по диагонали слева направо, в массиве массивов.
        /// </summary>
        /// <param name="array">Массив в котором нужно просуммировать диагональ.</param>
        /// <returns>Сумму по диагонали слева направо.</returns>
        private int LeftDiagonalSum(int[][] array)
        {
            int sum = default;
            for (var x = 0; x < array.Length; x++)
            {
                sum += array[x][x];
            }
            return sum;
        }

        /// <summary>
        /// Данный метод суммирует числа, расположенные по диагонали справа налево, в массиве массивов.
        /// </summary>
        /// <param name="array">Массив в котором нужно просуммировать диагональ.</param>
        /// <returns>Сумму по диагонали справа налево.</returns>
        private int RightDiagonalSum(int[][] array)
        {
            int sum = default;
            for (int x = 0, y = array.Length - 1; x < array.Length; x ++, y--)
            {
                sum += array[x][y];
            }
            return sum;
        }

        /// <summary>
        /// Данный метод суммирует числа, расположенные по строкам, в массиве массивов.
        /// </summary>
        /// <param name="array">Массив в котором нужно просуммировать строки.</param>
        /// <returns>Сумму по строкам.</returns>
        private List<int> RowsSum(int[][] array)
        {
            var sums = new List<int>();
            for (var x = 0; x < array.Length; x ++)
            {
                int sum = default;
                for (var y = 0; y < array.Length; y++)
                {
                    sum += array[x][y];
                }
                sums.Add(sum);
            }
            return sums;
        }

        /// <summary>
        /// Данный метод суммирует числа, расположенные по колонкам, в массиве массивов.
        /// </summary>
        /// <param name="array">Массив в котором нужно просуммировать колонки.</param>
        /// <returns>Сумму по колонкам.</returns>
        private List<int> ColumnsSum(int[][] array)
        {
            var sums = new List<int>();
            for (var x = 0; x < array.Length; x ++)
            {
                int sum = default;
                for (var y = 0; y < array.Length; y++)
                {
                    sum += array[y][x];
                }
                sums.Add(sum);
            }
            return sums;
        }

        /// <summary>
        /// Данный метод сумирует значения в масиве масивов по всем направлениям и вызвращает список сумм.
        /// </summary>
        /// <param name="array">Массив в котором нужно просуммировать значения во всех направлениях.</param>
        /// <returns>Список сумм.</returns>
        public List<int> GetSums(int[][] array)
        {
            var sums = new List<int>
            {
                LeftDiagonalSum(array),
                RightDiagonalSum(array)
            };
            sums.AddRange(RowsSum(array));
            sums.AddRange(ColumnsSum(array));
            return sums;
        }

        /// <summary>
        /// Данный метод проверяет наличие ожидаемой суммы в одном из напрвлений, что означает победу одной из фигур.
        /// </summary>
        /// <param name="expectedSums">Ожидаемая сумма направлений.</param>
        /// <returns>True в случае совпадения суммы с ожидаемой в одном из направлений.</returns>
        public bool IsAllIdentical(List<int> expectedSums)
        {
            if (IsArrayFilledByDefault(square)) return false;
            var realSums = GetSums(square);
            return realSums.Any(t => t == expectedSums[0]);
        }
    
        /// <summary>
        /// Проверяет наличие в массиве свободных ячеек.
        /// </summary>
        /// <param name="array">Проверяемый массив.</param>
        /// <returns>True если если в массиве есть значения по умолчанию.</returns>
        private bool IsArrayFilledByDefault(int[][] array)
        {
            var result = array.SelectMany(line => line).ToList();
            return result.All(i => i == 0);
        }
    }
}