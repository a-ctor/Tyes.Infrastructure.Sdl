namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call returning a boolean.
  /// Negative values indicate failure.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlBoolResult
  {
    private readonly int _result;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlBoolResult (int result)
    {
      _result = result;
    }

    /// <summary>
    /// Returns the integer result of the SDL call, or throws an <see cref="SdlException" /> if the SDL call failed.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public bool Unwrap()
    {
      if (_result < 0)
        throw SdlMarshal.GetSdlExceptionFromLastError();

      return _result != 0;
    }


    /// <summary>
    /// Returns the integer result of the SDL call, or throws an <see cref="SdlException" /> if the SDL call failed.
    /// Also checks for a possible exception if false is returned, which is necessary for some SDL methods.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public bool UnwrapAmbiguous()
    {
      if (Unwrap())
        return true;

      var lastError = SdlMarshal.GetLastError();
      if (lastError != null)
      {
        SdlMarshal.ClearLastError();
        throw new SdlException (lastError);
      }

      return false;
    }

    /// <summary>
    /// Returns the integer result of the SDL call if the result is <see langword="true" />, otherwise throws an
    /// <see cref="SdlException" /> if the SDL call failed.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed or the result was <see langword="false" />.</exception>
    public void UnwrapTrue()
    {
      if (_result <= 0)
        throw SdlMarshal.GetSdlExceptionFromLastError();
    }
  }
}
