using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace BikeShopAPI.Entities
{
    public class BikeTrickSequence
    {
        public class Trick
        {
            public string Action { get; set; } = string.Empty;
            public int Count { get; set; }
            public char DifficultyLetter { get; set; }
            public double Modifier { get; set; }
        }

        public List<Trick> Tricks { get; set; } = new List<Trick>();
        public double Difficulty => CalculateDifficulty();

        private static readonly Dictionary<char, double> DifficultyModifiers = new()
        {
            {'A', 1.0},
            {'B', 1.2},
            {'C', 1.4},
            {'D', 1.6},
            {'E', 1.8}
        };

        public static BikeTrickSequence Parse(string signature)
        {
            var sequence = new BikeTrickSequence();
            var regex = new Regex(@"([LH RST])(\d+)([A-E])", RegexOptions.Compiled);
            var matches = regex.Matches(signature);
            foreach (Match match in matches)
            {
                var action = match.Groups[1].Value;
                var count = int.Parse(match.Groups[2].Value);
                var diffLetter = match.Groups[3].Value[0];
                sequence.Tricks.Add(new Trick
                {
                    Action = action,
                    Count = count,
                    DifficultyLetter = diffLetter,
                    Modifier = DifficultyModifiers[diffLetter]
                });
            }
            return sequence;
        }

        private double CalculateDifficulty()
        {
            double total = 0.0;
            for (int i = 0; i < Tricks.Count; i++)
            {
                var trick = Tricks[i];
                double baseScore = trick.Count * trick.Modifier;
                // Special rules
                if (trick.Action == "R" && i > 0 && Tricks[i - 1].Action == "L")
                {
                    baseScore *= 2; // Cash Roll after 360
                }
                if (trick.Action == "S" && i > 0 && Tricks[i - 1].Action == "T")
                {
                    baseScore *= 3; // Barspin after Table
                }
                total += baseScore;
            }
            return Math.Round(total, 2);
        }
    }
}