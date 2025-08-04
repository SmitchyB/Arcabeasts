using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcabeasts.DataLib
{
    public static class PlayerDataService
    {
        public static PlayerData LoadOrCreatePlayerData()
        {
            var db = LiteDbService.Database;
            var collection = db.GetCollection<PlayerData>("player_data");

            var data = collection.FindAll().FirstOrDefault();
            if (data == null)
            {
                data = new PlayerData
                {
                    UserId = Guid.NewGuid(),
                    UserProfiles = new List<UserProfile>()
                };

                collection.Insert(data);
            }
            else if (data.UserId == Guid.Empty)
            {
                // Add GUID if it somehow wasn't set
                data.UserId = Guid.NewGuid();
                collection.Update(data);
            }

            return data;
        }

        public static void SavePlayerData(PlayerData data)
        {
            var db = LiteDbService.Database;
            var collection = db.GetCollection<PlayerData>("player_data");

            collection.Update(data);
        }
        public static void UpdateUserProfile(Guid userId, int profileIndex, UserProfile updatedProfile)
        {
            var db = LiteDbService.Database;
            var collection = db.GetCollection<PlayerData>("player_data");

            var data = collection.FindOne(x => x.UserId == userId);
            if (data == null) return;

            if (profileIndex >= 0 && profileIndex < data.UserProfiles.Count)
            {
                data.UserProfiles[profileIndex] = updatedProfile;
                collection.Update(data);
            }
        }

    }

}
