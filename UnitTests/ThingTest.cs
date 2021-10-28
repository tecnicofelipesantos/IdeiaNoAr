using IdeiaNoAr;
using Xunit;

namespace UnitTests
{
  public class ThingTest
  {
    [Fact]
    public void TestThingNotStartDistroyed()
    {
      var thing = new Thing();
      
      Assert.False(thing.Destroyed);
    }

    [Fact]
    public void TestDamageToThings()
    {
      var character = new Character();
      var thing = new Thing();

      character.Damage(thing);

      Assert.True(thing.Health < Thing.HEALTH_INI);
    }

    [Fact]
    public void TestDamageToDestruction()
    {
      var character = new Character();
      var thing = new Thing();

      while(thing.Health > 0)
        character.Damage(thing);

      Assert.True(thing.Destroyed);
    }
  }
}
