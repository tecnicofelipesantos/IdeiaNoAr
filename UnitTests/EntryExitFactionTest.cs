using IdeiaNoAr;
using Xunit;

namespace UnitTests
{
  public class EntryExitFactionTest
  {
    [Fact]
    public void TestCharacterFactionEntry()
    {
      var faction = new Faction();
      var character = new Character();

      character.FactionEntry(faction);
      Assert.True(character.Faction.Contains(faction));
    }

    [Fact]
    public void TestCharacterFactionExit()
    {
      var faction = new Faction();
      var character = new Character();

      character.FactionEntry(faction);
      character.FactionExit(faction);

      Assert.False(character.Faction.Contains(faction));
    }
  }
}
