using FSharpPlus.Control;
using Microsoft.FSharp.Core;
using SharpinoCounter;

namespace ASP.Components.Pages
{
    // using different styles to handle the "ok" "error" of the Result. None of them are desirable at the moment. 
    public partial class Counter {
        private static Guid counterGuid = Guid.Parse("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e");
        private static SharpinoCounterApi.SharpinoCounterApi sharpinoCount = new SharpinoCounterApi.SharpinoCounterApi();
        static Counter()
        {
            // not sure how to handle the error, so I use a plain old gard boolean value and then I will include other 
            // possibilities to stay closer to idiomatic F# style in C# as well.
            bool success = true;
            success = success && sharpinoCount.AddCounter(counterGuid).IsOk;
            success = success && sharpinoCount.Increment(counterGuid).IsOk;
            success = success && sharpinoCount.Increment(counterGuid).IsOk;
            success = success && sharpinoCount.Increment(counterGuid).IsOk;
            success = success && sharpinoCount.Increment(counterGuid).IsOk;
            if (!success) {
                // where is the error?
                throw new Exception("Error initializing sharpino counter");
            }
        }

        private int currentCount = sharpinoCount.GetCounter(counterGuid).IsOk ? sharpinoCount.GetCounter(counterGuid).ResultValue.State : 0;

        private void IncrementCount()
        {
            if (sharpinoCount.Increment(counterGuid).IsOk) 
                {
                    currentCount = sharpinoCount.GetCounter(counterGuid).ResultValue.State;
                }
            else {
                // what is the error?
                throw new Exception("Error in counter");
            }
        }
    }
}