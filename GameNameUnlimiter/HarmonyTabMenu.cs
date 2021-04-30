using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using static PulsarPluginLoader.Patches.HarmonyHelpers;

namespace GameNameUnlimiter
{
    [HarmonyPatch(typeof(PLTabMenu), "ClickSendItemOfIndex")]
    class HarmonyTabMenu
    {
        public static string RemoveColor(string text)
        {
            while (true)
            {
                int index = text.IndexOf("<color=");
                if (index < 0)
                    break;
                int endIndex = index;
                bool valid = false;
                for (; endIndex < text.Length; endIndex++)
                {
                    if (text[endIndex] == '>')
                    {
                        valid = true;
                        break;
                    }
                }
                if (valid)
                {
                    text = text.Remove(index, endIndex - index + 1);
                }
                int index2 = text.IndexOf("</color>");
                if (index2 < 0)
                    break;
                text = text.Remove(index2, 8);
            }
            return text;
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldfld),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Callvirt)
            };

            List<CodeInstruction> injectedSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(HarmonyTabMenu), "RemoveColor"))
            };

            return PatchBySequence(instructions, targetSequence, injectedSequence, PatchMode.AFTER, CheckMode.NEVER);
        }
    }
}
