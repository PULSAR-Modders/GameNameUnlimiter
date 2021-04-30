using HarmonyLib;
using System.Collections.Generic;

namespace GameNameUnlimiter
{
    [HarmonyPatch(typeof(PLUIGameSettingsMenu), "ResetUIToCurrent")]
    public class HarmonyPlayerNameMenu
    {
        static void Prefix(PLUIGameSettingsMenu __instance)
        {
            __instance.GameNameInput.characterLimit = 0;
        }
    }
}
