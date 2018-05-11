using System;
using System.Collections;
using System.Collections.Generic;

namespace Lingumi
{
    class Program
    {
        static void Main(string[] args)
        {
            Word a = new Word("apple", false, 2);
            Word b = new Word("bad", false, 0);
            Word c = new Word("cat", true, 5);
            Word d = new Word("dog", false, 0);

            Word[] words = { a, b, c, d };

            String[] ids = { "bad", "bad", "cat", "pus" };

            Word[] result = filterList(new List<Word>(words), new List<string>(ids));
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadKey();
        }

        public void sendStickers(List<Word> words, List<string> wordIds)
        {

        }

        private static Word[] filterList(List<Word> words, List<string> wordIds)
        {
            List<Word> filteredList = new List<Word>();

            for (int i = 0; i < words.Count; i++)
            {
                Word currentWord = words[i];
                for (int j = 0; j < wordIds.Count; j++)
                {
                    String currentID = wordIds[j];
                    if (currentWord.getId().Equals(currentID))
                    {
                        currentWord.setNumberOfTimesLearned(currentWord.getNumberOfTimesLearned() + 1);
                    }
                }
                if (currentWord.getNumberOfTimesLearned() > 0)
                {
                    filteredList.Add(currentWord);
                }
            }

            Word[] toReturn = filteredList.ToArray();
            return toReturn;
        }
    }
}
