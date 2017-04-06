using System;

namespace MVCPracticeProject.Models
{
    public class SukudoBoardVerifyModel
    {
        private int[,] _gameboard;
        private int _size;
        private int _region;

        public SukudoBoardVerifyModel(int[,] board)
        {
            _gameboard = board;
            _size = _gameboard.GetLength(0);
            _region = (int)Math.Sqrt(_size);
        }

        public bool verify()
        {
            for (int i = 0; i < _size; i++)
            {
                if (verifyRow(_size, i) == false) return false;
                if (verifyColumn(_size, i) == false) return false;
            }
            for (int k = 0; k < _size; k += _region)
            {
                for (int j = 0; j < _size; j += _region)
                {
                    if (verifyRegion(_size, k, j) == false) return false;
                }
            }
            return true;
        }

        public bool verifyRow(int size, int row)
        {
            bool[] verifyArray = new bool[size];
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                verifyArray[i] = false;
            }
            for (int i = 0; i < size; i++)
            {
                int boardValue;
                if (_gameboard[row, i] == 0) counter++;
                if (_gameboard[row, i] > 0 && _gameboard[row, i] <= size)
                {
                    boardValue = _gameboard[row, i];
                    verifyArray[boardValue - 1] = true;
                }
            }
            for (int i = 0; i < size; i++)
            {
                if (verifyArray[i] == true) counter++;
            }
            if (counter == size) return true;
            else return false;
        }

        public bool verifyColumn(int size, int column)
        {
            bool[] verifyArray = new bool[size];
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                verifyArray[i] = false;
            }
            for (int i = 0; i < size; i++)
            {
                int boardValue;
                if (_gameboard[i, column] == 0) counter++;
                if (_gameboard[i, column] > 0 && _gameboard[i, column] <= size)
                {
                    boardValue = _gameboard[i, column];
                    verifyArray[boardValue - 1] = true;
                }
            }
            for (int i = 0; i < size; i++)
            {
                if (verifyArray[i] == true) counter++;
            }
            if (counter == size) return true;
            else return false;
        }

        public bool verifyRegion(int size, int startRow, int startColumn)
        {
            bool[] verifyArray = new bool[size];
            int counter = 0;

            for (int i = 0; i < _region; i++)
            {
                verifyArray[i] = false;
            }
            for (int i = startRow; i < _region + startRow; i++)
            {
                for (int j = startColumn; j < _region + startColumn; j++)
                {
                    int boardValue;
                    if (_gameboard[i, j] == 0) counter++;
                    if (_gameboard[i, j] > 0 && _gameboard[i, j] <= size)
                    {
                        boardValue = _gameboard[i, j];
                        verifyArray[boardValue - 1] = true;
                    }
                }
            }
            for (int i = 0; i < _size; i++)
            {
                if (verifyArray[i] == true) counter++;
            }
            if (counter == size) return true;
            else return false;
        }
    }
}