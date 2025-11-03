using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork17
{
    internal class Character
    {
        private int currentHealth;
        private int maxHealth;
        private string name;
        private int minForce;
        private int maxForce;
        Random rand = new Random();
        public int Heal(int heal, int currentHealth)
        {
            return currentHealth + heal;
        }
        public int TakeDamage(int getAttackDamage, int currentHealth)
        {
            return currentHealth - getAttackDamage;
        }
        public int GetAttackDamage(int minForce, int maxForce)
        {
            return rand.Next(minForce, maxForce);
        }
        public int Health
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        public bool IsAlive
        {
            get { return currentHealth > 0; }
        }
    }
}
