namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using System;
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlHandleResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap_Null()
    {
      var errorApiMock = Mock<ISdl3ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      var nullSafeHandleFactoryMock = Mock<SdlSafeHandleFactory<NullSdlSafeHandle>>();

      Assert.That (() => new SdlHandleResult<NullSdlSafeHandle> (IntPtr.Zero).Unwrap (nullSafeHandleFactoryMock.Object), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }

    [Test]
    public void Unwrap_Handle()
    {
      var argument = new IntPtr (1337);
      var result = new NullSdlSafeHandle();

      var nullSafeHandleFactoryMock = Mock<SdlSafeHandleFactory<NullSdlSafeHandle>>();
      nullSafeHandleFactoryMock.Setup (e => e (argument)).Returns (result);

      Assert.That (new SdlHandleResult<NullSdlSafeHandle> (argument).Unwrap (nullSafeHandleFactoryMock.Object), Is.SameAs (result));
    }
  }
}
