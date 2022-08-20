namespace Tyes.Infrastructure.Sdl.Render
{
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Drawing;
  using Interop;
  using Video;

  [DebuggerDisplay ("{Name}")]
  public class SdlRendererInfo
  {
    public static unsafe IReadOnlyList<SdlRendererInfo> GetRendererInfos()
    {
      var renderDriversCount = UnsafeNativeMethods.SDL_GetNumRenderDrivers().Unwrap();

      SdlRendererInfo[] rendererInfos = new SdlRendererInfo[renderDriversCount];
      for (var i = 0; i < renderDriversCount; i++)
      {
        UnsafeNativeMethods.SDL_GetRenderDriverInfo (i, out var rendererInfo).Unwrap();
        rendererInfos[i] = rendererInfo.CreateFriendly (i);
      }

      return rendererInfos;
    }

    public int Index { get; }

    public string Name { get; }

    public SdlRendererFlags Flags { get; }

    public IReadOnlyList<PixelFormat> TextureFormats { get; }

    public Size MaxTextureDimensions { get; }

    public SdlRendererInfo (int index, string name, SdlRendererFlags flags, IReadOnlyList<PixelFormat> textureFormats, Size maxTextureDimensions)
    {
      Index = index;
      Name = name;
      Flags = flags;
      TextureFormats = textureFormats;
      MaxTextureDimensions = maxTextureDimensions;
    }
  }
}
