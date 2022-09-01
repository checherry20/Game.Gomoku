namespace Game.Gomoku.Infrastructure
{
    public interface IMovementChecker
    {
        bool Check(List<string> stone, string point);
    }
}