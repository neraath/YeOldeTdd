namespace Improving.YeOldeTdd.Model.Interfaces
{
    using System;

    public interface IBattlefieldEntity
    {
        int Health { get; set; }

        bool IsAlive { get; }

        bool WasAttacked { get; set; }

        void Attack(IBattlefieldEntity enemy);
    }
}
