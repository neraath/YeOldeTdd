namespace Improving.YeOldeTdd.Model.Factories
{
    using System;
    using System.Reflection;

    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Interfaces;

    public class CombatantFactory : ICombatantFactory
    {
        private IPowerGenerator powerGenerator;

        public CombatantFactory(IPowerGenerator generator)
        {
            powerGenerator = generator;
        }

        public ICombatant CreateRandomCombatant()
        {
            Random randomizer = new Random();
            int randomValue = randomizer.Next(1, 29);

            ICombatant combatant = null;
            if (randomValue < 10)
            {
                combatant = new Catapult(powerGenerator);
            }
            else if (randomValue < 20)
            {
                combatant = new Knight(powerGenerator);
            }
            else if (randomValue < 30)
            {
                combatant = new Combatant(powerGenerator);
            }

            return combatant;
        }
    }
}
