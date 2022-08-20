namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call returning an string.
  /// Null indicate failure, while an empty string might indicate a failure.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlStringResult
  {
    private readonly IntPtr _ptr;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlStringResult (IntPtr ptr)
    {
      _ptr = ptr;
    }

    /// <summary>
    /// Returns the string result of the SDL call, or throws an <see cref="SdlException" /> if the SDL call failed.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public string Unwrap()
    {
      var value = SdlMarshal.PtrToSdlString (_ptr);
      if (value == null)
        throw SdlMarshal.GetSdlExceptionFromLastError();
      if (value.Length != 0)
        return value;

      var lastError = SdlMarshal.GetLastError();
      if (lastError != null)
      {
        SdlMarshal.ClearLastError();
        throw new SdlException (lastError);
      }

      return value;
    }
  }
}
