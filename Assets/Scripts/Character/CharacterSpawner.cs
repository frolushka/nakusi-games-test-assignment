using System.Collections;
using NakusiGames.Map;
using NakusiGames.ScriptableObjects;
using UnityEngine;

namespace NakusiGames.Components
{
    public class CharacterSpawner : ISpawnerCore
    {
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
        }
    }
}