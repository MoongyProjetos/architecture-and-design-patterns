using Microsoft.Extensions.DependencyModel;

namespace teste;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        //arrange
        var ex = lib.Class1.Metodo();
        //act

        //assert
        Assert.IsNotNull(ex);
    }
}
