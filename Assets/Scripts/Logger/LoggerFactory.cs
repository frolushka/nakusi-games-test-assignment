using System;
using System.Collections.Generic;

namespace NakusiGames.Logger
{
    public static class LoggerFactory
    {
        private static readonly Dictionary<System.Type, ILogger> Cache = new Dictionary<Type, ILogger>();
        public static ILogger GetLogger(System.Type type)
        {
            if (!Cache.ContainsKey(type))
            {
                Cache[type] = new ConsoleLogger(type);
            }
            
            return Cache[type];
        }
    }
}