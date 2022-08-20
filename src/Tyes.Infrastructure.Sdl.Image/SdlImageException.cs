namespace Tyes.Infrastructure.Sdl.Image
{
  using System;

  public class SdlImageException : Exception
  {
    /// <inheritdoc />
    public SdlImageException (string? message)
      : base (message)
    {
    }

    /// <inheritdoc />
    public SdlImageException (string? message, Exception innerException)
      : base (message, innerException)
    {
    }
  }
}
