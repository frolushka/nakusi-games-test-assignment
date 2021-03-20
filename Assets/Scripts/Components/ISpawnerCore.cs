using NakusiGames.Map;
using UnityEngine;

namespace NakusiGames.Components
{
    public interface ISpawnerCore
    {
        void Spawn(Transform parent, IMapModel mapModel);
    }
}