using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace SimpleTransfer.Images.Projectiles
{
    public static class ProjAIs
    {
        internal static void PipeProj(Projectile proj)
        {
            Player player = Main.player[proj.owner];
            if (Main.myPlayer == proj.owner)
            {
                if (proj.localAI[1] > 0f)
                {
                    proj.localAI[1] -= 1f;
                }
                if (player.noItems || player.CCed || player.dead)
                {
                    proj.Kill();
                }
                else if (Main.mouseRight && Main.mouseRightRelease)
                {
                    proj.Kill();
                    player.mouseInterface = true;
                    Main.blockMouse = true;
                }
                else if (!player.channel)
                {
                    if (proj.localAI[0] == 0f)
                    {
                        proj.localAI[0] = 1f;
                    }
                    proj.Kill();
                }
                else if (proj.localAI[1] == 0f)
                {
                    Vector2 val = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
                    if (player.gravDir == -1f)
                    {
                        val.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y;
                    }
                    if (val != proj.Center)
                    {
                        proj.netUpdate = true;
                        proj.Center = val;
                        proj.localAI[1] = 1f;
                    }
                    if (proj.ai[0] == 0f && proj.ai[1] == 0f)
                    {
                        proj.ai[0] = (int)proj.Center.X / 16f;
                        proj.ai[1] = (int)proj.Center.Y / 16f;
                        proj.netUpdate = true;
                        proj.velocity = Vector2.Zero;
                    }
                }
                proj.velocity = Vector2.Zero;
                Point val2 = Utils.ToPoint(new Vector2(proj.ai[0], proj.ai[1]));
                Point val3 = proj.Center.ToTileCoordinates();
                Math.Abs(val2.X - val3.X);
                Math.Abs(val2.Y - val3.Y);
                int num = Math.Sign(val3.X - val2.X);
                int num2 = Math.Sign(val3.Y - val2.Y);
                Point val4 = default;
                bool flag = player.direction == 1;
                int num3;
                int num4;
                int num5;
                if (flag)
                {
                    val4.X = val2.X;
                    num3 = val2.Y;
                    num4 = val3.Y;
                    num5 = num2;
                }
                else
                {
                    val4.Y = val2.Y;
                    num3 = val2.X;
                    num4 = val3.X;
                    num5 = num;
                }
                for (int i = num3; i != num4; i += num5)
                {
                    if (flag)
                    {
                        val4.Y = i;
                    }
                    else
                    {
                        val4.X = i;
                    }
                }
                if (flag)
                {
                    val4.Y = val3.Y;
                    num3 = val2.X;
                    num4 = val3.X;
                    num5 = num;
                }
                else
                {
                    val4.X = val3.X;
                    num3 = val2.Y;
                    num4 = val3.Y;
                    num5 = num2;
                }
                for (int j = num3; j != num4; j += num5)
                {
                    if (!flag)
                    {
                        val4.Y = j;
                    }
                    else
                    {
                        val4.X = j;
                    }
                }
            }
            int num6 = Math.Sign(player.velocity.X);
            if (num6 != 0)
            {
                player.ChangeDir(num6);
            }
            player.heldProj = proj.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = 0f;
        }
    }
}
