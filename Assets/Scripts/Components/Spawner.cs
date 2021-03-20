using System.Collections;
using NakusiGames.Bomb;
using NakusiGames.Components;
using NakusiGames.Map;
using UnityEngine;

namespace NakusiGames.Character
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay;
        [SerializeReference] private ISpawnerCore _core;

        public void Initialize(IMapModel mapModel)
        {
            StartCoroutine(RepeativeSpawn());

            IEnumerator RepeativeSpawn()
            {
                var charactersParent = new GameObject($"{_core.GetType()}.Spawned");
                var cachedDelay = new WaitForSeconds(spawnDelay);
                while (true)
                {
                    yield return cachedDelay;
                    
                    _core.Spawn(charactersParent.transform, mapModel);
                }
            }
        }
        
        #region Editor

        [ContextMenu("Set character core")]
        private void SetCharacterCore()
        {
            _core = new CharacterSpawner();
        }
        
        [ContextMenu("Set bomb core")]
        private void SetBombCore()
        {
            _core = new BombSpawner();
        }
        
        #endregion
    }
}