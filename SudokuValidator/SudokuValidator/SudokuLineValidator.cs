
using System.Linq;

namespace SudokuValidator
{
    class SudokuLineValidator
    {
        private int[] LinesValidated;
        private int Goal = 9;
        private int Counter;

        private Sudoku sdk;


        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="sdk">sudoku</param>
        public SudokuLineValidator(Sudoku sdk)
        {
            this.sdk = sdk;
        }

        /// <summary>
        /// Validates all lines in the sudoku if completed
        /// </summary>
        /// <returns>array with the line index as value when a line is valid</returns>
        public int[] CheckLines(int[,] resultBoard, int[,] playerBoard)
        {
            this.LinesValidated = new int[9];

            this.LoopLines(resultBoard, playerBoard);

            return LinesValidated;
        }

        /// <summary>
        /// Loops in between the 9 cells of a line to validate the full
        /// </summary>
        /// <param name="resultBoard">original board</param>
        /// <param name="playerBoard">player input board</param>
        private void LoopLines(int[,] resultBoard, int[,] playerBoard)
        {
            //SquaresBoard Loops
            for (int line = 0; line < 9; line++)
            {
                Counter = 1;

                //SquareCellLoops
                this.LoopCells(resultBoard, playerBoard, line);

                //When all cells in square are validated
                this.ValidateLine(this.Counter, line);
            }
        }

        /// <summary>
        /// Loops in between the 9 cells of the square to validate the full
        /// </summary>
        /// <param name="resultBoard">original board</param>
        /// <param name="playerBoard">player input board</param>
        /// <param name="line">y coords</param>
        private void LoopCells(int[,] resultBoard, int[,] playerBoard, int line)
        {
            for (int col = 0; col < resultBoard.GetLength(1); col++)
            {

                if (resultBoard[line, col] == playerBoard[line, col])
                {
                    this.Counter++;
                }
            }
        }

        /// <summary>
        /// If the values in a line are validated adds the coords to lines validated
        /// </summary>
        /// <param name="countValidInSquare">if 9 line is valid</param>
        /// <param name="yBoard">coord y</param>
        private void ValidateLine(int countValidInSquare, int yBoard)
        {
            if (countValidInSquare == this.Goal)
            {
                this.LinesValidated.Append(yBoard);
            }
        }
    }
}
