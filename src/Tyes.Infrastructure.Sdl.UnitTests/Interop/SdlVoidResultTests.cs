namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlVoidResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ((string?) null);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlVoidResult().Unwrap(), Throws.Nothing);
    }

    [Test]
    public void Unwrap_Error()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlVoidResult().Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }
  }
}
