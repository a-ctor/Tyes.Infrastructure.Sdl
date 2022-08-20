namespace Tyes.Infrastructure.Sdl.Events
{
  using System;
  using Interop;

  /// <summary>
  /// Provides methods for manipulation te SDL event queue.
  /// </summary>
  public static class SdlEventQueue
  {
    /// <summary>
    /// Returns the <see cref="SdlEventState" /> for the specified <paramref name="eventType" />.
    /// </summary>
    public static SdlEventState GetEventState (SdlEventType eventType) => UnsafeNativeMethods.SDL_EventState (eventType, UnsafeNativeMethods.QueryEventState);

    /// <summary>
    /// Sets the <paramref name="eventState" /> for the specified <paramref name="eventType" />.
    /// </summary>
    public static void SetEventState (SdlEventType eventType, SdlEventState eventState) => UnsafeNativeMethods.SDL_EventState (eventType, eventState);

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_HasEvent" />
    public static bool Contains (SdlEventType eventType) => UnsafeNativeMethods.SDL_HasEvent (eventType).UnwrapAmbiguous();

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_HasEvents" />
    public static bool ContainsBetween (SdlEventType minEventType, SdlEventType maxEventType) => UnsafeNativeMethods.SDL_HasEvents (minEventType, maxEventType).UnwrapAmbiguous();

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_FlushEvent" />
    public static void RemoveAll (SdlEventType eventType) => UnsafeNativeMethods.SDL_FlushEvent (eventType);

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_FlushEvents" />
    public static void RemoveAll (SdlEventType minEventType, SdlEventType maxEventType) => UnsafeNativeMethods.SDL_FlushEvents (minEventType, maxEventType);

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_PushEvent" />
    public static bool Push (in SdlEvent ev) => UnsafeNativeMethods.SDL_PushEvent (in ev).Unwrap();

    /// <summary>
    /// Tries to push the specified <paramref name="events" /> onto the event queue.
    /// </summary>
    /// <returns>Returns the number of events pushed onto the event queue.</returns>
    /// <exception cref="SdlException">The specified <paramref name="events" /> could not be pushed.</exception>
    public static unsafe int Push (ReadOnlySpan<SdlEvent> events)
    {
      fixed (SdlEvent* ev = events)
      {
        var result = UnsafeNativeMethods.SDL_PeepEvents (
            ev,
            events.Length,
            SdlPeepEventsAction.Add,
            SdlEventType.FirstEvent,
            SdlEventType.FirstEvent)
          .Unwrap();

        return result;
      }
    }

    /// <summary>
    /// Returns events from the event queue without removing them, filling up <paramref name="buffer" />.
    /// </summary>
    /// <returns>The amount of events that have been put into the provided buffer.</returns>
    /// <exception cref="SdlException">An error occurred while processing the event queue.</exception>
    public static unsafe int Peek (Span<SdlEvent> buffer)
    {
      return Peek (buffer, SdlEventType.FirstEvent, SdlEventType.LastEvent);
    }

    /// <summary>
    /// Returns events with event types between <paramref name="minEventType" /> and <paramref name="maxEventType" /> from the
    /// event queue without removing them, filling up <paramref name="buffer" />.
    /// </summary>
    /// <returns>The amount of events that have been put into the provided buffer.</returns>
    /// <exception cref="SdlException">An error occurred while processing the event queue.</exception>
    public static unsafe int Peek (Span<SdlEvent> buffer, SdlEventType minEventType, SdlEventType maxEventType)
    {
      fixed (SdlEvent* ev = buffer)
      {
        var result = UnsafeNativeMethods.SDL_PeepEvents (
            ev,
            buffer.Length,
            SdlPeepEventsAction.Peek,
            minEventType,
            maxEventType)
          .Unwrap();

        return result;
      }
    }

    /// <summary>
    /// Removes events from the event queue, filling up <paramref name="buffer" />.
    /// </summary>
    /// <returns>The amount of events that have been put into the provided buffer.</returns>
    /// <exception cref="SdlException">An error occurred while processing the event queue.</exception>
    public static unsafe int Get (Span<SdlEvent> buffer)
    {
      return Get (buffer, SdlEventType.FirstEvent, SdlEventType.LastEvent);
    }

    /// <summary>
    /// Removes events with event types between <paramref name="minEventType" /> and <paramref name="maxEventType" /> from the
    /// event queue, filling up <paramref name="buffer" />.
    /// </summary>
    /// <returns>The amount of events that have been put into the provided buffer.</returns>
    /// <exception cref="SdlException">An error occurred while processing the event queue.</exception>
    public static unsafe int Get (Span<SdlEvent> buffer, SdlEventType minEventType, SdlEventType maxEventType)
    {
      fixed (SdlEvent* ev = buffer)
      {
        var result = UnsafeNativeMethods.SDL_PeepEvents (
            ev,
            buffer.Length,
            SdlPeepEventsAction.Get,
            minEventType,
            maxEventType)
          .Unwrap();

        return result;
      }
    }

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_PumpEvents" />
    public static void Pump() => UnsafeNativeMethods.SDL_PumpEvents();

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_PollEvent" />
    public static bool Poll (out SdlEvent ev) => UnsafeNativeMethods.SDL_PollEvent (out ev).UnwrapAmbiguous();

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_WaitEvent" />
    /// <exception cref="SdlException">An error occurred while waiting for new events.</exception>
    public static void Wait (out SdlEvent ev)
    {
      UnsafeNativeMethods.SDL_WaitEvent (out ev).UnwrapTrue();
    }

    /// <inheritdoc cref="UnsafeNativeMethods.SDL_WaitEventTimeout" />
    /// <exception cref="SdlException">An error occurred while waiting for new events.</exception>
    public static bool Wait (out SdlEvent ev, TimeSpan timeout)
    {
      var timeoutInMillisecond = (int) timeout.TotalMilliseconds;
      return UnsafeNativeMethods.SDL_WaitEventTimeout (out ev, timeoutInMillisecond).UnwrapAmbiguous();
    }
  }
}
