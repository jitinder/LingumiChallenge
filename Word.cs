using System;
using System.Collections.Generic;
using System.Text;

namespace Lingumi
{
    /// <summary>
    /// Class representing a Word Object.
    /// </summary>
    class Word
    {
        private string id; // Word ID
        private bool hasAlreadyCollected; // Whether the Word has been collected before or not.
        private int numberOfTimesLearned; // Number of Times the Word has been learned.

        public Word(string id, bool hasAlreadyCollected, int numberOfTimesLearned)
        {
            this.id = id;
            this.hasAlreadyCollected = hasAlreadyCollected;
            this.numberOfTimesLearned = numberOfTimesLearned;
        }

        /*
         * Basic Getters and Setters
         */
        public string getId()
        {
            return this.id;
        }

        public bool isAlreadyCollected()
        {
            return this.hasAlreadyCollected;
        }

        public int getNumberOfTimesLearned()
        {
            return this.numberOfTimesLearned;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public void setCollected(bool hasAlreadyCollected)
        {
            this.hasAlreadyCollected = hasAlreadyCollected;
        }

        public void setNumberOfTimesLearned(int numberOfTimesLearned)
        {
            this.numberOfTimesLearned = numberOfTimesLearned;
        }
        
        /*
         * Overriden function for ease of debugging
         */
        override
        public string ToString()
        {
            return "ID = " + id + " Collected? " + hasAlreadyCollected + " Learnt " + numberOfTimesLearned + " times";
        }
    }
}
