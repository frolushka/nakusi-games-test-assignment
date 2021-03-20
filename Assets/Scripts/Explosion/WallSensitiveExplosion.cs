using NakusiGames.Character;
using UnityEngine;

namespace NakusiGames.Explosion
{
    public class WallSensitiveExplosion : ExplosionBase
    {
        private LayerMask _obstacleMask;
        protected override bool Validate(Vector3 position, GameObject damageable, IUnitHealth health)
        {
            var offset = damageable.transform.position - position;
            return !Physics.Raycast(position, offset, offset.magnitude, _obstacleMask);
        }

        public WallSensitiveExplosion(float damage, float radius, LayerMask damageableMask, LayerMask obstacleMask) 
            : base(damage, radius, damageableMask)
        { }
    }
}