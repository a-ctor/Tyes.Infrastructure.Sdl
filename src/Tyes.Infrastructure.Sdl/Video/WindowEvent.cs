namespace Tyes.Infrastructure.Sdl.Video
{
  using System.Runtime.InteropServices;
  using Events;

  [StructLayout (LayoutKind.Sequential)]
  public readonly struct WindowEvent : ISdlEvent
  {
    public readonly uint WindowID;
    public readonly WindowEventType Type;
    public readonly int Data1;
    public readonly int Data2;

    /// <inheritdoc />
    public bool CanBeCreatedFromEventOfType (SdlEventType eventType) => eventType == SdlEventType.WindowEvent;

    /// <inheritdoc />
    public override string ToString()
    {
      return $"{nameof(WindowID)}: {WindowID}, {nameof(Type)}: {Type}, {nameof(Data1)}: {Data1}, {nameof(Data2)}: {Data2}";
    }
  }
}
