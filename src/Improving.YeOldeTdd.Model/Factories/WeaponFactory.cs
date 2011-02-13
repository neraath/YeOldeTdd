namespace Improving.YeOldeTdd.Model.Factories
{
    using System;

    using Improving.YeOldeTdd.Model.Entities.Weapons;
    using Improving.YeOldeTdd.Model.Interfaces;

    public class WeaponFactory : IEquipmentFactory
    {
        #region Implementation of IEquipmentFactory

        public void EquipCombatant(ICombatant combatant)
        {
            combatant.EquipWeapon(new CatapultStone());
        }

        #endregion
    }
}
