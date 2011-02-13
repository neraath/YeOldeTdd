namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class Combatant : ICombatant
    {
        #region Protected Members

        protected IWeapon weapon;

        #endregion

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
            if (enemy == null) throw new ArgumentNullException("enemy");
            
            if (enemy.IsAlive && this.weapon != null)
            {
                enemy.Health -= this.weapon.CalculateDamage();
                enemy.WasAttacked = true;
            }
        }

        public string Name { get; set; }

        public IPowerGenerator PowerGenerator { get; set; }

        public void EquipWeapon(IWeapon weapon)
        {
            if (weapon == null) throw new ArgumentNullException("weapon");
            this.weapon = weapon;
        }

        #endregion
    }
}
