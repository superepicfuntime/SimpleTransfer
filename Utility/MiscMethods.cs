using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SimpleTransfer.Utility
{
    public static class MiscMethods
    {
        internal static void WriteText(string text)
        {
            WriteText(text, new Color(255, 0, 0));
        }

        internal static void WriteText(string text, Color c)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), c);
            }
            else
            {
                Main.NewText(text, c);
            }
        }

        internal static void StressChange(Player p, int amount)
        {
            ModPlayer modPlayer = p.GetModPlayer<ModPlayer>();
            modPlayer.GetType().GetField("stress").SetValue(modPlayer, amount);
        }

        internal static void DrawRectangleOutline(SpriteBatch sb, Rectangle rect, Color c)
        {
            rect.X -= (int)Main.screenPosition.X;
            rect.Y -= (int)Main.screenPosition.Y;
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X, rect.Y, rect.Width, 2), c);
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X, rect.Y + rect.Height - 2, rect.Width, 2), c);
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X, rect.Y, 2, rect.Height), c);
            sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X + rect.Width - 2, rect.Y, 2, rect.Height), c);
        }

        private static void NPCLookAtTarget(NPC npc, Player p, ref SpriteEffects sE, ref float rot, int textureType = -1)
        {
            rot = (npc.Center - p.Center).ToRotation() + (float)Math.PI / 2f;
            CheckRotation(ref rot);
            switch (textureType)
            {
                case 262:
                    sE = (SpriteEffects)2;
                    break;
                case 370:
                    rot += (float)Math.PI / 2f;
                    CheckRotation(ref rot);
                    if (rot >= (float)Math.PI / 2f && rot < 4.712389f)
                    {
                        sE = (SpriteEffects)2;
                    }
                    break;
                case 113:
                    rot -= (float)Math.PI / 2f;
                    CheckRotation(ref rot);
                    break;
            }
        }

        private static void CheckRotation(ref float rot)
        {
            if (rot < 0f)
            {
                rot += (float)Math.PI * 2f;
            }
            else if (rot >= (float)Math.PI * 2f)
            {
                rot -= (float)Math.PI * 2f;
            }
        }

        internal static void DrawProjCenteredOnHitbox(SpriteBatch sb, Projectile proj)
        {
            float rotation = proj.rotation;
            Rectangle hitbox = proj.Hitbox;
            Rectangle val = hitbox;
            float num = val.Center.X - (int)Main.screenPosition.X - TextureAssets.Projectile[proj.type].Value.Width / 2;
            hitbox = proj.Hitbox;
            val = hitbox;
            Vector2 spinningpoint = new(num, val.Center.Y - (int)Main.screenPosition.Y - TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type] / 2);
            hitbox = proj.Hitbox;
            val = hitbox;
            float autoAddX = val.Center.X - (int)Main.screenPosition.X;
            hitbox = proj.Hitbox;
            Vector2 val2 = default;
            val = hitbox;
            val2.ToWorldCoordinates(autoAddX, val.Center.Y - (int)Main.screenPosition.Y);
            Vector2 val3 = Utils.RotatedBy(spinningpoint, rotation, val2);
            sb.Draw(TextureAssets.Projectile[proj.type].Value, new Rectangle((int)val3.X, (int)val3.Y, TextureAssets.Projectile[proj.type].Value.Width, TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type]), (Rectangle?)new Rectangle(0, proj.frame * TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type], TextureAssets.Projectile[proj.type].Value.Width, TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type]), new Color(255, 255, 255), proj.rotation, Vector2.Zero, (SpriteEffects)((proj.direction == 1) ? 1 : 0), 0f);
        }

        internal static void Despawn(int npc)
        {
            Main.npc[npc] = new NPC
            {
                whoAmI = npc
            };
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc);
            }
        }

        internal static void DespawnPacket()
        {
            ModPacket packet = SimpleTransfer.Instance.GetPacket();
            ((BinaryWriter)packet).Write(14);
            packet.Send();
        }

        internal static void ThisItemIcon(Player player, Item item)
        {
            if (!Main.GamepadDisableCursorItemIcon && !player.mouseInterface && !Main.mouseText && player.whoAmI == Main.myPlayer)
            {
                player.cursorItemIconEnabled = true;
                Main.ItemIconCacheUpdate(item.type);
                player.cursorItemIconID = item.type;
            }
        }
    }
}
