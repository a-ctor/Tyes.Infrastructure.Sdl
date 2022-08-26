namespace Tyes.Infrastructure.Sdl.UnitTests.Events;

using NUnit.Framework;
using Sdl.Events;

[TestFixture]
public class WrappedEnumTests
{
  enum MyEnum
  {
    A = 1,
    B = 2,
    C = 3
  }
  
  [Test]
  public void RawToEnum()
  {
    var value = new WrappedEnum<MyEnum, byte>(1);
    
    Assert.That(value.Value, Is.EqualTo(MyEnum.A));
  }
}
