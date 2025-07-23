
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BikeShopAPI.Entities
{
    public class BikeTrickSequence
    {
        public List<Trick> Tricks { get; set; } = new List<Trick>();
        public double Difficulty { get; set; }

        public class Trick
        {
            public string? Action { get; set; }
            public int Count { get; set; }
            public char DifficultyModifier { get; set; }
            public double ModifierValue => DifficultyModifiers.ContainsKey(DifficultyModifier) ? DifficultyModifiers[DifficultyModifier] : 1.0;
            public double Score { get; set; }
            public string ActionName => Action != null && ActionNames.ContainsKey(Action) ? ActionNames[Action] : Action ?? string.Empty;

            public static readonly Dictionary<char, double> DifficultyModifiers = new Dictionary<char, double>
            {
                {'A', 1.0},
                {'B', 1.2},
                {'C', 1.4},
                {'D', 1.6},
                {'E', 1.8}
            };

            public static readonly Dictionary<string, string> ActionNames = new Dictionary<string, string>
            {
                {"L", "360"},
                {"H", "Tuck No-Hander"},
                {"R", "Cash Roll"},
                {"S", "Barspin"},
                {"T", "Table"}
            };
        }

        public static BikeTrickSequence Parse(string signature)
        {
            var sequence = new BikeTrickSequence();
            var regex = new Regex(@"([A-Z])(\d+)([A-E])");
            var matches = regex.Matches(signature);
            Trick? prevTrick = null;
            double totalDifficulty = 0.0;

            foreach (Match match in matches)
            {
                var action = match.Groups[1].Value;
                var count = int.Parse(match.Groups[2].Value);
                var diffMod = match.Groups[3].Value[0];
                var trick = new Trick
                {
                    Action = action,
                    Count = count,
                    DifficultyModifier = diffMod
                };
                double baseDifficulty = count * trick.ModifierValue;

                // Special rules
                if (action == "R" && prevTrick?.Action == "L")
                {
                    baseDifficulty *= 2; // Cash Roll after 360
                }
                if (action == "S" && prevTrick?.Action == "T")
                {
                    baseDifficulty *= 3; // Barspin after Table
                }

                trick.Score = baseDifficulty;
                totalDifficulty += baseDifficulty;
                sequence.Tricks.Add(trick);
                prevTrick = trick;
            }
            sequence.Difficulty = Math.Round(totalDifficulty, 2);
            return sequence;
        }
    }
}