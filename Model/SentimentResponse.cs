
namespace FinalBlazor_ServerApp.Model
{
    public class ModelOutput
    {
        public uint Label { get; set; }

        public float PredictedLabel { get; set; }

        public float[] Score { get; set; }
    }
}
