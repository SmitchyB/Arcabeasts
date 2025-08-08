using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcabeasts.DataLib
{
    public static class PlayerDataService
    {
        public static PlayerData LoadOrCreatePlayerData() // Loads existing player data or creates a new one if it doesn't exist
        {
            var db = LiteDbService.Database; // Access the LiteDB database instance
            var collection = db.GetCollection<PlayerData>("player_data"); // Get the collection for player data
            var data = collection.FindAll().FirstOrDefault(); // Try to find existing player data
            if (data == null) // If no data exists, create a new PlayerData instance
            {
                data = new PlayerData // Initialize a new PlayerData object
                {
                    UserId = Guid.NewGuid(), // Generate a new GUID for the user
                    UserProfiles = new List<UserProfile>() // Initialize an empty list of user profiles
                };
                collection.Insert(data); // Insert the new PlayerData into the collection
            }
            else if (data.UserId == Guid.Empty) // Check if the UserId is empty
            {
                data.UserId = Guid.NewGuid(); // If it is, generate a new GUID
                collection.Update(data); // Update the existing PlayerData with the new UserId
            }
            return data; // Return the loaded or newly created PlayerData
        }
        // Saves the player data to the database
        public static void SavePlayerData(PlayerData data)
        {
            var db = LiteDbService.Database; // Access the LiteDB database instance
            var collection = db.GetCollection<PlayerData>("player_data"); // Get the collection for player data
            collection.Update(data); // Update the existing PlayerData in the collection
        }
        // Updates a specific user profile in the player data based on the userId and profileIndex
        public static void UpdateUserProfile(Guid userId, int profileIndex, UserProfile updatedProfile)
        {
            var db = LiteDbService.Database; // Access the LiteDB database instance
            var collection = db.GetCollection<PlayerData>("player_data"); // Get the collection for player data
            var data = collection.FindOne(x => x.UserId == userId); // Find the PlayerData for the specified userId
            if (data == null) return; // If no PlayerData is found, exit the method
            if (profileIndex >= 0 && profileIndex < data.UserProfiles.Count) // Check if the profileIndex is valid
            {
                data.UserProfiles[profileIndex] = updatedProfile; // Update the specified user profile with the new data
                collection.Update(data); // Update the PlayerData in the collection with the modified user profiles
            }
        }
    }
}
