namespace Tyes.Infrastructure.Sdl.Render
{
  using System;
  using System.Drawing;
  using System.Runtime.CompilerServices;
  using Interop;
  using Surface;

  public class SdlRenderer : SdlSafeHandle
  {
    public static readonly SdlSafeHandleFactory<SdlRenderer> Factory = ptr => new SdlRenderer (ptr);

    /// <inheritdoc />
    public SdlRenderer()
      : base (true)
    {
    }

    private SdlRenderer (IntPtr ptr)
      : base (true)
    {
      handle = ptr;
    }

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
      UnsafeNativeMethods.SDL_DestroyRenderer (handle);
      return true;
    }

    public Color RenderDrawColor
    {
      get
      {
        UnsafeNativeMethods.SDL_GetRenderDrawColor (
            this,
            out var r,
            out var g,
            out var b,
            out var a)
          .Unwrap();

        return Color.FromArgb (a, r, g, b);
      }
      set
      {
        UnsafeNativeMethods.SDL_SetRenderDrawColor (
            this,
            value.R,
            value.G,
            value.B,
            value.A)
          .Unwrap();
      }
    }


    public SdlTexture CreateTextureFromSurface (SdlSurface surface)
    {
      return UnsafeNativeMethods.SDL_CreateTextureFromSurface (this, surface).Unwrap (SdlTexture.Factory);
    }


    public void Clear() => UnsafeNativeMethods.SDL_RenderClear (this).Unwrap();

    public void DrawLine (Point from, Point to) => UnsafeNativeMethods.SDL_RenderDrawLine (this, from.X, from.Y, to.X, to.Y).Unwrap();
    
    public void DrawLine (PointF from, PointF to) => UnsafeNativeMethods.SDL_RenderDrawLineF (this, from.X, from.Y, to.X, to.Y).Unwrap();

    public unsafe void DrawLine (Span<Point> points)
    {
      fixed (Point* ptr = points)
        UnsafeNativeMethods.SDL_RenderDrawLines (this, ptr, points.Length).Unwrap();
    }

    public unsafe void DrawLine (Span<PointF> points)
    {
      fixed (PointF* ptr = points)
        UnsafeNativeMethods.SDL_RenderDrawLinesF (this, ptr, points.Length).Unwrap();
    }

    public void DrawPoint (Point point) => UnsafeNativeMethods.SDL_RenderDrawPoint (this, point.X, point.Y).Unwrap();

    public void DrawPoint (PointF point) => UnsafeNativeMethods.SDL_RenderDrawPointF (this, point.X, point.Y).Unwrap();

    public unsafe void DrawPoints (Span<Point> points)
    {
      fixed (Point* ptr = points)
        UnsafeNativeMethods.SDL_RenderDrawPoints (this, ptr, points.Length).Unwrap();
    }

    public unsafe void DrawPoints (Span<PointF> points)
    {
      fixed (PointF* ptr = points)
        UnsafeNativeMethods.SDL_RenderDrawPointsF (this, ptr, points.Length).Unwrap();
    }

    public void DrawRectangle (Rectangle rectangle) => UnsafeNativeMethods.SDL_RenderDrawRect (this, rectangle).Unwrap();

    public void DrawRectangle (RectangleF rectangle) => UnsafeNativeMethods.SDL_RenderDrawRectF (this, rectangle).Unwrap();

    public unsafe void DrawRectangles (Span<Rectangle> rectangles)
    {
      fixed (Rectangle* ptr = rectangles)
        UnsafeNativeMethods.SDL_RenderDrawRects (this, ptr, rectangles.Length).Unwrap();
    }

    public unsafe void DrawRectangles (Span<RectangleF> rectangles)
    {
      fixed (RectangleF* ptr = rectangles)
        UnsafeNativeMethods.SDL_RenderDrawRectsF (this, ptr, rectangles.Length).Unwrap();
    }

    public void DrawFilledRectangle (Rectangle rectangle) => UnsafeNativeMethods.SDL_RenderFillRect (this, rectangle).Unwrap();

    public void DrawFilledRectangle (RectangleF rectangle) => UnsafeNativeMethods.SDL_RenderFillRectF (this, rectangle).Unwrap();
    
