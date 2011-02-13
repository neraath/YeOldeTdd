namespace Improving.YeOldeTdd.Logic.Events
{
    using System;

    using Improving.YeOldeTdd.Model.Entities;

    public delegate void WarEnding(object sender, WarEndingEventArgs args);

    public class WarEndingEventArgs : EventArgs
    {
        public Army Victor { get; set; }

        public Army Loser { get; set; }
    }
}
