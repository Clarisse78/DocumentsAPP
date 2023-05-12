namespace Interfaces.Characters;


public interface IPersonnage
{
    int PV { get; set; }
    public void Attack(IPersonnage target);

}

