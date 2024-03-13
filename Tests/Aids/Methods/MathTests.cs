
namespace MJ.Tests.Aids.Methods;
[TestClass]
public class MathTests {
    [TestMethod] public void AddTest() {
        Assert.AreEqual(4, MJ.Aids.Methods.Math.Add(2, 2));
        Assert.AreEqual(1, MJ.Aids.Methods.Math.Add(0, 1));
        Assert.AreEqual(0, MJ.Aids.Methods.Math.Add(1, -1));
        Assert.AreEqual(int.MinValue, MJ.Aids.Methods.Math.Add(int.MaxValue, 1));
        Assert.AreEqual(int.MaxValue, MJ.Aids.Methods.Math.Add(int.MaxValue, -1));
    }
    [TestMethod]
    public void SubtractTest() {
        Assert.AreEqual(2, MJ.Aids.Methods.Math.Subtract(4, 2));
        Assert.AreEqual(int.MaxValue, MJ.Aids.Methods.Math.Subtract(int.MinValue, 1));
    }
}

