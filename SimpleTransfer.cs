using SimpleTransfer.UI;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace SimpleTransfer
{
    public class SimpleTransfer : Mod
    {
        internal static SimpleTransfer Instance { get; private set; }

        internal static Mod MagicStorageMod { get; private set; }

        internal static bool MagicStorageLoaded { get; private set; }

        public override void Load()
        {
            if (!Main.dedServ)
            {
                Textures.Load();
            }
            Instance = this;
            if (Main.rand == null)
            {
                if (!Main.dedServ)
                {
                    Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
                }
                else
                {
                    Main.rand = new UnifiedRandom();
                }
            }
            SimpleTransferUI.sLoad();
        }

        public override void Unload()
        {
            UnloadLoadedMods();
            if (!Main.dedServ)
            {
                Textures.Unload();
            }
            Instance = null;
        }

        public override void PostSetupContent()
        {
            LoadedMods();
        }

        private static void LoadedMods()
        {
            ModLoader.TryGetMod("MagicStorage", out var result6);
            MagicStorageLoaded = result6 != null;
            MagicStorageMod = MagicStorageLoaded ? result6 : null;
        }

        private static void UnloadLoadedMods()
        {
            MagicStorageMod = null;
        }

        internal void sendmessage(int origin)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(28 + origin));
            packet.Send();
        }

        internal void sendWindMessage(int origin, int identifier = -1)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(38 + origin));
            packet.Write((Int32)(identifier));
            packet.Send();
        }

        internal void sendmessageBack(int origin, bool status)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(32 + origin));
            packet.Write(status);
            packet.Send();
        }

        internal void sendWindMessageBack(int speedMode, float speed)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(41));
            packet.Write((Int32)speedMode);
            packet.Write((double)speed);
            packet.Send();
        }

        internal void askForUIUpdate(int from)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(34));
            packet.Write((Int32)from);
            packet.Send();
        }

        internal void sendUpdate(bool x, bool h, int to)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(35));
            packet.Write(x);
            packet.Write(h);
            packet.Send(to);
        }

        internal void sendWindUpdate(float speed, int mode, bool leftToRight, int to)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(42));
            packet.Write((Int32)mode);
            packet.Write((double)speed);
            packet.Write(leftToRight);
            packet.Send(to);
        }

        internal void sendDirectionMessageBack(bool direction)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(43));
            packet.Write((Int32)(direction ? 1 : 2));
            packet.Send();
        }

        internal void AskForSeconds(int from)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(36));
            packet.Write((Int32)from);
            packet.Send();
        }

        internal void SendSeconds(int seconds, int to)
        {
            ModPacket packet = this.GetPacket();
            packet.Write((Int32)(37));
            packet.Write(seconds);
            packet.Send(to);
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {

        }
    }
}