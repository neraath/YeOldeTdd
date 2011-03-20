namespace Improving.YeOldeTdd.Logic
{
    using System;

    using Improving.YeOldeTdd.Logic.Events;
    using Improving.YeOldeTdd.Model;

    public class WarLogic
    {
        public event WarEnding OnWarEnding = delegate { };

        private void InvokeOnWarEnding(IBattlefieldEntity victor, IBattlefieldEntity loser)
        {
            WarEnding handler = this.OnWarEnding;
            handler(this, new WarEndingEventArgs() { Victor = victor, Loser = loser });
        }

        public void GoToWar(IBattlefieldEntity armyA, IBattlefieldEntity armyB) {
            while (armyA.IsAlive && armyB.IsAlive)
            {
                armyA.Attack(armyB);
                armyB.Attack(armyA);
            }

            IBattlefieldEntity victor = armyA.IsAlive ? armyA : armyB;
            IBattlefieldEntity loser = armyA.IsAlive ? armyB : armyA;
            this.InvokeOnWarEnding(victor, loser);
        }

    }
}
