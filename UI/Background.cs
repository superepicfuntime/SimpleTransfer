using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace SimpleTransfer.UI
{
    public class Background
    {
        private Texture2D texture = Textures.BackgroundTextures;

        private static readonly Rectangle middle = new(2, 2, 16, 16);

        private static readonly Rectangle corner = new(18, 18, 10, 10);

        private static readonly Rectangle topBottom = new(2, 0, 32, 10);

        private static readonly Rectangle leftRight = new(0, 2, 10, 32);

        private static readonly Color white = new(255, 255, 255);

        internal Vector2 Dimensions { get; private set; }

        public Background(Vector2 dimensions)
        {
            Dimensions = dimensions;
        }

        internal void ChangeDimensions(Vector2 dimensions)
        {
            Dimensions = dimensions;
        }

        internal void Draw(SpriteBatch sb, Vector2 pos)
        {
            if (texture == null) texture = Textures.BackgroundTextures;
            sb.End();
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, (Effect)null, Main.UIScaleMatrix);
            sb.Draw(texture, pos, (Rectangle?)middle, white, 0f, Vector2.Zero, new Vector2(Dimensions.X * 2f, Dimensions.Y * 2f), (SpriteEffects)0, 0f);
            sb.Draw(texture, pos + new Vector2((float)(-corner.Width), (float)(-corner.Height)), (Rectangle?)corner, white, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
            sb.Draw(texture, pos + new Vector2(Dimensions.X * 32f, (float)(-corner.Height)), (Rectangle?)corner, white, 0f, Vector2.Zero, 1f, (SpriteEffects)1, 0f);
            sb.Draw(texture, pos + new Vector2(Dimensions.X * 32f, Dimensions.Y * 32f), (Rectangle?)corner, white, 0f, Vector2.Zero, 1f, (SpriteEffects)3, 0f);
            sb.Draw(texture, pos + new Vector2((float)(-corner.Width), Dimensions.Y * 32f), (Rectangle?)corner, white, 0f, Vector2.Zero, 1f, (SpriteEffects)2, 0f);
            sb.Draw(texture, pos + new Vector2(0f, (float)(-topBottom.Height)), (Rectangle?)topBottom, white, 0f, Vector2.Zero, new Vector2(Dimensions.X, 1f), (SpriteEffects)0, 0f);
            sb.Draw(texture, pos + new Vector2(Dimensions.X * 32f, 0f), (Rectangle?)leftRight, white, 0f, Vector2.Zero, new Vector2(1f, Dimensions.Y), (SpriteEffects)1, 0f);
            sb.Draw(texture, pos + new Vector2(0f, Dimensions.Y * 32f), (Rectangle?)topBottom, white, 0f, Vector2.Zero, new Vector2(Dimensions.X, 1f), (SpriteEffects)2, 0f);
            sb.Draw(texture, pos + new Vector2((float)(-leftRight.Width), 0f), (Rectangle?)leftRight, white, 0f, Vector2.Zero, new Vector2(1f, Dimensions.Y), (SpriteEffects)0, 0f);
            int num = Main.mouseX;
            int num2 = Main.mouseY;
            int num3 = (int)pos.X - 10;
            int num4 = (int)pos.Y - 10;
            if (num >= num3 && !((float)num >= (float)num3 + 32f * Dimensions.X + 20f) && num2 >= num4 && !((float)num2 >= (float)num4 + 32f * Dimensions.Y + 20f))
            {
                Main.blockMouse = true;
                Main.player[Main.myPlayer].cursorItemIconEnabled = false;
                Main.player[Main.myPlayer].cursorItemIconID = -1;
            }
        }
    }
}
