namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the result of a SDL call which returns a <typeparamref name="TResult" />, but requires explicit checking for
  /// errors.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public readonly ref struct SdlResult<TResult>
    where TResult : unmanaged
  {
    private readonly TResult _result;

    // For unit testing purposes, normally instantiated through P/Invoke
    internal SdlResult (TResult result)
    {
      _result = result;
    }

    /// <summary>
    /// Checks for a SDL last-error and throws a <see cref="SdlException" /> if one is available.
    /// </summary>
    /// <exception cref="SdlException">The SDL call failed.</exception>
    public TResult Unwrap()
    {
      var lastError = SdlMarshal.GetLastError();
      if (lastError == null)
        return _result;

      SdlMarshal.ClearLastError();
      throw new SdlException (lastError);
    }
  }
}
