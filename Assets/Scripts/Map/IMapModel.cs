using System.Collections.Generic;
using UnityEngine;

namespace NakusiGames.Map
{
    public interface IMapModel
    {
        IEnumerable<Vector3> WallPositions { get; }
        
        Vector3? GetRandomCharacterSpawnPoint();
        Vector3 GetRandomBombSpawnPont();
    }
}