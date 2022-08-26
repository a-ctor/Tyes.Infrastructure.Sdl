namespace Tyes.Infrastructure.Sdl.Events;

using System.Numerics;
using System.Runtime.CompilerServices;

public readonly struct WrappedEnum<TEnum, TData>
  where TEnum : Enum
  where TData : INumber<TData>, IConvertible
{
  private static readonly Type s_enumUnderlyingType = Enum.GetUnderlyingType(typeof(TEnum));

  private readonly TData _rawValue;

  public TData RawValue => _rawValue;

  public WrappedEnum(TData rawValue)
  {
    _rawValue = rawValue;
  }

  public TEnum Value
  {
    get
    {
      if (s_enumUnderlyingType == typeof(int))
      {
        var source = _rawValue.ToInt32(null);
        return Unsafe.As<int, TEnum>(ref source);
      }

      return (TEnum)Convert.ChangeType(_rawValue, s_enumUnderlyingType);
    }
  }
}
