namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;
  using Events;
  using JetBrains.Annotations;

  internal static partial class UnsafeNativeMethods
  {
    /// <summary>
    /// Special <see cref="SdlEventState" /> used to query an event state.
    /// </summary>
    public const SdlEventState QueryEventState = (SdlEventState) (-1);

    /// <summary>
    /// Gets or sets the <see cref="SdlEventState" /> for the <paramref name="eventType" />.
    /// </summary>
    /// <param name="eventType">The <see cref="SdlEventType" /> to get/set.</param>
    /// <param name="eventState">
    /// The <see cref="SdlEventState" /> to set, or the special <see cref="QueryEventState" /> value
    /// to query the current event state.
    /// </param>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlEventState SDL_EventState (SdlEventType eventType, SdlEventState eventState);


    /// <summary>
    /// Updates the internal event queue by polling input devices.
    /// </summary>
    /// <remarks>
    /// Only call on main thread.
    /// </remarks>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_PumpEvents();

    /// <summary>
    /// Removes all events on the event queue with the specified <paramref name="eventType" />.
    /// </summary>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_FlushEvent (SdlEventType eventType);

    /// <summary>
    /// Removes all events on the event queue between the specified <paramref name="minEventType" /> and
    /// <paramref name="maxEventType" />.
    /// </summary>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_FlushEvents (SdlEventType minEventType, SdlEventType maxEventType);

    /// <summary>
    /// Allows adding/peeking/removing certain events from the event queue.
    /// </summary>
    /// <param name="buffer">A buffer for the events that are to be added/peeked/removed.</param>
    /// <param name="bufferSize">The size of the specified <paramref name="buffer" /></param>
    /// <param name="action">The type of action that should be taken.</param>
    /// <param name="minEventType">
    /// The minimum event type to peek/remove. Ignored when <paramref name="action" /> is
    /// <see cref="SdlPeepEventsAction.Add" />.
    /// </param>
    /// <param name="maxEventType">
    /// The maximum event type to peek/remove. Ignored when <paramref name="action" /> is
    /// <see cref="SdlPeepEventsAction.Add" />.
    /// </param>
    /// <returns></returns>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlIntResult SDL_PeepEvents (
      SdlEvent* buffer,
      int bufferSize,
      SdlPeepEventsAction action,
      SdlEventType minEventType,
      SdlEventType maxEventType);

    /// <summary>
    /// Pushes the specified event <paramref name="ev" /> onto the event queue.
    /// </summary>
    /// <returns>Returns <see langword="true" /> if successful, <see langword="false" /> otherwise.</returns>
    /// <remarks>
    /// This function is thread-safe.
    /// A common error reason is the event queue being full.
    /// </remarks>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult SDL_PushEvent (in SdlEvent ev);

    /// <summary>
    /// Removes the next event from the event queue.
    /// </summary>
    /// <remarks>
    /// Can only be called from the thread that initialized the video subsystem.
    /// </remarks>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult SDL_PollEvent (out SdlEvent ev);


    /// <summary>
    /// Returns <see langword="true" /> if an event with the specified <paramref name="eventType" /> is in the event queue,
    /// otherwise returns <see langword="false" />.
    /// </summary>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult SDL_HasEvent (SdlEventType eventType);

    /// <summary>
    /// Returns <see langword="true" /> if an event within <paramref name="minEventType" /> and
    /// <paramref name="maxEventType" /> is in the event queue, otherwise returns <see langword="false" />.
    /// </summary>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult SDL_HasEvents (SdlEventType minEventType, SdlEventType maxEventType);

    /// <summary>
    /// Waits until the next available event is pushed onto the event queue.
    /// </summary>
    /// <remarks>
    /// Can only be called from the thread that initialized the video subsystem.
    /// </remarks>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult SDL_WaitEvent (out SdlEvent ev);

    /// <summary>
    /// Waits until the next available event is pushed onto the event queue or the specified <paramref name="timeout" /> is
    /// reached.
    /// </summary>
    /// <remarks>
    /// Can only be called from the thread that initialized the video subsystem.
    /// </remarks>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlBoolResult SDL_WaitEventTimeout (out SdlEvent ev, int timeout);
  }
}
