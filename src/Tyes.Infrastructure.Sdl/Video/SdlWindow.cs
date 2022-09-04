namespace Tyes.Infrastructure.Sdl.Video;

using System.Drawing;
using System.Runtime.InteropServices;
using Interop;
using Render;

public class SdlWindow : SdlSafeHandle
{
  public static readonly SdlSafeHandleFactory<SdlWindow> Factory = ptr => new SdlWindow (ptr);


  public bool IsResizeable
  {
    get => HasFlag (WindowFlags.Resizeable);
    set => UnsafeNativeMethods.SDL_SetWindowResizable (this, value);
  }

  public bool IsBorderless
  {
    get => HasFlag (WindowFlags.Borderless);
    set => UnsafeNativeMethods.SDL_SetWindowBordered (this, value);
  }

  public Point Position
  {
    get
    {
      UnsafeNativeMethods.SDL_GetWindowPosition (this, out var x, out var y);
      return new Point (x, y);
    }
    set => UnsafeNativeMethods.SDL_SetWindowPosition (this, value.X, value.Y);
  }

  public Size Size
  {
    get
    {
      UnsafeNativeMethods.SDL_GetWindowSize (this, out var width, out var height);
      return new Size (width, height);
    }
    set => UnsafeNativeMethods.SDL_SetWindowSize (this, value.Width, value.Width);
  }

  public Size DrawableSize
  {
    get
    {
      UnsafeNativeMethods.SDL_Vulkan_GetDrawableSize (this, out var width, out var height);
      return new Size (width, height);
    }
  }

  public Size MinimumSize
  {
    get
    {
      UnsafeNativeMethods.SDL_GetWindowMinimumSize (this, out var width, out var height);
      return new Size (width, height);
    }
    set => UnsafeNativeMethods.SDL_SetWindowMinimumSize (this, value.Width, value.Width);
  }

  public Size MaximumSize
  {
    get
    {
      UnsafeNativeMethods.SDL_GetWindowMaximumSize (this, out var width, out var height);
      return new Size (width, height);
    }
    set => UnsafeNativeMethods.SDL_SetWindowMaximumSize (this, value.Width, value.Width);
  }

  public string Title
  {
    get => UnsafeNativeMethods.SDL_GetWindowTitle (this).Unwrap ();
    set
    {
      using var title = SdlString.Allocate (value);
      UnsafeNativeMethods.SDL_SetWindowTitle (this, title);
    }
  }

  public float Brightness
  {
    get => UnsafeNativeMethods.SDL_GetWindowBrightness (this).Unwrap ();
    set => UnsafeNativeMethods.SDL_SetWindowBrightness (this, Math.Clamp (value, 0.0f, 1.0f)).Unwrap ();
  }


  public int DisplayIndex => UnsafeNativeMethods.SDL_GetWindowDisplayIndex (this).Unwrap (); // todo belongs to Display

  public unsafe DisplayMode DisplayMode // todo needs corresponding type in Tyes
  {
    get
    {
      UnsafeNativeMethods.SDL_GetWindowDisplayMode (this, out var displayMode).Unwrap ();
      return displayMode;
    }
    set => UnsafeNativeMethods.SDL_SetWindowDisplayMode (this, &value).Unwrap ();
  }

  public WindowFlags Flags => UnsafeNativeMethods.SDL_GetWindowFlags (this).Unwrap ();

  public SdlWindow ()
    : base (true)
  {
  }

  private SdlWindow (IntPtr ptr)
    : base (true)
  {
    handle = ptr;
  }

  /// <inheritdoc />
  protected sealed override bool ReleaseHandle ()
  {
    UnsafeNativeMethods.SDL_DestroyWindow (handle);
    return true;
  }

  /// <summary>
  ///   Creates a renderer using the specified <paramref name="rendererInfo" />.
  /// </summary>
  public SdlRenderer CreateRenderer (SdlRendererInfo rendererInfo)
  {
    return UnsafeNativeMethods.SDL_CreateRenderer (this, rendererInfo.Index, SdlRendererFlags.None).Unwrap (SdlRenderer.Factory);
  }

