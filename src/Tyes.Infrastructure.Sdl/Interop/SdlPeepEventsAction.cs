namespace Tyes.Infrastructure.Sdl.Interop
{
  /// <summary>
  /// Represents the types of actions done by SDL_PeepEvents.
  /// </summary>
  internal enum SdlPeepEventsAction
  {
    /// <summary>
    /// Adds events to the event queue.
    /// </summary>
    Add,

    /// <summary>
    /// Returns events from the event queue without removing them.
    /// </summary>
    Peek,

    /// <summary>
    /// Returns events from the event queue and removes them.
    /// </summary>
    Get
  }
}
