using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace SimpleTransfer.UI
{
    public class Button
    {
        private readonly Texture2D texture;

        private readonly int size;

        private readonly Rectangle texPos;

        private readonly Func<bool> state;

        private readonly Action pressed;

        private readonly string text;

        private readonly Func<string> dynamicText;

        protected int X { get; private set; }

        protected int Y { get; private set; }

        public Button(int x, int y, int size, string text, Texture2D texture, Func<bool> state, Action pressed, int texPosX = -1, int texPosY = -1, Func<string> dynamicText = null)
        {
            X = x;
            Y = y;
            this.size = size;
            this.text = text;
            this.texture = texture;
            this.state = state;
            this.pressed = pressed;
            this.dynamicText = dynamicText;
            texPos = new Rectangle((texPosX == -1) ? x : texPosX, (texPosY == -1) ? y : texPosY, size, size);
        }

        private static void MouseText(string s)
        {
            if (!Main.mouseText)
            {
                if ((s == "Pearlwood" || s == "Hallow Grass" || s == "Hallow" || s == "Hallow Ice") && !Main.hardMode)
                {
                    Main.instance.MouseText(s + "\nHardmode only", 0, (byte)0, -1, -1, -1, -1);
                }
                else Main.instance.MouseText(s, 0, (byte)0, -1, -1, -1, -1);
                Main.mouseText = true;
            }
        }

        internal void Draw(SpriteBatch sb, int xOffset, int yOffset)
        {
            sb.Draw(texture, new Rectangle(X + xOffset, Y + yOffset, size, size), (Rectangle?)texPos, state() ? SimpleTransferUI.UIOnColor : SimpleTransferUI.UIOffColor);
        }

        internal bool Update(int xOffset, int yOffset)
        {
            int num = Main.mouseX;
            int num2 = Main.mouseY;
            if (num < X + xOffset || num >= X + xOffset + size || num2 < Y + yOffset || num2 >= Y + yOffset + size)
            {
                return false;
            }
            MouseText((dynamicText != null) ? dynamicText() : text);
            if (!Main.mouseLeft || !Main.mouseLeftRelease)
            {
                return false;
            }
            pressed();
            Main.mouseLeftRelease = false;
            return true;
        }
    }
}
