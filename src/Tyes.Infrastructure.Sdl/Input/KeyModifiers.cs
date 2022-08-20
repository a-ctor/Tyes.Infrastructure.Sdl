namespace Tyes.Infrastructure.Sdl.Input
{
  using System;

  [Flags]
  public enum KeyModifiers
  {
    None = 0x0000,
    LeftShift = 0x0001,
    RightShift = 0x0002,
    LeftControl = 0x0040,
    RightControl = 0x0080,
    LeftAlt = 0x0100,
    RightAlt = 0x0200,
    LeftGui = 0x0400,
    RightGui = 0x0800,
    NumLock = 0x1000,
    CapsLock = 0x2000,

    Shift = LeftShift | RightShift,
    Control = LeftControl | RightControl,
    Alt = LeftAlt | RightAlt,
    Gui = LeftGui | RightGui
  }
}
