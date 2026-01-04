namespace Tyes.Infrastructure.Sdl
{
  using System;
  using Interop;

  public static partial class Sdl
  {
    private static Version? s_version;

    public static Version Version
    {
      get
      {
        if (s_version != null)
          return s_version;

        UnsafeNativeMethods.SDL_GetVersion (out var sdlVersion);
        var version = sdlVersion.AsVersion();
        s_version = version;

        return version;
      }
    }
  }
}
