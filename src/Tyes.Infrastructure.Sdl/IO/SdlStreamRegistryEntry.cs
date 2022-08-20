namespace Tyes.Infrastructure.Sdl.IO
{
  /// <summary>
  /// Represents an entry in the <see cref="SdlStreamRegistry"/> that can be passed to native code.
  /// </summary>
  internal readonly struct SdlStreamRegistryEntry
  {
    public readonly int Slot;
    public readonly int Cookie;

    public SdlStreamRegistryEntry (int slot, int cookie)
    {
      Slot = slot;
      Cookie = cookie;
    }
  }
}
