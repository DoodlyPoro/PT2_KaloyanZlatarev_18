using System;
using DataLayer;
using BusinessLayer;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestingLayer
{
    [TestFixture]
    public class UserContextTest
    {
        private UserContext context = new UserContext(SetupFixture.dbContext);
        private User user;
        private Game g1, g2;

        [SetUp]
        public void CreateUser()
        {
            user = new User("Pesho", "Svetkavicata", 17, "McQueen", "iAmSpeed", "iAm@fast.af");

            g1 = new Game("Tag");
            g2 = new Game("Car race");

            user.Games.Add(g1);
            user.Games.Add(g2);

            context.Create(user);
        }

        [TearDown]
        public void DropUser()
        {
            foreach (User user in SetupFixture.dbContext.Users)
            {
                SetupFixture.dbContext.Users.Remove(user);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            User newUser = new User("dido", "Yordanov", 17, "Splyx", "randompass", "splyx@gmail.com");

            int usersBefore = SetupFixture.dbContext.Users.Count();
            context.Create(newUser);

            int usersAfter = SetupFixture.dbContext.Users.Count();
            Assert.IsTrue(usersBefore + 1 == usersAfter, "Create() doesn't work!");
        }

        [Test]
        public void Read()
        {
            User readUser = context.Read(user.Id);

            Assert.AreEqual(user, readUser, "Read() doesn't return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            User readUser = context.Read(user.Id, true);

            Assert.That(readUser.Games.Contains(g1) && readUser.Games.Contains(g2), "g1 and g2 is not in the Games list!");
        }

        [Test]
        public void ReadAll()
        {
            List<User> users = (List<User>)context.ReadAll();

            Assert.That(users.Count != 0, "ReadAll() doesn't return users!");
        }

        [Test]
        public void Update()
        {
            User changeUser = context.Read(user.Id);

            changeUser.FirstName = "New First Name";
            changeUser.Password = "1234";

            context.Update(changeUser);

            Assert.AreEqual(changeUser, user, "Update() doesn't work!");
        }

        [Test]
        public void Delete()
        {
            int usersBefore = SetupFixture.dbContext.Users.Count();

            context.Delete(user.Id);
            int usersAfter = SetupFixture.dbContext.Users.Count();

            Assert.IsTrue(usersBefore - 1 == usersAfter, "Delete() doesn't work!");
        }
    }
}

