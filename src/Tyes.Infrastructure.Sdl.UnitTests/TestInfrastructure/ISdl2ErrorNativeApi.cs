namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using NativeMock;
  using Sdl.Interop;

  [NativeMockInterface ("SDL2", DeclaringType = typeof(UnsafeNativeMethods))]
  public interface ISdl2ErrorNativeApi
  {
    void SDL_ClearError();

    SdlStr SDL_GetError();

    int SDL_SetError (SdlString lastError);
  }
}
