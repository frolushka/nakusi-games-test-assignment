using NakusiGames.Character;
using NakusiGames.Explosion;
using UnityEngine;

namespace NakusiGames.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Bomb Parameter Factory", menuName = "Bomb/Patameter Factory", order = 0)]
    public class BombParameterFactory : ScriptableObject
    {
        [SerializeField] private GameObject[] views;
        [SerializeField] private LayerMask obstacleMask;
        [SerializeField] private LayerMask damageableMask;
        [SerializeField] private float damage;
        [SerializeField] private float radius;

        public GameObject View => views[Random.Range(0, views.Length)];
        
        private System.Lazy<SimpleExplosion> _cachedSimpleExplosion;
        private System.Lazy<WallSensitiveExplosion> _cachedWallSensitiveExplosion;
        public IExplosionCore Explosion
        {
            get
            {
                if (Random.value > 0.3f)
                {
                    return _cachedSimpleExplosion.Value;
                }
                else
                {
                    return _cachedWallSensitiveExplosion.Value;
                }
            }
        }

        private void OnEnable()
        {
            _cachedSimpleExplosion = new System.Lazy<SimpleExplosion>(() => new SimpleExplosion(damage, radius, damageableMask));
            _cachedWallSensitiveExplosion = new System.Lazy<WallSensitiveExplosion>(() => new WallSensitiveExplosion(damage, radius, damageableMask, obstacleMask));
        }
    }
}