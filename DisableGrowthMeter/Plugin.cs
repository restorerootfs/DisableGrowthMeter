using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System; // used for a Grand Total of ONE fucking line
using System.Reflection; // PatchAll using my mod GUID isnt working so fuck it patch current assembly
namespace DisableGrowthMeter
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class DGMBase : BaseUnityPlugin
    {
        // define BepInPlugin info
        private const string modGUID = "restorerootfs.lc.DisableGrowthMeter";
        private const string modName = "DisableGrowthMeter";
        private const string modVersion = "1.0.0";

        
        private readonly Harmony harmony = new Harmony(modGUID);

        private static DGMBase Instance;

        internal ManualLogSource mls;
        
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            // add funny quotes
            string[] randomMessages = {
            "If you see errors below this and they mention my mod, God help you.",
            "You're using the work of a man who has literally never TOUCHED C# ever before. Enjoy the plugin!",
            "Loaded, GLHF!",
            "My friends said upload this to Thunderstore don't dotPeek the code and laugh at me please",
            ".NET is actually a decent framework"
        };

            // decide the random index now
            int messageIndex = new Random().Next(randomMessages.Length);

            mls.LogInfo(randomMessages[messageIndex]);
            // Apply our patches
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
