using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System;
using System.Threading;

namespace BlabberApp.DomainTest.Entities{
    [TestClass]
    public class BlabTest{
        [TestMethod]
        public void TestSetGetMessageSuccess(){
            // Arrange
            Blab harness = new Blab(); 
            string expected = "Chris is learning DOTNET CORE"; 
            harness.Message = "Chris is learning DOTNET CORE";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestSetGetMessageFail(){
            // Arrange
            Blab harness = new Blab(); 
            string expected = "Chris is not learning DOTNET CORE"; 
            harness.Message = "Chris is learning DOTNET CORE";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetUserIDSuccess(){
            Blab harness = new Blab(); 
            string expected = "ccaldwell@mytrexinc.com";
            harness.UserID = "ccaldwell@mytrexinc.com";
            string actual = harness.UserID;
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestSetGetUserIDFail(){
            Blab harness = new Blab(); 
            string expected = "ccaldwell@mytrexinc.com";
            harness.UserID = "ccaldwell@gmail.com";
            string actual = harness.UserID;
            Assert.AreNotEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestGetSysIdSuccess(){
            Blab harness = new Blab();
            string expected = harness.getSysId();
            string actual = harness.getSysId();
            Assert.AreEqual(actual.ToString(), expected.ToString());
            Assert.AreEqual(true, harness.getSysId() is string);
        }
        [TestMethod]
        public void TestSysIdDoesNotEqual(){
            Blab harness = new Blab();
            Blab secondHarness = new Blab();
            bool equals = harness.Equals(secondHarness.getSysId());
            Assert.AreEqual(false, equals);
        }
        [TestMethod]
        public void TestSysIdDoesEqual(){
            Blab harness = new Blab();
            bool equals = harness.Equals(harness.getSysId());
            Assert.AreEqual(true, equals);
        }
        [TestMethod]
        public void TestCreatedDTTMSuccess(){
            Blab Expected = new Blab();
            Blab Actual = new Blab();
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void TestCreatedDTTMFail(){
            Blab Expected = new Blab();
            Thread.Sleep(1000);
            Blab Actual = new Blab();
            Assert.AreNotEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void TestModifiedDTTM(){
            Blab Expected = new Blab();
            Blab Actual = new Blab();
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
        [TestMethod]
        public void TestCModifiedDTTMFail(){
            Blab Expected = new Blab();
            Thread.Sleep(1000);
            Blab Actual = new Blab();
            Assert.AreNotEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
    }
}
