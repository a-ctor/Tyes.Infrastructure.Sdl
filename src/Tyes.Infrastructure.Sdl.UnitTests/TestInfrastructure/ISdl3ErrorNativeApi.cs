namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using NativeMock;
  using Sdl.Interop;

  [NativeMockInterface ("SDL3", DeclaringType = typeof(UnsafeNativeMethods))]
  public interface ISdl3ErrorNativeApi
  {
    void SDL_ClearError();

    SdlStr SDL_GetError();

    int SDL_SetError (SdlString lastError);
  }
}
