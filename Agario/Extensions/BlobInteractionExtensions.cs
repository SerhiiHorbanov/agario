using System;
using Agario.Extensions;
using Agario.GameObjects;

namespace Agario.Extensions
{
    static class BlobInteractionExtensions
    {
        public static void TryEat(this Blob attacker, Blob defender)
        {
            if (defender == attacker)
                return;

            if (defender.Mass > attacker.Mass * 0.95)
                return;

            if (attacker.position.Distance(defender.position) > attacker.Radius - defender.Radius)
                return;

            attacker.Mass += defender.Mass;
            attacker.shape.Radius = attacker.Radius;
            defender.ToDestroy = true;
        }

        public static void TryEat(this Blob blob, Food food)
        {
            if (blob.position.Distance(food.position) > blob.Radius - Food.radius)
                return;
            blob.Mass++;
            blob.shape.Radius = blob.Radius;
            food.ToDestroy = true;
        }
    }
}
