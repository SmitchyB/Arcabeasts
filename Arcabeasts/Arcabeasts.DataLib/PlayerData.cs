using LiteDB;
using System;
using System.Collections.Generic;

namespace Arcabeasts.DataLib
{
    public class PlayerData
    {
        [BsonId]
        public Guid UserId { get; set; }
        public List<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }

    public class UserProfile
    {
        public string PlayerName { get; set; }
        public PlayerArcabeast Arcabeast { get; set; }
    }

    public class PlayerArcabeast
    {
        public string CustomName { get; set; }
        public Guid ArcabeastId { get; set; } // Unique identifier for the Arcabeast
        public int Level { get; set; }
        public int Experience { get; set; }
        public List<Guid> LearnedMoveIds { get; set; } = new List<Guid>();
    }
}
