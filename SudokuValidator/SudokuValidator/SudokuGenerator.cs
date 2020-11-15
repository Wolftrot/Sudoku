using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuValidator
{
    class SudokuGenerator
    {

        private int[,] Board;
        private int[,] BoardHidden;
        private Random Rnd;

        /// <summary>
        /// Constructor
        /// </summary>
        public SudokuGenerator()
        {
            //init randomizer
            this.Rnd = new Random();

            //Init board
            this.Board = new int[9, 9];
            this.BoardHidden = new int[9, 9];

        }


        /// <summary>
        /// Generation template of a sudoku board
        /// </summary>
        /// <return>board array</return>
        public int[, ] InitializeBoard()
        {

            //Generate board
            this.GenerateBoard();

            //Randomize nb loops to mix the board
            int iterations = Rnd.Next(100);

            //Interate Randomize
            for (int i = 0; i < iterations; i++)
            {
                //Randomize
                this.RandomizeBoard(Rnd.Next(2));
            }


            return this.Board;

        }


        /*
         * Generates the numbers on the board using a standarized algorithm consisting in following a sequence:
         *  123456789
         *  456789123
         *  789123456
         *  234567891
         *  567891234
         *  891234567
         *  345678912
         *  678912345
         *  912345678
         * 
         */
        private void GenerateBoard()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    this.Board[y, x] = (y * 3 + y / 3 + x) % 9 + 1;
                }
            }
        }

        /*
         * Randomize the selection of columns and rows to swap in order to mix the whole board
         */
        private void RandomizeBoard(int swapper)
        {
            int i1 = Rnd.Next(0, 3);
            int i2 = 0;

            int floor = 0;
            int ceiling = 3;

            for (int i = 0; i < 3; i++)
            {
                //Get the 2 columns to swap in the range
                i1 = Rnd.Next(floor, ceiling);

                do
                {

                    i2 = Rnd.Next(floor, ceiling);

                } while (i1 == i2);

                //Increment the range
                floor += 3;
                ceiling += 3;

                //Decide whether to swap columns or lines
                if (swapper == 1)
                {
                    this.SwapXLines(i1, i2);
                }
                else
                {
                    this.SwapYLines(i1, i2);
                }
            }

        }

        /*
         * Swaps the lines in x axis by set of 3 (square) in order to mix them
         * 1,2,3, -> 3,1,2
         * 4,5,6, -> 6,5,4
         * 6,7,8  -> 8,7,6
         * 
         */
        private void SwapXLines(int col1, int col2)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    this.Swap(ref this.Board[y, col1], ref this.Board[y, col2]);
                }
            }
        }

        /*
         * Swaps the lines in y axis by set of 3 (square) in order to mix them
         * 1,2,3, -> 6,7,8
         * 4,5,6, -> 4,5,6
         * 6,7,8  -> 1,2,3
         * 
         */
        private void SwapYLines(int line1, int line2)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    this.Swap(ref this.Board[line1, x], ref this.Board[line2, x]);
                }
            }
        }

        /*
         * Swaps the 2 given values
         */
        private void Swap(ref int i1, ref int i2)
        {

            int temp = i1;
            i1 = i2;
            i2 = temp;

        }

        /// <summary>
        /// Generate hidden numbers by setting 0 in the cells of "BoardHidden" which clonates from the
        /// original board.
        /// To avoid transcribing 0s 
        /// </summary>
        /// <param name="nbHidden">Sets diffuculty level: 40 easy; 50 medium; 60 Hard</param>
        /// <returns>board array</returns>
        public int[,] GenerateHiddenNumbers( int maxHidden)
        {
            //clone original
            this.BoardHidden = Board.Clone() as int[,];

            //counter of hiddens
            int hiddenCounts = 1;


            do
            {
                //Select random coords
                int x = Rnd.Next(9);
                int y = Rnd.Next(9);

                //Check if 0 is not set before
                if (this.BoardHidden[y,x] != 0)
                {

                    this.BoardHidden[y, x] = 0;

                    hiddenCounts++;

                }

            } while (hiddenCounts != maxHidden);


            return this.BoardHidden;
        }


       

    }
}
