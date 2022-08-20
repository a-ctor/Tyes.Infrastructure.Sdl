namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap()
    {
      Assert.That (() => new SdlResult (0).Unwrap(), Throws.Nothing);
    }

    [Test]
    public void Unwrap_NegativeResult()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlResult (-1).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void Unwrap_PositiveResult()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlResult (-1).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void UnwrapT()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ((string?) null);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (new SdlResult<int> (45).Unwrap(), Is.EqualTo (45));
    }

    [Test]
    public void UnwrapT_Error()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlResult<int> (45).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }
  }
}
