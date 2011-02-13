namespace Improving.YeOldeTdd.Model.Entities.Weapons
{
    using System;

    public class Sword : Weapon
    {
        #region Overrides of Weapon

        protected override int MinimumDamage
        {
            get
            {
                return 2;
            }
        }

        protected override int MaximumDamage
        {
            get
            {
                return 10;
            }
        }

        #endregion
    }
}
