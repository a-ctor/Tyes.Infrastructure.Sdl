namespace Tyes.Infrastructure.Sdl.Input
{
  using System;
  using System.Runtime.CompilerServices;

  /// <summary>
  /// Represents the state of mouse, comprising of its position and its button state.
  /// </summary>
  public readonly struct SdlMouseState
  {
    public readonly int X;
    public readonly int Y;
    public readonly SdlMouseButtonState ButtonState;

    public SdlMouseState (int x, int y, SdlMouseButtonState buttonState)
    {
      X = x;
      Y = y;
      ButtonState = buttonState;
    }

    public SdlButtonState GetButtonState (SdlMouseButtons button)
    {
      var mask = button switch
      {
        SdlMouseButtons.Left => SdlMouseButtonState.Left,
        SdlMouseButtons.Middle => SdlMouseButtonState.Middle,
        SdlMouseButtons.Right => SdlMouseButtonState.Right,
        SdlMouseButtons.X1 => SdlMouseButtonState.X1,
        SdlMouseButtons.X2 => SdlMouseButtonState.X2,
        _ => throw new ArgumentOutOfRangeException(nameof(button), button, null)
      };
      
      return (ButtonState & mask) == mask ? SdlButtonState.Pressed : SdlButtonState.Released;
    }
  }
}
