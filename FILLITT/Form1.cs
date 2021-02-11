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
            ClearListBox();
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"Select * from People WHERE FirstName LIKE '%" + textBox1.Text + "%'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["FirstName"]);
                listBox2.Items.Add(dr["LastName"]);
                listBox3.Items.Add(dr["BirthDate"]);
                listBox4.Items.Add(dr["DateOfDeath"]);
                listBox5.Items.Add(dr["Mother"]);
                listBox6.Items.Add(dr["Father"]);
                listBox7.Items.Add(dr["Id"]);
            }
            
            con.Close();
        }

        private void ClearListBox()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
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
                 SET FirstName = @namn, LastName = @lastnamn, BirthDate = @Birthdate, DateOfDeath = @deathdate  
                 WHERE Id = @ident";
                 
                 //values (@namn, @lastnamn, @Birthdate, @deathdate, @mother, @father)";

                SqlCommand cmd = new SqlCommand(insertString, con);
                cmd.Parameters.AddWithValue("@namn", tbFirstNameUpdate.Text);
                cmd.Parameters.AddWithValue("@lastnamn", tbLastNameUpdate.Text);
                cmd.Parameters.AddWithValue("@Birthdate", tbBirthdateUpdate.Text);
                cmd.Parameters.AddWithValue("@deathdate", tbDateOfDeathUpdate.Text);
                cmd.Parameters.AddWithValue("@mother", tbMotherUpdate.Text);
                cmd.Parameters.AddWithValue("@father", tbFatherUpdate.Text);
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
    }
}

