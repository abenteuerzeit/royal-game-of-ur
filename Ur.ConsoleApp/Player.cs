using System.Text;

namespace Ur.ConsoleApp;

internal class Player
{
    private const int PieceCount = 7;

    public int Number { get; }
    private Queue<Piece> Pieces { get; }

    public Player(int number)
    {
        Number = number;
        Pieces = new Queue<Piece>(PieceCount);
        for (var i = 0; i <= PieceCount; i++) Pieces.Enqueue(new Piece(this));
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append("Player ");
        sb.Append(Number);
        sb.Append(' ');
        sb.Append('(');
        sb.Append("pieces: ");
        sb.Append(Pieces.Count);
        sb.Append(')');
        return sb.ToString();
    }
}