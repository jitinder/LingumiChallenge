using System;
using System.Collections;
using System.Collections.Generic;

namespace Lingumi
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string[] sendStickers(List<Word> words, List<string> wordIds)
        {
            // Updating, Filtering then sorting in Descending order by numberOfTimesLearned
            Word[] filtered = filterList(words, wordIds);
            filtered = sortByTimesLearned(filtered);
            // Sideline already sent Stickers for prioritising not sent stickers
            List<Word> sent = new List<Word>();
            List<Word> unsent = new List<Word>();
            for (int i = 0; i < filtered.Length; i++)
            {
                if (filtered[i].isAlreadyCollected()) {
                    sent.Add(filtered[i]);
                } else {
                    unsent.Add(filtered[i]);
                }
            }
            string[] toSend = new string[3];

            int fromUnsent = unsent.Count; // Number of Items in unsent
            if(fromUnsent > 3){
                fromUnsent = 3; // If Length of unsent > 3, set fromUnsent to 3, for setting toSend Values
            }
            int fromSent = 3 - fromUnsent; // Number of Items to put in toSend from Sent

            // Set data from unsent
            for (int i = 0; i < fromUnsent; i++) {
                toSend[i] = unsent[i].getId();
            }
            // Set data from sent
            for (int j = 0; j < fromSent; j++) {
                toSend[fromUnsent + j - 1] = sent[j].getId();
            }

            return toSend;
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
            Array.Reverse(array); // Descending Order
        }
    }
}
