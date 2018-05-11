using System;
using System.Collections.Generic;
using System.Text;

namespace Lingumi
{
    class Word
    {
        private string id;
        private bool hasAlreadyCollected;
        private int numberOfTimesLearned;

        public Word(string id, bool hasAlreadyCollected, int numberOfTimesLearned)
        {
            this.id = id;
            this.hasAlreadyCollected = hasAlreadyCollected;
            this.numberOfTimesLearned = numberOfTimesLearned;
        }

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
        
        override
        public string ToString()
        {
            return "ID = " + id + " Collected? " + hasAlreadyCollected + " Learnt " + numberOfTimesLearned + " times";
        }
    }
}
