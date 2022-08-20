namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call returning a handle to a SDL resource.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlHandleResult<T>
    where T : SdlSafeHandle
  {
    private readonly IntPtr _ptr;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlHandleResult (IntPtr ptr)
    {
      _ptr = ptr;
    }

    public T Unwrap (SdlSafeHandleFactory<T> factory)
    {
      if (_ptr == IntPtr.Zero)
        throw SdlMarshal.GetSdlExceptionFromLastError();

      return factory (_ptr);
    }
  }
}
