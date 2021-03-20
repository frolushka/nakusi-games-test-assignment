using NakusiGames.Character;
using UnityEngine;

namespace NakusiGames.Components
{
    public class Character : MonoBehaviour, IUnitHealth
    {
        private IUnitHealth _health;
        
        public event IUnitHealth.DeathHandler OnDeath
        {
            add => _health.OnDeath += value;
            remove => _health.OnDeath -= value;
        }

        public void Initialize(IUnitHealth health)
        {
            _health = health;
            _health.OnDeath += DestroyCharacter;
        }

        private void DestroyCharacter()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);
        }
    }
}