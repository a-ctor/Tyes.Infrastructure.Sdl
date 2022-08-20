namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// Represents a pointer to an immutable unowned SDL string (a null-terminated UTF-8 string).
  /// </summary>
  public readonly ref struct SdlStr
  {
    public static SdlStr Null => new (IntPtr.Zero);

    private readonly IntPtr _ptr;

    public unsafe bool IsEmpty => IsNull || *(byte*) _ptr == 0;

    public bool IsNull => _ptr == IntPtr.Zero;

    // For unit testing purposes
    internal IntPtr Ptr => _ptr;

    public SdlStr (IntPtr ptr)
    {
      _ptr = ptr;
    }

    public string? AsString() => Marshal.PtrToStringUTF8 (_ptr);

    /// <inheritdoc />
    public override string ToString()
    {
      return AsString() ?? string.Empty;
    }
  }
}
