using PracticalWork17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork17
{
    internal class Player : Character
    {
        private int currentHealth;
        private int maxHealth;
        private string name;
        private int minForce;
        private int maxForce;
        private int quantityHealthHeal;
        private int powerSpecialAttack;
        private bool specialAttack;
        public Player(int newCurHealth, int newMaxHealth, string newName, int newMinForce, int newMaxForce, int newQuanHH, int newPowSpecAt, bool newSpecAttack)
        {
            currentHealth = newCurHealth; //Текущее здоровье
            maxHealth = newMaxHealth; //Максимальное здоровье
            name = newName; //Имя
            minForce = newMinForce; //Минимальная сила атаки
            maxForce = newMaxForce; //Максимальняа сила атаки
            quantityHealthHeal = newQuanHH; //Количество единиц хилок
            powerSpecialAttack = newPowSpecAt; //Сила супер-атаки
            specialAttack = newSpecAttack; //Супер-атака
        }
        public int PLayerCurrentHealth()
        {
            return currentHealth;
        }
        public bool SpecialAttackClose()
        {
            specialAttack = false;
            return false;
        }
        public bool SpecialAttack(Player player)
        {
            return specialAttack;
        }
        public int SpecialAttack(int damage, int specialAttack)
        {
            return damage * specialAttack;
        }
        public override string ToString()
        {
            return "=======Информация о герое=======\n" +
                $"Имя героя: {name}\n" +
                $"Текущий уровень здоровья: {currentHealth}\n" +
                $"Максимальный уровень здоровья: {maxHealth} \n" +
                $"Сила максимальной атаки: {maxForce} \n" +
                $"Количество хилок: {quantityHealthHeal} \n" +
                $"Мощность специальной атаки: {powerSpecialAttack} \n";
        }
        public string Info()
        {
            if (currentHealth < 0)
                currentHealth = 0;
            Console.WriteLine($"{name}");
            Console.WriteLine($" HP: {currentHealth}");
            Console.WriteLine($" Атака: от {minForce} до {maxForce}");
            Console.WriteLine($" Лечение: {quantityHealthHeal}\n");
            return "";
        }
        public int Damage(int damage)
        {
            currentHealth = TakeDamage(damage, currentHealth);
            if (currentHealth < 0)
                currentHealth = 0; Console.SetCursorPosition(1, 1);
            Console.WriteLine($"HP: {currentHealth}         \n");
            return currentHealth;
        }
        public int HealPLayer(int heal)
        {
            currentHealth = Heal(heal, currentHealth);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"HP: {currentHealth}         \n");
            return currentHealth;
        }
    }
}
