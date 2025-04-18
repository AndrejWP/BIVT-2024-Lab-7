using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_5
    {
        public struct Match
        {

            private int _goals;
            private int _misses;


            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => _goals - _misses;
            public int Score 
            {
                get
                {
                    if (_goals > _misses) return 3;
                    if (_goals == _misses) return 1;
                    return 0;
                }
            }

            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }

            public void Print()
            {
                Console.WriteLine($"Забито: {_goals}, Пропущено: {_misses}, Очки: {Score}");
            }



        }

        public abstract class Team
        {
            private string _name;
            private Match[] _matches;

            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalScore
            {
                get
                {
                    if (_matches == null || _matches.Length == 0)
                        return 0;

                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Score;
                    }
                    return total;
                }
            }

            public int TotalDifference
            {
                get
                {
                    if (_matches == null || _matches.Length == 0)
                        return 0;

                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Difference;
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }

            public virtual void PlayMatch(int goals, int misses)
            {
                if (_matches == null) return;

                Match newMatch = new Match(goals, misses);
                Match[] newMatches = new Match[_matches.Length + 1];

                for (int i = 0; i < _matches.Length; i++)
                {
                    newMatches[i] = _matches[i];
                }

                newMatches[newMatches.Length - 1] = newMatch;
                _matches = newMatches;
            }

            public static void SortTeams(Team[] teams)
            {
                int n = teams.Length;
                bool sw;

                for (int i = 0; i < n - 1; i++)
                {
                    sw = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore ||
                            (teams[j].TotalScore == teams[j + 1].TotalScore &&
                             teams[j].TotalDifference < teams[j + 1].TotalDifference))
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                            sw = true;
                        }
                    }
                    if (!sw) break;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {_name}, Очки: {TotalScore}, Разница голов: {TotalDifference}");
            }
        }

        public class ManTeam : Team
        {
            private ManTeam _derby;


            public ManTeam Derby => _derby;


            public ManTeam(string name, ManTeam derby = null) : base(name)
            {
                _derby = derby;
            }


            public void PlayMatch(int goals, int misses, ManTeam team = null)
            {
                if (team == _derby)
                {
                    goals++;
                }
                base.PlayMatch(goals, misses);
            }
        }

        public class WomanTeam : Team
        {

            private int[] _penalties;

            public int[] Penalties => _penalties;

            public int TotalPenalties
            {
                get
                {
                    int total = 0;
                    foreach (var penalty in _penalties)
                    {
                        total += penalty;
                    }
                    return total;
                }
            }
            public WomanTeam(string name) : base(name)
            {
                _penalties = new int[0];
            }

            public override void PlayMatch(int goals, int misses)
            {
                base.PlayMatch(goals, misses);

                if (misses > goals)
                {
                    int penalty = misses - goals;
                    int[] newPenalties = new int[_penalties.Length + 1];

                    for (int i = 0; i < _penalties.Length; i++)
                    {
                        newPenalties[i] = _penalties[i];
                    }

                    newPenalties[newPenalties.Length - 1] = penalty;
                    _penalties = newPenalties;
                }
            }
        }
    }
}
