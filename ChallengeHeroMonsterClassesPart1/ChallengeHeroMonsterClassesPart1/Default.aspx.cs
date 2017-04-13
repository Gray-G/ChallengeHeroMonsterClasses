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
            hero.Name = "Joe";
            hero.Health = 100;
            hero.DamageMaximum = 30;
            hero.AttackBonus = false;

            Character monster = new Character();
            monster.Name = "Skeleton";
            monster.Health = 100;
            monster.DamageMaximum = 10;
            monster.AttackBonus = false;

            // Hero attacks
            int damage = hero.Attack();
            monster.Defend(damage);

            // Monster attacks
            damage = monster.Attack();
            hero.Defend(damage);

            DisplayResults(hero);
            DisplayResults(monster);
        }

        private void DisplayResults(Character character)
        {
            resultLabel.Text += $"Name: {character.Name} - health: {character.Health} - attack bonus: {character.AttackBonus} - damage maximum: {character.DamageMaximum}.<br />";
        }

        public class Character
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public bool AttackBonus { get; set; }

            Random random = new Random();

            public int Attack()
            {
                return random.Next(this.DamageMaximum);
            }

            public void Defend(int damage)
            {
                this.Health -= damage;
            }
        }
    }
}