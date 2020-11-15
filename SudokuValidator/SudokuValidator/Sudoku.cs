using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace SudokuValidator
{
    class Sudoku
    {
        private SudokuGenerator SudokuGenerator;

        private int[,] Board;
        private int[,] BoardHidden;
        private int[,] BoardPlayer;

        private Stopwatch Watch;

        private SudokuLineValidator XLineListener;
        private SudokuColumnValidator YLineListener;
        private SudokuSquareValidator SquareListener;

        /// <summary>
        /// Initialize sudoku and execute validations in parallel threads
        /// </summary>
        public void ExecuteThreaded()
        {
            //Init board
            this.Initialize();

            this.SetStopWatch();

            //Initizialise workers
            ThreadStart i1 = new ThreadStart(StartLineValidator);
            ThreadStart i2 = new ThreadStart(StartColumnValidator);
            ThreadStart i3 = new ThreadStart(StartSquareValidator);

            //this.Show(this.Board);
            //this.Show(this.BoardHidden);
            this.ShowSimulation(this.Board, this.BoardHidden);

            UnsetStopWatch();
        }

        /// <summary>
        /// Set and Starts Line Validator
        /// </summary>
        private void StartLineValidator()
        {
            this.XLineListener = new SudokuLineValidator(this);
            this.XLineListener.CheckLines(this.Board, this.Board);
        }

        /// <summary>
        /// Set and Starts Column Validator
        /// </summary>
        private void StartColumnValidator()
        {
            this.YLineListener = new SudokuColumnValidator(this);
            this.YLineListener.CheckColumns(this.Board, this.Board);
        }

        /// <summary>
        /// Set and Starts Square Validator
        /// </summary>
        private void StartSquareValidator()
        {
            this.SquareListener = new SudokuSquareValidator(this);
            this.SquareListener.CheckSquares(this.Board, this.Board);
        }

        /// <summary>
        /// Initialize sudoku and execute validations in procedural
        /// </summary>
        public void ExecuteProcedural()
        {
            //Init board
            this.Initialize();

            this.SetStopWatch();

            //Initizialise worker
            this.XLineListener = new SudokuLineValidator(this);
            this.XLineListener.CheckLines(this.Board, this.Board);

            this.YLineListener = new SudokuColumnValidator(this);
            this.YLineListener.CheckColumns(this.Board, this.Board);

            this.SquareListener = new SudokuSquareValidator(this);
            this.SquareListener.CheckSquares(this.Board, this.Board);

            //this.Show(this.Board);
            //this.Show(this.BoardHidden);
            this.ShowSimulation(this.Board, this.BoardHidden);

            UnsetStopWatch();
        }

        /// <summary>
        /// initialize timer
        /// </summary>
        private void SetStopWatch()
        {
            Watch = Stopwatch.StartNew();
            Watch.Start();
        }

        /// <summary>
        /// stop and display timer
        /// </summary>
        private void UnsetStopWatch()
        {
            Watch.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(Watch.Elapsed);
            Console.ForegroundColor = ConsoleColor.White;

        }

        /// <summary>
        /// Initialize Sudoku Generator and instantiate the Board with all the results
        /// and the Boardhidden containing the board with hidden values.
        /// 
        /// Note: A solution using 2 arrays instead of a 3D array is implemented 
        /// to help into portability and easy understanding sacrificing optimisation.
        /// </summary>
        private void Initialize()
        {
            this.SudokuGenerator = new SudokuGenerator();
            this.Board = this.SudokuGenerator.InitializeBoard();
            this.BoardHidden = this.SudokuGenerator.GenerateHiddenNumbers(60);
            this.BoardPlayer = this.BoardHidden.Clone() as int[,];
        }


        /// <summary>
        /// Displays the selected board
        /// </summary>
        /// <param name="boardToShow">board to display on console</param>
        private void Show(int[,] boardToShow)
        {

            for (int y = 0; y < 9; y++)
            {

                for (int x = 0; x < 9; x++)
                {

                    if (boardToShow[y, x] == 0)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(boardToShow[y, x]);

                    }

                }

                Console.WriteLine();

            }

        }

        // <summary>
        /// Simulate user input in console
        /// </summary>
        /// <param name="boardToShow">board to display on console</param>
        private void ShowSimulation(int[,] boardToShow, int[,] boardHidden)
        {

            for (int y = 0; y < 9; y++)
            {
                if(y+1%3 == 0) { Console.Write('-'); }

                for (int x = 0; x < 9; x++)
                {
                    if (y + 1 % 3 == 0) { Console.Write('|'); }

                    if (boardHidden[y, x] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(boardToShow[y, x]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(boardToShow[y, x]);

                    }

                }

                Console.WriteLine();

            }

           

        }
    }

}
