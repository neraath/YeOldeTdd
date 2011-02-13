namespace Improving.YeOldeTdd.Model.Tests
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class FakeCombatant : ICombatant
    {
        #region Implementation of IBattlefieldEntity

        public Guid Id { get; private set; }

        public int Health { get; set; }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public int Power { get; set; }

        public bool WasAttacked { get; set; }

        public virtual void Attack(IBattlefieldEntity enemy)
        {
            this.HasAttacked = true;
            enemy.Health--;
        }

        public string Name { get; set; }

        public IPowerGenerator PowerGenerator { get; set; }

        public void EquipWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public bool HasAttacked { get; private set; }

        #endregion
    }
}
