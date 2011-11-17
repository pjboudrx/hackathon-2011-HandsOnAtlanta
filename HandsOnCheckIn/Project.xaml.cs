using System;
using System.Collections.Generic;
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
	public partial class Project : PhoneApplicationPage
	{
		public Project()
		{
			InitializeComponent();
			this.volunteers.DataContext = FakeDatabase.Projects[0].Volunteers;
		}

		private void find_volunteer_Click(object sender, System.EventArgs e)
		{
			NavigationService.Navigate(new Uri("/FindVolunteer.xaml", UriKind.Relative));
		}

		private void CheckOut_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Button button = (Button) sender;
			Volunteer volunter = (Volunteer) button.DataContext;

			volunter.OutTime = DateTime.Now;
		}
	}
}