namespace Tyes.Infrastructure.Sdl.Input
{
  using System.Runtime.InteropServices;
  using Events;

  [StructLayout (LayoutKind.Sequential)]
  public readonly struct KeyboardEvent : ISdlEvent
  {
    public readonly uint WindowID;
    public readonly byte State;
    public readonly byte Repeat;
    public readonly ScanCode ScanCode;
    public readonly KeyCode KeyCode;
    public readonly ushort Modifier;

    /// <inheritdoc />
    public bool CanBeCreatedFromEventOfType (SdlEventType eventType) => eventType == SdlEventType.KeyDown || eventType == SdlEventType.KeyUp;

    /// <inheritdoc />
    public override string ToString()
    {
      return $"{nameof(WindowID)}: {WindowID}, {nameof(State)}: {State}, {nameof(Repeat)}: {Repeat}, {nameof(ScanCode)}: {ScanCode}, {nameof(KeyCode)}: {KeyCode}, {nameof(Modifier)}: {Modifier}";
    }
  }
}
