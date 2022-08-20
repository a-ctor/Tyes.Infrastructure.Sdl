namespace Tyes.Infrastructure.Sdl
{
  using System;
  using Interop;
  using Video;

  public static partial class Sdl2
  {
    public static bool IsScreenSaverEnabled => UnsafeNativeMethods.SDL_IsScreenSaverEnabled();

    public static void DisableScreenSaver() => UnsafeNativeMethods.SDL_DisableScreenSaver().Unwrap();

    public static void EnableScreenSaver() => UnsafeNativeMethods.SDL_EnableScreenSaver().Unwrap();


    public static SdlWindow CreateWindow (string title, int width, int height, WindowFlags flags)
    {
      return CreateWindow (
        title,
        UnsafeNativeMethods.WindowPositionUndefined,
        UnsafeNativeMethods.WindowPositionUndefined,
        width,
        height,
        flags);
    }

    public static SdlWindow CreateCenteredWindow (string title, int width, int height, WindowFlags flags)
    {
      return CreateWindow (
        title,
        UnsafeNativeMethods.WindowPositionCentered,
        UnsafeNativeMethods.WindowPositionCentered,
        width,
        height,
        flags);
    }

    public static SdlWindow CreateWindow (string title, int x, int y, int width, int height, WindowFlags flags)
    {
      SdlWindow window;
      using (var titleSdlString = SdlString.Allocate (title))
      {
        window = UnsafeNativeMethods.SDL_CreateWindow (
          titleSdlString,
          x,
          y,
          width,
          height,
          flags).Unwrap (SdlWindow.Factory);
      }

      return window;
    }

    public static SdlWindow CreateWindowFrom (IntPtr handle)
    {
      var windowHandle = UnsafeNativeMethods.SDL_CreateWindowFrom (handle).Unwrap (SdlWindow.Factory);

      return windowHandle;
    }
  }
}
