namespace Improving.YeOldeTdd.Model.Factories
{
    using System;

    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Entities.Weapons;
    using Improving.YeOldeTdd.Model.Interfaces;

    public class CombatantFactory : ICombatantFactory
    {
        private IPowerGenerator powerGenerator;

        private IEquipmentFactory equipmentFactory;

        public CombatantFactory(IPowerGenerator generator, IEquipmentFactory equipmentFactory)
        {
            this.powerGenerator = generator;
            this.equipmentFactory = equipmentFactory;
        }

        public T CreateCombatant<T>(string name) where T : ICombatant, new()
        {
            T combatant = new T() { Health = 100, Name = name, PowerGenerator = powerGenerator };
            equipmentFactory.EquipCombatant(combatant);

            return combatant;
        }

        public ICombatant CreateRandomCombatant(string name)
        {
            Random randomizer = new Random();
            int randomValue = randomizer.Next(1, 29);

            ICombatant combatant = null;
            if (randomValue < 10)
            {
                combatant = new Catapult() { Health = 100, Name = name, PowerGenerator = powerGenerator };
            }
            else if (randomValue < 20)
            {
                combatant = new Knight() { Health = 100, Name = name, PowerGenerator = powerGenerator };
            }
            else if (randomValue < 30)
            {
                combatant = new Combatant() { Health = 100, Name = name, PowerGenerator = powerGenerator };
            }

            equipmentFactory.EquipCombatant(combatant);

            return combatant;
        }
    }
}
