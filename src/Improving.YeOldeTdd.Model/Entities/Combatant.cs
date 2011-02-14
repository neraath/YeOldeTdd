namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class Combatant : ICombatant
    {
        private IPowerGenerator powerGenerator;

        #region Implementation of ICombatant

        public Combatant()
            : this(null)
        {
        }

        public Combatant(IPowerGenerator powerGenerator)
        {
            this.Health = 100;
            this.powerGenerator = powerGenerator;
        }

        public int Health { get; set; }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public int Power
        {
            get
            {
                if (this.powerGenerator == null) throw new InvalidOperationException();
                return this.powerGenerator.GeneratePower();
            }
        }

        public bool WasAttacked { get; set; }

        public virtual void Attack(IBattlefieldEntity enemy)
        {
            if (enemy == null) throw new ArgumentNullException("enemy");

            if (enemy.IsAlive)
            {
                enemy.Health -= this.Power;
                enemy.WasAttacked = true;
            }
        }

        #endregion
    }
}
