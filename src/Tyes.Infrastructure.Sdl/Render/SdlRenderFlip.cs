namespace Tyes.Infrastructure.Sdl.Render
{
  using System;

  [Flags]
  public enum SdlRenderFlip
  {
    None = 0b0000,
    Horizontal = 0b0001,
    Vertical = 0b0010,
    Both = Horizontal | Vertical
  }
}
