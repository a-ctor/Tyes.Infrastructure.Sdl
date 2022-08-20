namespace Tyes.Infrastructure.Sdl.Input
{
  /// <summary>
  /// Represents the different buttons available on most mouses.
  /// </summary>
  public enum SdlMouseButtons
  {
    // Changes to the values also need to be done in SdlMouseButtonState
    Left = 0x0001,
    Middle = 0x0002,
    Right = 0x0004,
    X1 = 0x0008,
    X2 = 0x0010
  }
}
