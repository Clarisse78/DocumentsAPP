namespace Interfaces.Characters;

public class Wizard : IPersonnage
{
    public int PV { get; set; }
    public int MagicalPower { get; set; }

    public void Attack(IPersonnage target)
    {
        target.PV -= MagicalPower;
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
