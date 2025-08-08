using LiteDB;
using System;
using System.IO;

namespace Arcabeasts.DataLib
{
    public static class LiteDbService
    {
        private static readonly string _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArcabeastUserData.db"); //Db file path
        private static readonly Lazy<LiteDatabase> _dbInstance = new Lazy<LiteDatabase>(() => new LiteDatabase(_dbPath)); //database instance
        public static LiteDatabase Database => _dbInstance.Value; // Public property to access the database instance
    }
}
