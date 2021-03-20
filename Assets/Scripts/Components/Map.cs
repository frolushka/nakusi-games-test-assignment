using NakusiGames.Map;
using UnityEngine;

namespace NakusiGames.Components
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private GameObject wallPrefab;

        private IMapModel _mapModel;

        public void Initialize(IMapModel mapModel)
        {
            _mapModel = mapModel;
            SpawnWalls();
        }

        private void SpawnWalls()
        {
            foreach (var wallPosition in _mapModel.WallPositions)
            {
                var wall = Instantiate(wallPrefab, transform);
                wall.transform.localPosition = wallPosition;
            }
        }
    }
}