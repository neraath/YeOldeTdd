namespace Improving.YeOldeTdd.Model.Entities
{
    using Improving.YeOldeTdd.Model.Interfaces;

    public class Catapult : Combatant
    {
        public Catapult()
            : base()
        {
        }

        public Catapult(IPowerGenerator powerGenerator)
            : base(powerGenerator)
        {
        }
    }
}
