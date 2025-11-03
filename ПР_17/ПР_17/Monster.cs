using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР_17
{
    internal class Monster : Character
    {
        private int currentHealth;
        private int maxHealth;
        private string name;
        private int minForce;
        private int maxForce;
        public Monster(int newCurHealth, int newMaxHealth, string newName, int newMinForce, int newMaxForce)
        {
            currentHealth = newCurHealth;
            maxHealth = newMaxHealth;
            name = newName;
            minForce = newMinForce;
            maxForce = newMaxForce;
        }
        public int MonsterCurrentHealth()
        {
            return currentHealth;
        }
        public override string ToString()
        {
            return "=======Информация о монстре=======\n" +
                $"Имя монстра: {name}\n" +
                $"Максимальный уровень здоровья: {maxHealth}\n" +
                $"Текущий уровень здоровья: {currentHealth}\n" +
                $"Уровень максимального урона: {maxForce}\n";
        }
        public string Info()
        {
            if (currentHealth < 0)
                currentHealth = 0;
            string info = $"{name}\n" +
                $" HP: {currentHealth}\n" +
                $" Атака: от {minForce} до {maxForce}\n";
            return info;
        }
        public int Damage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
                currentHealth = 0; Console.SetCursorPosition(1, 7);
            Console.WriteLine($"HP: {currentHealth}         \n");
            return currentHealth;
        }
    }
}
