namespace Improving.YeOldeTdd.Model
{
    public interface IBattlefieldEntity
    {
        int Health { get; set; }

        int Power { get; set; }

        void Attack(IBattlefieldEntity enemy);
    }
}
