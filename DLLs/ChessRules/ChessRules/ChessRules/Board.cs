using System.Runtime.Remoting.Messaging;

namespace ChessRules
{
    class Board
    {
        public string fen  { get; private set; }
        public Color moveColor { get; private set; }

        private Figure[,] figures;

        public Board(string fen)
        {
            this.fen = fen;
            figures=new Figure[8,8];
            Init();
        }

        public Board Move(FigureMoving fm)
        {
            Board next=new Board(fen);
            next.SetFigureAt(fm.from,Figure.None);
            next.SetFigureAt(fm.to, fm.figure);
            next.moveColor = moveColor.FlipColor();
            return next;
        }

        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
            {
                return figures[square.x, square.y];
            }

            return Figure.None;
        }

        private void SetFigureAt(Square square, Figure figure)
        {
            if (square.OnBoard())
            {
                figures[square.x, square.y] = figure;
            }
        }

        private void Init()
        {
            SetFigureAt(new Square("a1"),Figure.WhiteKing );
            SetFigureAt(new Square("h8"), Figure.BlackKing);
            moveColor = Color.White;

        }
    }
}
