using Game.Gomoku.Abstract;


namespace Game.Gomoku.Infrastructure
{
    public class CheckCounterDiagonal : FiveRows
    {
        private readonly List<string> _stone;
        private readonly string _point;

        public CheckCounterDiagonal(List<string> stone, string point)
        {
            _stone = stone;
            _point = point;
        }

        public override int CountRows()
        {
            var validCount = 1;
            CenterToTopRight(_point);
            CenterToBottomLeft(_point);

            void CenterToTopRight(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointChar = NextOrPreviousLetter(pointChar, 1);
                pointInteger = pointInteger.MoveInteger(1);

                if (IsOutsideMovement(pointChar, pointInteger))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToTopRight($"{pointChar.ToString()}{pointInteger}");
                }
            }

            void CenterToBottomLeft(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointChar = NextOrPreviousLetter(pointChar, -1);
                pointInteger = pointInteger.MoveInteger(-1);

                if (IsOutsideMovement(pointChar, pointInteger))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToBottomLeft($"{pointChar.ToString()}{pointInteger}");
                }
            }

            return validCount;
        }
    }
}