namespace Improving.YeOldeTdd.Model.Entities
{
    using Improving.YeOldeTdd.Model.Interfaces;

    public class Knight : Combatant
    {
        public Knight()
            : base()
        {
        }

        public Knight(IPowerGenerator powerGenerator)
            : base(powerGenerator)
        {
        }
    }
}
