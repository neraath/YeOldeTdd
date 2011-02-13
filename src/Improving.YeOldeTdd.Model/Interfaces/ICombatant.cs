namespace Improving.YeOldeTdd.Model.Interfaces
{
    public interface ICombatant : IBattlefieldEntity
    {
        IPowerGenerator PowerGenerator { get; set; }

        void EquipWeapon(IWeapon weapon);
    }
}
