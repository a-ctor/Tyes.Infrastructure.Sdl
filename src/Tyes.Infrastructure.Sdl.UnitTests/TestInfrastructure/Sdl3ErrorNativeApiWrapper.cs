namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using Sdl.Interop;

  public class Sdl3ErrorNativeApiWrapper : SdlNativeApiWrapperBase<ISdl3ErrorApi>, ISdl3ErrorNativeApi
  {
    public Sdl3ErrorNativeApiWrapper (ISdl3ErrorApi innerNativeApi)
      : base (innerNativeApi)
    {
    }

    /// <inheritdoc />
    public void SDL_ClearError()
    {
      Inner.SDL_ClearError();
    }

    /// <inheritdoc />
    public SdlStr SDL_GetError()
    {
      return NativeResourceHelper.GetString (Inner.SDL_GetError());
    }

    /// <inheritdoc />
    public int SDL_SetError (SdlString lastError)
    {
      return Inner.SDL_SetError (lastError.AsString());
    }
  }
}
