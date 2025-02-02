using System;
using System.Threading.Tasks;
using CS2.Hacks;
using GameOverlay.Drawing;

namespace CS2.Core;

public class Windows
{
    private static string fullText = "Juice cheats";
    private static string animatedText = "";
    private static int animationDuration = 30000; // 30 seconds
    private static int interval = animationDuration / fullText.Length;

    public static async Task AnimateText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            animatedText = fullText.Substring(0, i);
            await Task.Delay(interval);
        }
    }

    public static void DrawWatermark(Overlay overlay, Graphics gfx, System.Drawing.Point cursorPos)
    {       
        var infoText = $"FPS: {gfx.FPS} | Cursor: {cursorPos.X}, {cursorPos.Y}";
        gfx.DrawTextWithBackground(overlay.fonts["consolas"], overlay.colors["green"], overlay.colors["black"], 10, 10, infoText);
        gfx.DrawTextWithBackground(overlay.fonts["consolas"], overlay.colors["red"], overlay.colors["black"], 10, 30, animatedText);
    }

    public static async Task UseTriggerBot(Overlay overlay, Graphics gfx, System.Drawing.Point cursorPos)
    {
        await TriggerBot.Loop();
    }

    public static async Task DrawEsp(Overlay overlay, Graphics gfx, System.Drawing.Point cursorPos)
    {
        await Esp.Loop(overlay, gfx);
    }
}
