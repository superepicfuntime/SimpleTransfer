using SimpleTransfer.UI.OtherItemUIs;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;

namespace SimpleTransfer.UI
{
    public abstract class RightClickUI : ButtonBox
    {
        internal bool holding;

        public RightClickUI(int x, int y)
            : base(x, y)
        {
        }

        public RightClickUI(float x, float y)
            : base(x, y)
        {
        }

        internal abstract void Reset();

        internal static RightClickUI[] Create()
        {
            return new RightClickUI[1]
            {
                    new PipeUI()
            };
        }

        internal void RightClick()
        {
            Player val = Main.player[Main.myPlayer];
            if (holding)
            {
                if (val.mouseInterface || val.lastMouseInterface || val.dead || Main.mouseItem.type > ItemID.None || val.itemTime > 0)
                {
                    onMenu = false;
                }
                else if (Main.mouseRight && Main.mouseRightRelease && !PlayerInput.LockGamepadTileUseButton && val.noThrow == 0 && !Main.HoveringOverAnNPC && val.talkNPC == -1)
                {
                    if (onMenu)
                    {
                        onMenu = false;
                    }
                    else if (!Main.SmartInteractShowingGenuine)
                    {
                        onMenu = true;
                        position = Utils.ToPoint(Main.MouseScreen - bg.Dimensions * 16f);
                    }
                }
            }
            else
            {
                onMenu = false;
            }
        }
    }
}
