namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;
  using IO;
  using JetBrains.Annotations;
  using Surface;

  internal static unsafe partial class UnsafeNativeMethods
  {
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlSurface> SDL_LoadBMP_RW (SdlStream stream, [MarshalAs (UnmanagedType.Bool)] bool free);

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_FreeSurface (IntPtr handle);
  }
}
