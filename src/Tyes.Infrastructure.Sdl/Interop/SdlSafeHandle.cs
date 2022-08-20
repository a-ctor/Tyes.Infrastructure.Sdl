namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents a wrapper handle for SDL handles.
  /// </summary>
  public abstract class SdlSafeHandle : SafeHandle
  {
    protected SdlSafeHandle (bool ownsHandle)
      : base (IntPtr.Zero, ownsHandle)
    {
    }

    /// <inheritdoc />
    public override bool IsInvalid => handle == IntPtr.Zero;
  }
}
