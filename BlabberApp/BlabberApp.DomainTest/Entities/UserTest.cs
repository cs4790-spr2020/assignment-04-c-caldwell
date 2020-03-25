using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System.Threading;

namespace BlabberApp.DomainTest.Entities{
    [TestClass]
    public class UserTest{
        [TestMethod]
        public void TestSetGetEmail_Success(){
            User harness = new User(); 
            string expected = "foobar@example.com";
            harness.ChangeEmail("foobar@example.com");
            string actual = harness.Email; 
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail00(){
            User harness = new User(); 
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail01(){
            User harness = new User(); 
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail02(){
            User harness = new User(); 
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestGetSysId(){
            User harness = new User();
            string expected = harness.getSysId();
            string actual = harness.getSysId();
            Assert.AreEqual(actual.ToString(), expected.ToString());
            Assert.AreEqual(true, harness.getSysId() is string);
        }
        [TestMethod]
        public void TestSysIdDoesNotEqual(){
            User harness = new User();
            User secondHarness = new User();
            bool equals = harness.Equals(secondHarness.getSysId());
            Assert.AreEqual(false, equals);
        }
        [TestMethod]
        public void TestSysIdDoesEqual(){
            User harness = new User();
            bool equals = harness.Equals(harness.getSysId());
            Assert.AreEqual(true, equals);
        }
        [TestMethod]
        public void TestCreatedDTTMSuccess(){
            User Expected = new User();
            User Actual = new User();
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void TestCreatedDTTMFail(){
            User Expected = new User();
            Thread.Sleep(1000);
            User Actual = new User();
            Assert.AreNotEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void TestModifiedDTTM(){
            User Expected = new User();
            User Actual = new User();
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
        [TestMethod]
        public void TestCModifiedDTTMFail(){
            User Expected = new User();
            Thread.Sleep(1000);
            User Actual = new User();
            Assert.AreNotEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }   



    }
}
