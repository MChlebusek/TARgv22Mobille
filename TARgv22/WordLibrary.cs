
using System;
using System.Collections.Generic;
using System.Text;


namespace TARgv22
{
    public static class WordLibrary
    {
        private static List<string> words = new List<string>
        {
            "apple", "lemon", "peach", "mango",
            "berry", "guava", "melon", "dates",
            "grape", "water", "teeth", "vodka",
            "olive", "orange", "zebra",
            "tiger", "fence", "dance", "black"
        };

        private static Random random = new Random();

        public static string GetRandomWord()
        {
            int index = random.Next(words.Count);
            return words[index];
        }
    }
}