using Game.Gomoku.Abstract;


namespace Game.Gomoku.Infrastructure
{
    public class CheckVertical : FiveRows
    {
        private readonly List<string> _stone;
        private readonly string _point;

        public CheckVertical(List<string> _stone, string _point)
        {
            this._stone = _stone;
            this._point = _point;
        }
        public override int CountRows()
        {
            var validCount = 1;
            CenterToTop(_point);
            CenterToBottom(_point);

            void CenterToTop(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointInteger = pointInteger.MoveInteger(1);

                if (IsIntegerOutsideBoard(pointInteger))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToTop($"{pointChar.ToString()}{pointInteger}");
                }
            }

            void CenterToBottom(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointInteger = pointInteger.MoveInteger(-1);

                if (IsIntegerOutsideBoard(pointInteger))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToBottom($"{pointChar.ToString()}{pointInteger}");
                }
            }

            return validCount;
        }
    }
}