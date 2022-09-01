namespace Game.Gomoku.Infrastructure
{
    public static class Extensions
    {
        public static char MoveLetter(this char letterIn, int moveLetterTo)
        {
            int ascii = (int)letterIn;
            int nextAscii = ascii + moveLetterTo;
            char nextChar = (char)nextAscii;
            return nextChar;
        }

        public static int MoveInteger(this int numberIn, int moveNumber)
        {
            return numberIn + moveNumber;
        }
    }
}
