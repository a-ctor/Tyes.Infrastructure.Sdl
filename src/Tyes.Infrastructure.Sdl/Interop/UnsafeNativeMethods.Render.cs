namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;
  using System.Drawing;
  using System.Runtime.InteropServices;
  using JetBrains.Annotations;
  using Render;
  using Surface;
  using Video;

  internal static partial class UnsafeNativeMethods
  {
    [StructLayout (LayoutKind.Sequential)]
    public unsafe struct RendererInfo
    {
      private const int c_maxTextureFormatCount = 16;

      private readonly byte* _name;
      private readonly SdlRendererFlags _flags;
      private readonly int _textureFormatsCount;
      private fixed uint _textureFormats[c_maxTextureFormatCount];
      private readonly int _maximumTextureWidth;
      private readonly int _maximumTextureHeight;

      public SdlRendererInfo CreateFriendly (int index)
      {
        var name = SdlMarshal.PtrToSdlString (_name);

        var textureFormatsCount = Math.Clamp (_textureFormatsCount, 0, c_maxTextureFormatCount);
        var textureFormats = new PixelFormat[textureFormatsCount];
        for (var i = 0; i < textureFormats.Length; i++)
          textureFormats[i] = (PixelFormat) _textureFormats[i];

        return new SdlRendererInfo (
          index,
          name ?? string.Empty,
          _flags,
          textureFormats,
          new Size (_maximumTextureWidth, _maximumTextureHeight));
      }
    }

    /// <summary>
    /// Returns the numbers of 2D rendering drivers that are available.
    /// </summary>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlIntResult SDL_GetNumRenderDrivers();

    /// <summary>
    /// Returns information about the renderer driver specified by <paramref name="index" />.
    /// </summary>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_GetRenderDriverInfo (int index, out RendererInfo rendererInfo);


    public const int UnspecifiedRendererInfoIndex = -1;

    /// <summary>
    /// Creates a SDL renderer for the specified <paramref name="window" /> using the renderer driver with the specified
    /// <paramref name="index" />.
    /// </summary>
    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlRenderer> SDL_CreateRenderer (SdlWindow window, int index, SdlRendererFlags flags);

    /// <summary>
    /// Destroys the specified SDL <paramref name="renderer" />.
    /// </summary>
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_DestroyRenderer (IntPtr renderer);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_GetRenderDrawColor (SdlRenderer renderer, out byte r, out byte g, out byte b, out byte a);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_SetRenderDrawColor (SdlRenderer renderer, byte r, byte g, byte b, byte a);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderClear (SdlRenderer renderer);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderDrawLine (SdlRenderer renderer, int x1, int y1, int x2, int y2);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderDrawLineF (SdlRenderer renderer, float x1, float y1, float x2, float y2);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderDrawLines (SdlRenderer renderer, Point* points, int pointCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderDrawLinesF (SdlRenderer renderer, PointF* points, int pointCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderDrawPoint (SdlRenderer renderer, int x, int y);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderDrawPointF (SdlRenderer renderer, float x, float y);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderDrawPoints (SdlRenderer renderer, Point* points, int pointCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderDrawPointsF (SdlRenderer renderer, PointF* points, int pointCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderDrawRect (SdlRenderer renderer, in Rectangle rectangle);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderDrawRectF (SdlRenderer renderer, in RectangleF rectangle);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderDrawRects (SdlRenderer renderer, Rectangle* rectangles, int rectangleCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderDrawRectsF (SdlRenderer renderer, RectangleF* rectangles, int rectangleCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderFillRect (SdlRenderer renderer, in Rectangle rectangle);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderFillRectF (SdlRenderer renderer, in RectangleF rectangle);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderFillRects (SdlRenderer renderer, Rectangle* rectangles, int rectangleCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe SdlResult SDL_RenderFillRectsF (SdlRenderer renderer, RectangleF* rectangles, int rectangleCount);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderPresent (SdlRenderer renderer);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlHandleResult<SdlTexture> SDL_CreateTextureFromSurface (SdlRenderer renderer, SdlSurface surface);

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_DestroyTexture (IntPtr texture);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderCopy (SdlRenderer renderer, SdlTexture texture, in Rectangle src, in Rectangle dst);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderCopyF (SdlRenderer renderer, SdlTexture texture, in Rectangle src, in RectangleF dst);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderCopyEx (SdlRenderer renderer, SdlTexture texture, in Rectangle src, in Rectangle dst, double angle, in Point center, SdlRenderFlip flip);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult SDL_RenderCopyExF (SdlRenderer renderer, SdlTexture texture, in Rectangle src, in RectangleF dst, double angle, in PointF center, SdlRenderFlip flip);
  }
}
