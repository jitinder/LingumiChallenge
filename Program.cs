using System;
using System.Collections;
using System.Collections.Generic;

namespace Lingumi
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramTest programTest = new ProgramTest();
            //programTest.testMultipleWords();
        }

        /// <summary>
        /// Function for determining and returning 3 most appropriate stickers
        /// from an overall List of Words and a list of Word IDs learnt in the
        /// most recent lesson
        /// </summary>
        /// <param name="words">List of Overall Words (Type: Word)</param>
        /// <param name="wordIds">List of Word IDs (Type: String)</param>
        /// <returns>Array of 3 Strings where each string is the Word ID for the sticker to reward</returns>
        public string[] sendStickers(List<Word> words, List<string> wordIds)
        {
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

            string[] toSend = new string[3]; // The Array that will be returned

            int fromUnsent = unsent.Count;
            if(fromUnsent > 3){
                fromUnsent = 3; // If Length of unsent > 3, set fromUnsent to 3, for setting toSend Values
            }
            // Set data from unsent
            for (int i = 0; i < fromUnsent; i++)
            {
                toSend[i] = unsent[i].getId();
            }

            int fromSent = 0;
            if(fromUnsent == 0)
            {
                fromSent = sent.Count;
            }
            if (sent.Count >= 3 - fromUnsent) {
                fromSent = 3 - fromUnsent; // Number of Items to put in toSend from Sent
            }
            // Set data from sent (if needed)
            for (int j = 0; j < fromSent; j++) {
                toSend[fromUnsent + j] = sent[j].getId();
            }

            return toSend;
        }

        /// <summary>
        /// Updates the value of numberOfTimesLearned for all Words that were learnt in the previous lesson
        /// Creates a new list from the overall list which only contains Words with numberOfTimesLearned > 0
        /// </summary>
        /// <param name="words">List of Overall Words (Type: Word)</param>
        /// <param name="wordIds">List of Word IDs (Type: String)</param>
        /// <returns>An updated and appropriately filtered list of Words</returns>
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

        /// <summary>
        /// Sorts an Array of Words using quickSort and reverses it to obtain 
        /// Descending Order of numberOfTimesLearned
        /// </summary>
        /// <param name="words">Array of Words to sort (Type: Word)</param>
        /// <returns></returns>
        private static Word[] sortByTimesLearned(Word[] words)
        {
            quickSort(words, 0, words.Length - 1);
            Array.Reverse(words); // Descending Order
            return words;
        }

        // Functions for implementing QuickSort on an Array of Words

        /*************************************************************************************** 
        *    Basic code for QuickSort on an array of Integers used from:
        *    
        *    Title:         Quick Sort Recursive Implementation
        *    Author:        Programming Algorithms
        *    Date:          11th May 2018
        *    Code version:  1
        *    Availability:  https://www.programmingalgorithms.com/algorithm/quick-sort-recursive
        *
        ***************************************************************************************/

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
