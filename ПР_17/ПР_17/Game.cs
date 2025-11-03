using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР_17
{
    internal class Game
    {
        public Monster monster;
        public Player player;
        public string theCourseOfTheGame = "\n***Ход игры***\n";
        public Game(Monster newMonster, Player newPlayer)
        {
            monster = newMonster;
            player = newPlayer;
        }
        public string StartGame(Monster monster, Player player)
        {
            return "\t***Игра запущена***";
        }
        public int GameStop(Monster monster, Player player)
        {
            return 409;
        }
        public string GameTheEnd()
        {
            return "\nКомпания RBKV благодарит вас за сыгранную игру!";
        }
        public int MovePlayerAttack(Monster monster, Player player)
        {
            int damage = player.GetAttackDamage(2, 12);
            return monster.Damage(damage);
        }
        public int MovePlayerSuperAttack(Monster monster, Player player)
        {
            int damage = player.SpecialAttack(player.GetAttackDamage(2, 12), 4);
            return monster.Damage(damage);
        }
        public int MovePlayerHealing(Monster monster, Player player)
        {
            int heal = player.HealPLayer(15);
            return heal;
        }
        public int MoveMonsterAttack(Monster monster, Player player)
        {
            int damage = monster.GetAttackDamage(2, 15);
            return player.Damage(damage);
        }
        public string GetInfo()
        {
            return monster.ToString(); player.ToString();
        }
        public string CourseOfTheGame(string motion)
        {
            theCourseOfTheGame = theCourseOfTheGame + "\n" + motion;
            return "";
        }
        public string EndingCourseGame()
        {
            return theCourseOfTheGame;
        }
    }
}
