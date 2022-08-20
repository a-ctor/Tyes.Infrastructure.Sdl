namespace Tyes.Infrastructure.Sdl.UnitTests.Events
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Runtime.InteropServices;
  using NUnit.Framework;
  using Sdl.Events;

  [TestFixture]
  public class SdlEventTests
  {
    [Test]
    public void StructSizeMatchesConstant()
    {
      Assert.That (typeof(SdlEvent).StructLayoutAttribute?.Size, Is.EqualTo (SdlEvent.Size));
      Assert.That (Marshal.SizeOf (typeof(SdlEvent)), Is.EqualTo (SdlEvent.Size));
    }

    [Test]
    public void StructTSizeMatchesConstant()
    {
      Assert.That (typeof(SdlEvent<>).StructLayoutAttribute?.Size, Is.EqualTo (SdlEvent.Size));
    }

    private static IEnumerable<TestCaseData> GetSdlEventTypes()
    {
      return typeof(Sdl2).Assembly.GetTypes()
        .Where (t => t.IsValueType)
        .Where (t => t.IsAssignableTo (typeof(ISdlEvent)))
        .Select (t => new TestCaseData (t) {TestName = $"{t.Name}"});
    }

    [Test]
    [TestCaseSource (nameof(GetSdlEventTypes))]
    public void HasCorrectStructSize (Type target)
    {
      // We cannot use Marshal.SizeOf() here, since it cannot handle generic types
      // As such, we have to use reflection to call Unsafe.SizeOf<T>() on our specified type
      var sdlEventType = typeof(SdlEvent<>).MakeGenericType (target);
      var sdlEventTypeSizeofMethod = typeof(Unsafe).GetMethod (nameof(Unsafe.SizeOf))!.MakeGenericMethod (sdlEventType);
      Assert.That (sdlEventTypeSizeofMethod.Invoke (null, Array.Empty<object>()), Is.AtMost (SdlEvent.Size));
    }

    [Test]
    [TestCaseSource (nameof(GetSdlEventTypes))]
    public void HasStructLayoutAttribute (Type target)
    {
      Assert.That (target.StructLayoutAttribute, Is.Not.Null);
      Assert.That (target.StructLayoutAttribute!.Value, Is.EqualTo (LayoutKind.Sequential).Or.EqualTo (LayoutKind.Explicit));
    }
  }
}
