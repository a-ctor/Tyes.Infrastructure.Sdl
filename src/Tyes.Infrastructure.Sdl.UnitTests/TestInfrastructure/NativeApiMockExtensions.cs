namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using Moq;
  using NativeMock;

  public static class NativeApiMockExtensions
  {
    public static NativeMock<T> AsNativeMock<T> (this Mock<T> mock)
      where T : class
    {
      return new (mock.Object);
    }

    public static NativeMock<ISdl2ErrorNativeApi> AsNativeMock (this Mock<ISdl2ErrorApi> errorApi)
    {
      return new (new Sdl2ErrorNativeApiWrapper (errorApi.Object));
    }
  }
}
