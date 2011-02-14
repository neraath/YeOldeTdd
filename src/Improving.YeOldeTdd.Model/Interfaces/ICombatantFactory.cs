namespace Improving.YeOldeTdd.Model.Interfaces
{
    public interface ICombatantFactory
    {
        T CreateCombatant<T>() where T : ICombatant, new();

        ICombatant CreateRandomCombatant();
    }
}
