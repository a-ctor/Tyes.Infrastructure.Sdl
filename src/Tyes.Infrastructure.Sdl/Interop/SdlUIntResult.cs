namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call returning an unsigned integer.
  /// Zero indicate failure.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlUIntResult
  {
    private readonly uint _result;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlUIntResult (uint result)
    {
      _result = result;
    }

    /// <summary>
    /// Returns the integer result of the SDL call, or throws an <see cref="SdlException" /> if the SDL call failed.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public uint Unwrap()
    {
      if (_result == 0)
        throw SdlMarshal.GetSdlExceptionFromLastError();

      return _result;
    }
  }
}
