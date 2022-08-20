namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call which does not return any value, but returns an integer error code.
  /// Negative values indicate failure.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlResult
  {
    private readonly int _result;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlResult (int result)
    {
      _result = result;
    }

    /// <summary>
    /// Returns the integer result of the SDL call, or throws an <see cref="SdlException" /> if the SDL call failed.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public void Unwrap()
    {
      if (_result != 0)
        throw SdlMarshal.GetSdlExceptionFromLastError();
    }
  }
}
