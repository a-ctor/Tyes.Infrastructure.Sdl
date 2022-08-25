namespace Tyes.Infrastructure.Sdl.Render
{
  using System;
  using System.Drawing;
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

    public Color ColorMod
    {
      get
      {
        UnsafeNativeMethods.SDL_GetTextureColorMod (this, out var r, out var g, out var b).Unwrap();
        UnsafeNativeMethods.SDL_GetTextureAlphaMod (this, out var a);
        return Color.FromArgb (a, r, g, b);
      }
      set
      {
        UnsafeNativeMethods.SDL_SetTextureColorMod (this, value.R, value.G, value.B).Unwrap();
        UnsafeNativeMethods.SDL_SetTextureAlphaMod (this, value.A).Unwrap();
      }
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
      UnsafeNativeMethods.SDL_DestroyTexture (handle);
      return true;
    }
  }
}
