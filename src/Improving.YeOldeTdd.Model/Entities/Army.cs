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

            // Randomize the power. 
            Random randGen = new Random();
            this.Power = randGen.Next(20);

            if (enemy.IsAlive)
            {
                enemy.Health -= this.Power;
                enemy.WasAttacked = true;
            }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
