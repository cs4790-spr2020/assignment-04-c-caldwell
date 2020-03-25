using BlabberApp.Domain.Entities;
using BlabberApp.DataStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore{
    //Creates an ApplicationContext class that extends DbContext
    public class ApplicationContext : DbContext{
        //The constructor for creating an ApplicationContext which takes a DBContextOptions<ApplicationContext> as an argument internally named options and extends base(options)
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {

        }
        //Protected method that OnModelCreating which accepts a ModelBuilder object and builds our Model
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //I'm not gonna lie.. I have no idea what this does. It appears to create some sort of DB model that allows us to add Entities
            base.OnModelCreating(modelBuilder);
            //This looks like it uses the ModelBuilder method .Entity to create an entity for Blab
            new BlabMap(modelBuilder.Entity<Blab>());
            //This looks like it uses the ModelBuilder method .Entity to create an entity for User
            new UserMap(modelBuilder.Entity<User>());
        }
    }
}