namespace Tyes.Infrastructure.Sdl
{
  using System;

  [Flags]
  public enum SdlInitializationFlags : uint
  {
    None = 0x0u,
    Timer = 0x1u,
    Audio = 0x10u,
    Video = 0x20u,
    Joystick = 0x200u,
    Haptic = 0x1000u,
    GameController = 0x2000u,
    Events = 0x4000u,
    Sensor = 0x8000u,
    Everything = Timer | Audio | Video | Joystick | Haptic | GameController | Events | Sensor
  }
}
