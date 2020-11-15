
namespace SudokuValidator
{
    class SudokuSquareValidator
    {
        int[,] SquareBoard;
        int counter;

        private Sudoku sdk;
        public SudokuSquareValidator(Sudoku sdk)
        {
            this.sdk = sdk;
        }

        /// <summary>
        /// Check if a square in the sudoku
        /// </summary>
        /// <returns>array with 1 as value when a square is valid</returns>
        public int[,] CheckSquares(int[,] resultBoard, int[,] playerBoard)
        {
            this.SquareBoard = new int[3,3];

            this.LoopBoard(resultBoard, playerBoard);

            return SquareBoard;
        }

        /// <summary>
        /// Loops in between the 9 cells of the square to validate the full
        /// </summary>
        /// <param name="resultBoard">original board</param>
        /// <param name="playerBoard">player input board</param>
        /// <param name="yBoard">y coords</param>
        /// <param name="xBoard">x coords</param>
        private void LoopBoard(int[,] resultBoard, int[,] playerBoard)
        {
            //SquaresBoard Loops
            for (int yBoard = 0; yBoard < 3; yBoard++)
            {

                for (int xBoard = 0; xBoard < 3; xBoard++)
                {
                    counter = 1;

                    //SquareCellLoops
                    this.LoopSquare(resultBoard, playerBoard, yBoard, xBoard);

                    //When all cells in square are validated
                    this.ValidateSquare(counter, yBoard, xBoard);
                }
            }
        }

        /// <summary>
        /// Loops in between the 9 cells of the square to validate the full
        /// </summary>
        /// <param name="resultBoard">original board</param>
        /// <param name="playerBoard">player input board</param>
        /// <param name="yBoard">y coords</param>
        /// <param name="xBoard">x coords</param>
        private void LoopSquare(int[,] resultBoard, int[,] playerBoard, int yBoard, int xBoard)
        {
            for (int ySquare = 0; ySquare < 3; ySquare++)
            {

                for (int xSquare = 0; xSquare < 3; xSquare++)
                {

                    if (resultBoard[ySquare * yBoard, xSquare * xBoard]
                    == playerBoard[ySquare * yBoard, xSquare * xBoard])
                    {
                        counter++;
                    }

                }
            }
        }

        /// <summary>
        /// If the the values in a square are validated adds one to the prop SquareBoard
        /// </summary>
        /// <param name="countValidInSquare">if 9 square is valid</param>
        /// <param name="yBoard">coord y</param>
        /// <param name="xBoard">coord x</param>
        private void ValidateSquare(int countValidInSquare, int yBoard, int xBoard)
        {
            if (countValidInSquare == 9)
            {
                this.SquareBoard[yBoard, xBoard] = 1;
            }
        }

    }
}
