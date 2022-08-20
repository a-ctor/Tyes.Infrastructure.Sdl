namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using NativeMock;
  using Sdl.Events;
  using Sdl.Interop;

  [NativeMockInterface ("SDL2", DeclaringType = typeof(UnsafeNativeMethods))]
  internal unsafe partial interface ISdl2EventNativeApi
  {
    SdlEventState SDL_EventState (SdlEventType eventType, SdlEventState eventState);

    void SDL_PumpEvents();

    void SDL_FlushEvent (SdlEventType eventType);

    void SDL_FlushEvents (SdlEventType minEventType, SdlEventType maxEventType);

    SdlIntResult SDL_PeepEvents (
      SdlEvent* buffer,
      int bufferSize,
      SdlPeepEventsAction action,
      SdlEventType minEventType,
      SdlEventType maxEventType);

    SdlBoolResult SDL_PushEvent (in SdlEvent ev);

    SdlBoolResult SDL_PollEvent (out SdlEvent ev);

    SdlBoolResult SDL_HasEvent (SdlEventType eventType);

    SdlBoolResult SDL_HasEvents (SdlEventType minEventType, SdlEventType maxEventType);

    SdlBoolResult SDL_WaitEvent (out SdlEvent ev);

    SdlBoolResult SDL_WaitEventTimeout (out SdlEvent ev, int timeout);
  }
}
