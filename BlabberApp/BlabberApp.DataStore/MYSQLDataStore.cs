// using BlabberApp.Domain.Entities;
// using BlabberApp.Domain.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace BlabberApp.DataStore{
//     public class MYSQLDataStore<T> : IRepository<T> where T : BaseEntity{
//         private ApplicationContext Context;
//         private DbSet<T> _entities; 
//         public MYSQLDataStore(ApplicationContext context){
//             //Sets the context varibale
//             Context = context;
//             //uses the context object to set something.. but I'm not sure what
//             _entities = context.Set<T>();
//         }
//         //Method for adding an entity
//         public void Add(T entity){
//             //Throws an exception if null
//             if (entity == null){
//                 throw new ArgumentNullException("entity");
//             }
//             //Adds the entity to the entities collection
//             _entities.Add(entity);
//             //Saves the changes to the context?
//             Context.SaveChanges();
//         }
//         //Method for removing an entity
//         public void Remove(T entity){
//             //Throws exception if the entity is null
//             if (entity == null){
//                 throw new ArgumentNullException("entity");
//             }
//             //REmoves the entity from the DBSet _entities
//             _entities.Remove(entity);
//             //Saves the changes to the context
//             Context.SaveChanges();
//         }
//         //Method for updating an entity
//         public void Update(T entity){
//             //Throws exception if the entity is null
//             if (entity == null){
//                 throw new ArgumentNullException("entity");
//             }
//             //This saves the changes to the context, but it doesn't look like it actually does anything to change the _entities variable so I'm not sure what its updating
//             _entities.Update(entity);
//             Context.SaveChanges();
//         }
//         //Returns the entities as an enumerable.. but it doesn't test if it actually has anything in it so what would happen if it was empty?
//         public IEnumerable<T> GetAll(){
//             //Returns the _entities as an enumerable
//             return _entities.AsEnumerable();
//         }
//         //Returns an entity by its sysId
//         public T GetBySysId(string sysId){
//             //Checks if the string is blank and throws a sysID null exception
//             if (sysId.Equals("")){
//                 throw new ArgumentNullException("sysId");
//             }
            
//             //returns a single specific element, or the default value if that element is not found. What is the default value?
//             // string sqlstatement = "SELECT * FROM Add_writes WHERE "
//             // T returnedObj = _entities.FromSql();
//             return _entities.FirstOrDefault(p => p._SysId == sysId);
            
//         }
//         //Returns an entity found by the user ID
//         public T GetByUserId(string userId){
//             //Checks if the userID is blank and throws a userId exception if it is
//             if ( userId.Equals("")){
//                 throw new ArgumentNullException("userId");
//             }
//             //returns all entities with that user ID
//             return _entities.Find(userId);
//         }

//         public int GetDataSetLength(){
//             return _entities.Count();
//         }
//     }
// }
