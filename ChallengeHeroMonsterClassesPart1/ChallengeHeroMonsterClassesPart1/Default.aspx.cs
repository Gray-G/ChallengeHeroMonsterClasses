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
            Character monster = new Character();

            hero.Name = "Joe";
            hero.Health = 100;
            hero.DamageMaximum = 30;
            hero.AttackBonus = 15;

            monster.Name = "Skeleton";
            monster.Health = 100;
            monster.DamageMaximum = 10;
            monster.AttackBonus = 10;

            monster.Defend(hero.Attack());
            hero.Defend(monster.Attack());

            DisplayResults(hero, monster);
        }

        private void DisplayResults(Character hero, Character monster)
        {
            resultLabel.Text = $"Hero {hero.Name} now has {hero.Health} health. <br />" +
                $"Monster {monster.Name} now has {monster.Health} health.";
        }

        public class Character
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public int AttackBonus { get; set; }

            Random random = new Random();

            public int Attack()
            {
                return random.Next(this.AttackBonus, this.DamageMaximum);
            }

            public void Defend(int damage)
            {
                this.Health -= damage;
            }
        }
    }
}