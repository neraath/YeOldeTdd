namespace Improving.YeOldeTdd.Model
{
    using System;

    public interface IBattlefieldEntity
    {
        Guid Id { get; }

        int Health { get; set; }

        int Power { get; set; }

        bool WasAttacked { get; set; }

        void Attack(IBattlefieldEntity enemy);
    }
}
