using NakusiGames.Bomb;
using NakusiGames.Logger;
using UnityEngine;
using ILogger = NakusiGames.Logger.ILogger;

namespace NakusiGames.Character
{
    public class CharacterHealth : IUnitHealth
    {
        private static readonly ILogger Logger = LoggerFactory.GetLogger(typeof(CharacterHealth));

        private float _currentHealth;
        
        public event IUnitHealth.DeathHandler OnDeath;

        public CharacterHealth(float defaultHealth)
        {
            _currentHealth = defaultHealth;
        }
        
        public void TakeDamage(float value)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - value);
            Logger.Debug($"Got damage: {value}, current health: {_currentHealth}");
            
            if (_currentHealth == 0)
            {
                Logger.Debug($"Current health is equal to 0. Invoke OnDeath.");
                OnDeath?.Invoke();
            }
        }   
    }
}