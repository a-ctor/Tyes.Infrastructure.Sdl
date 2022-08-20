namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;

  internal static partial class UnsafeNativeMethods
  {
    private const string c_sdlName = "SDL2";
    private const CallingConvention c_callingConvention = CallingConvention.Cdecl;
  }
}
