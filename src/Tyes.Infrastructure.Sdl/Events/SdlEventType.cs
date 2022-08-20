namespace Tyes.Infrastructure.Sdl.Events
{
  /// <summary>
  /// Specifies different types of <see cref="SdlEvent" />s.
  /// </summary>
  public enum SdlEventType : uint
  {
    // Do not remove since this is needed as a marker for the lowest allowed value
    FirstEvent = 0x00,
    Quit = 0x100,
    AppTerminating,
    AppLowMemory,
    AppWillEnterBackground,
    AppDidEnterBackground,
    AppWillEnterForeground,
    AppDidEnterForeground,
    DisplayEvent = 0x150,
    WindowEvent = 0x200,
    SyswmEvent,
    KeyDown = 0x300,
    KeyUp,
    TextEditing,
    TextInput,
    KeyMapChanged,
    MouseMotion = 0x400,
    MouseButtonDown,
    MouseButtonUp,
    Mousewheel,
    JoyAxisMotion = 0x600,
    JoyBallMotion,
    JoyHatMotion,
    JoyButtonDown,
    JoyButtonUp,
    JoyDeviceAdded,
    JoyDeviceRemoved,
    ControllerAxisMotion = 0x650,
    ControllerButtonDown,
    ControllerButtonUp,
    ControllerDeviceAdded,
    ControllerDeviceRemoved,
    FingerDown = 0x700,
    FingerUp,
    FingerMotion,
    DollarGesture = 0x800,
    DollarRecord,
    MultiGesture,
    ClipboardUpdate = 0x900,
    DropFile = 0x1000,
    DropText,
    DropBegin,
    DropComplete,
    AudioDeviceAdded = 0x1100,
    AudioDeviceRemoved,
    SensorUpdate = 0x1200,
    RenderTargetsReset = 0x2000,
    RenderDeviceReset,
    UserEvent = 0x8000,

    // Do not remove since this is needed as a marker for the highest allowed value
    LastEvent = 0xffff
  }
}
