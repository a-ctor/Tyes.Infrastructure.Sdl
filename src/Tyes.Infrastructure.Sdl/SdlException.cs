namespace Tyes.Infrastructure.Sdl
{
  using System;

  public class SdlException : Exception
  {
    /// <inheritdoc />
    public SdlException (string? message)
      : base (message)
    {
    }

    /// <inheritdoc />
    public SdlException (string? message, Exception innerException)
      : base (message, innerException)
    {
    }
  }
}
