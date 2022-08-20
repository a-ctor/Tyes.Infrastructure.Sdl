namespace Tyes.Infrastructure.Sdl.UnitTests.Events
{
  using System.Runtime.CompilerServices;
  using System.Runtime.InteropServices;
  using NUnit.Framework;
  using Sdl.Events;

  [TestFixture]
  public class SdlEventExtensionsTests
  {
    [StructLayout (LayoutKind.Sequential, Size = SdlEvent.Size + 1)]
    private struct TooBigStruct : ISdlEvent
    {
      /// <inheritdoc />
      public bool CanBeCreatedFromEventOfType (SdlEventType eventType) => false;
    }

    private struct TestEvent : ISdlEvent
    {
      /// <inheritdoc />
      public bool CanBeCreatedFromEventOfType (SdlEventType eventType) => eventType == SdlEventType.UserEvent;
    }

    [Test]
    public void As()
    {
      SdlEvent ev = default;
      Unsafe.AsRef (in ev.Type) = SdlEventType.UserEvent;

      ref readonly var specificEvent = ref ev.As<TestEvent>();
      Unsafe.AsRef (in ev.Timestamp) = 1337;

      Assert.That (specificEvent.Timestamp, Is.EqualTo (1337));
    }

    [Test]
    public void As_ThrowsWhenEventTypeIsTooBig()
    {
      SdlEvent ev = default;
      Assert.That (() => ev.As<TooBigStruct>(), Throws.InvalidOperationException.With.Message.StartWith ("Cannot cast"));
    }

    [Test]
    public void As_ThrowsWhenEventTypeIsNotSupported()
    {
      SdlEvent ev = default;
      Assert.That (() => ev.As<TestEvent>(), Throws.InvalidOperationException.With.Message.StartWith ("The event type"));
    }

    [Test]
    public void AsUnsafe()
    {
      SdlEvent ev = default;
      Unsafe.AsRef (in ev.Type) = SdlEventType.UserEvent;
      Unsafe.AsRef (in ev.Timestamp) = 9;

      ref readonly var specificEvent = ref ev.AsUnsafe<TestEvent>();
      Assert.That (specificEvent.Timestamp, Is.EqualTo (9));

      Unsafe.AsRef (in ev.Timestamp) = 1337;
      Assert.That (specificEvent.Timestamp, Is.EqualTo (1337));
    }

    [Test]
    public void AsUnsafe_ThrowsWhenEventTypeIsTooBig()
    {
      SdlEvent ev = default;
      Assert.That (() => ev.AsUnsafe<TooBigStruct>(), Throws.InvalidOperationException.With.Message.StartWith ("Cannot cast"));
    }

    [Test]
    public void AsUnsafe_DoesNotThrowWhenEventTypeIsNotSupported()
    {
      SdlEvent ev = default;
      Assert.That (() => ev.AsUnsafe<TestEvent>(), Throws.Nothing);
    }
  }
}
