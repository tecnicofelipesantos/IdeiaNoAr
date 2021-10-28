using IdeiaNoAr;
using Xunit;

namespace UnitTests
{
  public class HealTest
  {
    [Fact]
    public void TestHealingDeadCharacters()
    {
      var characterA = new Character();
      var characterB = new Character { Alive = false, Health = 0 };
      characterA.Heal(characterB);

      Assert.Equal(0, characterB.Health);
      Assert.False(characterB.Alive) ;
    }

    [Fact]
    public void TestHealingLimit()
    {
      var characterA = new Character();
      var characterB = new Character();
      characterA.Heal(characterB);

      Assert.Equal(Character.HEALTH_INI, characterB.Health);
    }

    [Fact]
    public void TestHealingYourSelf()
    {
      var faction = new Faction();
      var character = new Character { Health = 900 };
      character.FactionEntry(faction);
      character.Heal(character);

      Assert.Equal(Character.HEALTH_INI, character.Health);
    }
  }
}
