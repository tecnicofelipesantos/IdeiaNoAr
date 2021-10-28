using IdeiaNoAr;
using Xunit;

namespace UnitTests
{
  public class CharacterTest
  {
    [Fact]
    public void TestCharacterIsAlive()
    {
      var character = new Character();

      Assert.True(character.Alive);
    }

    [Fact]
    public void TestCharacterInitialHealth()
    {
      var character = new Character();

      Assert.Equal(Character.HEALTH_INI, character.Health);
    }

    [Fact]
    public void TestInitialHealth()
    {
      var character = new Character();

      Assert.Equal(Character.HEALTH_INI, character.Health);
    }

    [Fact]
    public void TestInitialLevel()
    {
      var character = new Character();

      Assert.Equal(1, character.Level);
    }

    [Fact]
    public void TestCharaterNoFaction()
    {
      var character = new Character();

      Assert.Empty(character.Faction);
    }
  }
}
