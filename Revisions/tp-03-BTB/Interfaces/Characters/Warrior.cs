namespace Interfaces.Characters;

public class Warrior : IPersonnage
{
    public int PV { get; set; }
    public int Damages { get; set; }

    public void Attack(IPersonnage target)
    {
        target.PV -= Damages;
        if (target.PV <= 0)
        {
            target.PV = 0;
        }
    }

    public override string ToString()
    {
        return GetType().ToString();
    }
}
