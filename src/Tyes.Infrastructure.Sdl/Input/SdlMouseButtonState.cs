namespace Tyes.Infrastructure.Sdl.Input
{
  using System;

  /// <summary>
  /// Represents the state (released/pressed) of a mouse's buttons.
  /// </summary>
  [Flags]
  public enum SdlMouseButtonState
  {
    // Changes to the values also need to be done in SdlMouseButtons
    None = 0x0000,
    Left = 0x0001,
    Middle = 0x0002,
    Right = 0x0004,
    X1 = 0x0008,
    X2 = 0x0010,
    All = Left | Middle | Right | X1 | X2
  }
}
