namespace Tyes.Infrastructure.Sdl.Events
{
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents the common portion of an SDL event.
  /// </summary>
  /// <remarks>
  /// Accessing the event-specific details requires a conversion to corresponding <see cref="SdlEvent{TDetails}" /> according
  /// to the <see cref="Type" /> using <see cref="SdlEventExtensions.As{TEvent}" />.
  /// </remarks>
  [StructLayout (LayoutKind.Sequential, Size = Size)]
  public readonly struct SdlEvent
  {
    public const int Size = 56;

    public readonly SdlEventType Type;
    public readonly uint Timestamp;

    /// <inheritdoc />
    public override string ToString()
    {
      return $"{nameof(Type)}: {Type}, {nameof(Timestamp)}: {Timestamp}";
    }
  }

  /// <summary>
  /// Represents a SDL event with details of type <typeparamref name="TDetails" />.
  /// </summary>
  /// <typeparam name="TDetails">The event-specific details.</typeparam>
  [StructLayout (LayoutKind.Sequential, Size = SdlEvent.Size)]
  public readonly struct SdlEvent<TDetails>
    where TDetails : unmanaged, ISdlEvent
  {
    public readonly SdlEventType Type;
    public readonly uint Timestamp;
    public readonly TDetails Details;

    /// <inheritdoc />
    public override string ToString()
    {
      return $"{nameof(Type)}: {Type}, {nameof(Timestamp)}: {Timestamp}, {nameof(Details)}: {Details}";
    }
  }
}
