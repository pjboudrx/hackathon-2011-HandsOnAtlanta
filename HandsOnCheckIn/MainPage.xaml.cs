using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace HandsOnCheckIn
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			serviceProjectsList.SelectionChanged += new SelectionChangedEventHandler(serviceProjectsList_SelectionChanged);

			
			
		}

		void serviceProjectsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var project = (ServiceProject) serviceProjectsList.SelectedItem;
			NavigationService.Navigate(new Uri("/Project.xaml?name=" + project.Name, UriKind.Relative));
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			serviceProjectsList.DataContext = FakeDatabase.Projects;
			base.OnNavigatedTo(e);
		}
	}

	public static class FakeDatabase
	{
		public static ObservableCollection<ServiceProject> Projects = new ObservableCollection<ServiceProject>
		                                              	{
		                                              		new ServiceProject()
		                                              			{
		                                              				Name = "Clean up Chastain",
		                                              				Date = new DateTime(2011, 01, 01),
		                                              				Location = "Chastain Park",
		                                              				Volunteers = new ObservableCollection<Volunteer>
		                                              				             	{
		                                              				             		new Volunteer
		                                              				             			{
		                                              				             				Name = "Fred Flinstone",
		                                              				             				InTime = new DateTime(1, 1, 1, 8, 22, 0),
		                                              				             				OutTime = new DateTime(1, 1, 1, 12, 35, 0)
		                                              				             			},
		                                              				             		new Volunteer
		                                              				             			{
		                                              				             				Name = "Barney Rubble",
		                                              				             				InTime = new DateTime(1, 1, 1, 8, 22, 0)
		                                              				             			}
		                                              				             	}
		                                              			},

																new ServiceProject()
		                                              			{
		                                              				Name = "River Keepers",
		                                              				Date = new DateTime(2011, 05, 01),
		                                              				Location = "The 'Hooch",
		                                              				Volunteers = new ObservableCollection<Volunteer>
		                                              				             	{
		                                              				             		
		                                              				             	}
		                                              			}
		                                              	};

	}

	public class ServiceProject : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }

		public ObservableCollection<Volunteer> Volunteers { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void AddVolunteer(Volunteer volunteer)
		{
			Volunteers.Add(volunteer);
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs("Volunteers"));
		}
	}

	public class Volunteer : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public string MailingAddress { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public DateTime DateOfBirth { get; set; }

		private DateTime? _outTime;
		public DateTime? OutTime
		{
			get { return _outTime; }
			set
			{
				_outTime = value;
				OnPropertyChanged("OutTime");
				OnPropertyChanged("OutTimeLabelViz");
				OnPropertyChanged("CheckOutButtonViz");
			}
		}

		public Visibility OutTimeLabelViz
		{
			get
				{
					if (OutTime.HasValue)
						return Visibility.Visible;

					return Visibility.Collapsed;
				}
		}

		public Visibility CheckOutButtonViz
		{
			get
			{
				if (OutTime.HasValue)
					return Visibility.Collapsed;

				return Visibility.Visible;
			}
		}

		public DateTime InTime { get; set; }

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}