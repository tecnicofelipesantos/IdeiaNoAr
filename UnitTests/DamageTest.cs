using IdeiaNoAr;
using Xunit;

namespace UnitTests
{
  public class DamageTest
  {
    [Fact]
    public void TestDamageFromOpponent()
    {
      var character = new Character();
      var opponent = new Character();

      character.Damage(opponent);

      Assert.True(opponent.Health < Character.HEALTH_INI); 
    }

    [Fact]
    public void TestDamageOnYourSelf()
    {
      var character = new Character();
      character.Damage(character);

      Assert.Equal(Character.HEALTH_INI, character.Health);
    }

    [Fact]
    public void TestDamageToDeath()
    {
      var character = new Character();
      var opponent = new Character();

      while(opponent.Health > 0)
        character.Damage(opponent);

      Assert.False(opponent.Alive);
    }
      
    [Fact]
    public void TestDamageByLevel_BiggerThan50Percent()
    {
      var character = new Character { Level = 8 };
      var opponent = new Character();
      var result = opponent.Health - (Character.DAMAGE_DEFAULT + (Character.DAMAGE_DEFAULT / 2));
      
      character.Damage(opponent);

      Assert.Equal(result, opponent.Health); 
    }

    [Fact]
    public void TestDamageByLevel_SamallerThan50Percent()
    {
      var character = new Character();
      var opponent = new Character { Level = 8 };
      var result = opponent.Health - (Character.DAMAGE_DEFAULT - (Character.DAMAGE_DEFAULT / 2));

      character.Damage(opponent);

      Assert.Equal(result, opponent.Health);
    }

    [Fact]
    public void TestNoDamageToAllies()
    {
      var faction = new Faction();
      var character = new Character();
      var ally = new Character();

      character.FactionEntry(faction);
      ally.FactionEntry(faction);
      character.Damage(ally);

      Assert.Equal(Character.HEALTH_INI, ally.Health);
    }
  }
}
