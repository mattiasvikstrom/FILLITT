﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FILLITT
{
    public partial class Form1 : Form
    {
        public Database db = new Database();
        public List<Person> people = new List<Person>();
        public List<Person> children = new List<Person>();
        public List<Person> siblings = new List<Person>();
        public List<Person> parents = new List<Person>();
        public List<Person> grandparents = new List<Person>();
        public List<Person> cousins = new List<Person>();
        public List<Person> parentsiblings = new List<Person>();

        SqlConnection con = new SqlConnection(Database.CnnValue("MattiasFamilyTree")); // gets connection
        SqlCommand cmd;
        SqlDataReader dr;
        private int selectedComboBoxIndex;
        /// <summary>
        /// Initialize
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            FillComboboxMenu();
        }
        /// <summary>
        /// Search button that handles searches in the database, by year and name. Searches use LIKE to handle incomplete search parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            int result;
            ClearListBox();
            try
            {
                con.Open();
                string searchVariable = textBox1.Text.Trim();
                cmd = new SqlCommand
                {
                    Connection = con
                };

                if (Int32.TryParse(searchVariable, out result))
                {
                    string _result = result.ToString();
                    cmd.CommandText = @"Select * from People WHERE BirthDate LIKE '%' + @searchValue + '%';";
                    cmd.Parameters.AddWithValue("@searchValue", _result);
                }
                else
                {
                    cmd.CommandText = @"Select * from People WHERE FirstName LIKE '%' + @searchValue + '%';";
                    cmd.Parameters.AddWithValue("@searchValue", searchVariable);
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbFirstName.Items.Add(dr["FirstName"]);
                    lbLastName.Items.Add(dr["LastName"]);
                    lbBirthDate.Items.Add(dr["BirthDate"]);
                    lbYearOfDeath.Items.Add(dr["DateOfDeath"]);
                    lbMother.Items.Add(dr["Mother"]);
                    lbFather.Items.Add(dr["Father"]);
                    lbId.Items.Add(dr["Id"]);
                }
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        /// <summary>
        /// Clears boxes before displaying data.
        /// </summary>
        private void ClearListBox()
        {
            lbFirstName.Items.Clear();
            lbLastName.Items.Clear();
            lbBirthDate.Items.Clear();
            lbYearOfDeath.Items.Clear();
            lbMother.Items.Clear();
            lbFather.Items.Clear();
            lbId.Items.Clear();
        }
        public void EnterPersonToDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string insertString = @"
                 INSERT INTO People
                 (FirstName, LastName, BirthDate, DateOfDeath, Mother, Father)
                 values (@namn, @lastnamn, @Birthdate, @deathdate, @mother, @father)";

                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.Parameters.AddWithValue("@namn", tbFirstNameAdd.Text);
                cmd.Parameters.AddWithValue("@lastnamn", tbLastNameAdd.Text);
                cmd.Parameters.AddWithValue("@Birthdate", tbBirthdateAdd.Text);
                cmd.Parameters.AddWithValue("@deathdate", tbDateOfDeathAdd.Text);
                string mother = tbMotherAdd.Text;
                int motherId = HandleParentInput(mother);
                cmd.Parameters.AddWithValue("@mother", motherId);
                string father = tbFatherAdd.Text;
                int fatherId = HandleParentInput(father);
                cmd.Parameters.AddWithValue("@father", fatherId);

                cmd.ExecuteNonQuery();
                FillComboboxMenu();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        /// <summary>
        /// Displays the persons information who is chosen in the combo box drop down menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cousins.Clear();
            tbFirstNameUpdate.Clear();
            tbLastNameUpdate.Clear();
            tbBirthdateUpdate.Clear();
            tbDateOfDeathUpdate.Clear();
            tbMotherUpdate.Clear();
            tbFatherUpdate.Clear();
            


            selectedComboBoxIndex = comboBox1.SelectedIndex;
            var index = comboBox1.SelectedIndex;
            try
            {
                tbFirstNameUpdate.Text = people[index].FirstName;
                tbLastNameUpdate.Text = people[index].LastName;
                tbBirthdateUpdate.Text = people[index].BirthDate;
                tbDateOfDeathUpdate.Text = people[index].DateOfDeath;
                DisplayParentsNamesFromId(index);
            }
            finally
            {
                if (con != null)
                {
                    children = ListChildren();
                    lbChildren.DataSource = children;
                    lbChildren.DisplayMember = "FirstName";

                    siblings = ListSiblings(selectedComboBoxIndex);
                    lbSiblings.DataSource = siblings;
                    lbSiblings.DisplayMember = "FirstName";

                    grandparents = ListGrandparents();
                    lbGrandparents.DataSource = grandparents;
                    lbGrandparents.DisplayMember = "FirstName";

                    cousins = Cousins();
                    lbCousins.DataSource = cousins;
                    lbCousins.DisplayMember = "FirstName";
                    con.Close();
                }
            }
        }
        /// <summary>
        /// Parents are stored as Id's and this retrieves the Name from that Id to be displayed 
        /// </summary>
        /// <param name="index"></param>
        private void DisplayParentsNamesFromId(int index)
        {
            var mother = people[index].Mother;
            int n = 0;
            parents.Clear();
            if (people[index].Mother > 0)
            {
                foreach (Person item in people)
                {
                    if (item.Id == mother)
                    {
                        n = people.IndexOf(item);
                        parents.Add(people[n]);
                        break;
                    }
                }
                tbMotherUpdate.Text = people[n].FirstName;
            }
            else
            {
                tbMotherUpdate.Text = "";
            }
            var father = people[index].Father;
            if (people[index].Father > 0)
            {
                foreach (Person item in people)
                {
                    if (item.Id == father)
                    {
                        n = people.IndexOf(item);
                        parents.Add(people[n]);
                        break;
                    }
                }
                tbFatherUpdate.Text = people[n].FirstName;
            }
            else
            {
                tbFatherUpdate.Text = "";
            }
        }
        /// <summary>
        /// Updates the combo box menu to accurately represent the current state of the database
        /// </summary>
        public void FillComboboxMenu()
        {
            comboBox1.Items.Clear();
            var i = 0;
            people = db.GetDatabaseList();
            while (people.Count > i)
            {
                comboBox1.Items.Add(people[i].FirstName);
                i++;
            }
        }
        /// <summary>
        /// Update button gets the Id of selected person in combo box list and gets the entered information into the SQLstring
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updatePerson_Click(object sender, EventArgs e)
        {
            try
            {
                var selectId = selectedComboBoxIndex;
                var ident = people[selectId].Id;
                con.Open();
                string insertString = @"
                 UPDATE People
                 SET FirstName = @namn, LastName = @lastnamn, BirthDate = @Birthdate, DateOfDeath = @deathdate, Mother = @mother, Father = @father 
                 WHERE Id = @ident";

                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.Parameters.AddWithValue("@namn", tbFirstNameUpdate.Text);
                cmd.Parameters.AddWithValue("@lastnamn", tbLastNameUpdate.Text);
                cmd.Parameters.AddWithValue("@Birthdate", tbBirthdateUpdate.Text);
                cmd.Parameters.AddWithValue("@deathdate", tbDateOfDeathUpdate.Text);
                string mother = tbMotherUpdate.Text;
                int motherId = HandleParentInput(mother);
                cmd.Parameters.AddWithValue("@mother", motherId);
                string father = tbFatherUpdate.Text;
                int fatherId = HandleParentInput(father);
                cmd.Parameters.AddWithValue("@father", fatherId);
                cmd.Parameters.AddWithValue("@ident", ident);

                cmd.ExecuteNonQuery();
                people = db.GetDatabaseList();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    FillComboboxMenu();
                }
            }
        }
        /// <summary>
        /// Deletes the selected person in the combo box from the SQLdatabase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                var selectId = selectedComboBoxIndex;
                var ident = people[selectId].Id;
                con.Open();
                const string insertString = @"DELETE FROM People WHERE Id = @ident";

                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.Parameters.AddWithValue("@ident", ident);
                cmd.ExecuteNonQuery();
                people = db.GetDatabaseList();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    FillComboboxMenu();
                }
            }
        }
        /// <summary>
        /// Input from user regarding parents can be by Id or by Name and is always entered into database as Id.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        private int HandleParentInput(string parent)
        {
            int i = 0;
            int parentId = 0;

            foreach (var item in people)
            {
                if (!Int32.TryParse(parent, out parentId))
                {
                    if (people[i].FirstName == parent)
                    {
                        return parentId = people[i].Id;
                    }
                }
                else if (Int32.TryParse(parent, out parentId))
                {
                    if (people[i].Id == parentId)
                    {
                        return parentId;
                    }
                }
                i++;
            }
            return parentId;
        }
        /// <summary>
        /// Gets and displays a selected persons children.
        /// </summary>
        private List<Person> ListChildren()
        {
            var children = new List<Person>();
            children.Clear();
            int i = 0;
            int index = selectedComboBoxIndex;
            int parent = people[index].Id;
            foreach (var item in people)
            {
                if (people[i].Mother == parent && people[i].Mother != 0 || people[i].Father == parent && people[i].Father != 0)
                {
                    if (i != comboBox1.SelectedIndex)
                        children.Add(people[i]);
                }
                i++;
            }
            return children;
        }
        /// <summary>
        /// Checks if the selected person in the combo box has people who share the same parent or parents which are then displayed as siblings.
        /// </summary>
        private List<Person> ListSiblings(int index)
        {
            var siblings = new List<Person>();
            int i = 0;
            siblings.Clear();
            int mother = people[index].Mother;
            int father = people[index].Father;
            foreach (var item in people)
            {
                if (people[i].Mother == mother && people[i].Mother != 0 || people[i].Father == father && people[i].Father != 0)
                {
                    if (i != index)
                    {
                        siblings.Add(people[i]);
                    }
                }
                i++;
            }
            return siblings;

        }
        /// <summary>
        /// Handles the displaying of grandparents to the selected person in the combo box.
        /// </summary>
        private List<Person> ListGrandparents()
        {
            var grandparents = new List<Person>();
            grandparents.Clear();
            int index = selectedComboBoxIndex;
            int mother = people[index].Mother;
            int father = people[index].Father;
            grandparents = GetGrandparents(grandparents, mother);
            grandparents = GetGrandparents(grandparents, father);
            return grandparents;
        }
        /// <summary>
        /// uses parameters to retrieve the correct matches for grandparents.
        /// </summary>
        /// <param name="grandparents"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private List<Person> GetGrandparents(List<Person> grandparents, int parent)//säkert rätta metoden att kalla på... Byt namn till getParents kan sen skickas till getGrandparents sen get siblings och sen kusiner
        {
            int personsMother = 0;
            int personsFather = 0;
            int i = 0;
            foreach (var item in people)
            {
                if (people[i].Id == parent)
                {
                    personsMother = people[i].Mother;
                    personsFather = people[i].Father;
                }
                i++;
            }
            i = 0;
            foreach (var item in people) //bryt ut metoden 
            {
                if (people[i].Id == personsMother || people[i].Id == personsFather)
                {
                    grandparents.Add(people[i]);
                }
                i++;
            }
            return grandparents;
        }
        /// <summary>
        /// Gets the selected persons mothers Id
        /// </summary>
        private List<Person> Cousins()
        {
            //var cousins = new List<Person>();
            var parentsiblings = new List<Person>();
            //cousins.Clear();

            parentsiblings = GetParentSiblings(parents);
            return GetCousins(parentsiblings);
        }

        /// <summary>
        /// Collects the selected persons cousins
        /// </summary>
        /// <param name="cousins"></param>
        /// <param name="mother"></param>
        /// <returns></returns>
        /// 
        private List<Person> GetParentSiblings(List<Person> parents)
        {
            var parentsiblings = new List<Person>();
            parentsiblings.Clear();

            int index = selectedComboBoxIndex;
            int j = 0;
            foreach (var item in parents)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Id == parents[j].Id)
                    {
                        index = i;
                        parentsiblings.AddRange(ListSiblings(index)); //DEN NOLLSTÄLLER LISTAN
                    }
                }
                j++;
            }
            return parentsiblings;
        }

        private List<Person> GetCousins(List<Person> parentsiblings)
        {
            int index = selectedComboBoxIndex;
            var cousins = new List<Person>();
            int j = 0;
            foreach (var item in parentsiblings)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (parentsiblings[j].Id == people[i].Mother && people[i].Id != people[index].Mother )
                    {
                        cousins.Add(people[i]);
                    }
                    else if (parentsiblings[j].Id == people[i].Father && people[i].Id != people[index].Father)
                    {
                        cousins.Add(people[i]);
                    }
                }
                j++;
            }
            return cousins;
        }
        //private List<Person> GetGrandParents(int mother, int father)
        //{
        //    var grandparents = new List<Person>();
        //    for (int i = 0; i < people.Count; i++)
        //    {
        //        if (people[i].Id == mother)
        //        {
        //            var grandmother = people[i].Mother;
        //            for (int j = 0; j < people.Count; j++)
        //            {
        //                if(people[j].Mother == grandmother && people[j].Mother != people[selectedComboBoxIndex].Mother)
        //                {
        //                    grandparents.Add(people[j]);
        //                }
        //            }
        //        }
        //        else if (people[i].Id == father)
        //        {
        //            var grandfather = people[i].Father;
        //            for (int k = 0; k < people.Count; k++)
        //            {
        //                if (people[k].Father == grandfather && people[k].Father != people[selectedComboBoxIndex].Father)
        //                {
        //                    grandparents.Add(people[k]);
        //                }
        //            }

        //        }
        //    }
        //    return grandparents;
        //}
    }
}

