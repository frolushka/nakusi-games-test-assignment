using NakusiGames.Explosion;
using UnityEngine;

namespace NakusiGames.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bomb : MonoBehaviour
    {
        private IExplosionCore _explosion;

        public void Initialize(IExplosionCore explosion)
        {
            _explosion = explosion;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            _explosion.Explode(transform.position);
            Destroy(gameObject);
        }
    }
}