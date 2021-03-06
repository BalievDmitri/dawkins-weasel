﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DawkinsWeasel.Models;
using System.Windows.Threading;
using System.Windows.Input;

namespace DawkinsWeasel.ViewModels
{
    public class MutatingViewModel:ObservableObject
    {
        private MutatingString mutator;
        private string state = "";
        private ObservableCollection<string> generations = new ObservableCollection<string>();

        public MutatingViewModel(string origin, string goal, Action goalReached)
        {
            mutator = new MutatingString(origin, goal)
            {
                Children = Properties.Settings.Default.Childerns,
                Probability = Properties.Settings.Default.Probability
            };
            State = origin;
            GoalReached = goalReached;
        }

        Action GoalReached;

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                RaisePropertyChangedEvent("State");
            }
        }

        public ObservableCollection<string> Generations
        {
            get
            {
                return mutator.Generations;
            }

            //set
            //{
            //    generations = value;
            //}
        }

        private bool stop = false;

        public ICommand Stop
        {
            get
            {
                return new DelegateCommand(() => stop = true);
            }
        }

        public void Mutate(Dispatcher dispatcher)
        {
            while(!mutator.GoalReached && !stop)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.01));
                mutator.Mutate(dispatcher);
                State = mutator.State;
                //dispatcher.Invoke(() => Generations.Add(State));
            }
            GoalReached.Invoke();
        }
    }
}
