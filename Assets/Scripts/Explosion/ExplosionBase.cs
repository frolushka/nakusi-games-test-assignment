using NakusiGames.Character;
using UnityEngine;

namespace NakusiGames.Explosion
{
    public abstract class ExplosionBase : IExplosionCore
    {
        protected float _damage;
        protected float _radius;
        protected LayerMask _damageableMask;

        protected ExplosionBase(float damage, float radius, LayerMask damageableMask)
        {
            _damage = damage;
            _radius = radius;
            _damageableMask = damageableMask;
        }

        public void Explode(Vector3 position)
        {
            // TODO upgrade overlap to NonAlloc 
            var damageables = Physics.OverlapSphere(position, _radius, _damageableMask);
            foreach (var damageable in damageables)
            {
                if (damageable.attachedRigidbody.TryGetComponent<IUnitHealth>(out var health)
                    && Validate(position, damageable.attachedRigidbody.gameObject, health))
                {
                    health.TakeDamage(_damage);
                }
            }
        }

        protected abstract bool Validate(Vector3 position, GameObject damageable, IUnitHealth health);
    }
}