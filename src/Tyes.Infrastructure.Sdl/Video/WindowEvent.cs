namespace Tyes.Infrastructure.Sdl.Video
{
  using System.Runtime.InteropServices;
  using Events;

  [StructLayout (LayoutKind.Explicit)]
  public readonly struct WindowEvent : ISdlEvent
  {
    [FieldOffset (0)] public readonly uint WindowID;

    [FieldOffset (4)] public readonly WindowEventType Type;

    [FieldOffset (8)] public readonly int Data1;

    [FieldOffset (12)] public readonly int Data2;

    /// <inheritdoc />
    public bool CanBeCreatedFromEventOfType (SdlEventType eventType) => eventType == SdlEventType.WindowEvent;
  }
}
