using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace rpgInventory
{
    public class ScrollingBackground
    {
        private Texture2D background { get; set; }
        private int defaultPosition { get; set; }
        private int backgroundx { get; set; }
        private int backgroundy { get; set; }
        private Vector2 backgroundPosition { get; set; }
        private int backgroundImageSize { get; set; }

        public ScrollingBackground(int X, int Y)
        {
            backgroundx = X;
            backgroundy = Y;
            backgroundPosition = new Vector2(backgroundx, backgroundy);
            backgroundImageSize = 800;
            defaultPosition = 0;
        }

        public void ResetBackground()
        {
            backgroundx = defaultPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.InventoryBackground, new Vector2(backgroundx, backgroundy), null, null, null, 0, new Vector2(1.6f, 1.5f), Color.BurlyWood);
            spriteBatch.Draw(Assets.InventoryBackground, new Vector2(backgroundx - backgroundImageSize, backgroundy), null, null, null, 0, new Vector2(1.6f, 1.5f), Color.BurlyWood);
            backgroundx += 1;

            if (backgroundx == backgroundImageSize)
                backgroundx = defaultPosition;

        }
    }
}
