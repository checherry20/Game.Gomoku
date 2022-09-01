using Game.Gomoku.Abstract;

namespace Game.Gomoku.Infrastructure
{
    public class MovementChecker : IMovementChecker
    {
        public bool Check(List<string> stone, string point)
        {
            List<FiveRows> fiveRows = new List<FiveRows>();
            fiveRows.Add(new CheckLeadingDiagonal(stone, point));
            fiveRows.Add(new CheckCounterDiagonal(stone, point));
            fiveRows.Add(new CheckHorizontal(stone, point));
            fiveRows.Add(new CheckVertical(stone, point));

            foreach (var item in fiveRows)
            {
                if(item.CountRows() == 5)
                    return true;
            }

            return false;
        }
    }
}
