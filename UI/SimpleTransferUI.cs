using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleTransfer.Utility;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;

namespace SimpleTransfer.UI
{
    public class SimpleTransferUI : ModSystem
    {
        internal delegate object CallFunc(object[] args);

        internal static readonly Color UIOnColor = new(255, 255, 255);

        internal static readonly Color UIOffColor = new(100, 100, 100);

        private static RightClickUI[] rightClickUIs;

        public static void sLoad()
        {
            if (!Main.dedServ)
            {
                rightClickUIs = RightClickUI.Create();
            }
        }

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                rightClickUIs = null;
            }
        }


        internal static T RightClickUIs<T>() where T : RightClickUI
        {
            foreach (RightClickUI r in rightClickUIs)
            {
                if (r is T)
                {
                    return (T)r;
                }
            }
            return null;
        }

        internal static void ResetUIs()
        {
            foreach (RightClickUI rightClickUI in rightClickUIs)
            {
                rightClickUI.Reset();
            }
        }

        private static LegacyGameInterfaceLayer ButtonLayers()
        {
            GameInterfaceDrawMethod val = delegate
            {
                foreach (RightClickUI rightClickUI in rightClickUIs)
                {
                    rightClickUI.RightClick();
                    if (rightClickUI.onMenu)
                    {
                        rightClickUI.DoStuff(Main.spriteBatch);
                    }
                }
                return true;
            };
            return new LegacyGameInterfaceLayer("SimpleTransfer: Buttons", val, InterfaceScaleType.UI);
        }

        private static void DrawMouseCoords(SpriteBatch sb)
        {
            TileChecks.TileSafe(Player.tileTargetX, Player.tileTargetY);
            string text = "X: " + Player.tileTargetX + "\nY: " + Player.tileTargetY + "\nType: " + Main.tile[Player.tileTargetX, Player.tileTargetY].TileType;
            Vector2 val = new Vector2((float)(Main.screenWidth >> 1), (float)((Main.screenHeight >> 1) - 75)) - FontAssets.MouseText.Value.MeasureString(text) / 2f;
            ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.MouseText.Value, text, Utils.Floor(val), new Color(255, 85, 0), 0f, Vector2.Zero, Vector2.One, -1f, 2f);
        }

        private static void DrawSmartCursor(SpriteBatch sb, Point16 target, bool correctItem)
        {
            if (correctItem && Main.SmartCursorIsUsed && !(target == Point16.NegativeOne))
            {
                sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle((target.X << 4) - (int)Main.screenPosition.X, (target.Y << 4) - (int)Main.screenPosition.Y, 16, 16), new Color(255, 0, 0, 128));
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            Player val = Main.player[Main.myPlayer];
            SimpleTransferPlayer modPlayer = val.GetModPlayer<SimpleTransferPlayer>();
            int num = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Cursor"));
            if (num != -1)
            {
                layers.Insert(num, (GameInterfaceLayer)(object)ButtonLayers());
            }
        }
    }
}
