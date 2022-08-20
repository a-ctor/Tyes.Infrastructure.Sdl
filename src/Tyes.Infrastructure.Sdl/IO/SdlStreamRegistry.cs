namespace Tyes.Infrastructure.Sdl.IO
{
  using System;
  using System.IO;

  /// <summary>
  /// Stores the underlying <see cref="Stream" /> objects for <see cref="SdlStream" /> as the classes themselves are passed
  /// to native code and therefore cannot contain managed references.
  /// </summary>
  internal class SdlStreamRegistry
  {
    private struct RegisteredStream
    {
      public readonly int Cookie;
      public readonly Stream? Stream;

      public RegisteredStream (int cookie, Stream? stream)
      {
        Cookie = cookie;
        Stream = stream;
      }
    }

    private readonly object _lock = new();

    private RegisteredStream[] _openStreams = new RegisteredStream[8];
    private int _cookie = 1337; // Arbitrary starting value

    public SdlStreamRegistryEntry RegisterStream (Stream stream)
    {
      if (stream == null)
        throw new ArgumentNullException (nameof(stream));

      int GetNextSlotIndex()
      {
        var i = 0;
        for (; i < _openStreams.Length; i++)
        {
          if (_openStreams[i].Stream == null)
            break;
        }

        return i;
      }

      lock (_lock)
      {
        var slot = GetNextSlotIndex();
        if (slot == _openStreams.Length)
        {
          var expandedArray = new RegisteredStream[_openStreams.Length * 2];
          Array.Copy (_openStreams, expandedArray, _openStreams.Length);
          _openStreams = expandedArray;
        }

        var cookie = _cookie++;
        _openStreams[slot] = new RegisteredStream (cookie, stream);

        return new SdlStreamRegistryEntry (slot, cookie);
      }
    }

    public Stream? GetRegisteredStream (SdlStreamRegistryEntry entry)
    {
      if (entry.Slot < 0 || entry.Slot > _openStreams.Length)
        return null;

      var registeredStream = _openStreams[entry.Slot];
      return registeredStream.Cookie == entry.Cookie ? registeredStream.Stream : null;
    }

    public Stream? UnregisterStream (SdlStreamRegistryEntry entry)
    {
      if (entry.Slot < 0 || entry.Slot > _openStreams.Length)
        throw new ArgumentOutOfRangeException (nameof(entry));

      lock (_lock)
      {
        ref var targetSlot = ref _openStreams[entry.Slot];
        if (targetSlot.Cookie != entry.Cookie)
          return null;

        var stream = targetSlot.Stream;
        targetSlot = default;

        return stream;
      }
    }
  }
}