  /// <summary>
  ///   Creates a renderer using the first renderer that supports the specified <paramref name="rendererFlags" />.
  /// </summary>
  public SdlRenderer CreateRenderer (SdlRendererFlags rendererFlags)
  {
    return UnsafeNativeMethods.SDL_CreateRenderer (this, UnsafeNativeMethods.UnspecifiedRendererInfoIndex, rendererFlags).Unwrap (SdlRenderer.Factory);
  }

  /// <summary>
  ///   Creates a Vulkan surface for this window.
  /// </summary>
  /// <param name="vkInstance"></param>
  /// <returns></returns>
  public IntPtr GetVulkanSurface (IntPtr vkInstance)
  {
    UnsafeNativeMethods.SDL_Vulkan_CreateSurface (this, vkInstance, out var vulkanSurface);
    return vulkanSurface;
  }

  /// <summary>
  ///   Returns all Vulkan extension names which are required when drawing to a surface that was created from this window.
  /// </summary>
  public unsafe string[] GetRequiredVulkanExtensions ()
  {
    if (!UnsafeNativeMethods.SDL_Vulkan_GetInstanceExtensions (this, out var count, IntPtr.Zero))
      throw SdlMarshal.GetSdlExceptionFromLastError ();

    Span<IntPtr> namesPtr = stackalloc IntPtr[(int)count];
    if (!UnsafeNativeMethods.SDL_Vulkan_GetInstanceExtensions (this, out count, ref namesPtr.GetPinnableReference ()))
      throw SdlMarshal.GetSdlExceptionFromLastError ();

    var names = new string[count];
    for (var i = 0; i < namesPtr.Length; i++)
      names[i] = Marshal.PtrToStringAnsi (namesPtr[i]) ?? throw new SdlException ($"Cannot parse names returned by {nameof(UnsafeNativeMethods.SDL_Vulkan_GetInstanceExtensions)}.");

    return names;
  }


  public void Hide ()
  {
    UnsafeNativeMethods.SDL_HideWindow (this);
  }

  public void Show ()
  {
    UnsafeNativeMethods.SDL_ShowWindow (this);
  }

  public void Minimize ()
  {
    UnsafeNativeMethods.SDL_MinimizeWindow (this);
  }

  public void Maximize ()
  {
    UnsafeNativeMethods.SDL_MaximizeWindow (this);
  }

  public void Restore ()
  {
    UnsafeNativeMethods.SDL_RestoreWindow (this);
  }

  public void Raise ()
  {
    UnsafeNativeMethods.SDL_RaiseWindow (this);
  }


  public void DisableFullscreen ()
  {
    UnsafeNativeMethods.SDL_SetWindowFullscreen (this, WindowFlags.None).Unwrap ();
  }

  public void EnableFullscreen ()
  {
    UnsafeNativeMethods.SDL_SetWindowFullscreen (this, WindowFlags.Fullscreen).Unwrap ();
  }

  public void EnableBorderlessFullscreen ()
  {
    UnsafeNativeMethods.SDL_SetWindowFullscreen (this, WindowFlags.FullscreenDesktop).Unwrap ();
  }


  public void DisableInputGrabbing ()
  {
    UnsafeNativeMethods.SDL_SetWindowGrab (this, false);
  }

  public void EnableInputGrabbing ()
  {
    UnsafeNativeMethods.SDL_SetWindowGrab (this, true);
  }


  public bool HasFlag (WindowFlags flag)
  {
    return (Flags & flag) == flag;
  }

  /// <summary>
  ///   Uses the windows dimensions and the desktop's pixel format and refresh rate.
  /// </summary>
  public unsafe void SetDefaultDisplayMode ()
  {
    UnsafeNativeMethods.SDL_SetWindowDisplayMode (this, null).Unwrap ();
  }
}
