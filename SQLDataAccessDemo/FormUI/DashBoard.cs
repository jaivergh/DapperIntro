using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
	public partial class DashBoard : Form
	{
		List<Person> people = new List<Person>();

		public DashBoard()
		{
			InitializeComponent();
			UpdateBinding();
		}

		private void UpdateBinding()
		{
			peopleFoundListbox.DataSource = people;
			peopleFoundListbox.DisplayMember = "FullInfo";
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			DataAccess db = new DataAccess();
			people = db.GetPeople(lastNameTextbox.Text);
			UpdateBinding();
		}

		private void insertRecordButton_Click(object sender, EventArgs e)
		{
			DataAccess db = new DataAccess();
			db.InsertPerson(firstNameInsText.Text, lastNameInsText.Text, emailAddressInsText.Text, phoneNumberInsText.Text);

			firstNameInsText.Text = "";
			lastNameInsText.Text = "";
			emailAddressInsText.Text = "";
			phoneNumberInsText.Text = "";
		}
	}
}
