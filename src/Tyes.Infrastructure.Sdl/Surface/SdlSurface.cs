namespace Tyes.Infrastructure.Sdl.Surface
{
  using System;
  using System.IO;
  using Interop;
  using IO;

  public class SdlSurface : SdlSafeHandle<SdlSurfaceData>
  {
    public static readonly SdlSafeHandleFactory<SdlSurface> Factory = static ptr => new SdlSurface (ptr);

    public static unsafe SdlSurface LoadBmp (Stream stream, bool keepOpen = false)
    {
      if (stream == null)
        throw new ArgumentNullException (nameof(stream));
      
      using var sdlStream = new SdlStream (stream, keepOpen);

      return UnsafeNativeMethods.SDL_LoadBMP_RW (sdlStream, false).Unwrap (Factory);
    }

    public unsafe int Height => Data->Height;

    public unsafe int Width => Data->Width;

    public SdlSurface()
      : base (true)
    {
    }

    private SdlSurface (IntPtr ptr)
      : base (true)
    {
      handle = ptr;
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
      UnsafeNativeMethods.SDL_FreeSurface (handle);
      return true;
    }
  }
}
