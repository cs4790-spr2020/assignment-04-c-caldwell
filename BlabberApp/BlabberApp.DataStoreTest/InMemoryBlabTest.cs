using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;
using System.Collections.Generic;
using System;

namespace BlabberApp.DataStoreTest{
    [TestClass]
    //Class for testing in memory blab
    public class InMemory_Blab_UnitTests: Blab {
        //Object for an in memory blab for testing
        private InMemory<Blab> _harness;
        //Constructor which takes no unit tests
        public InMemory_Blab_UnitTests(){
            //I have literally no idea what any of this does BUT it looks like we are creating an options variable
            //That is a DBContextOptionsBuilder of type ApplicationContext which uses an in memory database
            //With an options thing at the end
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            //Harness variable is set with a new application context with the above options.
            _harness = new InMemory<Blab>(new ApplicationContext(options));
        }
        [TestMethod]
        public void Add_Blab_GetBySysId_Success(){
            Blab newBlab = new Blab();
            newBlab.Message = "Hello, this is Chris blabbing for the first time";
            newBlab.UserID = "ccaldwell@mytrexinc.com";
            string sysID = newBlab.getSysId();
            _harness.Add(newBlab);
            Blab blabReturnedFromInMemory = (Blab)_harness.GetBySysId(sysID);
            Assert.AreEqual(blabReturnedFromInMemory, newBlab);
        }
        [TestMethod]
        //Class for testing the adding of a blab and getting a user by ID
        public void Add_Blab_GetByUserId_Success(){
            // Arrange
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida posuere pretium. Cras maximus nibh sed accumsan elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = Email;
            _harness.Add(Expected);
            // Act
            Blab Actual = (Blab)_harness.GetByUserId(Email);
            // Assert
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        //Class for testing the adding of a blab and getting a user by ID
        public void Remove_Blab_BySysId(){
            Blab newBlab = new Blab();
            newBlab.Message = "Hello, this is Chris blabbing for the first time";
            newBlab.UserID = "ccaldwell@gmail.com";
            _harness.Add(newBlab);
            int ogLength = _harness.GetDataSetLength();
            _harness.Remove(newBlab);
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
            Blab newBlab = new Blab();
            newBlab.Message = "Hello, this is Chris blabbing for the first time";
            newBlab.UserID = "ccaldwell@yahoo.com";
            string sysID = newBlab.getSysId();
            _harness.Add(newBlab);
            newBlab.Message = "I lied, this is my second blab";
            _harness.Update(newBlab);
            Blab blabReturnedFromInMemory = (Blab)_harness.GetBySysId(sysID);
            Assert.AreEqual(newBlab, blabReturnedFromInMemory);
        }

        [TestMethod]
        //Class for testing the adding of a blab and getting a user by ID
        public void Get_All_Blabs_BlabsExist(){
            Blab newBlab = new Blab();
            newBlab.Message = "Hello, this is not Chris blabbing for the first time";
            newBlab.UserID = "chris@yahoo.com";
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
