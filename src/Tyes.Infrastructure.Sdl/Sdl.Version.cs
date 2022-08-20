namespace Tyes.Infrastructure.Sdl
{
  using System;
  using Interop;

  public static partial class Sdl2
  {
    private static string? s_revision;
    private static Version? s_version;

    public static string Revision => s_revision ??= UnsafeNativeMethods.SDL_GetRevision().AsString() ?? string.Empty;

    public static Version Version
    {
      get
      {
        if (s_version != null)
          return s_version;

        UnsafeNativeMethods.SDL_GetVersion (out var sdlVersion);
        var version = sdlVersion.AsVersion (UnsafeNativeMethods.SDL_GetRevisionNumber());
        s_version = version;

        return version;
      }
    }
  }
}
