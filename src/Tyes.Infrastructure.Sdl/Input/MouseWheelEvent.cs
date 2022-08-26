namespace Tyes.Infrastructure.Sdl.Input;

using System.Runtime.InteropServices;
using Events;

[StructLayout(LayoutKind.Sequential)]
public readonly struct MouseWheelEvent : ISdlEvent
{
  public readonly uint WindowID;
  public readonly uint Which;
  public readonly int X;
  public readonly int Y;
  public readonly uint Direction;
  public readonly float PreciseX;
  public readonly float PreciseY;

  /// <inheritdoc />
  public bool CanBeCreatedFromEventOfType(SdlEventType eventType) => eventType == SdlEventType.Mousewheel;

  /// <inheritdoc />
  public override string ToString()
  {
    return $"{nameof(WindowID)}: {WindowID}, {nameof(Which)}: {Which}, {nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Direction)}: {Direction}, {nameof(PreciseX)}: {PreciseX}, {nameof(PreciseY)}: {PreciseY}";
  }
}
