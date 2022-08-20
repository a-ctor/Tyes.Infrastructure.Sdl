namespace Tyes.Infrastructure.Sdl.Render
{
  using System;
  using Interop;

  public class SdlTexture : SdlSafeHandle
  {
    public static readonly SdlSafeHandleFactory<SdlTexture> Factory = static ptr => new SdlTexture (ptr);

    public SdlTexture()
      : base (true)
    {
    }

    private SdlTexture (IntPtr ptr)
      : base (true)
    {
      handle = ptr;
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
      UnsafeNativeMethods.SDL_DestroyTexture (handle);
      return true;
    }
  }
}
