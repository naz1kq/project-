using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebParseStringAPP
{
    public class ParseText
    {

        public int word_count = 0;
        public List<string> Sentence_colection = new List<string>();
        public List<int> Word_count = new List<int>();



        public void GetSentence(string text, string find_this)
        {

            string searching_sentence = null;

            foreach (char d in text)
            {
                searching_sentence = searching_sentence + d;
                if (d == '.' || d == '!' || d == '?')
                {
                    word_count = 0;
                    if (FindWord(searching_sentence, find_this))
                    {

                        Sentence_colection.Add(searching_sentence);

                    }
                    searching_sentence = null;
                }


            }
        }

        private bool FindWord(string text, string find_this)
        {
            string serching_word = null;

            int count = 0;
            foreach (char d in text)
            {
                count += 1;
                if (d != ' ' && d != '.' && d != '!' && d != '?')
                {
                    serching_word = serching_word + d;

                    if ((serching_word == find_this) && (text[count] == ' ' || text[count] == '.' || text[count] == '!' || text[count] == '?'))
                    {

                        word_count++;

                    }
                    continue;
                }
                serching_word = null;
            }

            if (word_count > 0)
            {
                Word_count.Add(word_count);
                return true;
            }


            return false;
        }

        public string String_Convert(string text)
        {
            string convertedString = null;

            for (int i = text.Length; i > 1; i--)
            {
                convertedString = convertedString + text[i-1];

            }

            return convertedString;
        }

            
        }

    }
