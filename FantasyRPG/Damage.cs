namespace FantasyRPG;

public class Damage
{
    public virtual int Base { get; set; }
    public virtual int Additional { get; set; }
    public virtual int Total { get => Base + Additional; }
}