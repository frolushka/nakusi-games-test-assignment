using NakusiGames.Character;
using UnityEngine;

namespace NakusiGames.Explosion
{
    public class SimpleExplosion : ExplosionBase
    {
        protected override bool Validate(Vector3 position, GameObject damageable, IUnitHealth health) => true;

        public SimpleExplosion(float damage, float radius, LayerMask damageableMask) 
            : base(damage, radius, damageableMask)
        { }
    }
}