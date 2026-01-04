namespace Tyes.Infrastructure.Sdl
{
  using Interop;

  public static partial class Sdl
  {
    public static void Initialize (SdlInitializationFlags sdlInitializationFlags) => UnsafeNativeMethods.SDL_Init (sdlInitializationFlags).UnwrapTrue();

    public static void InitializeSubsystem (SdlInitializationFlags sdlInitializationFlags) => UnsafeNativeMethods.SDL_InitSubSystem (sdlInitializationFlags).UnwrapTrue();

    public static void Quit() => UnsafeNativeMethods.SDL_Quit();

    public static void QuitSubsystem (SdlInitializationFlags sdlInitializationFlags) => UnsafeNativeMethods.SDL_QuitSubSystem (sdlInitializationFlags);


    public static SdlInitializationFlags InitializedSubsystems => UnsafeNativeMethods.SDL_WasInit (SdlInitializationFlags.None);

    public static SdlInitializationFlags WasInitialized (SdlInitializationFlags sdlInitializationFlags) => UnsafeNativeMethods.SDL_WasInit (sdlInitializationFlags);
  }
}
