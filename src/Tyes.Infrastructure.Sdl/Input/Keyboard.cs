namespace Tyes.Infrastructure.Sdl.Input
{
  using Interop;

  public static class Keyboard
  {
    internal const int ScanCodeMask = 1 << 30;

    /// <summary>
    /// Gets or sets the key modifiers that are reported to the application using keyboard events.
    /// </summary>
    /// <remarks>
    /// The modifiers might change when SDL handles events.
    /// </remarks>
    public static KeyModifiers KeyModifiers
    {
      get => UnsafeNativeMethods.SDL_GetModState();
      set => UnsafeNativeMethods.SDL_SetModState (value);
    }

    private static KeyboardState s_state;

    /// <remarks>
    /// The returned <see cref="KeyboardState"/> structure always queries the latest keyboard state.
    /// The keyboard state might change when SDL handles events.
    /// </remarks>
    public static unsafe KeyboardState State
    {
      get
      {
        if (s_state.StatePointer != null)
          return s_state;

        var statePtr = UnsafeNativeMethods.SDL_GetKeyboardState (out var keyCount);
        s_state = new KeyboardState (statePtr, keyCount);

        return s_state;
      }
    }


    /// <summary>
    /// Returns the <see cref="KeyCode"/> with the specified name.
    /// </summary>
    /// <returns>Returns <see cref="KeyCode.Unknown"/> if no scan code with the specified name could be found.</returns>
    public static KeyCode GetKeyCodeFromName (string name)
    {
      using var nameSdlString = SdlString.Allocate (name);
      return UnsafeNativeMethods.SDL_GetKeyFromName (nameSdlString).Unwrap();
    }

    /// <summary>
    /// Returns the <see cref="ScanCode"/> with the specified name.
    /// </summary>
    /// <returns>Returns <see cref="ScanCode.Unknown"/> if no scan code with the specified name could be found.</returns>
    public static ScanCode GetScanCodeFromName (string name)
    {
      using var nameSdlString = SdlString.Allocate (name);
      return UnsafeNativeMethods.SDL_GetScancodeFromName (nameSdlString).Unwrap();
    }


    public static bool IsTextInputActive => UnsafeNativeMethods.SDL_IsTextInputActive().Unwrap();

    public static void StartTextInput()
    {
      UnsafeNativeMethods.SDL_StartTextInput();
    }

    public static void StopTextInput()
    {
      UnsafeNativeMethods.SDL_StopTextInput();
    }
  }
}
