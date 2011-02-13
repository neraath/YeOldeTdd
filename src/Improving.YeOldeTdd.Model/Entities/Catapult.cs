namespace Improving.YeOldeTdd.Model.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class Catapult : Combatant
    {
        public override string ToString()
        {
            return "Catapult: " + this.Name;
        }
    }
}
