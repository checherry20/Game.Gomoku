using Game.Gomoku.Abstract;


namespace Game.Gomoku.Infrastructure
{
    public class CheckHorizontal : FiveRows
    {
        private readonly List<string> _stone;
        private readonly string _point;

        public CheckHorizontal(List<string> stone, string point)
        {
            _stone = stone;
            _point = point;
        }
        public override int CountRows()
        {
            var validCount = 1;
            CenterToRight(_point);
            CenterToLeft(_point);

            void CenterToRight(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointChar = NextOrPreviousLetter(pointChar, 1);

                if (IsLetterOutsideBoard(pointChar))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToRight($"{pointChar.ToString()}{pointInteger}");
                }
            }

            void CenterToLeft(string currentPoint)
            {
                if (validCount == 5)
                    return;

                char pointChar = char.Parse(currentPoint[..1]);
                int pointInteger = int.Parse(currentPoint[1..]);

                pointChar = NextOrPreviousLetter(pointChar, -1);

                if (IsLetterOutsideBoard(pointChar))
                    return;

                if (_stone.Contains($"{pointChar.ToString()}{pointInteger}"))
                {
                    validCount++;
                    CenterToLeft($"{pointChar.ToString()}{pointInteger}");
                }
            }

            return validCount;
        }
    }
}