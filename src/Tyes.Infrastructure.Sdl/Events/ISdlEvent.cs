namespace Tyes.Infrastructure.Sdl.Events
{
  /// <summary>
  /// Marker interface for all SDL events structures.
  /// </summary>
  public interface ISdlEvent
  {
    /// <summary>
    /// Returns <see langword="true" /> if an instance of the current event structure could be created from a
    /// <see cref="SdlEvent" /> with the specified <paramref name="eventType" />.
    /// </summary>
    /// <remarks>
    /// This method should be pure and "static", but because interfaces cannot (yet) have static members it must be an instance
    /// method.
    /// </remarks>
    bool CanBeCreatedFromEventOfType (SdlEventType eventType);
  }
}
