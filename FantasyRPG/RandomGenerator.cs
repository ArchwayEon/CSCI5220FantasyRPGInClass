namespace FantasyRPG;

public class RandomGenerator : IRandom
{
    private readonly Random _random = new();
    public int Get(int lower, int upper)
    {
        return _random.Next(lower, upper + 1);
    }
}