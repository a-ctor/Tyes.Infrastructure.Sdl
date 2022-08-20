namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents a pointer to an immutable owned SDL string (a null-terminated UTF-8 string).
  /// </summary>
  public ref struct SdlString
  {
    public static SdlString Null => new (IntPtr.Zero);

    public static SdlString Allocate (string? s)
    {
      var ptr = Marshal.StringToCoTaskMemUTF8 (s);
      return new SdlString (ptr);
    }

    private readonly IntPtr _ptr;

    public unsafe bool IsEmpty => IsNull || *(byte*) _ptr == 0;

    public bool IsNull => _ptr == IntPtr.Zero;

    private SdlString (IntPtr ptr)
    {
      _ptr = ptr;
    }

    public string? AsString()
    {
      return Marshal.PtrToStringUTF8 (_ptr);
    }

    public void Dispose()
    {
      Marshal.FreeCoTaskMem (_ptr);
    }

    /// <inheritdoc />
    public override string ToString()
    {
      return AsString() ?? string.Empty;
    }
  }
}
