namespace Tyes.Infrastructure.Sdl.Video
{
  using System;

  [Flags]
  public enum WindowFlags
  {
    None = 0,
    Fullscreen = 0x1,

    // ReSharper disable once InconsistentNaming
    OpenGL = 0x2,
    Shown = 0x4,
    Hidden = 0x8,
    Borderless = 0x10,
    Resizeable = 0x20,
    Minimized = 0x40,
    Maximized = 0x80,
    InputGrabbed = 0x100,
    InputFocus = 0x200,
    MouseFocus = 0x400,
    FullscreenDesktop = Fullscreen | 0x1000,
    Foreign = 0x800,

    // ReSharper disable once InconsistentNaming
    AllowHighDPI = 0x2000,
    MouseCapture = 0x4000,
    AlwaysOnTop = 0x8000,
    SkipTaskbar = 0x10000,
    Utility = 0x20000,
    Tooltip = 0x40000,
    PopupMenu = 0x80000,
    Vulkan = 0x10000000
  }
}
