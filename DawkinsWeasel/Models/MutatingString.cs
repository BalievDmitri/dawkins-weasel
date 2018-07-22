using DawkinsWeasel.Models.Settings;
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
        public MutatingString(string origin, IMutationSettingsProvider mutationSettings)
        {
            Origin = origin;
            this.mutationSettings = mutationSettings;
            //Goal = goal;
            Initialize();
        }

        IMutationSettingsProvider mutationSettings;

        private static RandomChar randomCharGenerator = new RandomChar();

        public ObservableCollection<string> Generations { get; set; } = new ObservableCollection<string>();

        public string State { get; private set; }

        public string Origin { get; private set; }

        int Fitness(string target, string current) => target.Zip(current, (a, b) => a == b ? 1 : 0).Sum() - Math.Abs(target.Length - current.Length);

        string Mutate(string current, double rate)
        {
            string mutation = String.Join("", from c in current
                                              select randomCharGenerator.NextDouble() <= rate ? randomCharGenerator.NextCharacter() : c);

            if (randomCharGenerator.NextDouble() <= rate) mutation = mutation.Insert(randomCharGenerator.Next(0, mutation.Length), randomCharGenerator.NextCharacter().ToString());
            
            if (randomCharGenerator.NextDouble() <= rate && mutation.Length > 0) mutation = mutation.Remove(randomCharGenerator.Next(0,mutation.Length-1),1);

            return mutation;
        }
        
        private void Initialize()
        {
            if (!mutationSettings.Goal.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c))) throw new ArgumentException("Для поля Goal допускаются только буквы и знаки пробела.");
            if (!Origin.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c))) throw new ArgumentException("Для поля Origin допускаются только буквы и знаки пробела.");

            State = Origin;
            Generations.Add("Поколение " + Generation + ": " + State);
        }

        public void Mutate(Dispatcher dispatcher = null)
        {
            // Create C mutated strings + the current parent.
            var candidates = (from child in Enumerable.Repeat(State, mutationSettings.Children)
                              select Mutate(child, mutationSettings.Probability))
                              .Concat(Enumerable.Repeat(State, 1));

            // Sort the strings by the fitness function.
            var sorted = from candidate in candidates
                         orderby Fitness(mutationSettings.Goal, candidate) descending
                         select candidate;

            // New parent is the most fit candidate.
            State = sorted.First();

            Generation++;
            if (dispatcher != null)
                dispatcher.Invoke(() => Generations.Add("Поколение " + Generation + ": " + State));
        }

        public bool GoalReached => State == mutationSettings.Goal ? true : false;

        public int Generation { get; private set; } = 0;
    }
}
