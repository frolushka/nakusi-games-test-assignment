using UnityEngine;

namespace NakusiGames.Character
{
    public class CharacterHealth : IUnitHealth
    {
        private float _currentHealth;
        
        public event IUnitHealth.DeathHandler OnDeath;

        public CharacterHealth(float defaultHealth)
        {
            _currentHealth = defaultHealth;
        }
        
        public void TakeDamage(float value)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - value);
            if (_currentHealth == 0)
            {
                OnDeath?.Invoke();
            }
        }   
    }
}