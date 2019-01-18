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
    class TabBar
    {
        public Vector2 Position { get; set; }
        public static bool OptionActive = false;

        private Item save { get; set; }
        private Item load { get; set; }
        private Item settings { get; set; }
        private static List<Item> items;

        private Vector2 titleTextTrue { get; set; }
        private Vector2 titleTextFalse { get; set; }

        private float radians;
        private int currentSelectedItem { get; set; }
        private int amount { get; set; }

        private Vector2 shadowScaleTrue { get; set; }
        private Vector2 shadowScaleFalse { get; set; }

        private Vector2 saveTruePosition { get; set; }
        private Vector2 loadTruePosition { get; set; }
        private Vector2 settingsTruePosition { get; set; }

        private KeyboardState kStateOld = Keyboard.GetState();

        public TabBar(int x, int y)
        {
            Position = new Vector2(x, y);

            titleTextFalse = new Vector2(Position.X + 100, Position.Y + 180);
            titleTextTrue = new Vector2(Position.X + 300, Position.Y + 180);
            shadowScaleTrue = new Vector2(100f, 600f);
            shadowScaleFalse = new Vector2(300f, 600f);

            radians = 1.5708f;
            currentSelectedItem = 0;

            saveTruePosition = new Vector2(Position.X + 50, Position.Y + 200);
            loadTruePosition = new Vector2(Position.X + 50, Position.Y + 300);
            settingsTruePosition = new Vector2(Position.X + 50, Position.Y + 400);

            save = new Item("Save Game", Assets.Mushroom, "N/A", 0);
            load = new Item("Load Game", Assets.Mushroom, "N/A", 0);
            settings = new Item("Settings", Assets.Mushroom, "N/A", 0);

            items = new List<Item>();
            items.Add(save);
            items.Add(load);
            items.Add(settings);

            amount = CountItem(items);
        }

        private void SetSelectedItem(Item item)
        {
            foreach (Item i in items)
            {
                i.Selected = false;
            }
            item.Selected = true;
        }

        private void SetSelectedItem(int index)
        {
            if (index > items.Count)
                return;
            if (index < 0)
                return;
            Item item = items[index];
            SetSelectedItem(item);
        }

        public int CountItem(List<Item> items)
        {
            int amount = items.Count();
            return amount;
        }

        public void Update(GameTime gametime)
        {
            KeyboardState kstate = Keyboard.GetState();
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.F) && kStateOld.IsKeyUp(Keys.F))
            {
                if (OptionActive == false)
                {
                    OptionActive = true;
                    SetSelectedItem(items[0]);
                }
                else if(OptionActive == true)
                {
                    OptionActive = false;
                }
            }

            if (kstate.IsKeyDown(Keys.Up) && kStateOld.IsKeyUp(Keys.Up))
            {
                currentSelectedItem -= 1;
                if (currentSelectedItem <= 0)
                {
                    currentSelectedItem = 0;
                    SetSelectedItem(currentSelectedItem);
                }
                else
                    SetSelectedItem(currentSelectedItem);
            }

            if (kstate.IsKeyDown(Keys.Down) && kStateOld.IsKeyUp(Keys.Down))
            {
                currentSelectedItem += 1;
                if (currentSelectedItem >= amount)
                {
                    currentSelectedItem = amount - 1;
                    SetSelectedItem(currentSelectedItem);
                }
                else
                    SetSelectedItem(currentSelectedItem);
            }

            kStateOld = kstate;
        }

            public void Draw(SpriteBatch spriteBatch)
        {
            if(OptionActive == false)
            {
                spriteBatch.Draw(Assets.BRectangle, new Vector2(Position.X, Position.Y), null, null, null, 0, Vector2.Add(Position, shadowScaleTrue), Color.AntiqueWhite * 0.10f);
                spriteBatch.DrawString(Assets.Font, "Option", new Vector2(titleTextFalse.X, titleTextFalse.Y), Color.Beige, radians, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);

            }
            else if(OptionActive == true)
            {
                if (save.Selected)
                {
                    spriteBatch.Draw(
                        texture: Assets.BRectangle,
                        destinationRectangle: new Rectangle((int)saveTruePosition.X, (int)saveTruePosition.Y, 170, 36),
                        color: new Color(0, 0, 0, 0.3f)
                    );
                }

                if (load.Selected)
                {
                    spriteBatch.Draw(
                        texture: Assets.BRectangle,
                        destinationRectangle: new Rectangle((int)loadTruePosition.X, (int)loadTruePosition.Y, 163, 36),
                        color: new Color(0, 0, 0, 0.3f)
                    );
                }

                if (settings.Selected)
                {
                    spriteBatch.Draw(
                        texture: Assets.BRectangle,
                        destinationRectangle: new Rectangle((int)settingsTruePosition.X, (int)settingsTruePosition.Y, 147, 36),
                        color: new Color(0, 0, 0, 0.3f)
                    );
                }


                spriteBatch.Draw(Assets.BRectangle, new Vector2(Position.X, Position.Y), null, null, null, 0, Vector2.Add(Position, shadowScaleFalse), Color.AntiqueWhite * 0.10f);
                spriteBatch.DrawString(Assets.Font, "Option", new Vector2(titleTextTrue.X, titleTextTrue.Y), Color.Beige, radians, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);

                spriteBatch.DrawString(Assets.Font_24, save.Name, new Vector2(saveTruePosition.X, saveTruePosition.Y), Color.AntiqueWhite);
                spriteBatch.DrawString(Assets.Font_24, load.Name, new Vector2(loadTruePosition.X, loadTruePosition.Y), Color.AntiqueWhite);
                spriteBatch.DrawString(Assets.Font_24, settings.Name, new Vector2(settingsTruePosition.X, settingsTruePosition.Y), Color.AntiqueWhite);
            }
        }
    }
}
