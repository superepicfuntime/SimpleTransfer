using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace SimpleTransfer.Utility
{
    public static class PipePlace
    {

        internal static void MassPipeOperation(Player p, Point ps, Point pe, Vector2 dropPoint, bool dir)
        {
            int num = Math.Sign(pe.X - ps.X);
            int num2 = Math.Sign(pe.Y - ps.Y);
            PipeWrenchMode uiPipeMode = p.GetModPlayer<SimpleTransferPlayer>().uiPipeMode;
            Point pt = default;
            bool flag = false;
            Item.StartCachingType(530);
            Item.StartCachingType(849);
            int num3;
            int num4;
            int num5;
            if (dir)
            {
                pt.X = ps.X;
                num3 = ps.Y;
                num4 = pe.Y;
                num5 = num2;
            }
            else
            {
                pt.Y = ps.Y;
                num3 = ps.X;
                num4 = pe.X;
                num5 = num;
            }
            for (int i = num3; i != num4; i += num5)
            {
                if (dir)
                {
                    pt.Y = i;
                }
                else
                {
                    pt.X = i;
                }
                if (!MassPipeOperationStep(pt, uiPipeMode))
                {
                    flag = true;
                    break;
                }
            }
            if (dir)
            {
                pt.Y = pe.Y;
                num3 = ps.X;
                num4 = pe.X;
                num5 = num;
            }
            else
            {
                pt.X = pe.X;
                num3 = ps.Y;
                num4 = pe.Y;
                num5 = num2;
            }
            for (int j = num3; j != num4; j += num5)
            {
                if (flag)
                {
                    break;
                }
                if (!dir)
                {
                    pt.Y = j;
                }
                else
                {
                    pt.X = j;
                }
                if (!MassPipeOperationStep(pt, uiPipeMode))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                MassPipeOperationStep(pe, uiPipeMode);
            }
            Item.DropCache(new EntitySource_Piping((int)dropPoint.X, (int)dropPoint.Y), dropPoint, Vector2.Zero, 530);
            Item.DropCache(new EntitySource_Piping((int)dropPoint.X, (int)dropPoint.Y), dropPoint, Vector2.Zero, 849);
        }

        private static bool MassPipeOperationStep(Point pt, PipeWrenchMode mode)
        {
            if (!WorldGen.InWorld(pt.X, pt.Y, 1))
            {
                return false;
            }
            Tile tileSafely = Framing.GetTileSafely(pt.X, pt.Y);
            if ((mode & PipeWrenchMode.Remover) == 0)
            {
                if ((mode & PipeWrenchMode.Red) != 0)
                {
                    WorldGen.PlaceWire(pt.X, pt.Y);
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 5, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Blue) != 0)
                {
                    WorldGen.PlaceWire2(pt.X, pt.Y);
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 10, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Green) != 0)
                {
                    WorldGen.PlaceWire3(pt.X, pt.Y);
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 12, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Input) != 0)
                {
                    WorldGen.PlaceWire4(pt.X, pt.Y);
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 16, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Output) != 0)
                {
                    WorldGen.PlaceActuator(pt.X, pt.Y);
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 8, pt.X, pt.Y);
                }
            }
            else
            {
                if ((mode & PipeWrenchMode.Red) != 0)
                {
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 6, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Blue) != 0)
                {
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 11, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Green) != 0)
                {
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 13, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Input) != 0)
                {
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 17, pt.X, pt.Y);
                }
                if ((mode & PipeWrenchMode.Output) != 0)
                {
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 9, pt.X, pt.Y);
                }
            }
            return true;
        }
    }
}
