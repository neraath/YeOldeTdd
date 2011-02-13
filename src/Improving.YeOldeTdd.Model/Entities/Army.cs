namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Factories;
    using Improving.YeOldeTdd.Model.Interfaces;

    public class Army : IBattlefieldEntity
    {
        #region Private Members

        private ICombatantFactory combatantFactory;

        private IPowerGenerator powerGenerator;

        #endregion

        #region Constructors

        public Army(IPowerGenerator powerGenerator)
            : this(powerGenerator, new CombatantFactory(powerGenerator))
        {
        }

        public Army(IPowerGenerator powerGenerator, ICombatantFactory factory)
        {
            this.powerGenerator = powerGenerator;
            this.combatantFactory = factory;
        }

        #endregion

        #region IBattfieldEntity Properties

        private int power = 1;

        private int health = 10;

        public Guid Id { get; private set; }

        public int Health 
        { 
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.health > 0;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            
            set
            {
                this.power = value;
            }
        }

        public bool WasAttacked { get; set; }

        public void Attack(IBattlefieldEntity enemy)
        {
            if (enemy == null) throw new ArgumentNullException("enemy");
            if (this.combatantFactory == null) throw new InvalidOperationException("No combatant factory to create combatants.");

            // Select a random combatant.
            ICombatant randomCombatant = this.combatantFactory.CreateRandomCombatant("My Random Combatant");
            randomCombatant.Attack(enemy);
        }

        public string Name { get; set; }

        #endregion

        public override string ToString()
        {
            return this.Name;
        }
    }
}
