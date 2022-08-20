namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using System.Runtime.CompilerServices;
  using NUnit.Framework;

  public static class AssertUtility
  {
    public static unsafe void SameReference (void* leftPtr, void* rightPtr)
    {
      Assert.That (leftPtr == rightPtr, "The two references are not the same.");
    }

    public static unsafe void SameReference<T> (in T left, in T right)
    {
      var leftPtr = Unsafe.AsPointer (ref Unsafe.AsRef (in left));
      var rightPtr = Unsafe.AsPointer (ref Unsafe.AsRef (in right));

      Assert.That (leftPtr == rightPtr, "The two references of '{0}' are not the same.", typeof(T));
    }
  }
}
