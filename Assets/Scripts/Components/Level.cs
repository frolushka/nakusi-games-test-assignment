using NakusiGames.Character;
using NakusiGames.Map;
using UnityEngine;

namespace NakusiGames.Components
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Vector2Int mapSize;
        [SerializeField] private Map map;
        [Space] 
        [SerializeField] private Spawner[] spawners;

        private void Start()
        {
            Initialize(new MapBuilder());
        }
        
        public void Initialize(MapBuilder mapBuilder)
        {
            var mapModel = mapBuilder.CreateMap(mapSize);

            if (map)
            {
                map.Initialize(mapModel);
            }

            if (spawners != null)
            {
                foreach (var spawner in spawners)
                {
                    if (spawner)
                    {
                        spawner.Initialize(mapModel);
                    }
                }
            }
        }
    }
}