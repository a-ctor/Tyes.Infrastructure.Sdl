namespace Tyes.Infrastructure.Sdl.Surface
{
  using System;
  using System.Drawing;
  using System.Runtime.InteropServices;

  [StructLayout (LayoutKind.Sequential)]
  public readonly struct SdlSurfaceData
  {
    public readonly uint Flags;
    public readonly IntPtr Format;
    public readonly int Width;
    public readonly int Height;
    public readonly int Pitch;
    public readonly IntPtr Pixels;
    public readonly IntPtr UserData;
    private readonly int _locked;
    private readonly IntPtr _lockData;
    public readonly Rectangle ClippingRectangle;
    private readonly IntPtr _blitMap;
    public readonly int RefCount;
  }
}
