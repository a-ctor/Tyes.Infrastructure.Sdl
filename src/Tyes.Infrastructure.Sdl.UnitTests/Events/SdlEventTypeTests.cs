namespace Tyes.Infrastructure.Sdl.UnitTests.Events
{
  using System;
  using System.Linq;
  using NUnit.Framework;
  using Sdl.Events;

  [TestFixture]
  public class SdlEventTypeTests
  {
    [Test]
    public void DefaultIsFirstEvent()
    {
      SdlEventType defaultEventType = default;
      Assert.That (SdlEventType.FirstEvent, Is.EqualTo (defaultEventType));
    }

    [Test]
    public void FirstEventIsLowestValue()
    {
      var min = Enum.GetValues<SdlEventType>()
        .Cast<uint>()
        .Min();

      Assert.That ((uint) SdlEventType.FirstEvent, Is.EqualTo (min));
    }

    [Test]
    public void LastEventIsHighestValue()
    {
      var min = Enum.GetValues<SdlEventType>()
        .Cast<uint>()
        .Max();

      Assert.That ((uint) SdlEventType.LastEvent, Is.EqualTo (min));
    }
  }
}
