namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;
  using JetBrains.Annotations;
  using Video;

  internal static unsafe partial class UnsafeNativeMethods
  {
    public static readonly int WindowPositionUndefined = 0x1FFF0000;
    public static readonly int WindowPositionCentered = 0x2FFF0000;

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlWindow> SDL_CreateWindow (
      SdlString title,
      int x,
      int y,
      int width,
      int height,
      WindowFlags flags);
    
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlWindow> SDL_CreateWindowFrom (IntPtr windowHandle);

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_DestroyWindow (IntPtr window);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_DisableScreenSaver();

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_EnableScreenSaver();

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    [return: MarshalAs (UnmanagedType.Bool)]
    public static extern bool SDL_IsScreenSaverEnabled();


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowBordered (SdlWindow window, [MarshalAs (UnmanagedType.Bool)] bool hasBorder);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult<float> SDL_GetWindowBrightness (SdlWindow window);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_SetWindowBrightness (SdlWindow window, float brightness);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlIntResult SDL_GetWindowDisplayIndex (SdlWindow window);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_GetWindowDisplayMode (SdlWindow window, out DisplayMode displayMode);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_SetWindowDisplayMode (SdlWindow window, DisplayMode* displayMode);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult<WindowFlags> SDL_GetWindowFlags (SdlWindow window);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_SetWindowFullscreen (SdlWindow window, WindowFlags windowFlags);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowGrab (SdlWindow window, [MarshalAs (UnmanagedType.Bool)] bool grabInput);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlUIntResult SDL_GetWindowID (SdlWindow window);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_GetWindowMaximumSize (SdlWindow window, out int width, out int height);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowMaximumSize (SdlWindow window, int width, int height);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_GetWindowMinimumSize (SdlWindow window, out int width, out int height);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowMinimumSize (SdlWindow window, int width, int height);


    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_GetWindowPosition (SdlWindow window, out int x, out int y);

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowPosition (SdlWindow window, int x, int y);


    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowResizable (SdlWindow window, [MarshalAs (UnmanagedType.Bool)] bool canResize);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_GetWindowSize (SdlWindow window, out int width, out int height);

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowSize (SdlWindow window, int width, int height);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlStringResult SDL_GetWindowTitle (SdlWindow window);

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_SetWindowTitle (SdlWindow window, SdlString title);


    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_HideWindow (SdlWindow window);

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_ShowWindow (SdlWindow window);


    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_MinimizeWindow (SdlWindow window);

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_MaximizeWindow (SdlWindow window);

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_RestoreWindow (SdlWindow window);


    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_RaiseWindow (SdlWindow window);
  }
}
