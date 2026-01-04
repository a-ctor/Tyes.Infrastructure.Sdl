namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  internal static partial class UnsafeNativeMethods
  {
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_GetVersion (out SdlVersion version);
  }
}
