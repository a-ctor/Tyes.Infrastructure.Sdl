namespace Tyes.Infrastructure.Sdl.UnitTests.Interop
{
  using NUnit.Framework;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public class SdlIntResultTests : SdlTestBase
  {
    [Test]
    public void Unwrap()
    {
      Assert.That (new SdlIntResult (0).Unwrap(), Is.EqualTo (0));
      Assert.That (new SdlIntResult (1337).Unwrap(), Is.EqualTo (1337));
      Assert.That (new SdlIntResult (int.MaxValue).Unwrap(), Is.EqualTo (int.MaxValue));
    }

    [Test]
    public void Unwrap_Error()
    {
      var errorApiMock = Mock<ISdl2ErrorApi>();
      errorApiMock.Setup (e => e.SDL_GetError()).Returns ("Error");
      errorApiMock.Setup (e => e.SDL_ClearError());

      using var errorApiNativeMock = errorApiMock.AsNativeMock();

      Assert.That (() => new SdlIntResult (-1).Unwrap(), Throws.TypeOf<SdlException>().With.Message.EqualTo ("Error"));
    }
  }
}
