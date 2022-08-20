namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlBoolResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap_TrueValue()
    {
      Assert.That (new SdlBoolResult (1).Unwrap(), Is.True);
    }

    [Test]
    public void Unwrap_FalseValue()
    {
      Assert.That (new SdlBoolResult (0).Unwrap(), Is.False);
    }

    [Test]
    public void Unwrap_Error()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlBoolResult (-1).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }


    [Test]
    public void UnwrapTrue_TrueValue()
    {
      Assert.That (() => new SdlBoolResult (1).UnwrapTrue(), Throws.Nothing);
    }

    [Test]
    public void UnwrapTrue_FalseValue()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlBoolResult (0).UnwrapTrue(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void UnwrapTrue_Error()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlBoolResult (-1).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }


    [Test]
    public void UnwrapAmbiguous_TrueValue()
    {
      Assert.That (new SdlBoolResult (1).UnwrapAmbiguous(), Is.True);
    }

    [Test]
    public void UnwrapAmbiguous_FalseValue()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ((string?) null);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (new SdlBoolResult (0).UnwrapAmbiguous(), Is.False);
    }

    [Test]
    public void UnwrapAmbiguous_AmbiguousFalseValue()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlBoolResult (0).UnwrapAmbiguous(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void UnwrapAmbiguous_Error()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlBoolResult (-1).UnwrapAmbiguous(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }
  }
}
