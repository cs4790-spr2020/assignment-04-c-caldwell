using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests 
    {
        private UserAdapter _harness = new UserAdapter(new InMemory());

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void AddUser()
        {
            bool accepted = false;
            User user = new User();
            _harness.Add(user);
            IEnumerable users  = _harness.GetAll();
            ArrayList list = new ArrayList(); 
            foreach (var item in users )  
            {     
                list.Add(item);
            }
            if(list.Count == 1){
                accepted = true;
            }
            Assert.AreEqual(true, accepted);
        }
        [TestMethod]
        public void AddMultipleUsers()
        {
            bool accepted = false;
            User user = new User();
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            _harness.Add(user);
            _harness.Add(user1);
            _harness.Add(user2);
            _harness.Add(user3);
            IEnumerable users  = _harness.GetAll();
            ArrayList list = new ArrayList(); 
            foreach (var item in users )  
            {     
                list.Add(item);
            }
            if(list.Count > 1 ){
                accepted = true;
            }
            Assert.AreEqual(true, accepted);
        }
        [TestMethod]
        public void UpdateUser()
        {
            User user = new User("ccaldwell@mytrexinc.com");
            _harness.Add(user);
            user.ChangeEmail("wankta@gmail.com");
            _harness.Update(user);
            IEnumerable users  = _harness.GetAll();
            ArrayList list = new ArrayList(); 
            System.Console.WriteLine(list.Count);
            foreach (var item in users )  
            {     
                list.Add(item);
            }
            User userFromInMemory = list[0] as User;
            Assert.AreNotEqual(userFromInMemory.Email, "ccaldwell@mytrexinc.com");
        }
        [TestMethod]
        public void ReadByUserID()
        {
            User user = new User("ccaldwell@mytrexinc.com");
            _harness.Add(user);
            User fromInMemory = _harness.GetById(user.Id);
            Assert.AreEqual(fromInMemory.Email, user.Email);
        }
    }
}
