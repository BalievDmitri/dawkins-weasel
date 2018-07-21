using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DawkinsWeasel.Models
{
    public class MutatingString
    {
        private static RandomChar randomCharGenerator = new RandomChar();
        private string origin;
        private string state;
        private string goal;
        private int children = 100;
        private double probability = 0.05;
        private int generation = 0;
        
        private ObservableCollection<string> generations = new ObservableCollection<string>();

        public ObservableCollection<string> Generations
        {
            get
            {
                return generations;
            }

            set
            {
                generations = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            private set
            {
                state = value;
            }
        }

        public string Goal
        {
            get
            {
                return goal;
            }

            private set
            {
                goal = value;
            }
        }

        public string Origin
        {
            get
            {
                return origin;
            }

            private set
            {
                origin = value;
            }
        }

        int Fitness(string target, string current)
        {
            //int fit = 0;
            //for (int i = 0; i < target.Length; i++)
            //{
            //    int sum = target.Skip(i).Zip(current, (a, b) => a == b ? 1 : 0).Sum();
            //    if (sum > fit) fit = sum;
            //}
            //return fit - Math.Abs(target.Length - current.Length);
            return target.Zip(current, (a, b) => a == b ? 1 : 0).Sum() - Math.Abs(target.Length - current.Length);
            //return target.Zip(current, (a, b) => a == b ? 1 : 0).Sum();
        }

        string Mutate(string current, double rate)
        {
            string mutation = String.Join("", from c in current
                                              select randomCharGenerator.NextDouble() <= rate ? randomCharGenerator.NextCharacter() : c);

            if (randomCharGenerator.NextDouble() <= rate) mutation = mutation.Insert(randomCharGenerator.Next(0, mutation.Length), randomCharGenerator.NextCharacter().ToString());
            
            if (randomCharGenerator.NextDouble() <= rate && mutation.Length > 0) mutation = mutation.Remove(randomCharGenerator.Next(0,mutation.Length-1),1);

            return mutation;
        }

        public MutatingString(string origin, string goal)
        {
            Origin = origin;
            State = state;
            Goal = goal;
            Initialize();
        }

        private void Initialize()
        {
            if (!Goal.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c))) throw new ArgumentException("Для поля Goal допускаются только буквы и знаки пробела.");
            if (!Origin.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c))) throw new ArgumentException("Для поля Origin допускаются только буквы и знаки пробела.");

            State = Origin;
            Generations.Add("Поколение " + Generation + ": " + State);
        }

        public void Mutate(Dispatcher dispatcher = null)
        {
            // Create C mutated strings + the current parent.
            var candidates = (from child in Enumerable.Repeat(State, Children)
                              select Mutate(child, Probability))
                              .Concat(Enumerable.Repeat(State, 1));

            // Sort the strings by the fitness function.
            var sorted = from candidate in candidates
                         orderby Fitness(Goal, candidate) descending
                         select candidate;

            // New parent is the most fit candidate.
            State = sorted.First();

            Generation++;
            if (dispatcher != null)
                dispatcher.Invoke(() => Generations.Add("Поколение " + Generation + ": " + State));
        }

        public bool GoalReached
        {
            get
            {
                return State == Goal ? true : false;
            }
        }

        public int Generation
        {
            get
            {
                return generation;
            }

            private set
            {
                generation = value;
            }
        }

        public int Children
        {
            get
            {
                return children;
            }

            set
            {
                children = value;
            }
        }

        public double Probability
        {
            get
            {
                return probability;
            }

            set
            {
                probability = value;
            }
        }
    }
}
