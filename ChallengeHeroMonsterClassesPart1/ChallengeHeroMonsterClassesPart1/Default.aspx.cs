using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            initializeCharacterValues("Joe", 100, 30, false, hero);

            Character monster = new Character();
            initializeCharacterValues("Skeleton", 100, 20, false, monster);

            Dice dice = new Dice();

            // Bonus
            checkAttackBonus(hero, monster, dice);

            // While either Character is alive...
            battleSequence(hero, monster, dice);
        }

        public class Character
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public bool AttackBonus { get; set; }

            public int Attack(Dice dice)
            {
                dice.Sides = this.DamageMaximum;
                return dice.Roll();
            }

            public void Defend(int damage)
            {
                this.Health -= damage;
            }
        }

        public class Dice
        {
            public int Sides { get; set; }
            Random random = new Random();

            public int Roll()
            {
                return random.Next(this.Sides);
            }
        }

        private void initializeCharacterValues(string Name, int Health, int DamageMaximum, bool AttackBonus, Character character)
        {
            character.Name = Name;
            character.Health = Health;
            character.DamageMaximum = DamageMaximum;
            character.AttackBonus = AttackBonus;
        }

        private void checkAttackBonus(Character hero, Character monster, Dice dice)
        {
            if (hero.AttackBonus)
                monster.Defend(hero.Attack(dice));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(dice));
        }

        private void battleSequence(Character hero, Character monster, Dice dice)
        {
            while (hero.Health > 0 && monster.Health > 0)
            {
                // Hero attacks
                monster.Defend(hero.Attack(dice));

                // Monster attacks
                hero.Defend(monster.Attack(dice));

                // Print stats to label
                printStats(hero); 
                printStats(monster);
                resultLabel.Text += "<br />";
            }
            // Print winner to resultLabel.Text
            printDeathMessage(hero, monster);

            return;
        }

        private void printStats(Character opponent)
        {
            resultLabel.Text += $"Name: {opponent.Name} - Health: {opponent.Health} - Attack Bonus: {opponent.AttackBonus} - Damage Maximum: {opponent.DamageMaximum}.<br />";
        }

        private void printDeathMessage(Character opponent1, Character opponent2)
        {
            if (opponent1.Health < 0 && opponent2.Health < 0)
                resultLabel.Text += "<br />They both died.";
            else if (opponent1.Health < 0)
                resultLabel.Text += $"<br />{opponent2.Name} defeats {opponent1.Name}.";
            else
                resultLabel.Text += $"<br />{opponent1.Name} defeats {opponent2.Name}.";
        }
    }
}