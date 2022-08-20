namespace Tyes.Infrastructure.Sdl
{
  using System;
  using Interop;

  // ReSharper disable ParameterOnlyUsedForPreconditionCheck.Global

  internal static class ArgumentUtility
  {
    internal static void CheckHandleIsOpen<T> (T handle, string parameterName)
      where T : SdlSafeHandle
    {
      if (handle.IsClosed)
        throw new ArgumentException ($"The specified {nameof(T)} handle is already closed.", parameterName);
    }
  }
}
