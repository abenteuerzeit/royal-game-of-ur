using System.Text;

namespace Ur.ConsoleApp;

internal class Board
{
    private readonly Dictionary<string, Square> _squares;

    public Board(Player p1, Player p2)
    {
        var exclusiveIds = new[] { 'A', 'B', 'C', 'D', 'K', 'L', 'M', 'N' };
        var sharedIds = new[] { 'E', 'F', 'G', 'H', 'I', 'J' };
        var rosettes = new[] { 'D', 'H', 'N' };

        var paths = new[] { p1, p2 }.SelectMany(player =>
            exclusiveIds.Select(id => new Square(id, owner: player, isRosette: rosettes.Contains(id)))
        ).Concat(
            sharedIds.Select(id => new Square(id, isRosette: rosettes.Contains(id)))
        ).ToList();

        LinkSquares(paths);

        _squares = paths.ToDictionary(sq => $"{sq.Owner?.Number ?? 0}{sq.Id}");
    }

    private static void LinkSquares(List<Square> squares)
    {
        var orderedSquares = squares
            .OrderBy(sq => sq.Owner?.Number ?? 0)
            .ThenBy(sq => sq.Id)
            .ToList();

        for (var i = 0; i < orderedSquares.Count - 1; i++)
            if (orderedSquares[i].Owner == orderedSquares[i + 1].Owner || orderedSquares[i].Owner == null)
                orderedSquares[i].Next = orderedSquares[i + 1];
    }

    private IEnumerable<char[]> CreateBoardArray()
    {
        var layout = new char[3][];
        for (var i = 0; i < 3; i++)
            layout[i] = new string(' ', 8).ToCharArray();

        foreach (var square in "EFGHIJKL") layout[1]["EFGHIJKL".IndexOf(square)] = square;

        foreach (var entry in _squares)
        {
            var key = entry.Key;
            var square = entry.Value;
            var symbol = square.GetDisplayRepresentation();
            var row = key.StartsWith("1") ? 2 : key.StartsWith("2") ? 0 : 1;
            var col = -1;

            if ("ABCD".Contains(square.Id))
                col = "DCBA".IndexOf(square.Id);
            else if (square.Id == 'M' || square.Id == 'N')
                col = square.Id == 'N' ? 6 : 7;
            else if (square.Id == 'H')
                col = 3;

            if (col != -1) layout[row][col] = symbol[0];
        }

        return layout;
    }


    public override string ToString()
    {
        var boardArray = CreateBoardArray();
        var builder = new StringBuilder();

        foreach (var row in boardArray)
        {
            foreach (var cell in row)
            {
                builder.Append(cell != '0' ? cell : ' ');
                builder.Append(' ');
            }

            if (builder.Length > 0) builder.Length--;
            builder.AppendLine();
        }

        return builder.ToString();
    }
}