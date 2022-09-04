namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;
  using JetBrains.Annotations;
  using Video;

  internal static partial class UnsafeNativeMethods
  {
    /// <returns><c>0</c> on success, negative on failure. Use <c>SDL_GetError</c> for more information.</returns>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_Init (SdlInitializationFlags sdlInitializationFlags);

    /// <returns><c>0</c> on success, negative on failure. Use <c>SDL_GetError</c> for more information.</returns>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_InitSubSystem (SdlInitializationFlags sdlInitializationFlags);


    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_Quit();

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_QuitSubSystem (SdlInitializationFlags sdlInitializationFlags);


    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlInitializationFlags SDL_WasInit (SdlInitializationFlags sdlInitializationFlags);

    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern bool SDL_Vulkan_GetInstanceExtensions(SdlWindow window, out uint count, ref IntPtr names);

    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern bool SDL_Vulkan_GetInstanceExtensions(SdlWindow window, out uint count, IntPtr names);
  }
}
