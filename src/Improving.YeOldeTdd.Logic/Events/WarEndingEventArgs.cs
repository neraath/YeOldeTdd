namespace Improving.YeOldeTdd.Logic.Events
{
    using System;

    using Improving.YeOldeTdd.Model;

    public delegate void WarEnding(object sender, WarEndingEventArgs args);

    public class WarEndingEventArgs : EventArgs
    {
        public IBattlefieldEntity Victor { get; set; }

        public IBattlefieldEntity Loser { get; set; }
    }
}
