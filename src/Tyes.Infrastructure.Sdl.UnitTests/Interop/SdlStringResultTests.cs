namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using System;
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlStringResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap()
    {
      var sdlStr = NativeResourceHelper.GetString ("Test");
      var sdlStrPtr = sdlStr.Ptr;

      Assert.That (new SdlStringResult (sdlStrPtr).Unwrap(), Is.EqualTo ("Test"));
    }

    [Test]
    public void Unwrap_Null()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlStringResult (IntPtr.Zero).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void Unwrap_EmptyString()
    {
      var sdlStr = NativeResourceHelper.GetString ("");
      var sdlStrPtr = sdlStr.Ptr;

      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ((string?) null);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (new SdlStringResult (sdlStrPtr).Unwrap(), Is.EqualTo (""));
    }

    [Test]
    public void Unwrap_EmptyStringWithError()
    {
      var sdlStr = NativeResourceHelper.GetString ("");
      var sdlStrPtr = sdlStr.Ptr;

      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlStringResult (sdlStrPtr).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }
  }
}
