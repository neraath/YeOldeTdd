namespace Improving.YeOldeTdd.Model.Interfaces
{
    public interface ICombatantFactory
    {
        T CreateCombatant<T>(string name) where T : ICombatant, new();

        ICombatant CreateRandomCombatant(string name);
    }
}
