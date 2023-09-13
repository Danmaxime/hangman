using System;
using System.Collections.Generic;
using System.IO;

namespace hangman
{
    public class Word
    {
        private static readonly List<string> WordList = new List<string>();
        private static readonly Dictionary<string ,string> WordDictionaryList = new Dictionary<string, string>();
        /* We can add new words to WordList below.
         * Each time the player starts a new game,
         * a random word is taken from WordList.
         * Take one word when the game starts.
         */
        private static Word wordPack;
        public static Word WordPack
        {
            get
            {
                if (wordPack == null)
                {
                    wordPack = new Word();
                }
                return wordPack;
            }
        }

        public KeyValuePair<string,string> TheWord { get; private set; }

        /*
         * Static constructor for loading all
         * the words into the static List<string> 
         * WordList.
         */

        private Word()
        {
            StreamReader sr = new StreamReader("word_list.csv");
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line == null)  continue;
                var wordPair = line.Split(',');
                if (WordDictionaryList.ContainsKey(wordPair[0])) continue;
                WordDictionaryList.Add(wordPair[0], wordPair[1]);
            }
        }

        public void LoadWord()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, WordDictionaryList.Count);
            TheWord = WordDictionaryList.ElementAt(num);

            while (TheWord.Value.Length > 12)
            {
                num = rnd.Next(0, WordDictionaryList.Count);
                TheWord = WordDictionaryList.ElementAt(num);
            }
        }

    }
}
