using Game.Gomoku.Abstract;


namespace Game.Gomoku.Infrastructure
{
    public class CheckLeadingDiagonal : FiveRows
    {
        private readonly List<string> _stone;
        private readonly string _point;

        public CheckLeadingDiagonal(List<string> stone, string point)
        {
            _stone = stone;
            _point = point;
        }
        public override int CountRows()
        {
            var validCount = 1;
            CenterToTopLeft(_point);
            CenterToBottomRight(_point);

            void CenterToTopLeft(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointChar = NextOrPreviousLetter(pointChar, -1);
                pointInteger = pointInteger.MoveInteger(1);

                if (IsOutsideMovement(pointChar, pointInteger))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToTopLeft($"{pointChar.ToString()}{pointInteger}");
                }
            }

            void CenterToBottomRight(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointChar = NextOrPreviousLetter(pointChar, 1);
                pointInteger = pointInteger.MoveInteger(-1);

                if (IsOutsideMovement(pointChar, pointInteger))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToBottomRight($"{pointChar.ToString()}{pointInteger}");
                }
            }

            return validCount;
        }
    }
}