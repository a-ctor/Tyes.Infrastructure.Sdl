namespace Tyes.Infrastructure.Sdl.UnitTests
{
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlMarshalTests : SdlTestBase
  {
    [Test]
    public void ClearLastError()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      SdlMarshal.ClearLastError();
    }


    [Test]
    public void GetLastError()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (SdlMarshal.GetLastError(), Is.EqualTo ("Error"));
    }

    [Test]
    public void GetLastError_EmptyStringIsConvertedToNull()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("");

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (SdlMarshal.GetLastError(), Is.Null);
    }

    [Test]
    public void GetLastError_NullPointerIsConvertedToNull()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ((string?) null);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (SdlMarshal.GetLastError(), Is.Null);
    }


    [Test]
    public void GetSdlExceptionFromLastError()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => throw SdlMarshal.GetSdlExceptionFromLastError(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void GetSdlExceptionFromLastError_GenericMessageIsUsedIfNoErrorWasFound()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ((string?) null);
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => throw SdlMarshal.GetSdlExceptionFromLastError(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("A generic SDL error has occurred."));
    }


    [Test]
    public void SetLastError()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_SetError ("Error")).Returns (0);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      SdlMarshal.SetLastError ("Error");
    }

    [Test]
    public void SetLastError_ThrowsOnNull()
    {
      Assert.That (() => SdlMarshal.SetLastError (null!), Throws.ArgumentNullException);
    }

    [Test]
    public void SetLastError_SanitizesErrorMessage()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_SetError ("Error%%%%23%%")).Returns (0);

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      SdlMarshal.SetLastError ("Error%%23%");
    }
  }
}
