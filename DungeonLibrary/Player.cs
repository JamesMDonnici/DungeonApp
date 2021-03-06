﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //Sealed - This class (Player) is now a child/derived class of Character (parent/base). The SEALED keyword indicates that this class cannot be used as a base class for any other class...no more inheritance can occur.

        //fields
        //N/A
        //props
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //ctors
        public Player() { }

        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            //Property = param;
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }
        //methods - ToString(), ClacDamage(), CalcHitChance()
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon: {4}\n" +
                "Block: {5}\n" +
                "Description: {6}\n\n",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                EquippedWeapon,
                Block,
                CharacterRace);
        }

        public override int CalcDamage()
        {
            //returnbase.CalcDamage(); - Don't want to return 0
            //Create a random object
            Random rand = new Random();
            //Determine the Damage
            int damage = rand.Next(EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);

            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}
