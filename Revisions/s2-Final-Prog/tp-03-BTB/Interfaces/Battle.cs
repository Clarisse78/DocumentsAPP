using Interfaces.Characters;

namespace Interfaces;

public class Battle
{
    private Player _joueur = new Player("You", 
        new List<IPersonnage>()
        {
            new Warrior{PV = 50,Damages = 10},
            new Wizard { PV = 30, MagicalPower = 20 }
        });
    
    private Player _computer = new Player("Computer", 
        new List<IPersonnage>()
        {
            new Warrior{PV = 50,Damages = 10},
            new Wizard { PV = 30, MagicalPower = 20 }
        });

    private Random random = new Random();

    public bool TeamOfPlayerIsDead(Player joueur)
    {
        if (joueur.Team.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Attack(IPersonnage attacker, IPersonnage target, Player joueur)
    {
        attacker.Attack(target);
        joueur.Team.RemoveAll(elem => elem.PV == 0);
    }

    private void DisplayTeam(Player _player)
    {
        Console.WriteLine("Team of " + _player + ":");
        for (int i = 0; i < _player.Team.Count; i++)
        {
            Console.WriteLine($"| ({i})" + _player.Team[i] + " - PV :" + _player.Team[i].PV + " |");
        }
    }

    public void ChooseACharacterComputer()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        var oui = random.Next(_computer.Team.Count-1);
        Console.WriteLine("Computer has choosen " + _computer.Team[oui] + " from his soldiers...");
        var target = random.Next(_joueur.Team.Count-1);
        Console.WriteLine("...and is going to attack your " + _joueur.Team[target]);
        Attack(_computer.Team[oui],_joueur.Team[target], _joueur);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void ChooseACharacter()
    {
        Console.WriteLine("Choose one of your characters for attack (1-" + _joueur.Team.Count + ")");
        var ask = Console.ReadLine();
        int ok = 0;
        while (ask is null || !int.TryParse(ask, out ok) || ok >= _joueur.Team.Count || ok < 1)
        {
            Console.WriteLine("Choose one of your characters for attack (1-" + _joueur.Team.Count + ")");
            ask = Console.ReadLine();
        }
        var attacker = _joueur.Team[ok-1];
        Console.WriteLine("You have chosen the " + attacker);
        ask = Console.ReadLine();
        while (ask is null || !int.TryParse(ask, out ok) || ok >= _computer.Team.Count || ok < 1)
        {
            Console.WriteLine("Choose one of your characters for attack (1-" + _computer.Team.Count + ")");
            ask = Console.ReadLine();
        }
        var target = _joueur.Team[ok-1];
        Attack(attacker,target, _computer);
    }

    private bool PlayRound(int roundIndex)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(_joueur + "is going to play");
        Console.ForegroundColor = ConsoleColor.White;
        DisplayTeam(_joueur);
        Console.ForegroundColor = ConsoleColor.Red;
        DisplayTeam(_computer);
        Console.ForegroundColor = ConsoleColor.White;
        ChooseACharacter();
        if (TeamOfPlayerIsDead(_computer))
        {
            return false;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ChooseACharacterComputer();
            Console.ForegroundColor = ConsoleColor.White;
            if (TeamOfPlayerIsDead(_joueur))
            {
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("End of the round n°" + roundIndex);
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
    }

    public void Play()
    {
        int i = 0;
        while (PlayRound(i))
        {
            i += 1;
        }   
        Console.ForegroundColor = ConsoleColor.Blue;
        if (TeamOfPlayerIsDead(_computer))
        {
            Console.WriteLine(_joueur + " won the battle... Like always");
        }
        else
        {
            Console.WriteLine(_computer + " won. AI will replace humans");
        }
    }
}