using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace FILLITT
{

    public class Database
    {
        public string ConnectionString { get; set; } = @"Data source=.\SQLEXPRESS; Integrated Security = SSPI";
        public string DatabaseName { get; set; } = "FamilyTree";
        public string TableName { get; set; } = "People";
        public List<Person> people = new List<Person>();
        /// <summary>
        /// Create a new database. If database exists do not create
        /// </summary>
        public void CreateDatabase()
        {
            //SqlConnection connect = new SqlConnection(CnnValue("FamilyTree")); fungerar såklart inte när man ska kolla om databasen lr table finns ;)
            SqlConnection connect = new SqlConnection(ConnectionString);
            var sql = @"IF EXISTS 
                       (
                        SELECT name FROM master.dbo.sysdatabases " +
                        "WHERE name = N'" + DatabaseName +
                     "')" +
                       "BEGIN " +
                       "SELECT 'Database already exist' AS Message " +
                       "END " +
                       "ELSE " +
                            "BEGIN " +
                            "CREATE DATABASE " + DatabaseName +
                            " SELECT 'Database has been created' " +
                       "END";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = connect;
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        /// <summary>
        /// Create a new table, if table exists do not create
        /// </summary>
        public void CreateTable()
        {
            SqlConnection connect = new SqlConnection(CnnValue("FamilyTree"));
            var sql = @"USE FamilyTree IF NOT EXISTS (SELECT name from sysobjects where name = 'People') CREATE TABLE People(Id int IDENTITY, FirstName nvarchar(50), LastName nvarchar(50), BirthDate nvarchar(50), DateOfDeath nvarchar(25), Mother int, Father int, PRIMARY KEY (Id))";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = connect;
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        /// <summary>
        /// Handles the connection to the database 'server'
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public void UpdatePerson()
        {
            /*
            place data in the string, parents name needs converting to name again  since we need the int to remain.
            
            */
        }
        public void CreatePerson()
        {
            
        }
        public List<Person> GetDatabaseList()
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnValue("FamilyTree")))
            {
                //return connection.Query<Person>($"Select * from People WHERE FirstName LIKE '%{name}%'").ToList(); //maybe use a like.
                people.Clear();
                return connection.Query<Person>($"Select * from People ").ToList();
            }
        }


        /* CRUD
        CreatePerson
        DeletePerson
        UpdatePerson
        LocateParents -- just om man ska söka efter en specifik person och endast få fram föräldrarna.. 
        eller att allt syns på den personen.

        
        */
    }
}
