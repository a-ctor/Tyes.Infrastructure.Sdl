namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;
  using Input;

  internal static partial class UnsafeNativeMethods
  {
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlMouseButtonState SDL_GetMouseState (out int x, out int y);

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlMouseButtonState SDL_GetGlobalMouseState (out int x, out int y);
  }
}
