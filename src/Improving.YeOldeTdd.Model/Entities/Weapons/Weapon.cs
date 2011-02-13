namespace Improving.YeOldeTdd.Model.Entities.Weapons
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public abstract class Weapon : IWeapon
    {
        #region Implementation of IWeapon

        protected abstract int MinimumDamage { get; }

        protected abstract int MaximumDamage { get; }

        public virtual int CalculateDamage()
        {
            Random randomizer = new Random();
            return randomizer.Next(this.MinimumDamage, this.MaximumDamage);
        }

        #endregion
    }
}
