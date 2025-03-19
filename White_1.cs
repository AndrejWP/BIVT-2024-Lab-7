using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_1
    {
        public class Participant
        {
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;

            private static double _standard = 5;
            private static int _activeParticipants = 0;
            private static int _disqualifiedParticipants = 0;

            public static int Jumpers => _activeParticipants;
            public static int Disqualified => _disqualifiedParticipants;

            
            static Participant()
            {
                _standard = 5;
            }

            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Club
            {
                get
                {
                    if (_club == null) return default;
                    return _club;
                }
            }
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum => _firstJump + _secondJump;

            public Participant(string surname, string club)
            {
                _surname = surname;
                _surname = surname;
                _club = club;
                _firstJump = 0;
                _secondJump = 0;
                _activeParticipants ++; 
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



            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].JumpSum < array[j + 1].JumpSum)
                        {
                            // Обмен местами
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }


            }
            public static void Disqualify(ref Participant[] participants)
            {
                for (int i = 0; i < participants.Length; i++)
                {
                    if (participants[i] != null && (participants[i].FirstJump < _standard || participants[i].SecondJump < _standard))
                    {
                        participants[i] = null;
                        _disqualifiedParticipants++;
                        _activeParticipants--;
                    }
                }

                // Удаление null элементов из массива
                participants = participants.Where(p => p != null).ToArray();
            }
        

        public void Print()
            {
                Console.WriteLine($"Фамилия: {_surname}, Клуб: {_club}, Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, Сумма: {JumpSum}");
            }
        }
    }
}