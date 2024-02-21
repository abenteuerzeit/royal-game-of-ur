// See https://aka.ms/new-console-template for more information

using Ur.ConsoleApp;

Console.WriteLine("The Royal Game of Ur");

Player p1 = new(1);
Player p2 = new(2);

Console.WriteLine("{0} vs. {1}", p1, p2);

Board gameBoard = new(p1, p2);

Console.WriteLine(gameBoard.ToString());