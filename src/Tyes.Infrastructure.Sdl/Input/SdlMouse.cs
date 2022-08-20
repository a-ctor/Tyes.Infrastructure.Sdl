namespace Tyes.Infrastructure.Sdl.Input
{
  using Interop;

  /// <summary>
  /// Provides methods for retrieving the state of the mouse.
  /// </summary>
  public static class SdlMouse
  {
    public static SdlMouseState GetGlobalState()
    {
      var mouseButtonState = UnsafeNativeMethods.SDL_GetGlobalMouseState (out var x, out var y);
      return new SdlMouseState (
        x,
        y,
        mouseButtonState);
    }

    public static SdlMouseState GetState()
    {
      var mouseButtonState = UnsafeNativeMethods.SDL_GetMouseState (out var x, out var y);
      return new SdlMouseState (
        x,
        y,
        mouseButtonState);
    }
  }
}
