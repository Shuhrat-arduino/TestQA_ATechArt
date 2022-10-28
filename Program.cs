using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestQA_ATechArt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"Top100ChessPlayers.csv";
            if(File.Exists(filePath))
            {
                List<ChessPlayer> chessPlayers = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(v => ChessPlayer.FromCsv(v))
                .ToList();

                List<ChessPlayer> chessPlayersTop10 = chessPlayers.Where(obj => obj.B_Year > 1980).ToList();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(
                        $"{chessPlayersTop10[i].Rank}\t"    +
                        $"{chessPlayersTop10[i].Name}\t"    +
                        $"{chessPlayersTop10[i].Title}\t"   +
                        $"{chessPlayersTop10[i].Country}\t" +
                        $"{chessPlayersTop10[i].Rating}\t"  +
                        $"{ chessPlayersTop10[i].Games}\t"  +
                        $"{chessPlayersTop10[i].B_Year};");
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
    }
    class ChessPlayer
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public int Games { get; set; }
        public int B_Year { get; set; }
        public static ChessPlayer FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            ChessPlayer chessPlayer = new ChessPlayer();
            chessPlayer.Rank = int.Parse(values[0]);
            chessPlayer.Name = values[1];
            chessPlayer.Title = values[2];
            chessPlayer.Country = values[3];
            chessPlayer.Rating = int.Parse(values[4]);
            chessPlayer.Games = int.Parse(values[5]);
            chessPlayer.B_Year = int.Parse(values[6]);

            return chessPlayer;
        }
    }
}
