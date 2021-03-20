using System.Collections;
using NakusiGames.Logger;
using NakusiGames.Map;
using NakusiGames.ScriptableObjects;
using UnityEngine;
using ILogger = NakusiGames.Logger.ILogger;

namespace NakusiGames.Components
{
    public class CharacterSpawner : ISpawnerCore
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(CharacterSpawner));

        [SerializeField] private Character characterPrefab;
        [SerializeField] private CharacterParameterFactory _parameterFactory;

        public void Spawn(Transform parent, IMapModel mapModel)
        {
            var freeCell = mapModel.GetRandomCharacterSpawnPoint();
            if (!freeCell.HasValue)
                return;
            
            var character = Character.Instantiate(characterPrefab);
            character.transform.SetParent(parent);
            character.transform.localPosition = freeCell.Value;

            GameObject.Instantiate(_parameterFactory.View, character.transform);

            character.Initialize(_parameterFactory.CharacterHealth);
            
            Logger.Debug($"Spawned character at cell {freeCell}");
        }
    }
}