namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class Combatant : ICombatant
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
            if (enemy == null) throw new ArgumentNullException("enemy");
            if (this.PowerGenerator == null) throw new InvalidOperationException("Cannot find power generator to generate power.");

            this.Power = this.PowerGenerator.GeneratePower();

            if (enemy.IsAlive)
            {
                enemy.Health -= this.Power;
            }
        }

        public string Name { get; set; }

        public IPowerGenerator PowerGenerator { get; set; }

        #endregion
    }
}
