namespace Tyes.Infrastructure.Sdl.Image
{
  using System;

  [Flags]
  public enum SdlImageInitializationFlags
  {
    None = 0x00,
    Jpg = 0x01,
    Png = 0x02,
    Tif = 0x04,
    Webp = 0x08
  }
}
