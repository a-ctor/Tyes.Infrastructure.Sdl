namespace Tyes.Infrastructure.Sdl.IO
{
  using System;
  using System.IO;
  using System.Runtime.CompilerServices;
  using System.Runtime.InteropServices;
  using System.Threading.Tasks;

  /// <summary>
  /// A wrapper around a <see cref="Stream"/> that can be used as an SDL_RWops.
  /// Dispose the stream after use.
  /// </summary>
  [StructLayout (LayoutKind.Sequential)]
  public unsafe class SdlStream : IDisposable, IAsyncDisposable
  {
    private static readonly SdlStreamRegistry s_registry = new();

    [UnmanagedCallersOnly (CallConvs = new[] {typeof(CallConvCdecl)})]
    private static long GetSizeCallback (IntPtr ptr)
    {
      return GetStreamFromPtr (ptr)?.Length ?? -1;
    }

    [UnmanagedCallersOnly (CallConvs = new[] {typeof(CallConvCdecl)})]
    private static long SeekCallback (IntPtr ptr, long offset, int seekType)
    {
      var stream = GetStreamFromPtr (ptr);
      if (stream is not {CanSeek: true} || seekType is < 0 or > 2)
        return -1;

      var origin = seekType switch
      {
        0 => SeekOrigin.Begin,
        1 => SeekOrigin.Current,
        2 => SeekOrigin.End,
        _ => throw new ArgumentOutOfRangeException (nameof(seekType), seekType, null)
      };

      return stream.Seek (offset, origin);
    }

    [UnmanagedCallersOnly (CallConvs = new[] {typeof(CallConvCdecl)})]
    private static nint ReadCallback (IntPtr ptr, IntPtr data, nint elementSize, nint elementCount)
    {
      var stream = GetStreamFromPtr (ptr);
      if (stream is not {CanRead: true})
        return 0;

      var length = (int) (elementSize * elementCount);
      var span = new Span<byte> (data.ToPointer(), length);

      return stream.Read (span);
    }

    [UnmanagedCallersOnly (CallConvs = new[] {typeof(CallConvCdecl)})]
    private static nint WriteCallback (IntPtr ptr, IntPtr data, nint elementSize, nint elementCount)
    {
      var stream = GetStreamFromPtr (ptr);
      if (stream is not {CanWrite: true})
        return -1;

      var length = (int) (elementSize * elementCount);
      var span = new Span<byte> (data.ToPointer(), length);

      stream.Write (span);
      return length;
    }

    [UnmanagedCallersOnly (CallConvs = new[] {typeof(CallConvCdecl)})]
    private static int CloseCallback (IntPtr ptr)
    {
      var stream = GetStreamFromPtr (ptr, true);
      if (stream == null)
        return -1;

      stream.Close();
      return 0;
    }

    private static Stream? GetStreamFromPtr (IntPtr ptr, bool remove = false)
    {
      if (ptr == IntPtr.Zero)
        return null;

      var userDataOffset = 5 * sizeof(nint) + sizeof(uint);
      var entry = Unsafe.Read<SdlStreamRegistryEntry> ((byte*) ptr.ToPointer() + userDataOffset);

      return remove
        ? s_registry.UnregisterStream (entry)
        : s_registry.GetRegisteredStream (entry);
    }

    // IMPORTANT: the layout of this class must not change as it mirrors the layout SDL expects
    // ReSharper disable UnusedMember.Local
    private readonly delegate* unmanaged[Cdecl]<IntPtr, long> _sizeCallback = &GetSizeCallback;
    private readonly delegate* unmanaged[Cdecl]<IntPtr, long, int, long> _seekCallback = &SeekCallback;
    private readonly delegate* unmanaged[Cdecl]<IntPtr, IntPtr, nint, nint, nint> _readCallback = &ReadCallback;
    private readonly delegate* unmanaged[Cdecl]<IntPtr, IntPtr, nint, nint, nint> _writeCallback = &WriteCallback;
    private readonly delegate* unmanaged[Cdecl]<IntPtr, int> _closeCallback = &CloseCallback;

    private readonly uint _flags = 0;
    // ReSharper enable UnusedMember.Local

    // User data
    private readonly SdlStreamRegistryEntry _registryEntry;
    private readonly bool _keepOpen;

    public SdlStream (Stream underlyingStream, bool keepOpen)
    {
      if (underlyingStream == null)
        throw new ArgumentNullException (nameof(underlyingStream));

      _registryEntry = s_registry.RegisterStream (underlyingStream);
      _keepOpen = keepOpen;
    }

    /// <inheritdoc />
    public void Dispose()
    {
      var underlyingStream = s_registry.UnregisterStream (_registryEntry);
      if (underlyingStream != null && !_keepOpen)
        underlyingStream.Dispose();
    }

    /// <inheritdoc />
    public ValueTask DisposeAsync()
    {
      return s_registry.UnregisterStream (_registryEntry)?.DisposeAsync() ?? ValueTask.CompletedTask;
    }
  }
}
