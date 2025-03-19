using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Lab_7
{
    public class White_2
    {
        public class Participant
        {
            // поля 
            private string _surname;
            private string _name;
            private double _firstJump;
            private double _secondJump;
            //свойства
            private static readonly double _standard;

            static Participant()
            {
                _standard = 3;
            }
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }


            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }

            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump => Math.Max(_firstJump, _secondJump);

            public bool IsPassed => BestJump >= _standard;
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstJump = 0;
                _secondJump = 0;
            }

            
            public Participant(string name, string surname, double firstJump, double secondJump)
            {
                _name = name;
                _surname = surname;
                _firstJump = firstJump;
                _secondJump = secondJump;
            }
            public void Jump(double result)
            {
                if (_firstJump == 0)
                {
                    _firstJump = result;
                }
                else if (_secondJump == 0)
                {
                    _secondJump = result;
                }
            }

            public static Participant[] GetPassed(Participant[] participants)
            {
                return participants.Where(p => p.IsPassed).ToArray();
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool y;
                for (int i = 0; i < n - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }
            }
                
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, Лучший прыжок: {BestJump}");
            }
        }
    }
}