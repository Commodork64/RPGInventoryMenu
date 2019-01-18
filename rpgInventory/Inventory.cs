using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpgInventory
{
    public class Inventory
    {

        public int MaxInventorySize { get; protected set; }
        public Vector2 Position { get; set; }
        public int Amount { get; set; }

        private int RowSize;

        private static List<Item> items;
        private int tileSize;

        public Inventory(int maxInventorySize, int x, int y)
        {
            items = new List<Item>();
            MaxInventorySize = maxInventorySize;
            Position = new Vector2(x, y);
            tileSize = 64;
        }

        public void AddItem(Item item)
        {
            if (items.Count == MaxInventorySize)
                return;
            else
                items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (items.Count < 0)
                return;
            else
                items.Remove(item);
        }

        public int CountItem(List<Item> items)
        {
            int amount = items.Count();
            return amount;
        }

        public Item GetItem(int index)
        {
            if (index < items.Count - 1)
            {
                return items[index];
            }
            else
            {
                return null;
            }
        }

        public void SetSelectedItem(Item item)
        {
            // makes sure all items are deselected, then sets the item passed in as selected
            foreach (Item i in items)
            {
                i.Selected = false;
            }
            item.Selected = true;
        }

        // as this is overloaded, its always best to have one "root" function that is called by
        // all the other overloaded functions, so in this case we take the index. Find the item
        // at that index, and then call the above function with that item.
        public void SetSelectedItem(int index)
        {
            if (index > items.Count)
                return;
            if (index < 0)
                return;
            Item item = items[index];
            SetSelectedItem(item);
        }

        public void Update(GameTime gametime)
        {
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;

          
            Amount = CountItem(items);
        }

        public void DrawTitle(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Assets.Font, "Inventory", new Vector2(Position.X + 150, Position.Y + 50), Color.Beige);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTitle(spriteBatch);

            int row = 0;
            int col = 0;

            for (int i = 0; i < items.Count && i < MaxInventorySize; i++)
            {
                Item item = items[i];

                // If we are on the 6th item (because 6 divided by 6 = 1 with 0 remainder) (and make sure i isnt equal to 0)
                // Then we want to go 1 row down (row++)
                // and set the column back to 0, so that we start drawing from the left hand side again
                if (i % 5 == 0 && i != 0)
                {
                    row++;
                    col = 0;
                }

                // If an item is marked as selected, then it will draw a transparent black box over it
                if (item.Selected)
                {
                    spriteBatch.Draw(
                        texture: Assets.BRectangle,
                        destinationRectangle: new Rectangle((col * tileSize) + (int)Position.X + 150, (row * tileSize) + (int)Position.Y + 150, tileSize, tileSize),
                        color: new Color(0, 0, 0, 0.3f)
                    );
                }

                spriteBatch.Draw(
                        texture: item.Texture,
                        color: Color.White,

                        // Draw the item as posx and posy where 
                        // posx = the column multiplied by the tile width
                        // posy = the row multipled by the tile height
                        // the Width and Height params of the rectangle scale the texture
                        // to the given dimensions. This should be the same values as tileX and tileY
                        // to ensure that the tiles are spaced correctly when drawn.
                        destinationRectangle: new Rectangle((col * tileSize) + (int)Position.X + 150, (row * tileSize) + (int)Position.Y + 150, tileSize, tileSize)
                    );

                // move over one column after the item is drawn
                col++;
            }
        }
    }
}
