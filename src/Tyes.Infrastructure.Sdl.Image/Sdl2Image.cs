// ReSharper disable InconsistentNaming

namespace Tyes.Infrastructure.Sdl.Image
{
  using System;
  using System.IO;
  using Interop;
  using IO;
  using Surface;

  public static class Sdl2Image
  {
    private static Version? s_version;

    public static Version Version
    {
      get
      {
        if (s_version != null)
          return s_version;

        var version = UnsafeNativeMethods.IMG_Linked_Version().AsVersion();
        s_version = version;

        return version;
      }
    }

    public static void Initialize (SdlImageInitializationFlags initializationFlags)
    {
      if (!TryInitialize (initializationFlags, out _))
        throw new SdlImageException ("SDl Image initialization failed.");
    }

    public static bool TryInitialize (SdlImageInitializationFlags initializationFlags, out SdlImageInitializationFlags initializedImageLoaders)
    {
      initializedImageLoaders = UnsafeNativeMethods.IMG_Init (initializationFlags);
      return (initializedImageLoaders & initializationFlags) != SdlImageInitializationFlags.None;
    }

    public static void Quit() => UnsafeNativeMethods.IMG_Quit();


    public static SdlSurface LoadImage (Stream stream, bool keepOpen)
    {
      if (stream == null)
        throw new ArgumentNullException (nameof(stream));

      using var sdlStream = new SdlStream (stream, keepOpen);

      return UnsafeNativeMethods.IMG_Load_RW (sdlStream, false).Unwrap (SdlSurface.Factory);
    }

    public static SdlSurface LoadImage (Stream stream, bool keepOpen, SdlImageType imageType)
    {
      if (stream == null)
        throw new ArgumentNullException (nameof(stream));

      using var sdlStream = new SdlStream (stream, keepOpen);

      var imageTypeString = imageType switch
      {
        SdlImageType.Bitmap => "BMP",
        SdlImageType.Cursor => "CUR",
        SdlImageType.Gif => "GIF",
        SdlImageType.Icon => "ICO",
        SdlImageType.Jpg => "JPG",
        SdlImageType.Lbm => "LBM",
        SdlImageType.Pcx => "PCX",
        SdlImageType.Png => "PNG",
        SdlImageType.Pnm => "PNM",
        SdlImageType.Tga => "TGA",
        SdlImageType.Tif => "TIF",
        SdlImageType.Xcf => "XCF",
        SdlImageType.Xpm => "XPM",
        SdlImageType.Xv => "XV",
        _ => throw new ArgumentOutOfRangeException (nameof(imageType), imageType, null)
      };

      using var sdlString = SdlString.Allocate (imageTypeString);
      return UnsafeNativeMethods.IMG_LoadTyped_RW (sdlStream, false, sdlString).Unwrap (SdlSurface.Factory);
    }

    public static bool IsBMP (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isBMP (sdlStream).Unwrap();
    }

    public static bool IsCUR (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isCUR (sdlStream).Unwrap();
    }

    public static bool IsGIF (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isGIF (sdlStream).Unwrap();
    }

    public static bool IsICO (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isICO (sdlStream).Unwrap();
    }

    public static bool IsJPG (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isJPG (sdlStream).Unwrap();
    }

    public static bool IsLBM (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isLBM (sdlStream).Unwrap();
    }

    public static bool IsPCX (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isPCX (sdlStream).Unwrap();
    }

    public static bool IsPNG (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isPNG (sdlStream).Unwrap();
    }

    public static bool IsPNM (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isPNM (sdlStream).Unwrap();
    }

    public static bool IsTIF (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isTIF (sdlStream).Unwrap();
    }

    public static bool IsXCF (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isXCF (sdlStream).Unwrap();
    }

    public static bool IsXPM (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isXPM (sdlStream).Unwrap();
    }

    public static bool IsXV (Stream stream, bool keepOpen)
    {
      using var sdlStream = new SdlStream (stream, keepOpen);
      return UnsafeNativeMethods.IMG_isXV (sdlStream).Unwrap();
    }
  }
}
