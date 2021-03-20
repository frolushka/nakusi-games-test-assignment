using System.Collections.Generic;
using UnityEngine;

namespace NakusiGames.Map
{
    public class GridMapModel : IMapModel
    {
        public IEnumerable<Vector3> WallPositions => _wallPositions;
        private List<Vector3> _wallPositions;
        private List<Vector3> _freePositions;
        
        private Vector2Int _size;

        public GridMapModel(bool[,] grid)
        {
            _size = new Vector2Int(grid.GetLength(0), grid.GetLength(1));
            
            _wallPositions = new List<Vector3>();
            _freePositions = new List<Vector3>();
            
            for (var i = 0; i < _size.x; i++)
            {
                for (var j = 0; j < _size.y; j++)
                {
                    // TODO fix y
                    var position = new Vector3(i, 0, j);
                    if (grid[i, j])
                    {
                        _wallPositions.Add(position);
                    }
                    else
                    {
                        _freePositions.Add(position);
                    }
                }
            }
        }
        
        public Vector3? GetRandomCharacterSpawnPoint()
        {
            return _freePositions.Count > 0
                ? (Vector3?)_freePositions[Random.Range(0, _freePositions.Count)]
                : null;
        }

        public Vector3 GetRandomBombSpawnPont()
        {
            var cell = GetRandomGridPoint();
            // TODO fix y
            return new Vector3(cell.x, 3, cell.y);
        }

        private Vector2 GetRandomGridPoint()
        {
            return new Vector2(Random.Range(0, _size.x), Random.Range(0, _size.y));
        }
    }
}