using NakusiGames.Components;
using NakusiGames.Logger;
using NakusiGames.Map;
using NakusiGames.ScriptableObjects;
using UnityEngine;
using ILogger = NakusiGames.Logger.ILogger;

namespace NakusiGames.Bomb
{
    public class BombSpawner : ISpawnerCore
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(BombSpawner));
        
        [SerializeField] private Components.Bomb bombPrefab;
        [SerializeField] private BombParameterFactory parameterFactory;

        public void Spawn(Transform parent, IMapModel mapModel)
        {
            var cell = mapModel.GetRandomBombSpawnPont();
            
            var bomb = Components.Bomb.Instantiate(bombPrefab);
            bomb.transform.SetParent(parent);
            bomb.transform.localPosition = cell;
            
            GameObject.Instantiate(parameterFactory.View, bomb.transform);
            
            bomb.Initialize(parameterFactory.Explosion);
            
            Logger.Debug($"Spawned bomb at cell {cell}");
        }
    }
}