namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;

  /// <summary>
  /// Provides miscellaneous methods used when interacting with the native SDL DLL.
  /// </summary>
  public static class SdlMarshal
  {
    /// <summary>
    /// Clears SDL's last-error for the calling thread.
    /// </summary>
    public static void ClearLastError() => UnsafeNativeMethods.SDL_ClearError();

    /// <summary>
    /// Returns SDL's last-error for the calling thread.
    /// </summary>
    public static string? GetLastError()
    {
      var lastError = UnsafeNativeMethods.SDL_GetError();
      return !lastError.IsEmpty
        ? lastError.AsString()
        : null;
    }

    /// <summary>
    /// Returns an <see cref="SdlException" /> consuming SDL's last-error.
    /// </summary>
    /// <remarks>
    /// Even if SDL's last-error is not set, this method will still return a <see cref="SdlException" />.
    /// This is useful in cases where the return value is non-valid but no last error has been set.
    /// </remarks>
    public static SdlException GetSdlExceptionFromLastError()
    {
      var lastError = GetLastError() ?? "A generic SDL error has occurred.";
      ClearLastError();

      return new SdlException (lastError);
    }

    /// <summary>
    /// Sets SDL's last-error for the calling thread.
    /// </summary>
    /// <remarks>
    /// Avoid passing a <paramref name="lastError" /> with percent signs (%) since this will require the string to be
    /// sanitized.
    /// </remarks>
    public static void SetLastError (string lastError)
    {
      if (lastError == null)
        throw new ArgumentNullException (nameof(lastError));

      var sanitizedError = lastError.Replace ("%", "%%");
      using (var lastErrorSdlString = SdlString.Allocate (sanitizedError))
        UnsafeNativeMethods.SDL_SetError (lastErrorSdlString);
    }

    public static unsafe string? PtrToSdlString (void* ptr) => PtrToSdlString (new IntPtr (ptr));

    public static string? PtrToSdlString (IntPtr ptr) => new SdlStr (ptr).AsString();
  }
}
