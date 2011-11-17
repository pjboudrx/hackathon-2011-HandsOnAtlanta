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
	public partial class FindVolunteer : PhoneApplicationPage
	{
		public FindVolunteer()
		{
			InitializeComponent();

			var folks =  new List<Volunteer>
			                         	{
			                         		new Volunteer {Name = "Ginger Rogers", DateOfBirth = new DateTime(1940, 01, 01)},
			                         		new Volunteer {Name = "Fred Astair", DateOfBirth = new DateTime(1938, 01, 01)},
			                         		new Volunteer {Name = "Roger Rabbit", DateOfBirth = new DateTime(1922, 01, 01)},
			                         		new Volunteer
			                         			{Name = "Thomas Tankengine", DateOfBirth = new DateTime(1940, 01, 01)},
			                         		new Volunteer {Name = "Will Sansbury", DateOfBirth = new DateTime(1958, 01, 01)},
			                         		new Volunteer {Name = "Jack Johnson", DateOfBirth = new DateTime(1988, 01, 01)},
			                         		new Volunteer {Name = "Brenda Framklin", DateOfBirth = new DateTime(1932, 01, 01)},
			                         		new Volunteer {Name = "Alfred Manfrede", DateOfBirth = new DateTime(1940, 01, 01)},
			                         		new Volunteer {Name = "Lee Worthington", DateOfBirth = new DateTime(1940, 01, 01)},
			                         		new Volunteer {Name = "Shelby McSheberson", DateOfBirth = new DateTime(1940, 01, 01)},
			                         	};
			folks.Sort(new NameComparer());

			volunteers.DataContext = folks;
		}

		private void Select_Tap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			Button button = (Button) sender;
			Volunteer volunteer = (Volunteer) button.DataContext;
			volunteer.InTime = DateTime.Now;
			FakeDatabase.Projects[0].AddVolunteer(volunteer);
			NavigationService.GoBack();
		}
	}

	public class NameComparer : IComparer<Volunteer>
	{
		public int Compare(Volunteer x, Volunteer y)
		{
			return x.Name.CompareTo(y.Name);
		}
	}
}