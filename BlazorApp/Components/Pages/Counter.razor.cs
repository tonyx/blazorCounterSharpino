using FSharpPlus.Control;
using Microsoft.FSharp.Core;
using SharpinoCounter;

namespace ASP.Components.Pages
{
    public partial class Counter {
        private static SharpinoCounterApi.SharpinoCounterApi sharpinoCount = new SharpinoCounterApi.SharpinoCounterApi();
        static Counter()
        {
            try {
                var counterGuid = Guid.Parse ("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e");
                sharpinoCount.AddCounter(counterGuid);
                sharpinoCount.Increment(counterGuid);
                sharpinoCount.Increment(counterGuid);
                sharpinoCount.Increment(counterGuid);
                sharpinoCount.Increment(counterGuid);
            }
            catch (Exception e) {
                Console.Out.WriteLine("Error initializing sharpino counter: " + e.Message);
            }
        }

        private int currentCount = sharpinoCount.GetCounter(Guid.Parse("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e")).IsOk ? sharpinoCount.GetCounter(Guid.Parse("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e")).ResultValue.State : 0;

        private void IncrementCount()
        {
            if (sharpinoCount.Increment(Guid.Parse ("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e")).IsOk) 
                {
                    currentCount = sharpinoCount.GetCounter(Guid.Parse("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e")).ResultValue.State;
                }
            else {
                Console.Out.WriteLine("Error incrementing sharpino counter");
                currentCount++;
            }
        }
    }
}