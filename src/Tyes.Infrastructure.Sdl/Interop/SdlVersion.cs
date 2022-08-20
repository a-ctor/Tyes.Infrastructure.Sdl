namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;

  public readonly struct SdlVersion
  {
    public readonly byte Major;
    public readonly byte Minor;
    public readonly byte Patch;

    public SdlVersion (byte major, byte minor, byte patch)
    {
      Major = major;
      Minor = minor;
      Patch = patch;
    }

    public Version AsVersion (int revision = 0)
    {
      return new Version (Major, Minor, Patch, revision);
    }
  }
}
