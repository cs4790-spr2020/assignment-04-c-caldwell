using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;
using System.Collections.Generic;
using System;

namespace BlabberApp.DataStoreTest{
    [TestClass]
    //Class for testing in memory user
    public class InMemory_User_UnitTests {
        //Object for an in memory user for testing
        private InMemory<User> _harness;
        //Constructor which takes no unit tests
        public InMemory_User_UnitTests()
        {
            //I have literally no idea what any of this does BUT it looks like we are creating an options variable
            //That is a DBContextOptionsBuilder of type ApplicationContext which uses an in memory database
            //With an options thing at the end
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            //Harness variable is set with a new application context with the above options.
            _harness = new InMemory<User>(new ApplicationContext(options));
        }

        [TestMethod]
        //Class for testing the adding of a user and getting a user by ID
        public void Add_User_GetByUserId_Success()
        {
            // Arrange
            User Expected = new User();
            Expected.ChangeEmail("foo@bar.com");
            var email = Expected.Email;
            _harness.Add(Expected);
            // Act
            User Actual = (User)_harness.GetByUserId(email);
            // Assert
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void Add_User_GetBySysId_Success(){
            User newUser = new User();
            newUser.ChangeEmail("ccaldwell@mytrexinc.com");
            string sysID = newUser.getSysId();
            _harness.Add(newUser);
            User blabReturnedFromInMemory = (User)_harness.GetBySysId(sysID);
            Assert.AreEqual(blabReturnedFromInMemory, newUser);
        }

        public void Remove_Blab_BySysId(){
            User newUser = new User();
            newUser.ChangeEmail("ccaldwell@gmail.com");
            _harness.Add(newUser);
            int ogLength = _harness.GetDataSetLength();
            _harness.Remove(newUser);
            int newLength = _harness.GetDataSetLength();
            bool correct = false;
            if(newLength == (ogLength - 1)){
                correct = true;
            }
            Assert.AreEqual(true, correct);
        }
        [TestMethod]
        //Class for testing the adding of a blab and getting a user by ID
        public void Update_Blab(){
            User newUser = new User();
            newUser.ChangeEmail("ccaldwell@yahoo.com");
            string sysID = newUser.getSysId();
            _harness.Add(newUser);
            _harness.Update(newUser);
            User blabReturnedFromInMemory = (User)_harness.GetBySysId(sysID);
            Assert.AreEqual(newUser, blabReturnedFromInMemory);
        }

        [TestMethod]
        //Class for testing the adding of a blab and getting a user by ID
        public void Get_All_Blabs_BlabsExist(){
            User newUser = new User();
            newUser.ChangeEmail("chris@yahoo.com");
            _harness.Add(newUser);
            IEnumerable<BaseEntity> allBlabs =  _harness.GetAll();
            int count = 0;
            foreach(var blab in allBlabs){
                count++;
            }
            bool hasItems = false;
            if(count > 0 ){
                hasItems = true;
            }
            Assert.AreEqual(hasItems, true);
        }
    }
}
