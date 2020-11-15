using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();

            Console.WriteLine();
            Console.WriteLine("PROCEDURAL SUDOKU VALIDATION");

            sudoku.ExecuteProcedural();

            Console.WriteLine();
            Console.WriteLine("THREADED SUDOKU VALIDATION");

            sudoku.ExecuteThreaded();

            Console.Read();
        }
    }
}
