using System;

namespace AlgorithmComplexityTheory
{
    internal abstract class LaboratoryWorksAutomaton
    {
        private protected string _w = null;
        private protected char[] Alphabet = null;
        public LaboratoryWorksAutomaton(char[] alphabet, string w)
        {
            Alphabet = alphabet;
            _w = w;
        }
        private protected bool CheckingAlphabet(string w, bool result = false)// string replace char[]
        {
            for (int i = 0; i < w.Length; i++)
            {
                result = false;
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (w[i] == Alphabet[j])
                        result = true;
                }
                if (!result)
                {
                    Console.WriteLine($"В строке обнаружен символ не принадлежащий алфавиту\n{w[i]}");
                    Console.ReadKey();
                    return result;
                }
            }
            return result;
        }
        public abstract void Start(string w);
        //private protected virtual void FiniteAutomaton() { }
    }
}
