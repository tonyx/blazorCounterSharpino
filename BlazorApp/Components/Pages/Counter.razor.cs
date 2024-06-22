using FSharpPlus.Control;
using Microsoft.FSharp.Core;
using static SharpinoCounter.SharpinoCounterApi;

namespace ASP.Components.Pages
{
    public partial class Counter {
        private static Guid counterGuid = Guid.Parse("3d2d4e89-3e9b-49cc-bc15-364ab3bf9d0e");
        private SharpinoCounterApi sharpinoCount;
        private int currentCount;

        private void IncrementCount()
        {
            if (sharpinoCount.Increment(counterGuid).IsOk) 
                {
                    currentCount = sharpinoCount.GetCounter(counterGuid).ResultValue.State;
                }
            else {
                throw new Exception("Error in counter");
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            sharpinoCount = new SharpinoCounterApi();
            currentCount = sharpinoCount.GetCounter(counterGuid).IsOk ? sharpinoCount.GetCounter(counterGuid).ResultValue.State : 0;
        }

    }
}