namespace Tyes.Infrastructure.Sdl.Render
{
  using System;

  /// <summary>
  /// Represents flags associated with a SDL renderer.
  /// </summary>
  [Flags]
  public enum SdlRendererFlags
  {
    None = 0x0,
    Software = 0x1,
    Accelerated = 0x2,
    SupportsVSync = 0x4,
    SupportsTextureRendering = 0x8
  }
}
