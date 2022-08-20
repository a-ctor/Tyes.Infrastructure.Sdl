namespace Tyes.Infrastructure.Sdl.Input
{
  using Interop;

  /// <summary>
  /// Provides methods for retrieving the state of the mouse.
  /// </summary>
  public static class SdlMouse
  {
    public static unsafe SdlMouseState GetState()
    {
      var mouseButtonState = UnsafeNativeMethods.SDL_GetGlobalMouseState (out var x, out var y);
      return new SdlMouseState (
        x,
        y,
        mouseButtonState);
    }
  }
}
