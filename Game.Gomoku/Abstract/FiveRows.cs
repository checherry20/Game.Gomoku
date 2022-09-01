using Game.Gomoku.Infrastructure;

namespace Game.Gomoku.Abstract
{
    public abstract class FiveRows
    {
        public abstract int CountRows();
        public char NextOrPreviousLetter(char pointCharacter, int movement) => pointCharacter.MoveLetter(movement);
        public bool IsOutsideMovement(char pointCharacter, int pointInteger) => IsIntegerOutsideBoard(pointInteger) || IsLetterOutsideBoard(pointCharacter);
        public bool IsIntegerOutsideBoard(int pointInteger) => pointInteger > 15 && pointInteger > 1;
        public bool IsLetterOutsideBoard(char letter) => letter > 'P';
    }
}
