namespace Tyes.Infrastructure.Sdl.Interop
{
  using System;

  public delegate T SdlSafeHandleFactory<out T> (IntPtr ptr)
    where T : SdlSafeHandle;
}