    public unsafe void DrawFilledRectangles (Span<Rectangle> rectangles)
    {
      fixed (Rectangle* ptr = rectangles)
        UnsafeNativeMethods.SDL_RenderFillRects (this, ptr, rectangles.Length).Unwrap();
    }
    
    public unsafe void DrawFilledRectangles (Span<RectangleF> rectangles)
    {
      fixed (RectangleF* ptr = rectangles)
        UnsafeNativeMethods.SDL_RenderFillRectsF (this, ptr, rectangles.Length).Unwrap();
    }

    public void Present() => UnsafeNativeMethods.SDL_RenderPresent (this).UnwrapTrue();

    public void Draw (SdlTexture texture, in Rectangle source, Point destination)
    {
      var destinationRectangle = new Rectangle (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopy (this, texture, in source, in destinationRectangle).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, PointF destination)
    {
      var destinationRectangle = new RectangleF (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyF (this, texture, in source, in destinationRectangle).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, Point destination, double angle)
    {
      var destinationRectangle = new Rectangle (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destinationRectangle, angle, in Unsafe.NullRef<Point>(), SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, PointF destination, double angle)
    {
      var destinationRectangle = new RectangleF (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destinationRectangle, angle, in Unsafe.NullRef<PointF>(), SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, Point destination, double angle, Point center)
    {
      var destinationRectangle = new Rectangle (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destinationRectangle, angle, in center, SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, PointF destination, double angle, PointF center)
    {
      var destinationRectangle = new RectangleF (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destinationRectangle, angle, in center, SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, Point destination, double angle, SdlRenderFlip flip)
    {
      var destinationRectangle = new Rectangle (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destinationRectangle, angle, in Unsafe.NullRef<Point>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, PointF destination, double angle, SdlRenderFlip flip)
    {
      var destinationRectangle = new RectangleF (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destinationRectangle, angle, in Unsafe.NullRef<PointF>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, Point destination, SdlRenderFlip flip)
    {
      var destinationRectangle = new Rectangle (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destinationRectangle, 0, in Unsafe.NullRef<Point>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, PointF destination, SdlRenderFlip flip)
    {
      var destinationRectangle = new RectangleF (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destinationRectangle, 0, in Unsafe.NullRef<PointF>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, Point destination, double angle, Point center, SdlRenderFlip flip)
    {
      var destinationRectangle = new Rectangle (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destinationRectangle, angle, in center, flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, PointF destination, double angle, PointF center, SdlRenderFlip flip)
    {
      var destinationRectangle = new RectangleF (destination, source.Size);
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destinationRectangle, angle, in center, flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in Rectangle destination)
    {
      UnsafeNativeMethods.SDL_RenderCopy (this, texture, in source, in destination).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in RectangleF destination)
    {
      UnsafeNativeMethods.SDL_RenderCopyF (this, texture, in source, in destination).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in Rectangle destination, double angle)
    {
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destination, angle, in Unsafe.NullRef<Point>(), SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in RectangleF destination, double angle)
    {
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destination, angle, in Unsafe.NullRef<PointF>(), SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in Rectangle destination, double angle, Point center)
    {
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destination, angle, in center, SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in RectangleF destination, double angle, PointF center)
    {
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destination, angle, in center, SdlRenderFlip.None).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in Rectangle destination, double angle, SdlRenderFlip flip)
    {
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destination, angle, in Unsafe.NullRef<Point>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in RectangleF destination, double angle, SdlRenderFlip flip)
    {
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destination, angle, in Unsafe.NullRef<PointF>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in Rectangle destination, SdlRenderFlip flip)
    {
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destination, 0, in Unsafe.NullRef<Point>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in RectangleF destination, SdlRenderFlip flip)
    {
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destination, 0, in Unsafe.NullRef<PointF>(), flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in Rectangle destination, double angle, Point center, SdlRenderFlip flip)
    {
      UnsafeNativeMethods.SDL_RenderCopyEx (this, texture, in source, in destination, angle, in center, flip).Unwrap();
    }

    public void Draw (SdlTexture texture, in Rectangle source, in RectangleF destination, double angle, PointF center, SdlRenderFlip flip)
    {
      UnsafeNativeMethods.SDL_RenderCopyExF (this, texture, in source, in destination, angle, in center, flip).Unwrap();
    }
  }
}
