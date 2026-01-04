namespace Tyes.Infrastructure.Sdl.Image
{
  using System.Runtime.InteropServices;
  using Interop;
  using IO;
  using JetBrains.Annotations;
  using Surface;

  internal static class UnsafeNativeMethods
  {
    private const string c_sdlName = "SDL3_image";
    private const CallingConvention c_callingConvention = CallingConvention.Cdecl;

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern ref readonly SdlVersion IMG_Linked_Version();

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlImageInitializationFlags IMG_Init (SdlImageInitializationFlags initializationFlags);

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void IMG_Quit();

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlSurface> IMG_Load_RW (SdlStream stream, [MarshalAs (UnmanagedType.Bool)] bool free);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlSurface> IMG_LoadTyped_RW (SdlStream stream, [MarshalAs (UnmanagedType.Bool)] bool free, SdlString format);
    
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isBMP (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isCUR (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isGIF (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isICO (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isJPG (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isLBM (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isPCX (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isPNG (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isPNM (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isTIF (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isXCF (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isXPM (SdlStream stream);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult IMG_isXV (SdlStream stream);
  }
}
