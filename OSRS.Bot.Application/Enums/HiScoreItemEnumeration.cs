using System.Reflection;

namespace OSRS.Bot.Application.Enums;

public abstract class HiScoreItemEnumeration : IComparable
{
    public string Name { get; private set; }
    public HiScoreTypeEnum HiScoreType { get; private set; }
    public int Id { get; private set; }

    protected HiScoreItemEnumeration(int id, string name, HiScoreTypeEnum hiScoreType) => (Id, Name, HiScoreType) = (id, name, hiScoreType);

    public static IEnumerable<T> GetAll<T>() where T : HiScoreItemEnumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not HiScoreItemEnumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object? obj) => Id.CompareTo(((HiScoreItemEnumeration?)obj)?.Id);

    public override int GetHashCode() => Id.GetHashCode();
}
