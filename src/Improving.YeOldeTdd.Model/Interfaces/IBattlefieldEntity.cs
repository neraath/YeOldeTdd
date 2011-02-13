namespace Improving.YeOldeTdd.Model
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public interface IBattlefieldEntity
    {
        Guid Id { get; }

        int Health { get; set; }

        bool IsAlive { get; }

        int Power { get; set; }

        bool WasAttacked { get; set; }

        void Attack(IBattlefieldEntity enemy);

        string Name { get; set; }
    }
}
