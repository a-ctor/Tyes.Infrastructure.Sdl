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

    public static NativeMock<ISdl3ErrorNativeApi> AsNativeMock (this Mock<ISdl3ErrorApi> errorApi)
    {
      return new (new Sdl3ErrorNativeApiWrapper (errorApi.Object));
    }
  }
}
