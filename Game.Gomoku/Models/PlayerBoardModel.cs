namespace Game.Gomoku.Models
{
    public class PlayerBoardModel
    {
        public string BoardName { get; set; }
        public List<string> BoardPoints { get; set; } = new List<string>();
        public List<string> WhitePlayerPoints { get; set; } = new List<string>();
        public List<string> BlackPlayerPoints { get; set; } = new List<string>();
    }
}
