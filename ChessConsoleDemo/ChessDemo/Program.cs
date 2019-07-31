using System;
using ChessRules;

namespace ChessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Chess chess=new Chess();
            chess.GetFigureAt(3, 5);
            while (true)
            {
                Console.WriteLine(chess.Fen);
                string move = Console.ReadLine();
                if (move == "")
                {
                    break;
                }
                chess = chess.Move(move);
            }
        }
    }
}
