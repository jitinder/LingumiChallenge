# LingumiChallenge
Solution to the C# Lingumi Challenge


## Testing Guidelines

All the Tests (2 at the moment) are written in ProgramTest.cs. 

**To Run a Test Case**

Ensure the test exists in ProgramTest.cs. In the Main method of Program.cs, call the test function after instantiating the ProgramTest class.

**To Create a Test**

Write the test as a function that calls the sendStickers method with the appropriate arguments. Use "Debug.Assert" to check whether the obtained result is correct or not.

## Responses to Questions

**1. How does the algorithm work from a high-level perspective?**


    The algorithm accepts the two lists (Words and Word IDs of words learnt in the previous lesson) and creates a word list that has the updated values of numberOfTimesLearned for the Words that were recently learned.
    Then it edits this updated list by removing words that have never been learnt.
    This list is then sorted in Descending order by numberOfWordsLearned and split into two lists of Words: sent and unsent where 
    - sent contains all words that have hasAlreadyCollected as True.
    - unsent contains all words that have hasAlreadyCollected as False.
    The algorithm then returns 3 words from these 2 lists, where priority is given to the 'unsent' list as the word stickers from that class haven't been awarded yet.
    
**2. Why did you choose to implement the algorithm in this way?**


    It logically appealed to me: As someone playing the game, i'd like the opportunity to eventually earn all stickers of the words i've learned and not just any 3 random stickers from the huge list of words i've learned
    throughout. By prioritising words i've never got stickers for before, that opportunity is given.
    Also, it makes sense to earn stickers for a word i've learned many more times than a freshly learned word.
    By combining these two thoughts, the current algorithm was created.

**3. How could you improve/evolve the algorithm if given more time?**


    It's honestly my first time programming in C#, so I focussed mainly on getting the functionality in sync with my intended solution.
    If given more time, I'd like to explore the language a lot more to understand and apply more efficient ways of writing code in C#.
    With respect to the algorithm, since the guideline was open-ended in terms of the implementation, I applied the solution that seemed most appropriate to me, but there might have been something i missed. I'd like to spend a bit more time on understanding the problem completely so that i can find the best solution.
    Also, I'm unaware of what kind of inputs will be actually provided to the function, so there was a limited amount of testing.
    
