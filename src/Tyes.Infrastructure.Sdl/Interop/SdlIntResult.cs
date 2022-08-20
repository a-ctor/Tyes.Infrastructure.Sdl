namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call returning an integer.
  /// Negative values indicate failure.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlIntResult
  {
    private readonly int _result;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlIntResult (int result)
    {
      _result = result;
    }

    /// <summary>
    /// Returns the integer result of the SDL call, or throws an <see cref="SdlException" /> if the SDL call failed.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public int Unwrap()
    {
      if (_result < 0)
        throw SdlMarshal.GetSdlExceptionFromLastError();

      return _result;
    }
  }
}
