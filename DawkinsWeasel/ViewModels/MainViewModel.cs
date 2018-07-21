using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DawkinsWeasel;
using System.Windows.Threading;

namespace DawkinsWeasel.ViewModels
{
    public class MainViewModel:ObservableObject
    {
        Views.NewInputPage inputPage = new Views.NewInputPage();
        NewInputPageModel inputPageVM;
        Views.MutatingPage mutatingPage = new Views.MutatingPage();
        MutatingViewModel mutatingPageVM;
        Views.LastPage lastPage = new Views.LastPage();

        System.Windows.Controls.Control currentPage;

        private void StartMutation()
        {
            string goal = Properties.Settings.Default.Goal;
            mutatingPageVM = new MutatingViewModel(inputPageVM.InputPhrase, goal, ShowLastPage);
            mutatingPage.DataContext = mutatingPageVM;
            SetCurrentPage(mutatingPage);
            Task.Factory.StartNew(() => mutatingPageVM.Mutate(mutatingPage.Dispatcher));
        }

        private void OpenSettings()
        {
            var settingsPage = new Views.Settings();
            var settingsViewModel = new SettingsViewModel(Restart);
            settingsPage.DataContext = settingsViewModel;

            SetCurrentPage(settingsPage);
        }

        private void ShowLastPage()
        {
            lastPage.Dispatcher.Invoke(() =>
            {
                lastPage.DataContext = new LastPageViewModel(mutatingPageVM.Generations.ToList(), Restart);
            });
            SetCurrentPage(lastPage);
        }

        private void Restart()
        {
            inputPageVM = new NewInputPageModel(StartMutation, OpenSettings);
            inputPage.DataContext = inputPageVM;
            SetCurrentPage(inputPage);
        }

        public MainViewModel()
        {
            Restart();
        }

        private void SetCurrentPage(System.Windows.Controls.Control page)
        {
            currentPage = page;
            RaisePropertyChangedEvent("CurrentPage");
        }

        public List<System.Windows.Controls.Control> CurrentPage
        {
            get
            {
                return new List<System.Windows.Controls.Control>() { currentPage };
            }
        }
    }
}
