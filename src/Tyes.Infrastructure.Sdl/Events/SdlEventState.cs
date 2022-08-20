namespace Tyes.Infrastructure.Sdl.Events
{
  /// <summary>
  /// Represents the state of a certain <see cref="SdlEventType" /> in the event queue.
  /// </summary>
  public enum SdlEventState
  {
    /// <summary>
    /// Events will be dropped from the event queue.
    /// </summary>
    Ignore = 0,

    /// <summary>
    /// Events will be processed normally by the event queue.
    /// </summary>
    Enabled = 1
  }
}
