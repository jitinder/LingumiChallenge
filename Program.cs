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

            String[] ids = { "cat", "bad", "bad", "pus" };

            Word[] result = filterList(new List<Word>(words), new List<string>(ids));
            result = sortByTimesLearned(result);
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

            return filteredList.ToArray();
        }

        private static Word[] sortByTimesLearned(Word[] words)
        {
            quickSort(words, 0, words.Length - 1);
            return words;
        }

        // Quicksort Algorithms
        // https://www.programmingalgorithms.com/algorithm/quick-sort-recursive

        private static int partition(Word[] array, int left, int right)
        {
            int pivot = array[right].getNumberOfTimesLearned();
            int temp;
            int i = left;

            for (int j = left; j < right; ++j)
            {
                if (array[j].getNumberOfTimesLearned() <= pivot)
                {
                    temp = array[j].getNumberOfTimesLearned();
                    array[j].setNumberOfTimesLearned(array[i].getNumberOfTimesLearned());
                    array[i].setNumberOfTimesLearned(temp);
                    i++;
                }
            }

            array[right] = array[i];
            array[i].setNumberOfTimesLearned(pivot);

            return i;
        }

        public static void quickSort(Word[] array, int left, int right)
        {
            if (left < right)
            {
                int q = partition(array, left, right);
                quickSort(array, left, q - 1);
                quickSort(array, q + 1, right);
            }
        }
    }
}
