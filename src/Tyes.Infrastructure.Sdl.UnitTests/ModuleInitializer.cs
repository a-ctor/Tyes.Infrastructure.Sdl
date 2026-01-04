namespace Tyes.Infrastructure.Sdl.UnitTests
{
  using System.Runtime.CompilerServices;
  using NativeMock;

  public static class ModuleInitializer
  {
    [ModuleInitializer]
    public static void Initialize()
    {
      NativeLibraryDummy.Load ("SDL3");

      NativeMockRegistry.Initialize();
      NativeMockRegistry.RegisterFromAssembly (typeof(ModuleInitializer).Assembly);
    }
  }
}
