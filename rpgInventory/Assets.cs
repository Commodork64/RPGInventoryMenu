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
    public static class Assets
    {
        public static Texture2D Mushroom { get; set; }
        public static Texture2D CharacterInventoryImage { get; set; }
        public static SpriteFont Font { get; set; }
        public static SpriteFont Font_24 { get; set; }
        public static Texture2D BRectangle { get; set; }
        public static Texture2D InventoryBackground { get; set; }

        public static void PreLoad(ContentManager contentManager)
        {
            Mushroom = contentManager.Load<Texture2D>("Assets/Mushroom");
            CharacterInventoryImage = contentManager.Load<Texture2D>("Assets/fighterportraitfemale");
            Font = contentManager.Load<SpriteFont>("Assets/Fonts/Gaelic");
            Font_24 = contentManager.Load<SpriteFont>("Assets/Fonts/Gaelic_24");
            BRectangle = contentManager.Load<Texture2D>("Assets/BlackRectangle");
            InventoryBackground = contentManager.Load<Texture2D>("Assets/dirt4");
        }
    }
}
