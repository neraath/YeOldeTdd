namespace Improving.YeOldeTdd.Model.Entities.Weapons
{
    using System;

    public class CatapultStone : Weapon
    {
        #region Overrides of Weapon

        protected override int MinimumDamage
        {
            get
            {
                return 10;
            }
        }

        protected override int MaximumDamage
        {
            get
            {
                return 25;
            }
        }

        #endregion
    }
}
