namespace Ur.ConsoleApp;

internal class Piece(Player owner)
{
    public Player Owner { get; } = owner;
    public Square? Position { get; set; } = null;
}