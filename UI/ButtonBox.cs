using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;

namespace SimpleTransfer.UI
{
    public abstract class ButtonBox
    {

        private static readonly string[] wireText = new string[6] { "Red", "Green", "Blue", "Input", "Output", "Remover" };

        protected List<Button> buttons = new();

        protected Background bg;

        internal bool onMenu;

        protected Point position = new(Main.screenWidth / 2, Main.screenHeight / 11);

        protected virtual int Size { get; } = 32;


        protected virtual int Border { get; } = 10;


        internal static SimpleTransferPlayer STP { get; private set; }

        protected static string WireText(int i)
        {
            return wireText[i];
        }

        public ButtonBox(int x, int y)
        {
            bg = new Background(new Vector2((float)x, (float)y));
        }

        public ButtonBox(float x, float y)
        {
            bg = new Background(new Vector2(x, y));
        }

        internal void DoStuff(SpriteBatch sb)
        {
            Draw(sb);
            Update();
        }

        protected virtual void Draw(SpriteBatch sb)
        {
            bg.Draw(sb, new Vector2((float)position.X, (float)position.Y));
            foreach (Button button in buttons)
            {
                button.Draw(sb, position.X, position.Y);
            }
        }

        protected virtual void Update()
        {
            using (List<Button>.Enumerator enumerator = buttons.GetEnumerator())
            {
                while (enumerator.MoveNext() && !enumerator.Current.Update(position.X, position.Y))
                {
                }
            }
        }
    }
}
