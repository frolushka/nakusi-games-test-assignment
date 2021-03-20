using NakusiGames.Character;
using UnityEngine;

namespace NakusiGames.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Character Parameter Factory", menuName = "Character/Patameter Factory", order = 0)]
    public class CharacterParameterFactory : ScriptableObject
    {
        [SerializeField] private GameObject[] views;
        [SerializeField] private float health;

        public GameObject View => views[Random.Range(0, views.Length)];
        public IUnitHealth CharacterHealth => new CharacterHealth(health);
    }
}