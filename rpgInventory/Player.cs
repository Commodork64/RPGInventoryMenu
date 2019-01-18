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
    public class Player
    {
        private KeyboardState kStateOld = Keyboard.GetState();
        private Vector2 position;
        private Vector2 scale;
        private Vector2 scaleCharacterPosition;
        private Vector2 scaleRightShadow;

        private string name;
        private int level;
        private int attack;
        private int defence;
        private int nextSelectedItem = 0;
        private int currentSelectedItem;
        private Vector2 screenSize;

        public Inventory Inventory { get; protected set; }

        public Player(int X, int Y, float ScaleX, float ScaleY)
        {
            Inventory = new Inventory(25, 0, 0);
            position = Inventory.Position;
            scale = new Vector2(ScaleX, ScaleY);
            scaleCharacterPosition = new Vector2(0.25f, 0.25f);
            scaleRightShadow = new Vector2(300f, 600f);
            screenSize = new Vector2(800f, 600f);

            name = "Name";
            level = 0;
            attack = 0;
            defence = 0;
            currentSelectedItem = nextSelectedItem;

        }

        public void Update(GameTime gametime)
        {
            KeyboardState kstate = Keyboard.GetState();
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;

            if (TabBar.OptionActive == false)
            {
                Inventory.Update(gametime);
                if (kstate.IsKeyDown(Keys.Q) && kStateOld.IsKeyUp(Keys.Q))
                {
                    Item item = new Mushroom();
                    Inventory.AddItem(item);
                    Inventory.SetSelectedItem(item);
                }

                if (Inventory.Amount > 1)
                {

                    if (kstate.IsKeyDown(Keys.Up) && kStateOld.IsKeyUp(Keys.Up))
                    {
                        MoveInventorySelectedItem(-5);
                    }

                    if (kstate.IsKeyDown(Keys.Down) && kStateOld.IsKeyUp(Keys.Down))
                    {
                        MoveInventorySelectedItem(5);
                    }

                    if (kstate.IsKeyDown(Keys.Left) && kStateOld.IsKeyUp(Keys.Left))
                    {
                        MoveInventorySelectedItem(-1);
                    }

                    if (kstate.IsKeyDown(Keys.Right) && kStateOld.IsKeyUp(Keys.Right))
                    {
                        MoveInventorySelectedItem(1);
                    }
                }

            }

            kStateOld = kstate;
        }

        private void MoveInventorySelectedItem(int amount)
        {
            currentSelectedItem += amount;
            if (currentSelectedItem >= Inventory.Amount)
            {
                currentSelectedItem = Inventory.Amount - 1;
                Inventory.SetSelectedItem(currentSelectedItem);
            }
            else if (currentSelectedItem <= 0)
            {
                currentSelectedItem = 0;
                Inventory.SetSelectedItem(currentSelectedItem);
            }
            else if (currentSelectedItem >= Inventory.Amount)
            {
                currentSelectedItem = Inventory.Amount - 1;
                Inventory.SetSelectedItem(currentSelectedItem);
            }
            else
                Inventory.SetSelectedItem(currentSelectedItem);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Assets.BRectangle, new Vector2(position.X + 500, position.Y), null, null, null, 0, Vector2.Add(scale, scaleRightShadow), Color.White * 0.10f);
            spriteBatch.Draw(Assets.CharacterInventoryImage, new Vector2(position.X + 525, position.Y + 25), null, null, null, 0, Vector2.Add(scale, scaleCharacterPosition), Color.White);

            spriteBatch.DrawString(Assets.Font_24, name, new Vector2(position.X + 550, position.Y + 400), Color.AntiqueWhite);
            spriteBatch.DrawString(Assets.Font_24, "Level: " + level.ToString(), new Vector2(position.X + 675, position.Y + 400), Color.AntiqueWhite);
            spriteBatch.DrawString(Assets.Font_24, "ATK: " + attack.ToString(), new Vector2(position.X + 550, position.Y + 440), Color.AntiqueWhite);
            spriteBatch.DrawString(Assets.Font_24, "DEF: " + defence.ToString(), new Vector2(position.X + 675, position.Y + 440), Color.AntiqueWhite);

            if (TabBar.OptionActive == true)
            {
                spriteBatch.Draw(Assets.BRectangle, new Vector2(position.X, position.Y), null, null, null, 0, Vector2.Add(scale, screenSize), Color.White * 0.40f);
                Inventory.DrawTitle(spriteBatch);
            }
            else
            {
                Inventory.Draw(spriteBatch);
            }

        }
    }
}
