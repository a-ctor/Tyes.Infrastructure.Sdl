namespace Tyes.Infrastructure.Sdl.Interop
{
  using System.Runtime.InteropServices;
  using Input;
  using JetBrains.Annotations;

  internal static partial class UnsafeNativeMethods
  {
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern unsafe byte* SDL_GetKeyboardState (out int keyCount);


    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern KeyModifiers SDL_GetModState();

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern void SDL_SetModState (KeyModifiers keyModifiers);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult<KeyCode> SDL_GetKeyFromScancode (ScanCode scanCode);

    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern ScanCode SDL_GetScancodeFromKey (KeyCode keyCode);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlStringResult SDL_GetScancodeName (ScanCode scanCode);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult<ScanCode> SDL_GetScancodeFromName (SdlString name);


    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlStringResult SDL_GetKeyName (KeyCode keyCode);

    [MustUseReturnValue]
    [DllImport (c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlResult<KeyCode> SDL_GetKeyFromName (SdlString name);


    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_StartTextInput();

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    [return: MarshalAs (UnmanagedType.Bool)]
    public static extern SdlResult<bool> SDL_IsTextInputActive();

    [MustUseReturnValue]
    [DllImport(c_sdlName, CallingConvention = c_callingConvention)]
    public static extern SdlVoidResult SDL_StopTextInput();
  }
}
