namespace Tyes.Infrastructure.Sdl.Input;

using System.Runtime.InteropServices;
using Events;

[StructLayout(LayoutKind.Sequential)]
public readonly struct MouseButtonEvent : ISdlEvent
{
  public readonly uint WindowID;
  public readonly uint Which;
  public readonly WrappedEnum<SdlMouseButtons, byte> Button;
  public readonly WrappedEnum<SdlMouseButtonState, byte> State;
  public readonly byte Clicks;
  public readonly int X;
  public readonly int Y;

  /// <inheritdoc />
  public bool CanBeCreatedFromEventOfType(SdlEventType eventType) => eventType is SdlEventType.MouseButtonDown or SdlEventType.MouseButtonUp;

  /// <inheritdoc />
  public override string ToString()
  {
    return $"{nameof(WindowID)}: {WindowID}, {nameof(Which)}: {Which}, {nameof(Button)}: {Button}, {nameof(State)}: {State}, {nameof(Clicks)}: {Clicks}, {nameof(X)}: {X}, {nameof(Y)}: {Y}";
  }
}
