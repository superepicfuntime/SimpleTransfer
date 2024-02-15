using SimpleTransfer.Items.Tools;
using SimpleTransfer.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SimpleTransfer
{
    public class SimpleTransferPlayer : ModPlayer
    {
        internal PipeWrenchMode uiPipeMode;

        public override void OnEnterWorld()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                SimpleTransfer.Instance.askForUIUpdate(Player.whoAmI);
            }
        }
        private void LoadUI(TagCompound tag)
        {
            uiPipeMode = (PipeWrenchMode)tag.Get<byte>("uiPipeMode");
        }

        private void SaveUI(TagCompound tag)
        {
            tag.Add("uiPipeMode", (byte)uiPipeMode);
        }

        public bool autoRuler(Item[] i)
        {
            foreach (Item item in i)
            {
                //TODO: add other builders so all builders get forced ruler line as well
                if (item.type == ModContent.ItemType<PipeWrench>())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
