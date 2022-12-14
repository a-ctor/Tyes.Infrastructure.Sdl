namespace Tyes.Infrastructure.Sdl.Input
{
  public enum KeyCode
  {
    Unknown = 0,

    Return = '\r',
    Escape = '\x1B',
    Backspace = '\b',
    Tab = '\t',
    Space = ' ',

    A = 'a',
    B = 'b',
    C = 'c',
    D = 'd',
    E = 'e',
    F = 'f',
    G = 'g',
    H = 'h',
    I = 'i',
    J = 'j',
    K = 'k',
    L = 'l',
    M = 'm',
    N = 'n',
    O = 'o',
    P = 'p',
    Q = 'q',
    R = 'r',
    S = 's',
    T = 't',
    U = 'u',
    V = 'v',
    W = 'w',
    X = 'x',
    Y = 'y',
    Z = 'z',

    ExclamationMark = '!',
    DoubleQuotationMark = '"',
    SingleQuotationMark = '\'',
    Hash = '#',
    Percent = '%',
    DollarSign = '$',
    Ampersand = '&',

    LeftParenthesis = '(',
    RightParenthesis = ')',
    LeftBrace = '<',
    RightBrace = '>',
    LeftBracket = '[',
    RightBracket = ']',

    Asterisk = '*',
    Plus = '+',
    Hyphen = '-',
    Slash = '/',

    Period = '.',
    Comma = ',',
    Colon = ':',
    Semicolon = ';',
    Equals = '=',
    QuestionMark = '?',
    AtSign = '@',
    Backslash = '\\',
    Caret = '^',
    Underscore = '_',
    GraveAccent = '`',

    Number1 = '1',
    Number2 = '2',
    Number3 = '3',
    Number4 = '4',
    Number5 = '5',
    Number6 = '6',
    Number7 = '7',
    Number8 = '8',
    Number9 = '9',
    Number0 = '0',

    CapsLock = ScanCode.CapsLock | Keyboard.ScanCodeMask,

    F1 = ScanCode.F1 | Keyboard.ScanCodeMask,
    F2 = ScanCode.F2 | Keyboard.ScanCodeMask,
    F3 = ScanCode.F3 | Keyboard.ScanCodeMask,
    F4 = ScanCode.F4 | Keyboard.ScanCodeMask,
    F5 = ScanCode.F5 | Keyboard.ScanCodeMask,
    F6 = ScanCode.F6 | Keyboard.ScanCodeMask,
    F7 = ScanCode.F7 | Keyboard.ScanCodeMask,
    F8 = ScanCode.F8 | Keyboard.ScanCodeMask,
    F9 = ScanCode.F9 | Keyboard.ScanCodeMask,
    F10 = ScanCode.F10 | Keyboard.ScanCodeMask,
    F11 = ScanCode.F11 | Keyboard.ScanCodeMask,
    F12 = ScanCode.F12 | Keyboard.ScanCodeMask,

    PrintScreen = ScanCode.PrintScreen | Keyboard.ScanCodeMask,
    ScrollLock = ScanCode.ScrollLock | Keyboard.ScanCodeMask,
    Pause = ScanCode.Pause | Keyboard.ScanCodeMask,
    Insert = ScanCode.Insert | Keyboard.ScanCodeMask,
    Home = ScanCode.Home | Keyboard.ScanCodeMask,
    PageUp = ScanCode.PageUp | Keyboard.ScanCodeMask,
    Delete = ScanCode.Delete | Keyboard.ScanCodeMask,
    End = ScanCode.End | Keyboard.ScanCodeMask,
    PageDown = ScanCode.PageDown | Keyboard.ScanCodeMask,
    Right = ScanCode.Right | Keyboard.ScanCodeMask,
    Left = ScanCode.Left | Keyboard.ScanCodeMask,
    Down = ScanCode.Down | Keyboard.ScanCodeMask,
    Up = ScanCode.Up | Keyboard.ScanCodeMask,

    NumLockClear = ScanCode.NumLockClear | Keyboard.ScanCodeMask,
    KeypadDivide = ScanCode.KeypadDivide | Keyboard.ScanCodeMask,
    KeypadMultiply = ScanCode.KeypadMultiply | Keyboard.ScanCodeMask,
    KeypadMinus = ScanCode.KeypadMinus | Keyboard.ScanCodeMask,
    KeypadPlus = ScanCode.KeypadPlus | Keyboard.ScanCodeMask,
    KeypadEnter = ScanCode.KeypadEnter | Keyboard.ScanCodeMask,
    KeypadPeriod = ScanCode.KeypadPeriod | Keyboard.ScanCodeMask,

    Keypad1 = ScanCode.Keypad1 | Keyboard.ScanCodeMask,
    Keypad2 = ScanCode.Keypad2 | Keyboard.ScanCodeMask,
    Keypad3 = ScanCode.Keypad3 | Keyboard.ScanCodeMask,
    Keypad4 = ScanCode.Keypad4 | Keyboard.ScanCodeMask,
    Keypad5 = ScanCode.Keypad5 | Keyboard.ScanCodeMask,
    Keypad6 = ScanCode.Keypad6 | Keyboard.ScanCodeMask,
    Keypad7 = ScanCode.Keypad7 | Keyboard.ScanCodeMask,
    Keypad8 = ScanCode.Keypad8 | Keyboard.ScanCodeMask,
    Keypad9 = ScanCode.Keypad9 | Keyboard.ScanCodeMask,
    Keypad0 = ScanCode.Keypad0 | Keyboard.ScanCodeMask

    // todo add missing key codes (also add to scan codes)
  }
}
