using System;
using System.Collections.Generic;


namespace IdeiaNoAr
{
  public class Character : IDamage
  {
    public const int HEALTH_INI = 1000;
    public const int LEVEL_INI = 1;
    public const int DAMAGE_DEFAULT = 100;
    public const int HEALTH_DEFAULT = 100;
    public const TypePlayer PLAYER_DEFAULT = TypePlayer.Melee_Fighter;


    public bool Alive { get; set; } = true;
    public int Health { get; set; } = HEALTH_INI;
    public int Level { get; set; } = LEVEL_INI;
    public int Position { get; set; }
    public TypePlayer TypePlayer { get; set; } = PLAYER_DEFAULT;
    public ISet<Faction> Faction { get; set; } = new HashSet<Faction>();
     

    public void Damage(IDamage opponent)
    {
      if (opponent is Character character)
        ApplyDamageCharacter((Character)opponent);
      else if (opponent is Thing thing)
        ApplyDamageThings((Thing)opponent);
    }

    public void Heal(IDamage target)
    {
      if (target is Character character)
        ApplyHeal((Character)target);
    }

    public void FactionEntry(Faction faction)
    {
      Faction.Add(faction);
    }

    public void FactionExit(Faction faction)
    {
      Faction.Remove(faction);
    }

    private int DamageIntensity(Character opponent)
    {
      var intensity = (DAMAGE_DEFAULT / 2);
      return (Level - 5 >= opponent.Level) ? DAMAGE_DEFAULT + intensity : DAMAGE_DEFAULT - intensity;
    }

    private bool ValidateRange(Character opponent)
    {
      int MaxPosition = Math.Max(Position, opponent.Position);
      int MinPosition = Math.Min(Position, opponent.Position);

      if (TypePlayer.Equals(TypePlayer.Melee_Fighter))
        return (MaxPosition - MinPosition) <= 2 ? true : false;
      else
        return (MaxPosition - MinPosition) <= 20 ? true : false;
    }

    private bool Ally(Character opponent)
    {
      return Faction.Overlaps(opponent.Faction);
    }

    private void ApplyDamageCharacter(Character target)
    {
      if ((this != target) && (target.Alive) && !Ally(target))
      {
        if (ValidateRange(target))
        {
          int damage = DamageIntensity(target);
          target.Health -= damage;

          if (target.Health <= 0)
          {
            target.Health = 0;
            target.Alive = false;
          }
        }
      }
    }

    private void ApplyDamageThings(Thing target)
    {
      if(!target.Destroyed)
      {
        target.Health -= DAMAGE_DEFAULT;

        if (target.Health <= 0)
        {
          target.Health = 0;
          target.Destroyed = true;
        }
      }
    }

    private void ApplyHeal(Character character)
    {
      if ((this == character) && (character.Alive) && Ally(character))
      {
        if (character.Health < HEALTH_INI)
          character.Health += HEALTH_DEFAULT;
      }
    }
  }
}
