
using HarmonyLib;

namespace DisableGrowthMeter.Patches
{
    [HarmonyPatch(typeof(CaveDwellerAI))]
    internal class PinGrowthMeterToZero
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void pinGrowthMeterToZero(ref float ___growthMeter)
        {
            ___growthMeter = 0f;
        }
    }
}
