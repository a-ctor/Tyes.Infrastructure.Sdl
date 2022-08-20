namespace Tyes.Infrastructure.Sdl.UnitTests.Events
{
  using System;
  using System.Runtime.CompilerServices;
  using NativeMock;
  using NUnit.Framework;
  using Sdl.Events;
  using Sdl.Interop;
  using TestInfrastructure;

  [TestFixture]
  public unsafe class SdlEventQueueTests : SdlTestBase
  {
    [Test]
    public void GetEventState()
    {
      var eventApiMock = Mock<ISdl2EventNativeApi>();
      eventApiMock.Setup (e => e.SDL_EventState (SdlEventType.UserEvent, (SdlEventState) (-1))).Returns (SdlEventState.Ignore);

      using var eventApiNativeMock = eventApiMock.AsNativeMock();

      Assert.That (SdlEventQueue.GetEventState (SdlEventType.UserEvent), Is.EqualTo (SdlEventState.Ignore));
    }

    [Test]
    public void SetEventState()
    {
      var eventApiMock = Mock<ISdl2EventNativeApi>();
      eventApiMock.Setup (e => e.SDL_EventState (SdlEventType.UserEvent, SdlEventState.Ignore)).Returns (SdlEventState.Ignore);

      using var eventApiNativeMock = eventApiMock.AsNativeMock();

      SdlEventQueue.SetEventState (SdlEventType.UserEvent, SdlEventState.Ignore);
    }

    [Test]
    public void Contains()
    {
      using var eventApiNativeMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiNativeMock.Setup<ISdl2EventNativeApi.SDL_HasEventDelegate> (e => e.SDL_HasEvent, type =>
      {
        Assert.That (type, Is.EqualTo (SdlEventType.UserEvent));

        return new SdlBoolResult (1);
      });

      Assert.That (SdlEventQueue.Contains (SdlEventType.UserEvent), Is.True);
      eventApiNativeMock.Verify();
    }

    [Test]
    public void ContainsBetween()
    {
      using var eventApiNativeMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiNativeMock.Setup<ISdl2EventNativeApi.SDL_HasEventsDelegate> (e => e.SDL_HasEvents, (minEventType, maxEventType) =>
      {
        Assert.That (minEventType, Is.EqualTo (SdlEventType.KeyDown));
        Assert.That (maxEventType, Is.EqualTo (SdlEventType.KeyUp));

        return new SdlBoolResult (1);
      });

      Assert.That (SdlEventQueue.ContainsBetween (SdlEventType.KeyDown, SdlEventType.KeyUp), Is.True);
      eventApiNativeMock.Verify();
    }

    [Test]
    public void RemoveAll_SingleEvent()
    {
      var eventApiMock = Mock<ISdl2EventNativeApi>();
      eventApiMock.Setup (e => e.SDL_FlushEvent (SdlEventType.UserEvent));

      using var eventApiNativeMock = eventApiMock.AsNativeMock();

      SdlEventQueue.RemoveAll (SdlEventType.UserEvent);
    }

    [Test]
    public void RemoveAll_EventRange()
    {
      var eventApiMock = Mock<ISdl2EventNativeApi>();
      eventApiMock.Setup (e => e.SDL_FlushEvents (SdlEventType.JoyDeviceAdded, SdlEventType.JoyDeviceRemoved));

      using var eventApiNativeMock = eventApiMock.AsNativeMock();

      SdlEventQueue.RemoveAll (SdlEventType.JoyDeviceAdded, SdlEventType.JoyDeviceRemoved);
    }

    [Test]
    public void Push_SingleEvent()
    {
      using var eventApiNativeMock = new NativeMock<ISdl2EventNativeApi>();

      SdlEvent sdlEvent = default;
      eventApiNativeMock.Setup<ISdl2EventNativeApi.SDL_PushEventDelegate> (e => e.SDL_PushEvent,
        (in SdlEvent ev) =>
        {
          AssertUtility.SameReference (in sdlEvent, in ev);
          return new SdlBoolResult (1);
        });

      Assert.That (SdlEventQueue.Push (in sdlEvent), Is.True);
      eventApiNativeMock.Verify();
    }

    [Test]
    public void Push()
    {
      Span<SdlEvent> events = stackalloc SdlEvent[2];
      var ptr = Unsafe.AsPointer (ref events[0]);

      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_PeepEventsDelegate> (e => e.SDL_PeepEvents, (buffer, size, action, minEventType, maxEventType) =>
      {
        AssertUtility.SameReference (ptr, buffer);
        Assert.That (size, Is.EqualTo (2));
        Assert.That (action, Is.EqualTo (SdlPeepEventsAction.Add));
        return new SdlIntResult (0);
      });

      SdlEventQueue.Push (events);
      eventApiMock.Verify();
    }

    [Test]
    public void Peek()
    {
      Span<SdlEvent> buffer = stackalloc SdlEvent[2];
      var ptr = Unsafe.AsPointer (ref buffer[0]);

      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_PeepEventsDelegate> (e => e.SDL_PeepEvents, (buffer, size, action, minEventType, maxEventType) =>
      {
        AssertUtility.SameReference (ptr, buffer);
        Assert.That (size, Is.EqualTo (2));
        Assert.That (action, Is.EqualTo (SdlPeepEventsAction.Peek));
        Assert.That (minEventType, Is.EqualTo (SdlEventType.FirstEvent));
        Assert.That (maxEventType, Is.EqualTo (SdlEventType.LastEvent));
        return new SdlIntResult (2);
      });

      Assert.That (SdlEventQueue.Peek (buffer), Is.EqualTo (2));
      eventApiMock.Verify();
    }

    [Test]
    public void Peek_WithEventFilter()
    {
      Span<SdlEvent> buffer = stackalloc SdlEvent[2];
      var ptr = Unsafe.AsPointer (ref buffer[0]);

      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_PeepEventsDelegate> (e => e.SDL_PeepEvents, (buffer, size, action, minEventType, maxEventType) =>
      {
        AssertUtility.SameReference (ptr, buffer);
        Assert.That (size, Is.EqualTo (2));
        Assert.That (action, Is.EqualTo (SdlPeepEventsAction.Peek));
        Assert.That (minEventType, Is.EqualTo (SdlEventType.KeyDown));
        Assert.That (maxEventType, Is.EqualTo (SdlEventType.KeyUp));
        return new SdlIntResult (2);
      });

      Assert.That (SdlEventQueue.Peek (buffer, SdlEventType.KeyDown, SdlEventType.KeyUp), Is.EqualTo (2));
      eventApiMock.Verify();
    }

    [Test]
    public void Get()
    {
      Span<SdlEvent> buffer = stackalloc SdlEvent[2];
      var ptr = Unsafe.AsPointer (ref buffer[0]);

      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_PeepEventsDelegate> (e => e.SDL_PeepEvents, (buffer, size, action, minEventType, maxEventType) =>
      {
        AssertUtility.SameReference (ptr, buffer);
        Assert.That (size, Is.EqualTo (2));
        Assert.That (action, Is.EqualTo (SdlPeepEventsAction.Get));
        Assert.That (minEventType, Is.EqualTo (SdlEventType.FirstEvent));
        Assert.That (maxEventType, Is.EqualTo (SdlEventType.LastEvent));
        return new SdlIntResult (2);
      });

      Assert.That (SdlEventQueue.Get (buffer), Is.EqualTo (2));
      eventApiMock.Verify();
    }

    [Test]
    public void Get_WithEventFilter()
    {
      Span<SdlEvent> buffer = stackalloc SdlEvent[2];
      var ptr = Unsafe.AsPointer (ref buffer[0]);

      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_PeepEventsDelegate> (e => e.SDL_PeepEvents, (buffer, size, action, minEventType, maxEventType) =>
      {
        AssertUtility.SameReference (ptr, buffer);
        Assert.That (size, Is.EqualTo (2));
        Assert.That (action, Is.EqualTo (SdlPeepEventsAction.Get));
        Assert.That (minEventType, Is.EqualTo (SdlEventType.KeyDown));
        Assert.That (maxEventType, Is.EqualTo (SdlEventType.KeyUp));
        return new SdlIntResult (2);
      });

      Assert.That (SdlEventQueue.Get (buffer, SdlEventType.KeyDown, SdlEventType.KeyUp), Is.EqualTo (2));
      eventApiMock.Verify();
    }

    [Test]
    public void Poll()
    {
      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_PollEventDelegate> (e => e.SDL_PollEvent, (out SdlEvent ev) =>
      {
        ev = new SdlEvent();
        Unsafe.AsRef (in ev.Type) = SdlEventType.UserEvent;

        return new SdlBoolResult (1);
      });

      Assert.That (SdlEventQueue.Poll (out var sdlEvent), Is.True);
      Assert.That (sdlEvent.Type, Is.EqualTo (SdlEventType.UserEvent));
      eventApiMock.Verify();
    }

    [Test]
    public void Wait()
    {
      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_WaitEventDelegate> (e => e.SDL_WaitEvent, (out SdlEvent ev) =>
      {
        ev = new SdlEvent();
        Unsafe.AsRef (in ev.Type) = SdlEventType.UserEvent;

        return new SdlBoolResult (1);
      });

      SdlEventQueue.Wait (out var sdlEvent);
      Assert.That (sdlEvent.Type, Is.EqualTo (SdlEventType.UserEvent));
      eventApiMock.Verify();
    }

    [Test]
    public void Wait_WithTimeout()
    {
      using var eventApiMock = new NativeMock<ISdl2EventNativeApi>();
      eventApiMock.Setup<ISdl2EventNativeApi.SDL_WaitEventTimeoutDelegate> (e => e.SDL_WaitEventTimeout, (out SdlEvent ev, int timeoutInMilliseconds) =>
      {
        Assert.That (timeoutInMilliseconds, Is.EqualTo (60_000));

        ev = new SdlEvent();
        Unsafe.AsRef (in ev.Type) = SdlEventType.UserEvent;

        return new SdlBoolResult (1);
      });

      SdlEventQueue.Wait (out var sdlEvent, TimeSpan.FromMinutes (1));
      Assert.That (sdlEvent.Type, Is.EqualTo (SdlEventType.UserEvent));
      eventApiMock.Verify();
    }
  }
}
