namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    public class Army
    {
        public bool WasAttacked { get; set; }

        public void Attack(Army enemy)
        {
            if (enemy == null) throw new ArgumentNullException("enemy");
            enemy.WasAttacked = true;
        }
    }
}
