namespace Improving.YeOldeTdd.Logic.Factories
{
    using System;

    using Improving.YeOldeTdd.Model.Interfaces;

    public class PowerGenerator : IPowerGenerator
    {
        public int GeneratePower()
        {
            Random randomizer = new Random();
            return randomizer.Next(1, 20);
        }
    }
}
