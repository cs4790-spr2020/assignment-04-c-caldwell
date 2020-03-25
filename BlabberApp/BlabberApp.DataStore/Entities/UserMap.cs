using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlabberApp.DataStore.Entities{
    //Creation of a UserMap class
   public class UserMap{
       //UserMap takes an argument of type EntityTypeBuilder<User> named entityBuilder internally
       public UserMap(EntityTypeBuilder<User> entityBuilder){
           //EntityTypeBuilder method to set a key (t is passed in (i'm assuming that is the user) and the property is set for email, and set as the key)
           entityBuilder.HasKey(t => t.Email);
           //EntityTypeBuilder method to set a property (t is passed in (i'm assuming that is the user) and the property for RegisterDTTM is set)
           entityBuilder.Property(t => t.RegisterDTTM).IsRequired();
           //EntityTypeBuilder method to set a property (t is passed in (i'm assuming that is the user) and the property for LastLoginTTM is set)
           entityBuilder.Property(t => t.LastLoginDTTM).IsRequired();
           //The below fields are all base entity fields
           entityBuilder.Property(t => t._SysId);
           entityBuilder.Property(t => t.CreatedDTTM);
           entityBuilder.Property(t => t.ModifiedDTTM);
       }
   } 
}