namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using System;

  public abstract class SdlNativeApiWrapperBase<TNativeInterface> : IDisposable
    where TNativeInterface : class
  {
    protected readonly TNativeInterface Inner;
    protected readonly NativeResourceHelper NativeResourceHelper = new();

    protected SdlNativeApiWrapperBase (TNativeInterface innerNativeInterface)
    {
      if (innerNativeInterface == null)
        throw new ArgumentNullException (nameof(innerNativeInterface));

      Inner = innerNativeInterface;
    }

    /// <inheritdoc />
    public void Dispose()
    {
      NativeResourceHelper.Dispose();
    }
  }
}
