namespace Tyes.Infrastructure.Sdl.Video
{
  // ReSharper disable InconsistentNaming
  // ReSharper disable IdentifierTypo
  // ReSharper disable ShiftExpressionZeroLeftOperand

  public enum PixelFormat : uint
  {
    Unknown,
    Index1LSB = (1 << 28) | (PixelType.Index1 << 24) | (PixelBitmapOrder._4321 << 20) | (PixelPackedLayout.None << 16) | (1 << 8) | 0,
    Index1MSB = (1 << 28) | (PixelType.Index1 << 24) | (PixelBitmapOrder._1234 << 20) | (PixelPackedLayout.None << 16) | (1 << 8) | 0,
    Index4LSB = (1 << 28) | (PixelType.Index4 << 24) | (PixelBitmapOrder._4321 << 20) | (PixelPackedLayout.None << 16) | (4 << 8) | 0,
    Index4MSB = (1 << 28) | (PixelType.Index4 << 24) | (PixelBitmapOrder._1234 << 20) | (PixelPackedLayout.None << 16) | (4 << 8) | 0,
    Index8 = (1 << 28) | (PixelType.Index8 << 24) | (PixelBitmapOrder.None << 20) | (PixelPackedLayout.None << 16) | (8 << 8) | 1,
    RGB332 = (1 << 28) | (PixelType.Packed8 << 24) | (PixelPackedOrder.XRGB << 20) | (PixelPackedLayout._332 << 16) | (8 << 8) | 1,
    RGB444 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.XRGB << 20) | (PixelPackedLayout._4444 << 16) | (12 << 8) | 2,
    BGR444 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.XBGR << 20) | (PixelPackedLayout._4444 << 16) | (12 << 8) | 2,
    RGB555 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.XRGB << 20) | (PixelPackedLayout._1555 << 16) | (15 << 8) | 2,
    BGR555 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.XBGR << 20) | (PixelPackedLayout._1555 << 16) | (15 << 8) | 2,
    ARGB4444 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.ARGB << 20) | (PixelPackedLayout._4444 << 16) | (16 << 8) | 2,
    RGBA4444 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.RGBA << 20) | (PixelPackedLayout._4444 << 16) | (16 << 8) | 2,
    ABGR4444 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.ABGR << 20) | (PixelPackedLayout._4444 << 16) | (16 << 8) | 2,
    BGRA4444 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.BGRA << 20) | (PixelPackedLayout._4444 << 16) | (16 << 8) | 2,
    ARGB1555 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.ARGB << 20) | (PixelPackedLayout._1555 << 16) | (16 << 8) | 2,
    RGBA5551 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.RGBA << 20) | (PixelPackedLayout._5551 << 16) | (16 << 8) | 2,
    ABGR1555 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.ABGR << 20) | (PixelPackedLayout._1555 << 16) | (16 << 8) | 2,
    BGRA5551 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.BGRA << 20) | (PixelPackedLayout._5551 << 16) | (16 << 8) | 2,
    RGB565 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.XRGB << 20) | (PixelPackedLayout._565 << 16) | (16 << 8) | 2,
    BGR565 = (1 << 28) | (PixelType.Packed16 << 24) | (PixelPackedOrder.XBGR << 20) | (PixelPackedLayout._565 << 16) | (16 << 8) | 2,
    RGB24 = (1 << 28) | (PixelType.ArrayU8 << 24) | (PixelArrayOrder.RGB << 20) | (PixelPackedLayout.None << 16) | (24 << 8) | 3,
    BGR24 = (1 << 28) | (PixelType.ArrayU8 << 24) | (PixelArrayOrder.BGR << 20) | (PixelPackedLayout.None << 16) | (24 << 8) | 3,
    RGB888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.XRGB << 20) | (PixelPackedLayout._8888 << 16) | (24 << 8) | 4,
    RGBX8888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.RGBX << 20) | (PixelPackedLayout._8888 << 16) | (24 << 8) | 4,
    BGR888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.XBGR << 20) | (PixelPackedLayout._8888 << 16) | (24 << 8) | 4,
    BGRX8888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.BGRX << 20) | (PixelPackedLayout._8888 << 16) | (24 << 8) | 4,
    ARGB8888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.ARGB << 20) | (PixelPackedLayout._8888 << 16) | (32 << 8) | 4,
    RGBA8888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.RGBA << 20) | (PixelPackedLayout._8888 << 16) | (32 << 8) | 4,
    ABGR8888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.ABGR << 20) | (PixelPackedLayout._8888 << 16) | (32 << 8) | 4,
    BGRA8888 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.BGRA << 20) | (PixelPackedLayout._8888 << 16) | (32 << 8) | 4,
    ARGB2101010 = (1 << 28) | (PixelType.Packed32 << 24) | (PixelPackedOrder.ARGB << 20) | (PixelPackedLayout._2101010 << 16) | (32 << 8) | 4,
    YV12 = 'Y' | ('V' << 8) | ('1' << 16) | ('2' << 24),
    IYUV = 'I' | ('Y' << 8) | ('U' << 16) | ('V' << 24),
    YUY2 = 'Y' | ('U' << 8) | ('Y' << 16) | ('2' << 24),
    UYVY = 'U' | ('Y' << 8) | ('V' << 16) | ('Y' << 24),
    YVYU = 'Y' | ('V' << 8) | ('Y' << 16) | ('U' << 24),
    NV12 = 'N' | ('V' << 8) | ('1' << 16) | ('2' << 24),
    NV21 = 'N' | ('V' << 8) | ('2' << 16) | ('1' << 24),
    ExternalOES = 'O' | ('E' << 8) | ('S' << 16) | (' ' << 24)
  }
}
