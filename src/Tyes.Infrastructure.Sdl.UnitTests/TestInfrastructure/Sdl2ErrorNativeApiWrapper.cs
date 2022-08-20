namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using Sdl.Interop;

  public class Sdl2ErrorNativeApiWrapper : SdlNativeApiWrapperBase<ISdl2ErrorApi>, ISdl2ErrorNativeApi
  {
    public Sdl2ErrorNativeApiWrapper (ISdl2ErrorApi innerNativeApi)
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
