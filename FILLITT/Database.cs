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
        public string DatabaseName { get; set; } = "MattiasFamilyTree";
        public string TableName { get; set; } = "People";
        public List<Person> people = new List<Person>();
 
        /// <summary>
        /// Evaluation of Database, table and population of database.
        /// </summary>
        public void RunDatabaseCheck()
        {
            bool dbExists = EvaluateDatabase();
            if (!dbExists)
            {
                CreateDatabase();
            }
            CreateTable();
            bool tblpopulated = IsTablePopulated();
            if(!tblpopulated)
            {
                DropTable();
                PopulateDatabase();
            }
        }
        /// <summary>
        /// Check if database exists
        /// </summary>
        /// <returns></returns>
        private bool EvaluateDatabase()
        {
            bool databaseEvaluationValue = false;
            SqlConnection connect = new SqlConnection(ConnectionString);
            var sql = @"SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = N'" +DatabaseName + "' ";
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
                    if(cmd.ExecuteNonQuery() != 0)
                    {
                        databaseEvaluationValue = true;
                    }
                    connect.Close();
                }
            }
            return databaseEvaluationValue;
        }
        
        /// <summary>
        /// Create a new database. If database exists do not create.
        /// </summary>
        private bool IsTablePopulated()
        {
            bool dataTableEvaluation = true;
            SqlConnection connect = new SqlConnection(CnnValue("MattiasFamilyTree"));
            var sql = @"USE MattiasFamilyTree SELECT COUNT(*) FROM People;";
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
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        dataTableEvaluation = false;
                    }
                    connect.Close();
                }
            }
            return dataTableEvaluation;
        }
        /// <summary>
        /// Before populating table it gets dropped to retain better Id structure
        /// </summary>
        private void DropTable()
        {
            SqlConnection connect = new SqlConnection(CnnValue("MattiasFamilyTree"));
            var sql = @"USE [MattiasFamilyTree] 
                    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U')) 
                    DROP TABLE [dbo].[People] 

                    SET ANSI_NULLS ON 

                    SET QUOTED_IDENTIFIER ON 

                    CREATE TABLE [dbo].[People]( 
	                    [Id] [int] IDENTITY(1,1) NOT NULL, 
	                    [FirstName] [nvarchar](50) NULL, 
	                    [LastName] [nvarchar](50) NULL, 
	                    [BirthDate] [nvarchar](50) NULL, 
	                    [DateOfDeath] [nvarchar](25) NULL, 
	                    [Mother] [int] NULL, 
	                    [Father] [int] NULL, 
                    PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC 
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY] 
                    ) ON [PRIMARY]";
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
        public void CreateDatabase()
        {
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
        /// Create a new table, if table exists do not create.
        /// </summary>
        public void CreateTable()
        {
            SqlConnection connect = new SqlConnection(CnnValue("MattiasFamilyTree"));
            var sql = @"USE MattiasFamilyTree IF NOT EXISTS (SELECT name from sysobjects where name = 'People') CREATE TABLE People(Id int IDENTITY, FirstName nvarchar(50), LastName nvarchar(50), BirthDate nvarchar(50), DateOfDeath nvarchar(25), Mother int, Father int, PRIMARY KEY (Id))";
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
        /// Handles the connection to the database 'server'.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        /// <summary>
        /// Re-populates the people list with data in the database.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetDatabaseList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnValue("MattiasFamilyTree")))
            {
                people.Clear();
                return connection.Query<Person>($"Select * from People ").ToList();
            }
        }
        /// <summary>
        /// Executes command to populate database
        /// </summary>
        private void PopulateDatabase()
        {
            SqlConnection connect = new SqlConnection(CnnValue("MattiasFamilyTree"));
            var sql = PopulateData();
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
        private string PopulateData()
        {
            const string sql = @"INSERT INTO People
                    (FirstName, LastName, BirthDate, DateOfDeath, Mother, Father)
                    VALUES
                    ('Mattias', 'Vikström', '1987', '', 4, 5),
                    ('Malin', 'Vikström', '1989', '', 4, 5),
                    ('Rasmus', 'Vikström', '1993', '', 4, 5),
                    ('Lena', 'Vikström', '1962', '', 6, 7),
                    ('Thomas', 'Vikström', '1961', '', 9, 8),
                    ('Lilith', 'Roos', '1938', '', 20, 21),
                    ('Lars', 'Roos', '1937', '1989', 0, 0),
                    ('Sven', 'Vikström', '1915', '1999', 18, 19),
                    ('Sally', 'Vikström', '1924', '1994', 0, 0),
                    ('Marie', 'Granberg', '1959', '', 6, 7),
                    ('Pär', 'Granberg', '1957', '', 0, 0),
                    ('Svante', 'Vikström', '1908', '1988', 18, 19),
                    ('Ingrid', 'Vikström', '1918', '1998', 18, 19),
                    ('Krister', 'Roos', '1964', '', 6, 7),
                    ('Hampus', 'Granberg', '1986', '', 10, 11),
                    ('Magnus', 'Granberg', '1983', '', 10, 11),
                    ('Paulina', 'Granberg', '1990', '', 10, 11),
                    ('Hilma', 'Vikström', '1881', '1967', 0, 0),
                    ('Erik', 'Vikström', '', '', 0, 0),
                    ('Elvira', 'Forsberg', '1915', '1998', 0, 0),
                    ('Efraem', 'Forsberg', '1903', '1973', 0, 0)";
            return sql;
        }
    }
}
