namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class Army : IBattlefieldEntity
    {
        private IPowerGenerator powerGenerator;

        public Army()
            : this(null)
        {
        }

        public Army(IPowerGenerator powerGenerator)
        {
            this.powerGenerator = powerGenerator;
            Health = 100;
        }

        public bool WasAttacked { get; set; }

        public int Power 
        { 
            get
            {
                if (this.powerGenerator == null) throw new InvalidOperationException();
                return this.powerGenerator.GeneratePower();
            }
        }

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
            enemy.WasAttacked = true;
            enemy.Health -= this.Power;
        }
    }
}
