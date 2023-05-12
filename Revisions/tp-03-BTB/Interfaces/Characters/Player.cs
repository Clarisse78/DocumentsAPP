namespace Interfaces.Characters;

public class Player
{
    public string Name { get; set; }

    public List<IPersonnage> Team;


    public Player(string name, List<IPersonnage> team)
    {
        Name = name;
        Team = new List<IPersonnage>();
        for (int i = 0; i < team.Count; i++)
        {
            Team.Add(team[i]);
        }
    }

    public override string ToString()
    {
        return Name;
    }
}