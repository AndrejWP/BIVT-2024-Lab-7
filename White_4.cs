using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_4
    {
        public class Human
        {
            protected string _name;
            protected string _surname;

            public string Surname => _surname ?? default;
            public string Name => _name ?? default;

            public Human(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            public virtual void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}");
            }
        }

        public class Participant : Human
        {
            private double[] _scores;
            private static int _count;

            public static int Count => _count;
            public double[] Scores => _scores?.ToArray() ?? Array.Empty<double>();
            public double TotalScore => _scores?.Sum() ?? 0;

            static Participant() => _count = 0;

            public Participant(string name, string surname) : base(name, surname)
            {
                _scores = Array.Empty<double>();
                _count++;
            }

            public void PlayMatch(double result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[^1] = result; // Используем индекс от конца
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length < 2) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore >= array[j + 1].TotalScore) continue;

                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                    if (!swapped) break;
                }
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Очки: {TotalScore:F1}");
            }
        }
    }

   
}
