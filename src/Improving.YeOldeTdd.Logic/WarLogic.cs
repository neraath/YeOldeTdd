namespace Improving.YeOldeTdd.Logic
{
    using Improving.YeOldeTdd.Logic.Events;
    using Improving.YeOldeTdd.Model.Entities;

    public class WarLogic
    {
        public event WarEnding OnWarEnding = delegate { };

        public void GoToWar(Army armyA, Army armyB)
        {
            while (armyA.IsAlive && armyB.IsAlive)
            {
                armyA.Attack(armyB);
                armyB.Attack(armyA);
            }

            Army victor = armyA.IsAlive ? armyA : armyB;
            Army loser = armyA.IsAlive ? armyB : armyA;
            this.InvokeOnWarEnding(victor, loser);
        }

        private void InvokeOnWarEnding(Army victor, Army loser)
        {
            WarEnding handler = this.OnWarEnding;
            handler(this, new WarEndingEventArgs() { Victor = victor, Loser = loser });
        }
    }
}
