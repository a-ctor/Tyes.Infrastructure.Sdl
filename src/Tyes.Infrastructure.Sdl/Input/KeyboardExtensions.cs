namespace Tyes.Infrastructure.Sdl.Input
{
  using Interop;

  public static class KeyboardExtensions
  {
    /// <summary>
    /// Searches the current keyboard layout to find the first <see cref="ScanCode"/> corresponding to the specified <see cref="KeyCode"/>.
    /// </summary>
    /// <returns>Returns <see cref="ScanCode.Unknown"/> if no corresponding <see cref="ScanCode"/> could be found.</returns>
    public static ScanCode ToScanCode (this KeyCode keyCode) => UnsafeNativeMethods.SDL_GetScancodeFromKey (keyCode);

    /// <summary>
    /// Returns the user friendly name of the specified <see cref="KeyCode"/>.
    /// </summary>
    /// <returns>Returns <see langword="null"/> if no name is available for the specified <see cref="KeyCode"/></returns>
    public static string GetName (this KeyCode keyCode) => UnsafeNativeMethods.SDL_GetKeyName (keyCode).Unwrap();


    /// <summary>
    /// Returns the user friendly name of the specified <see cref="ScanCode"/>.
    /// </summary>
    /// <returns>Returns <see langword="null"/> if no name is available for the specified <see cref="ScanCode"/></returns>
    public static string GetName (this ScanCode scanCode) => UnsafeNativeMethods.SDL_GetScancodeName (scanCode).Unwrap();

    /// <summary>
    /// Applies the current keyboard layout to the specified <see cref="ScanCode"/> returning the corresponding <see cref="KeyCode"/>.
    /// </summary>
    /// <returns>Returns <see cref="KeyCode.Unknown"/> if no corresponding <see cref="KeyCode"/> could be found.</returns>
    public static KeyCode ToKeyCode (this ScanCode scanCode) => UnsafeNativeMethods.SDL_GetKeyFromScancode (scanCode).Unwrap();
  }
}
