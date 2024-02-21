namespace Ur.ConsoleApp;

internal class Square(char id, Square? next = null, bool isRosette = false, Player? owner = null)

{
    public char Id { get; } = id;
    public Square? Next { get; set; } = next;
    private bool IsRosette { get; } = isRosette;
    private Piece? Occupant { get; set; } = null;
    public Player? Owner { get; set; } = owner;

    public string GetDisplayRepresentation()
    {
        if (Occupant != null)
            return Occupant.ToString();
        else if (IsRosette)
            return "*";
        else
            return Id.ToString();
    }
}