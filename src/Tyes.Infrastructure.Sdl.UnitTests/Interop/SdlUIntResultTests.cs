namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlUIntResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap()
    {
      Assert.That (new SdlUIntResult (1).Unwrap(), Is.EqualTo (1));
      Assert.That (new SdlUIntResult (1337).Unwrap(), Is.EqualTo (1337));
      Assert.That (new SdlUIntResult (int.MaxValue).Unwrap(), Is.EqualTo (int.MaxValue));
    }

    [Test]
    public void Unwrap_Error()
    {
      var errorApiMock = Mock<ISdl3ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlUIntResult (0).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }
  }
}
