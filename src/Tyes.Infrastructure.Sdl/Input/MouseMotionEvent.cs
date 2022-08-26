namespace Tyes.Infrastructure.Sdl.Input;

using System.Runtime.InteropServices;
using Events;

[StructLayout(LayoutKind.Sequential)]
public readonly struct MouseMotionEvent : ISdlEvent
{
  public readonly uint WindowID;
  public readonly uint Which;
  public readonly SdlMouseButtonState State;
  public readonly int X;
  public readonly int Y;
  public readonly int RelativeX;
  public readonly int RelativeY;

  /// <inheritdoc />
  public bool CanBeCreatedFromEventOfType(SdlEventType eventType) => eventType == SdlEventType.MouseMotion;

  /// <inheritdoc />
  public override string ToString()
  {
    return $"{nameof(WindowID)}: {WindowID}, {nameof(Which)}: {Which}, {nameof(State)}: {State}, {nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(RelativeX)}: {RelativeX}, {nameof(RelativeY)}: {RelativeY}";
  }
}
