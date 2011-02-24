using System;
using System.Collections.Generic;

using NUnit.Framework;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using BLToolkit.Mapping;

namespace HowTo.Data
{
    using DataAccess;

    [TestFixture]
    public class SetCommand
    {
		string cs = "testConnection";
        // Select a person list.
        //
        public IList<Person> GetPersonList()
        {
            using (DbManager db = new DbManager(cs))
            {
                return db
                    .SetCommand("SELECT * FROM Person")
                    .ExecuteList<Person>();
            }
        }

        [Test]
        public void Test1()
        {
            IList<Person> list = GetPersonList();

            Assert.AreNotEqual(0, list.Count);
        }

        // Select a person.
        //
        public Person GetPersonByID(int id)
        {
            using (DbManager db = new DbManager(cs))
            {
                return db
                    .SetCommand("SELECT * FROM Person WHERE PersonID = @id",
                        db.Parameter("@id", id))
                    .ExecuteObject<Person>();
            }
        }

        [Test]
        public void Test2()
        {
            Person person = GetPersonByID(1);

            Assert.IsNotNull(person);
        }

        // Insert, Update, and Delete a person.
        //
        public Person GetPersonByID(DbManager db, int id)
        {
            return db
                .SetCommand("SELECT * FROM Person WHERE PersonID = @id",
                    db.Parameter("@id", id))
                .ExecuteObject<Person>();
        }

        public Person CreatePerson(DbManager db)
        {
            int id = db
                .SetCommand(@"
                    INSERT INTO Person ( LastName,  FirstName,  Gender)
                    VALUES             (@LastName, @FirstName, @Gender)

                    SELECT Cast(SCOPE_IDENTITY() as int) PersonID",
                    db.Parameter("@LastName",  "Frog"),
                    db.Parameter("@FirstName", "Crazy"),
                    db.Parameter("@Gender",    Map.EnumToValue(Gender.Male)))
                .ExecuteScalar<int>();

            return GetPersonByID(db, id);
        }

        public Person UpdatePerson(DbManager db, Person person)
        {
            db
                .SetCommand(@"
                    UPDATE
                        Person
                    SET
                        LastName   = @LastName,
                        FirstName  = @FirstName,
                        Gender     = @Gender
                    WHERE
                        PersonID = @PersonID",
                    db.CreateParameters(person))
                .ExecuteNonQuery();

            return GetPersonByID(db, person.ID);
        }

        public Person DeletePerson(DbManager db, Person person)
        {
            db
                .SetCommand("DELETE FROM Person WHERE PersonID = @id",
                    db.Parameter("@id", person.ID))
                .ExecuteNonQuery();

            return GetPersonByID(db, person.ID);
        }

        [Test]
        public void Test3()
        {
            using (DbManager db = new DbManager(cs))
            {
                db.BeginTransaction();

                // Insert.
                //
                Person person = CreatePerson(db);

                Assert.IsNotNull(person);

                // Update.
                //
                Assert.AreEqual(Gender.Male, person.Gender);

                person.Gender = Gender.Female;

                person = UpdatePerson(db, person);

                Assert.AreEqual(Gender.Female, person.Gender);

                // Delete.
                //
                person = DeletePerson(db, person);

                Assert.IsNull(person);

                db.CommitTransaction();
            }
        }
    }
}


namespace HowTo.DataAccess
{
    public class Person
    {
        [MapField("PersonID"), PrimaryKey, NonUpdatable]
        public int    ID;

        public string LastName;
        public string FirstName;
        public string MiddleName;
        public Gender Gender;
    }
}







namespace HowTo.DataAccess
{
    public enum Gender
    {
        [MapValue("F")] Female,
        [MapValue("M")] Male,
        [MapValue("U")] Unknown,
        [MapValue("O")] Other
    }
}