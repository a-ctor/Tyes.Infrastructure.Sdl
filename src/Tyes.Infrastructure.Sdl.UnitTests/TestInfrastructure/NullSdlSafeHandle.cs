namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using Sdl.Interop;

  public class NullSdlSafeHandle : SdlSafeHandle
  {
    /// <inheritdoc />
    public NullSdlSafeHandle()
      : base (true)
    {
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle() => true;
  }
}
