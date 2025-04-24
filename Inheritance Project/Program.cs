using InheritanceProject;

Player playerCharacter = new Player("Fred", new Attributes(10, 10, 20));
playerCharacter.EquipWeapon(new Weapon("Zweihander", 2, 5));

Character goblinCharacter = new Goblin("Goblin", new Attributes(5, 5, 5));
goblinCharacter.EquipWeapon(new Weapon("Stick", 1, 3));
Character ogreCharacter = new Ogre("Ogre", new Attributes(5, 5, 15));
ogreCharacter.EquipWeapon(new Weapon("A literal boat", 5, 10));
Crate crate = new Crate();

List<ITarget> targets = new List<ITarget>{goblinCharacter, ogreCharacter, crate};

Console.WriteLine($"{playerCharacter} is in combat!");
foreach (ITarget target in targets)
{
    if (target is Character enemyTarget)
    {
        Console.WriteLine($"{enemyTarget} weilding a {enemyTarget.WeaponName()}");
    }
    else
    {
        Console.WriteLine($"{target}");
    }
}
Console.WriteLine("Press any key to start fighting!");
Console.ReadKey();

while (true)
{
    Console.Clear();
    Console.WriteLine(playerCharacter.DisplayStatus());
    int targetIndex = 0;
    foreach (ITarget target in targets)
    {
        Console.WriteLine($"{++targetIndex} : {target.DisplayStatus()}");
    }
    
    Console.WriteLine("What would you like to do?");
    string input = Console.ReadLine().ToLower();
    string[] commands = input.Split(' ');
    
    if (commands[0] == "attack" && int.TryParse(commands[1], out int targetNumber))
    {
        targetNumber--;
        bool validTarget = targetNumber >= 0 && targetNumber < targets.Count;
        if (validTarget)
        {
            ITarget target = targets[targetNumber];
            playerCharacter.Attack(target);
            if (target.IsDead())
            {
                targets.Remove(target);
                if (targets.Count == 0)
                {
                    break;
                }
            }

            if (target is Character enemy && !target.IsDead())
            {
                enemy.Attack(playerCharacter);
                if (playerCharacter.IsDead())
                {
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Must Select a valid target!");
        }
    }
    else
    {
        Console.WriteLine("I do not understand that command!");
    }

    Console.ReadKey();
}

Console.WriteLine("The battle is over!");