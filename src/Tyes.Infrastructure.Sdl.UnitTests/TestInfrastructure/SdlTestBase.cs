namespace Tyes.Infrastructure.Sdl.UnitTests.TestInfrastructure
{
  using System;
  using System.Collections.Generic;
  using Moq;
  using NUnit.Framework;

  [TestFixture]
  public abstract class SdlTestBase
  {
    private readonly List<Action> _verifications = new();

    protected readonly NativeResourceHelper NativeResourceHelper = new();

    [SetUp]
    public void SetUp()
    {
      _verifications.Clear();
    }

    [TearDown]
    public void TearDown()
    {
      foreach (var verification in _verifications)
        verification();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      NativeResourceHelper.Dispose();
    }

    protected Mock<T> Mock<T>()
      where T : class
    {
      var mock = new Mock<T> (MockBehavior.Strict);
      _verifications.Add (() => mock.VerifyAll());

      return mock;
    }
  }
}
