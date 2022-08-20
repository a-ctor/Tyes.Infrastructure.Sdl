namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  public interface ISdl2ErrorApi
  {
    void SDL_ClearError();

    string? SDL_GetError();

    int SDL_SetError (string? lastError);
  }
}
