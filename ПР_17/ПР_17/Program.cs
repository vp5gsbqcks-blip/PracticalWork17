using ПР_17;

int motionGame = 0, move = 0; //MotionGame - счётчик шагов игры, move - вариант действия игрока
int gameStop = 0; //Переменная для остановки игры
int movePlayer = 0, moveMonster = 0; //Счётчики ходов
string answer = "N", monsterName = "Монстр", playerName = "Игрок";
try
{
    Console.WriteLine("\tМини-игра - \"Битва с монстром\"\n");
    Console.WriteLine("=======Ознакомительная информация=======\n" +
        "Количество ХП и у героя и у монстра = 100.\nМинимальная атака = 2\nМаксимальные атаки:\n  Монстра: 15\n  Героя: 12\n\n" +
        "ХП лечится на 15 единиц\nУровень усиления атаки: 4\n\n" +
        "\nНажмите Enter, чтобы продолжить:");
    Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Хотите ввести имя монстра? Y-N");
    answer = Console.ReadLine();
    if (answer == "Y" || answer == "y")
    {
        Console.Write("Вы можете ввести имя монстра:\n--> ");
        monsterName = Console.ReadLine();
    }
    else if (answer == "N" || answer == "n")
    {
        Console.WriteLine("Вы выбрали имя по умолчанию.");
    }
    Console.WriteLine("\nВы хотите ввести имя героя? Y-N");
    answer = Console.ReadLine();
    if (answer == "Y" || answer == "y")
    {
        Console.Write("Вы можете ввести имя героя:\n--> ");
        playerName = Console.ReadLine();
    }
    else if (answer == "N" || answer == "n")
    {
        Console.WriteLine("Вы выбрали имя по умолчанию.");
    }
    else
    {
        Console.WriteLine("Ошибка: Неправильный ввод данных.");
        return;
    }
    Console.WriteLine("\n   Нажмите Enter, чтобы продолжить:");
    Console.ReadLine();
    Console.Clear();
    Monster monster = new Monster(100, 100, monsterName, 2, 15);
    Player player = new Player(100, 100, playerName, 2, 12, 15, 4, true);
    Console.WriteLine(monster.ToString());
    Console.WriteLine(player.ToString());
    Console.WriteLine("\nНажмите Enter, чтоб начать игру.");
    Console.ReadLine();
    Console.Clear();
    Game game = new Game(monster, player);
    int stopGame = 0;
    Console.WriteLine(game.StartGame(monster, player));
    Thread.Sleep(800);
    Console.Clear();
    do
    {
        Console.WriteLine(player.Info());
        Console.WriteLine(monster.Info());
        Thread.Sleep(1000);
        Random random = new Random();
        if (move == 0)
        {
            move = random.Next(1, 3);
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Ход игры:");
            Console.SetCursorPosition(0, 12);
            Console.WriteLine($"{motionGame}| Новая битва началась!");
        }
        if (move == 1)
        {
            game.MoveMonsterAttack(monster, player);
            motionGame++;
            moveMonster++;
            Console.WriteLine("\n\n\n" + monster.Info());
            Console.SetCursorPosition(0, 12);
            Console.WriteLine($"{motionGame}| Монстр нанёс удар!       \nГерой готовится к действию...");
            game.CourseOfTheGame($"{motionGame}| Удар монстра ххххх");
            Console.SetCursorPosition(0, 0);
            move = 2;
        }
        else if (move == 2)
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Герой делает ход:\n" +
                "1) Атаковать\n" +
                "2) Использовать супер-атаку\n" +
                "3) Вылечиться\n" +
                "4) Сдаться\n");
            Console.Write("Ваш выбор:\n");
            int playerAnswer = Convert.ToInt32(Console.ReadLine());
            if (playerAnswer > 4 || playerAnswer < 1)
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Номер действия не может быть больше/меньше 4. Выбран случайный ход");
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 0);
                Random rand = new Random();
                playerAnswer = rand.Next(1,4);
            }
            if (player.SpecialAttack(player) == false && playerAnswer == 2)
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Супер-атака уже использована. Применена простая атака.");
                motionGame++;
                movePlayer++;
                playerAnswer = 1;
                game.CourseOfTheGame($"{motionGame}| Попытка использования супер-атаки. Применение обычной атаки.");
                Thread.Sleep(1000);
            }
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("                                                                  ");
            if (playerAnswer == 1)
            {
                game.MovePlayerAttack(monster, player);
                motionGame++;
                movePlayer++;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"{motionGame}| Игрок нанёс удар!      \nМонстр готовится к действию...");
                game.CourseOfTheGame($"{motionGame}| Удар игрока ****");
                Console.SetCursorPosition(0, 0);
            }
            else if (playerAnswer == 2)
            {
                game.MovePlayerSuperAttack(monster, player);
                motionGame++;
                movePlayer++;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"{motionGame}| Игрок нанёс супер-удар!      \nМонстр готовится к действию...");
                game.CourseOfTheGame($"{motionGame}| Супер-удар игрока *!*!*!*");
                Console.SetCursorPosition(0, 0);
                player.SpecialAttackClose();
            }
            else if (playerAnswer == 3)
            {
                game.MovePlayerHealing(monster, player);
                motionGame++;
                movePlayer++;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"{motionGame}| Игрок вылечился!      \nМонстр готовится к действию...");
                game.CourseOfTheGame($"{motionGame}| Игрок вылечился +++++");
                Console.SetCursorPosition(0, 0);
            }
            else if (playerAnswer == 4)
            {
                gameStop = game.GameStop(monster, player);
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"{motionGame++}| Игрок сдался!                         \nМонстр победил!                     ");
                game.CourseOfTheGame($"{motionGame}| Игрок сдался :(");
                Console.SetCursorPosition(0, 0);
                break;
            }
            move = 1;
            if (player.PLayerCurrentHealth() <= 0)
            {
                gameStop = game.GameStop(monster, player);
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"{motionGame}| Игрок потерял всё здоровье!      \nМонстр победил!");
                Console.SetCursorPosition(0, 0);
                break;
            }
            else if (monster.MonsterCurrentHealth() <= 0)
            {
                gameStop = game.GameStop(monster, player);
                Console.SetCursorPosition(0, 12);
                Console.WriteLine($"{motionGame}| Монстр потерял всё здоровье!      \nИгрок победил!");
                Console.SetCursorPosition(0, 0);
                break;
            }
        }
    }
    while (stopGame != 4);
    if (gameStop == 409)
    {
        Console.SetCursorPosition(0, 21);
        Console.WriteLine("Игра окончена. Нажмите Enter, чтобы вывести информацию о сыгранной игре.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("===========Информация об игре===========\n" +
            $"Игроком сделано {movePlayer} ход(ов).\n" +
            $"Монстром сделано {moveMonster} ход(ов).");
        Console.WriteLine(game.EndingCourseGame());
    }
    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
    Console.ReadLine();
    Console.Clear();
    Console.WriteLine(game.GameTheEnd());
}
catch
{
    Console.WriteLine("Произошла непредвиденная ошибка!");
}