using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Hero
    {
        Random rnd = new Random();
        public string Foto;
        public string Name = "";
        private int age;
        public int Age
        {
            set
            {
                if (value > 500)
                {
                    age = 100;
                }
                else if (value < 0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            }
            get
            {
                return age;
            }
        }
        private bool? gender;
        public string Gender
        {
            set
            {
                if (value == "Мужчина")
                {
                    gender = true;
                }
                else if (value == "Женщина")
                {
                    gender = false;
                }
                else
                {
                    gender = null;
                }
            }
            get
            {
                if (gender == true)
                {
                    return "Мужчина";
                }
                else if (gender == false)
                {
                    return "Женщина";
                }
                else
                {
                    return "Средний пол";
                }
            }
        }
        public int Level = 1;
        private int strength;
        public int Strength
        {
            set
            {
                if (value > 10)
                {
                    strength = 10;
                }else if (value < 0)
                {
                    strength = 0;
                }
                else
                {
                    strength = value;
                }
            }
            get
            {
                return strength;
            }
        }
        private int intellect;
        public int Intellect
        {
            set
            {
                if (value > 10)
                {
                    intellect = 10;
                }
                else if (value < 0)
                {
                    intellect = 0;
                }
                else
                {
                    intellect = value;
                }
            }
            get
            {
                return intellect;
            }
        }
        private int experience;
        public int Experience
        {
            set
            {
                if (value < 0)
                {
                    experience = 0;
                }
                else
                {
                    experience = value;
                }
            }
            get
            {
                return experience;
            }
        }
        private int stamina;
        public int Stamina
        {
            set
            {
                if (value < 0)
                {
                    stamina = 0;
                }
                else
                {
                    stamina = value;
                }
            }
            get
            {
                return stamina;
            }
        }
        private int dexterity;
        public int Dexterity
        {
            set
            {
                if (value < 0)
                {
                    dexterity = 0;
                }
                else
                {
                    dexterity = value;
                }
            }
            get
            {
                return dexterity;
            }
        }
        private int luck;
        public int Luck
        {
            set
            {
                if (value < 0)
                {
                    luck = 0;
                }
                else
                {
                    luck = value;
                }
            }
            get
            {
                return luck;
            }
        }
        private int hp;
        public int HP
        {
            set
            {
                if (value < 0)
                {
                    hp = 0;
                }else if (value > 100 + this.Stamina * 20)
                {
                    hp = 100 + this.Stamina * 20;
                }
                else
                {
                    hp = value;
                }
            }
            get
            {
                return hp;
            }
        }
        private int mana;
        public int Mana
        {
            set
            {
                if (value < 0)
                {
                    mana = 0;
                }else if (value > 100 + this.Intellect * 20)
                {
                    mana = 100 + this.Intellect * 20;
                }
                else
                {
                    mana = value;
                }
            }
            get
            {
                return mana;
            }
        }
        public int attack(Hero enemy, int level_attack)
        {
            int x = (10 + strength * 5 * level_attack + rnd.Next(5));
            if (Luck > Strength*2)
            {
                if (enemy.Dexterity/2 > Strength)
                {
                    return 0;
                }
                else
                {
                    return x + Luck * 2;
                }
            }
            else
            {
                if (enemy.Dexterity/2 > Strength)
                {
                    return 0;
                }
                else
                {
                    return x;
                }
            }
        }
        public int Skillpoints;
    }
}