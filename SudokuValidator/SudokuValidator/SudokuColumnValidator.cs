using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuValidator
{
    class SudokuColumnValidator
    {
        

        private int[] ColumnsValidated;
        private int Goal = 9;
        private int Counter;

        private Sudoku sdk;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="sdk">sudoku</param>
        public SudokuColumnValidator(Sudoku sdk)
        {
            this.sdk = sdk;
        }

        /// <summary>
        /// Validates all Columns in the sudoku if completed
        /// </summary>
        /// <returns>array with the line index as value when a line is valid</returns>
        public int[] CheckColumns(int[,] resultBoard, int[,] playerBoard)
        {
            this.ColumnsValidated = new int[9];

            this.LoopColumns(resultBoard, playerBoard);

            return ColumnsValidated;
        }

        /// <summary>
        /// Loops in between the 9 cells of a column to validate the full
        /// </summary>
        /// <param name="resultBoard">original board</param>
        /// <param name="playerBoard">player input board</param>
        private void LoopColumns(int[,] resultBoard, int[,] playerBoard)
        {
            //SquaresBoard Loops
            for (int col = 0; col < 9; col++)
            {
                Counter = 1;

                //SquareCellLoops
                this.LoopCells(resultBoard, playerBoard, col);

                //When all cells in square are validated
                this.ValidateColumn(this.Counter, col);
            }
        }

        /// <summary>
        /// Loops in between the 9 cells of the column to validate the full set
        /// </summary>
        /// <param name="resultBoard">original board</param>
        /// <param name="playerBoard">player input board</param>
        /// <param name="col">y coords</param>
        private void LoopCells(int[,] resultBoard, int[,] playerBoard, int col)
        {
            for (int line = 0; line < resultBoard.GetLength(0); line++)
            {

                if (resultBoard[line, col] == playerBoard[line, col])
                {
                    this.Counter++;
                }
            }
        }

        /// <summary>
        /// If the values in a line are validated adds the coords to Columns validated
        /// </summary>
        /// <param name="countValidInSquare">if 9 line is valid</param>
        /// <param name="xBoard">coord y</param>
        private void ValidateColumn(int countValidInSquare, int xBoard)
        {
            if (countValidInSquare == this.Goal)
            {
                this.ColumnsValidated.Append(xBoard);
            }
        }
    }
}
