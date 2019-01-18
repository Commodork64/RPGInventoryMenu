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
    public class Item
    {
        public int Price { get; private set; }
        public string Name { get; private set; }
        public string Desc { get; private set; }
        public bool Selected { get; set; }

        public Texture2D Texture { get; protected set; }
      
        public Item(string name, Texture2D texture, string desc, int price)
        {
            Name = name;
            Texture = texture;
            Desc = desc;
            Price = price;
            
        }
    }

    class Weapon : Item
    {
        public int Damage { get; private set; }
        public bool Equip { get; private set; }

        public Weapon(string name, Texture2D texture, int damage, string desc, int price, bool equip) 
            : base(name, texture, desc, price)
        {
            Damage = damage;
            Equip = equip;
        }
    }

    class WoodenSword : Weapon
    {
        public WoodenSword()
            : base("Sword", 
                  Assets.Mushroom, 
                  10,
                  "A common sword.",
                  10,
                  true)
        {

        }
    }

    class RustyAxe : Weapon
    {
        public RustyAxe()
            : base("Axe",
                  Assets.Mushroom,
                  15,
                  "A common Axe.",
                  10,
                  true)
        {

        }
    }

    class OldGun : Weapon
    {
        public OldGun()
            : base("Gun",
                  Assets.Mushroom,
                  8,
                  "A common gun.",
                  10,
                  true)
        {

        }
    }

    class Healing : Item
    {
        public int HpRegen { get; private set; }

        public Healing(string name, Texture2D texture, string desc, int hpRegen, int price)
            : base(name, texture, desc, price)
        {

        }
    }

    class Mushroom : Healing
    {
        public Mushroom()
            : base("Mushroom",
                  Assets.Mushroom,
                  "A commonly found ingredient",
                  15,
                  10)
        {
 
        }
    }
}
            