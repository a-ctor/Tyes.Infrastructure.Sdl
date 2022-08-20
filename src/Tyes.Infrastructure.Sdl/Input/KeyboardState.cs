namespace Tyes.Infrastructure.Sdl.Input
{
  using System;

  public readonly unsafe struct KeyboardState
  {
    private const int c_pressed = 1;

    internal readonly byte* StatePointer;
    internal readonly int Length;

    internal KeyboardState (byte* statePointer, int length)
    {
      if (statePointer == null)
        throw new ArgumentNullException (nameof(statePointer));
      if (length < 0)
        throw new ArgumentOutOfRangeException (nameof(length));

      StatePointer = statePointer;
      Length = length;
    }


    public KeyState GetKeyState (ScanCode scanCode)
    {
      var index = (int) scanCode;
      if (index < 0 || index >= Length)
        throw new ArgumentOutOfRangeException (nameof(scanCode));

      return StatePointer[index] == c_pressed ? KeyState.Pressed : KeyState.Released;
    }


    public bool IsPressed (ScanCode scanCode)
    {
      var index = (int) scanCode;
      if (index < 0 || index >= Length)
        throw new ArgumentOutOfRangeException (nameof(scanCode));

      return StatePointer[index] == c_pressed;
    }

    public bool IsReleased (ScanCode scanCode)
    {
      var index = (int) scanCode;
      if (index < 0 || index >= Length)
        throw new ArgumentOutOfRangeException (nameof(scanCode));

      return StatePointer[index] != c_pressed;
    }
  }
}
