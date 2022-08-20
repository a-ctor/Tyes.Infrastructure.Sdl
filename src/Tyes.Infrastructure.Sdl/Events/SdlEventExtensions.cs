namespace Tyes.Infrastructure.Sdl.Events
{
  using System;
  using System.Runtime.CompilerServices;

  /// <summary>
  /// Provides methods for converting <see cref="SdlEvent" />s to <see cref="SdlEvent{TDetails}" />.
  /// </summary>
  public static class SdlEventExtensions
  {
    /// <summary>
    /// Converts the specified <paramref name="event" /> into a more concrete <see cref="SdlEvent{TDetails}" />, returning the
    /// result as reference to the specified <paramref name="event" />.
    /// </summary>
    /// <remarks>
    /// This method ensures that specified <paramref name="event" /> can be converted into <typeparamref name="TEvent" />.
    /// To circumvent this check use <see cref="AsUnsafe{TEvent}" />.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// The specified <typeparamref name="TEvent" /> is too big to fit into the
    /// specified <paramref name="event" />.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The specified <paramref name="event" /> cannot be converted into a
    /// <see cref="SdlEvent{TDetails}" /> of <typeparamref name="TEvent" />.
    /// </exception>
    public static unsafe ref readonly SdlEvent<TEvent> As<TEvent> (this in SdlEvent @event)
      where TEvent : unmanaged, ISdlEvent
    {
      if (sizeof(SdlEvent<TEvent>) > sizeof(SdlEvent))
        throw new InvalidOperationException ($"Cannot cast to the event type '{typeof(TEvent)}' as it exceeds the maximum size.");

      ref readonly var specificEvent = ref Unsafe.As<SdlEvent, SdlEvent<TEvent>> (ref Unsafe.AsRef (in @event));

      // ReSharper disable once PossiblyImpureMethodCallOnReadonlyVariable
      // Optimization gets rid of the copy if the struct method is pure
      if (!specificEvent.Details.CanBeCreatedFromEventOfType (specificEvent.Type))
        throw new InvalidOperationException ($"The event type '{specificEvent.Type}' is not valid for '{typeof(TEvent)}'.");

      return ref specificEvent;
    }

    /// <summary>
    /// Converts the specified <paramref name="event" /> into a more concrete <see cref="SdlEvent{TDetails}" /> without safety
    /// checks, returning the result as reference to the specified <paramref name="event" />.
    /// </summary>
    /// <remarks>
    /// Always use <see cref="As{TEvent}" /> if you are not sure that a successful conversion to the event is guaranteed.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// The specified <typeparamref name="TEvent" /> is too big to fit into the
    /// specified <paramref name="event" />.
    /// </exception>
    public static unsafe ref readonly SdlEvent<TEvent> AsUnsafe<TEvent> (this in SdlEvent @event)
      where TEvent : unmanaged, ISdlEvent
    {
      if (sizeof(SdlEvent<TEvent>) > sizeof(SdlEvent))
        throw new InvalidOperationException ($"Cannot cast to the event type '{typeof(TEvent)}' as it exceeds the maximum size.");

      return ref Unsafe.As<SdlEvent, SdlEvent<TEvent>> (ref Unsafe.AsRef (in @event));
    }
  }
}
