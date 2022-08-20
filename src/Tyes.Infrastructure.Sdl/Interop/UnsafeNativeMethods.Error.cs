namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  internal static partial class UnsafeNativeMethods
  {
    /// <summary>
    /// Clears SDL's last-error for the calling thread.
    /// </summary>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_ClearError();

    /// <summary>
    /// Returns SDL's last-error for the calling thread.
    /// </summary>
    /// <returns>The last-error for the current string, or an empty string if no last-error is set.</returns>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlStr SDL_GetError();

    /// <summary>
    /// Sets SDL's last-error for the calling thread to the specified <paramref name="lastError"/>.
    /// </summary>
    /// <remarks>
    /// This method does not support varargs arguments like the native method would.
    /// The specified <paramref name="lastError"/> is sanitized by escaping any percent symbol (%).
    /// </remarks>
    /// <returns>Always -1.</returns>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern int SDL_SetError (SdlString lastError);
  }
}
