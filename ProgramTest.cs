using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lingumi
{
    class ProgramTest
    {

        /// <summary>
        /// Tests the return value if WordList and IDList have one value
        /// </summary>
        public void testSample()
        {
            List<Word> Wordlist = new List<Word>();
            List<string> Idlist = new List<string>();

            Word obj = new Word("one", true, 1);
            Wordlist.Add(obj);
            Idlist.Add("one");
            Program program = new Program();
            string[] s = program.sendStickers(Wordlist, Idlist);
            
            Debug.Assert(s[0] == "one");
        }

        /// <summary>
        /// Tests for Multiple Words and IDs. Priority checking is tested.
        /// </summary>
        public void testMultipleWords()
        {
            List<Word> Wordlist = new List<Word>();
            List<string> Idlist = new List<string>();

            Word obj1 = new Word("one", true, 1);
            Word obj2 = new Word("two", true, 2);
            Word obj3 = new Word("three", false, 3);
            Word obj4 = new Word("four", false, 4);
            Word obj5 = new Word("five", true, 5);

            Wordlist.Add(obj1);
            Wordlist.Add(obj2);
            Wordlist.Add(obj3);
            Wordlist.Add(obj4);
            Wordlist.Add(obj5);

            Idlist.Add("one");
            Idlist.Add("two");
            Idlist.Add("three");
            Idlist.Add("four");
            Idlist.Add("five");


            Program program = new Program();
            string[] s = program.sendStickers(Wordlist, Idlist);
            Debug.Assert(s[0] == "four");
            Debug.Assert(s[1] == "three");
            Debug.Assert(s[2] == "five");

        }
    }
}
