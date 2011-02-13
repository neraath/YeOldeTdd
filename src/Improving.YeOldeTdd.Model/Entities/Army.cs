namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    public class Army
    {
        public Army()
        {
            Health = 100;
        }

        public bool WasAttacked { get; set; }

        public int Power { get; set; }

        public int Health { get; set; }

        public void Attack(Army enemy)
        {
            if (enemy == null) throw new ArgumentNullException("enemy");
            enemy.WasAttacked = true;
            enemy.Health -= this.Power;
        }
    }
}
