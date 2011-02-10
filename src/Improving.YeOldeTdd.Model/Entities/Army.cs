namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    public class Army : IBattlefieldEntity
    {
        public Guid Id { get; private set; }

        public int Health { get; set; }

        public int Power { get; set; }

        public bool WasAttacked { get; set; }

        public void Attack(IBattlefieldEntity enemy)
        {
            if (enemy == null) throw new ArgumentNullException("enemy");

            enemy.WasAttacked = true;
        }
    }
}
