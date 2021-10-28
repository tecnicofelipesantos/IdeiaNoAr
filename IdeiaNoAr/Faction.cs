using System;

namespace IdeiaNoAr
{
  public class Faction : IEquatable<Faction>
  {
    public Guid ID { get; set; } = Guid.NewGuid();

    public bool Equals(Faction obj)
    {
      if (ReferenceEquals(null, obj))
        return true;

      if (ReferenceEquals(this, obj))
        return true;

      return ID.Equals(obj.ID);
    }
  }
}