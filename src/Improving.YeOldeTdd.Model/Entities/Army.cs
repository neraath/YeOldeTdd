namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class Army : IBattlefieldEntity
    {
        private IPowerGenerator powerGenerator;

        private ICombatantFactory combatantFactory;

        public Army()
            : this(null)
        {
        }

        public Army(IPowerGenerator powerGenerator)
            : this(powerGenerator, null)
        {
        }

        public Army(IPowerGenerator powerGenerator, ICombatantFactory factory)
        {
            Health = 100;
            this.powerGenerator = powerGenerator;
            this.combatantFactory = factory;
        }

        public bool WasAttacked { get; set; }

        public int Health { get; set; }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public void Attack(IBattlefieldEntity enemy)
        {
            if (enemy == null) throw new ArgumentNullException("enemy");
            if (this.combatantFactory == null) throw new InvalidOperationException("No combatant factory to create combatants.");

            // Select a random combatant.
            ICombatant randomCombatant = this.combatantFactory.CreateRandomCombatant();
            randomCombatant.Attack(enemy);
        }
    }
}
