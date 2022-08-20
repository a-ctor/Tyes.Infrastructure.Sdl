namespace Tyes.Infrastructure.Sdl.Interop
{
  /// <summary>
  /// Represents a wrapper handle for SDL handles.
  /// </summary>
  public abstract unsafe class SdlSafeHandle<TData> : SdlSafeHandle
    where TData : unmanaged
  {
    protected SdlSafeHandle (bool ownsHandle)
      : base (ownsHandle)
    {
    }

    protected TData* Data => (TData*) handle;
  }
}
