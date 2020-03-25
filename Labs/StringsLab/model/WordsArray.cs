namespace StringsLab.model
{
    class WordsArray : AbstractWordArray
    {
        //Filter words from the input file. Return filtered value, "" if input was invalid.
        public override string FilterWords(string str)
        {
            string[] unsorted = str.Split("\n");
            string sorted = "";

            foreach (string s in unsorted)
            {
                string[] sentence = s.Split(" ");
                string currentSentence = "";

                foreach (string word in sentence)
                {
                    if (IsValidWord(word))
                    {
                        currentSentence += word + " ";
                    }
                }

                if (currentSentence != "")
                {
                    sorted += currentSentence.Trim() + "\n";
                }
            }

            return sorted;
        }
        //Check that the string value is valid, i.e. contains at less two different literal values
        private bool IsValidWord(string s)
        {
            if (s.Length > 1)
            {
                char ch = s[0];

                for (int i = 0; i < s.Length; i++)
                {
                    if (ch != s[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
