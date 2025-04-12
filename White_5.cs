using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_7
{
    public class White_5 {
        public struct Match
        {
            public int Goals { get; }
            public int Misses { get; }
            public int Difference => Goals - Misses;
            public int Score => Goals > Misses ? 3 : Goals == Misses ? 1 : 0;

            public Match(int goals, int misses)
            {
                if (goals < 0 || misses < 0)
                {
                    Console.WriteLine("Количество голов/пропусков не может быть отрицательным");
                    Goals = Misses = 0;
                    return;
                }

                Goals = goals;
                Misses = misses;
            }

            public void Print() => Console.WriteLine($"Забито: {Goals}, Пропущено: {Misses}, Очки: {Score}");
        }

        public abstract class Team
        {
            protected string _name;
            protected List<Match> _matches = new();

            public string Name => _name;
            public IReadOnlyList<Match> Matches => _matches.AsReadOnly();
            public int TotalScore => _matches.Sum(m => m.Score);
            public int TotalDifference => _matches.Sum(m => m.Difference);

            protected Team(string name) => _name = name;

            public virtual void PlayMatch(int goals, int misses) =>
                _matches.Add(new Match(goals, misses));

            public static void SortTeams(Team[] teams)
            {
                Array.Sort(teams, (a, b) =>
                    (b.TotalScore, b.TotalDifference).CompareTo((a.TotalScore, a.TotalDifference)));
            }

            public virtual void Print() =>
                Console.WriteLine($"Команда: {Name}, Очки: {TotalScore}, Разница голов: {TotalDifference}");
        }

        public class ManTeam : Team
        {
            public ManTeam? Derby { get; }

            public ManTeam(string name, ManTeam? derby = null) : base(name) => Derby = derby;

            public void PlayMatch(int goals, int misses, ManTeam? opponent = null)
            {
                if (opponent == Derby) goals++;
                base.PlayMatch(goals, misses);
            }
        }

        public class WomanTeam : Team
        {
            private List<int> _penalties = new();
            public IReadOnlyList<int> Penalties => _penalties.AsReadOnly();
            public int TotalPenalties => _penalties.Sum();

            public WomanTeam(string name) : base(name) { }

            public override void PlayMatch(int goals, int misses)
            {
                base.PlayMatch(goals, misses);
                if (misses > goals)
                    _penalties.Add(misses - goals);
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Штрафные очки: {TotalPenalties}");
            }
        }
    } 

    
}
