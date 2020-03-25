using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System;
using System.Threading;

namespace BlabberApp.DomainTest.Entities{
    [TestClass]
    public class BaseEntityTest{
        private BaseEntity _harness;
        public BaseEntityTest() {
            _harness = new BaseEntity();
        }
        [TestMethod]
        public void TestGetSysId(){
            string expected = _harness.getSysId();
            string actual = _harness.getSysId();
            Assert.AreEqual(actual.ToString(), expected.ToString());
            Assert.AreEqual(true, _harness.getSysId() is string);
        }
        [TestMethod]
        public void TestSysIdDoesNotEqual(){
            BaseEntity _secondHarness = new BaseEntity();
            bool equals = _harness.Equals(_secondHarness.getSysId());
            Assert.AreEqual(false, equals);
        }
        [TestMethod]
        public void TestSysIdDoesEqual(){
            var equals = _harness.Equals(_harness.getSysId());
            Assert.AreEqual(true, equals);
        }
        [TestMethod]
        public void TestCreatedDttm(){
            BaseEntity Expected = new BaseEntity();
            BaseEntity Actual = new BaseEntity();
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void TestCreatedDTTMDoesNotMatch(){
            Thread.Sleep(1000);
            BaseEntity Expected = new BaseEntity();
            Assert.AreNotEqual(Expected.CreatedDTTM.ToString(), _harness.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void TestModifiedDttm(){
            // Arrange
            BaseEntity Expected = new BaseEntity();
            // Act
            BaseEntity Actual = new BaseEntity();
            // Assert
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
        [TestMethod]
        public void TestModifiedDTTMDoesNotMatch(){
            Thread.Sleep(1000);
            BaseEntity Expected = new BaseEntity();
            Assert.AreNotEqual(Expected.ModifiedDTTM.ToString(), _harness.ModifiedDTTM.ToString());
        }
    }
}
