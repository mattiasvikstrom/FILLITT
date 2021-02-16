using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace FILLITT
{
    public partial class Form1 : Form
    {
        public Database db = new Database();
        public List<Person> people = new List<Person>();
        public List<Person> peopleUpdate = new List<Person>(); //testa använda denna för att ta med den användaren som uppdateras
        SqlConnection con = new SqlConnection(Database.CnnValue("FamilyTree")); // gets connection
        SqlCommand cmd;
        SqlDataReader dr;
        int selectedComboBoxIndex;
        //DataTable dt;

        public Form1()
        {
            InitializeComponent();
            TestingComboBox();
            //people = db.GetDatabaseList(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear the listbox before each new query
            //tryparse the search to see if it is a name or birthdate
            int result;

            ClearListBox();
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (!Int32.TryParse(textBox1.Text, out result)) 
            {
                cmd.CommandText = @"Select * from People WHERE FirstName LIKE '%" + textBox1.Text + "%'";
            }
            else
            {
                cmd.CommandText = @"Select * from People WHERE BirthDate LIKE '%" + textBox1.Text + "%'";
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
                listBox7.Items.Add(dr["Id"]);
            }
            
            con.Close();
        }

        private void ClearListBox()
        {
            lbFirstName.Items.Clear();
            lbLastName.Items.Clear();
            lbBirthDate.Items.Clear();
            lbYearOfDeath.Items.Clear();
            lbMother.Items.Clear();
            lbFather.Items.Clear();
            listBox7.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
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
                cmd.Parameters.AddWithValue("@mother", tbMotherAdd.Text);
                cmd.Parameters.AddWithValue("@father", tbFatherAdd.Text);

                cmd.ExecuteNonQuery();
                TestingComboBox(); //When a new person is added update the people list
            }
            finally
            {
                if (con != null)
                {
                    
                    con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

                //find issue. people with no parents displays wrong parents
                var mother = people[index].Mother;
                int n = 0;
                if (people[index].Mother > 0)
                {
                    foreach (Person item in people)
                    {
                        if (item.Id == mother)
                        {
                            n = people.IndexOf(item);
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
                            break;
                        }
                    }
                    tbFatherUpdate.Text = people[n].FirstName;
                }
                else
                {
                    tbMotherUpdate.Text = "";
                }
            }
            finally
            {
                if (con != null)
                {
                    ListSiblings();
                    ListGrandparents();
                    con.Close();
                }
            }

        }

        private void TestingComboBox()
        {
            comboBox1.Items.Clear();
            var i = 0;
            people = db.GetDatabaseList(); //placering av denna kallelse. hämta vid start och vid förändring (lägga till, uppdatera, Delete)
            while (people.Count > i)
            {
                comboBox1.Items.Add(people[i].FirstName);
                i++;
            }
        }

        private void updatePerson_Click(object sender, EventArgs e)
        {
            try
            {
                var selectId = selectedComboBoxIndex; //måste ju ha databasens id.
                var ident = people[selectId].Id;
                //best way to identity the correct id
                con.Open();
                string insertString = @"
                 UPDATE People
                 SET FirstName = @namn, LastName = @lastnamn, BirthDate = @Birthdate, DateOfDeath = @deathdate, Mother = @mother, Father = @father 
                 WHERE Id = @ident";
                 
                 //values (@namn, @lastnamn, @Birthdate, @deathdate, @mother, @father)";

                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.Parameters.AddWithValue("@namn", tbFirstNameUpdate.Text);
                cmd.Parameters.AddWithValue("@lastnamn", tbLastNameUpdate.Text);
                cmd.Parameters.AddWithValue("@Birthdate", tbBirthdateUpdate.Text);
                cmd.Parameters.AddWithValue("@deathdate", tbDateOfDeathUpdate.Text);
                int motherId = GetMotherId();
                cmd.Parameters.AddWithValue("@mother", motherId);
                int fatherId = GetFatherId();
                cmd.Parameters.AddWithValue("@father", fatherId);
                cmd.Parameters.AddWithValue("@ident", ident);

                cmd.ExecuteNonQuery();
                people = db.GetDatabaseList(); //When a new person is added or updated update the people list
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    TestingComboBox();
                }
            }
        }

        private void deletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                var selectId = selectedComboBoxIndex; //måste ju ha databasens id.
                var ident = people[selectId].Id;
                con.Open();
                string insertString = @"DELETE FROM People WHERE Id = @ident";

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
                    TestingComboBox();
                }
            }
        }
        private int GetMotherId()
        {
            int i = 0;
            int motherId = 0;
            string mother = tbMotherUpdate.Text;
            foreach (var item in people)
            {
                if (people[i].FirstName == mother)
                {
                    return motherId = people[i].Id;
                }
                i++;
            }
            return motherId;
        }
        private int GetFatherId()
        {
            int i = 0;
            int fatherId = 0;
            string father = tbFatherUpdate.Text;
            foreach (var item in people)
            {
                if (people[i].FirstName == father)
                {
                    return fatherId = people[i].Id;
                }
                i++;
            }
            return fatherId;
        }
        private void ListSiblings()
        {
            List<Person> siblings = new List<Person>();
            int i = 0;
            int index = selectedComboBoxIndex;
            int mother = people[index].Mother;
            int father = people[index].Father;
            foreach (var item in people)
            {
                if (people[i].Mother == mother && i != comboBox1.SelectedIndex)
                {
                    siblings.Add(people[i]);
                }
                else if(people[i].Father == father)
                {

                }
                i++;
            }
            lbSiblings.DataSource = siblings;
            lbSiblings.DisplayMember = "FirstName";
        }
        private void ListGrandparents() //testa med fatherparents , ska inte bli dubbletter
        {
            List<Person> grandparents = new List<Person>();
            int i = 0;
            int index = selectedComboBoxIndex;
            int mother = people[index].Mother;
            int father = people[index].Father;
            int motherParents = 0;
            int fatherParents = 0;
            foreach (var item in people)
            {
                for (int person = 0; person < people.Count; person++)
                {
                    if (people[i].Id == mother)
                    {
                        motherParents = people[i].Mother;
                    }
                }

                if (people[i].Id == motherParents)
                {
                    grandparents.Add(people[i]);
                }
                i++;
            }
            lbGrandparents.DataSource = grandparents;
            lbGrandparents.DisplayMember = "FirstName";
        }
    }
}

