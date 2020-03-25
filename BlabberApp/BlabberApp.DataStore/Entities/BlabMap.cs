using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlabberApp.DataStore.Entities{
    //Creates a BlabMap class
    public class BlabMap{
        //Constructor for the blab map which takes an object of type EntityTypeBuilder<Blab> that is internally named entityBuilder
        public BlabMap(EntityTypeBuilder<Blab> entityBuilder){
            //EntityTypeBuilder method to set a key (t is a blab (i'm assuming) that is passed in and sets the key as the blabs UserID)
            entityBuilder.HasKey(t => t.UserID);
            //EntityTypeBuilder method to set a property (t is a blab (i'm assuming) that is passed in, and this property is set as the Blab Message)
            entityBuilder.Property(t => t.Message);
            //The below fields are all for Base Entities
            entityBuilder.Property(t => t._SysId);
            entityBuilder.Property(t => t.CreatedDTTM);
            entityBuilder.Property(t => t.ModifiedDTTM);
        }
    } 
}