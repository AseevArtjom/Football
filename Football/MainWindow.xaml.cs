using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Football
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            switch (Prod.SelectedIndex)
            {
                default:
                    break;
                case -1:
                    MessageBox.Show("Select procedure", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 0:
                    ShowDifferenceGoals();
                    break;
                case 1:
                    ShowFullInformationAboutMatches();
                    break;
                case 2:
                    ShowAboutMatchInSelectedDate();
                    break;
                case 3:
                    ShowMatchesSelectedTeam();
                    break;
                case 4:
                    ShowWhoGoalInSelectedDate();
                    break;
                case 5:

                    break;
            }
        }

        private void ShowDifferenceGoals()
        {
            using (MatchContext db = new MatchContext())
            {
                var GoalDifference = from Match in db.Match
                                     join FirstTeam in db.Team on Match.FirstTeamId equals FirstTeam.Id
                                     join SecondTeam in db.Team on Match.SecondTeamId equals SecondTeam.Id     
                                     select new
                                     {
                                         Team1 = FirstTeam.Name,
                                         Team2 = SecondTeam.Name,
                                         Goals1 = Match.GoalsFirstTeam,
                                         Goals2 = Match.GoalsSecondTeam
                                     };
                DG_Main.ItemsSource = GoalDifference.ToList();
            }
        }

        private void ShowFullInformationAboutMatches()
        {
            using (MatchContext db = new MatchContext())
            {
                var query = from match in db.Match
                            join firstTeam in db.Team on match.FirstTeamId equals firstTeam.Id
                            join secondTeam in db.Team on match.SecondTeamId equals secondTeam.Id
                            join goalPlayer in db.Player on match.WhoGoal equals goalPlayer.Id
                            select new
                            {
                                Id = match.Id,
                                Name = match.Name,
                                FirstTeam = firstTeam.Name,
                                SecondTeam = secondTeam.Name,
                                GoalsFirstTeam = match.GoalsFirstTeam,
                                GoalsSecondTeam = match.GoalsSecondTeam,
                                WhoGoal = goalPlayer.FullName,
                                PlayingDate = match.PlayingDate
                            };
                DG_Main.ItemsSource = query.ToList();
            }
        }

        private void ShowAboutMatchInSelectedDate()
        {
            using (MatchContext db = new MatchContext())
            {
                DateTime selectedDate = Convert.ToDateTime(SelectedDate.SelectedDate.GetValueOrDefault());

                var query = from match in db.Match
                            join firstTeam in db.Team on match.FirstTeamId equals firstTeam.Id
                            join secondTeam in db.Team on match.SecondTeamId equals secondTeam.Id
                            join goalPlayer in db.Player on match.WhoGoal equals goalPlayer.Id
                            where selectedDate == match.PlayingDate
                            select new
                            {
                                Id = match.Id,
                                Name = match.Name,
                                FirstTeam = firstTeam.Name,
                                SecondTeam = secondTeam.Name,
                                GoalsFirstTeam = match.GoalsFirstTeam,
                                GoalsSecondTeam = match.GoalsSecondTeam,
                                WhoGoal = goalPlayer.FullName,
                                PlayingDate = match.PlayingDate
                            };
                DG_Main.ItemsSource = query.ToList();
            }
        }

        private void ShowMatchesSelectedTeam()
        {
            using (MatchContext db = new MatchContext())
            {
               
                var query = from match in db.Match
                            join firstTeam in db.Team on match.FirstTeamId equals firstTeam.Id
                            join secondTeam in db.Team on match.SecondTeamId equals secondTeam.Id
                            join goalPlayer in db.Player on match.WhoGoal equals goalPlayer.Id
                            where firstTeam.Name.Contains(Main_TextBox.Text) || secondTeam.Name.Contains(Main_TextBox.Text)
                            select new
                            {
                                Id = match.Id,
                                Name = match.Name,
                                FirstTeam = firstTeam.Name,
                                SecondTeam = secondTeam.Name,
                                GoalsFirstTeam = match.GoalsFirstTeam,
                                GoalsSecondTeam = match.GoalsSecondTeam,
                                WhoGoal = goalPlayer.FullName,
                                PlayingDate = match.PlayingDate
                            };
                DG_Main.ItemsSource = query.ToList();
            }
        }

        private void ShowWhoGoalInSelectedDate()
        {
            
        }
    }
}
