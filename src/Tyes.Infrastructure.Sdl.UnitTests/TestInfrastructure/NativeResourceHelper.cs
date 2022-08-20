namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using System;
  using System.Collections.Generic;
  using System.Runtime.InteropServices;
  using System.Text;
  using Sdl.Interop;

  public unsafe class NativeResourceHelper : IDisposable
  {
    private readonly List<IntPtr> _unmanagedResources = new();

    public NativeResourceHelper()
    {
    }

    ~NativeResourceHelper()
    {
      Dispose();
    }

    public SdlStr GetString (string? value)
    {
      if (value == null)
        return SdlStr.Null;

      var byteCount = Encoding.UTF8.GetByteCount (value) + 1;

      var allocHGlobal = Marshal.AllocHGlobal (byteCount);
      _unmanagedResources.Add (allocHGlobal);

      var allocSpan = new Span<byte> (allocHGlobal.ToPointer(), byteCount);
      Encoding.UTF8.GetBytes (value, allocSpan);

      allocSpan[byteCount - 1] = 0;

      return new SdlStr (allocHGlobal);
    }

    /// <inheritdoc />
    public void Dispose()
    {
      foreach (var unmanagedResource in _unmanagedResources)
        Marshal.FreeHGlobal (unmanagedResource);
      _unmanagedResources.Clear();

      GC.SuppressFinalize (this);
    }
  }
}
