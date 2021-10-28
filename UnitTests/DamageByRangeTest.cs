using IdeiaNoAr;
using Xunit;

namespace UnitTests
{
  public class DamageByRangeTest
  {
    [Fact]
    public void TestDamageByRange_RangedFighter()
    {
      var character = new Character{ Position = 10, TypePlayer = TypePlayer.Ranged_Fighter };
      var opponent = new Character { Position = 25 };

      character.Damage(opponent);

      Assert.True(opponent.Health < Character.HEALTH_INI);
    }

    [Fact]
    public void TestDamageByRange_MeleeFighter()
    {
      var character = new Character { Position = 3, TypePlayer = TypePlayer.Melee_Fighter };
      var opponent = new Character { Position = 5 };

      character.Damage(opponent);

      Assert.True(opponent.Health < Character.HEALTH_INI);
    }
  }
}
