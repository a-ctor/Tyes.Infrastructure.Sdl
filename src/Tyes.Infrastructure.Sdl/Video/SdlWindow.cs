namespace Tyes.Infrastructure.Sdl.Video
{
  using System;
  using System.Drawing;
  using Interop;
  using Render;

  public class SdlWindow : SdlSafeHandle
  {
    public static readonly SdlSafeHandleFactory<SdlWindow> Factory = ptr => new SdlWindow (ptr);

    public SdlWindow()
      : base (true)
    {
    }

    private SdlWindow (IntPtr ptr)
      : base (true)
    {
      handle = ptr;
    }

    /// <inheritdoc />
    protected sealed override bool ReleaseHandle()
    {
      UnsafeNativeMethods.SDL_DestroyWindow (handle);
      return true;
    }


    public bool IsResizeable
    {
      get => HasFlag (WindowFlags.Resizeable);
      set => UnsafeNativeMethods.SDL_SetWindowResizable (this, value).Unwrap();
    }

    public bool IsBorderless
    {
      get => HasFlag (WindowFlags.Borderless);
      set => UnsafeNativeMethods.SDL_SetWindowBordered (this, value).Unwrap();
    }

    public Point Position
    {
      get
      {
        UnsafeNativeMethods.SDL_GetWindowPosition (this, out var x, out var y).Unwrap();
        return new Point (x, y);
      }
      set => UnsafeNativeMethods.SDL_SetWindowPosition (this, value.X, value.Y).Unwrap();
    }

    public Size Size
    {
      get
      {
        UnsafeNativeMethods.SDL_GetWindowSize (this, out var width, out var height).Unwrap();
        return new Size (width, height);
      }
      set => UnsafeNativeMethods.SDL_SetWindowSize (this, value.Width, value.Width).Unwrap();
    }

    public Size MinimumSize
    {
      get
      {
        UnsafeNativeMethods.SDL_GetWindowMinimumSize (this, out var width, out var height).Unwrap();
        return new Size (width, height);
      }
      set => UnsafeNativeMethods.SDL_SetWindowMinimumSize (this, value.Width, value.Width).Unwrap();
    }

    public Size MaximumSize
    {
      get
      {
        UnsafeNativeMethods.SDL_GetWindowMaximumSize (this, out var width, out var height).Unwrap();
        return new Size (width, height);
      }
      set => UnsafeNativeMethods.SDL_SetWindowMaximumSize (this, value.Width, value.Width).Unwrap();
    }

    public string Title
    {
      get => UnsafeNativeMethods.SDL_GetWindowTitle (this).Unwrap();
      set
      {
        using var title = SdlString.Allocate (value);
        UnsafeNativeMethods.SDL_SetWindowTitle (this, title).Unwrap();
      }
    }

    public float Brightness
    {
      get => UnsafeNativeMethods.SDL_GetWindowBrightness (this).Unwrap();
      set => UnsafeNativeMethods.SDL_SetWindowBrightness (this, Math.Clamp (value, 0.0f, 1.0f)).Unwrap();
    }


    public int DisplayIndex => UnsafeNativeMethods.SDL_GetWindowDisplayIndex (this).Unwrap(); // todo belongs to Display

    public unsafe DisplayMode DisplayMode // todo needs corresponding type in Tyes
    {
      get
      {
        UnsafeNativeMethods.SDL_GetWindowDisplayMode (this, out var displayMode).Unwrap();
        return displayMode;
      }
      set => UnsafeNativeMethods.SDL_SetWindowDisplayMode (this, &value).Unwrap();
    }

    public WindowFlags Flags => UnsafeNativeMethods.SDL_GetWindowFlags (this).Unwrap();

    /// <summary>
    /// Creates a renderer using the specified <paramref name="rendererInfo" />.
    /// </summary>
    public SdlRenderer CreateRenderer (SdlRendererInfo rendererInfo)
    {
      return UnsafeNativeMethods.SDL_CreateRenderer (this, rendererInfo.Index, SdlRendererFlags.None).Unwrap (SdlRenderer.Factory);
    }

    /// <summary>
    /// Creates a renderer using the first renderer that supports the specified <paramref name="rendererFlags" />.
    /// </summary>
    public SdlRenderer CreateRenderer (SdlRendererFlags rendererFlags)
    {
      return UnsafeNativeMethods.SDL_CreateRenderer (this, UnsafeNativeMethods.UnspecifiedRendererInfoIndex, rendererFlags).Unwrap (SdlRenderer.Factory);
    }

    public void Hide() => UnsafeNativeMethods.SDL_HideWindow (this).Unwrap();

    public void Show() => UnsafeNativeMethods.SDL_ShowWindow (this).Unwrap();

    public void Minimize() => UnsafeNativeMethods.SDL_MinimizeWindow (this).Unwrap();

    public void Maximize() => UnsafeNativeMethods.SDL_MaximizeWindow (this).Unwrap();

    public void Restore() => UnsafeNativeMethods.SDL_RestoreWindow (this).Unwrap();

    public void Raise() => UnsafeNativeMethods.SDL_RaiseWindow (this).Unwrap();


    public void DisableFullscreen() => UnsafeNativeMethods.SDL_SetWindowFullscreen (this, WindowFlags.None).Unwrap();

    public void EnableFullscreen() => UnsafeNativeMethods.SDL_SetWindowFullscreen (this, WindowFlags.Fullscreen).Unwrap();

    public void EnableBorderlessFullscreen() => UnsafeNativeMethods.SDL_SetWindowFullscreen (this, WindowFlags.FullscreenDesktop).Unwrap();


    public void DisableInputGrabbing() => UnsafeNativeMethods.SDL_SetWindowGrab (this, false).Unwrap();

    public void EnableInputGrabbing() => UnsafeNativeMethods.SDL_SetWindowGrab (this, true).Unwrap();


    public bool HasFlag (WindowFlags flag)
    {
      return (Flags & flag) == flag;
    }

    /// <summary>
    /// Uses the windows dimensions and the desktop's pixel format and refresh rate.
    /// </summary>
    public unsafe void SetDefaultDisplayMode() => UnsafeNativeMethods.SDL_SetWindowDisplayMode (this, null).Unwrap();
  }
}
