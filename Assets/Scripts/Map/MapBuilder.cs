using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NakusiGames.Map
{
    public class MapBuilder
    {
        public IMapModel CreateMap(Vector2Int size)
        {
            // TODO better wrong size handling?
            if (size.x <= 3 && size.y <= 3)
            {
                throw new System.ArgumentOutOfRangeException(nameof(size), "size.x and size.y must be strictly greater than 3");
            }
            
            var grid = new bool[size.x, size.y];
            CreateEnclosedSquare(grid, size);
            FillWithRandomWalls(grid, size);
            return new GridMapModel(grid);
        }

        private static void CreateEnclosedSquare(bool[,] grid, Vector2Int size)
        {
            for (var i = 0; i < size.x; i++)
            {
                grid[i, 0] = true;
                grid[i, size.y - 1] = true;
            }
            for (var j = 0; j < size.y; j++)
            {
                grid[0, j] = true;
                grid[size.x - 1, j] = true;
            }
        }

        private static void FillWithRandomWalls(bool[,] grid, Vector2Int size)
        {
            for (var i = 1; i < size.x - 1; i++)
            {
                for (var j = 1; j < size.y - 1; j++)
                {
                    grid[i, j] = Random.value > 0.5f;
                }
            }
        }
    }
}
