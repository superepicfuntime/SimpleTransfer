using SimpleTransfer.Items.Tools;
using SimpleTransfer.Utility;
using Terraria;
using Terraria.ModLoader;

namespace SimpleTransfer.UI.OtherItemUIs
{
    public class PipeUI : RightClickUI
    {
        public PipeUI()
            : base(6, 1)
        {
            for (int i = 0; i < 6; i++)
            {
                int current = i;
                buttons.Add(new Button(i * Size, 0, Size, ButtonBox.WireText(i), Textures.PipeTextures, () => ((uint)ButtonBox.STP.uiPipeMode & (uint)(byte)(1 << current)) != 0, delegate
                {
                    ButtonBox.STP.uiPipeMode ^= (PipeWrenchMode)(byte)(1 << current);
                }));
            }
        }

        internal override void Reset()
        {
            if (!(Main.player[Main.myPlayer].HeldItem.type == ModContent.ItemType<PipeWrench>())) base.holding = false;
        }
    }
}
