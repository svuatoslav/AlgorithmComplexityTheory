using System;

namespace AlgorithmComplexityTheory
{
    internal class Program
    {
        static void Main()
        {
            //Console.Write("Введите строку:");
            //FirstLaboratoryWork firstLaboratoryWork = new FirstLaboratoryWork(Alphabet, Console.ReadLine());
            //while (Cont()) { firstLaboratoryWork.Start(Console.ReadLine()); }
            //SecondLaboratoryWork secondLaboratoryWork = new(Alphabet, Console.ReadLine());
            //char[] Alphabet = { '0', '1' };
            //const int Q = 4;
            //const string DeltaPath = "путь до проекта\\bin\\Debug\\Delta.xlsx";
            //const int StartState = 0;
            //int[] EndStates = new int[] { 1, 2};
            //_ = new ThirdLaboratoryWork(Q, Alphabet, DeltaPath, StartState, EndStates);

            //int start_node = 0;
            //int goal_node = 12;
            //int k = 1000000;//2 3
            //_ = new FourthLaboratoryWork(start_node, goal_node, k);
            _ = new FifthLaboratoryWork();
            Console.ReadKey();
        }
        static bool Cont() 
        {
            Console.WriteLine("Продолжить? Да или Y"); 
            string cont = Console.ReadLine(); 
            if (cont == "Да" || cont == "Y") return true;
            else return false;
        }
    }
}
