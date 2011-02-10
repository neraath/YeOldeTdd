namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    public class Army : IBattlefieldEntity
    {
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

            enemy.Health -= this.Power;
            enemy.WasAttacked = true;
        }
    }
}
