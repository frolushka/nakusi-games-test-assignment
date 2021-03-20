using NakusiGames.Components;
using NakusiGames.Map;
using NakusiGames.ScriptableObjects;
using UnityEngine;

namespace NakusiGames.Bomb
{
    public class BombSpawner : ISpawnerCore
    {
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
        }
    }
}