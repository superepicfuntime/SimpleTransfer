using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace SimpleTransfer.UI
{
    public static class Textures
    {
        private const string location = "SimpleTransfer/Images/Settings/";

        internal static Texture2D BackgroundTextures { get; private set; }

        internal static Texture2D PipeTextures { get; private set; }


        internal static void Unload()
        {
            BackgroundTextures = null;
            PipeTextures = null;
        }

        internal static void Load()
        {
            BackgroundTextures = ModContent.Request<Texture2D>(string.Format("{0}Background", location), AssetRequestMode.ImmediateLoad).Value;
            PipeTextures = ModContent.Request<Texture2D>(string.Format("{0}Pipe", location), AssetRequestMode.ImmediateLoad).Value;
        }
    }
}
