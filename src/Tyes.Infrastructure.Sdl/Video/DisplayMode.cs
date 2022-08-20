namespace Tyes.Infrastructure.Sdl.Video
{
  public readonly struct DisplayMode
  {
    public readonly PixelFormat PixelFormat;
    public readonly int Width;
    public readonly int Height;
    public readonly int RefreshRate;
    public readonly nint DriverData;

    public DisplayMode (PixelFormat pixelFormat, int width, int height, int refreshRate)
      : this (pixelFormat, width, height, refreshRate, default)
    {
    }

    public DisplayMode (PixelFormat pixelFormat, int width, int height, int refreshRate, nint driverData)
    {
      PixelFormat = pixelFormat;
      Width = width;
      Height = height;
      RefreshRate = refreshRate;
      DriverData = driverData;
    }
  }
}
