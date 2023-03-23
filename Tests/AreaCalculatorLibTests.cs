namespace Tests
{
    /// <summary>
    /// Tests for area calculator library.
    /// </summary>
    [TestClass]
    public class AreaCalculatorLibTests
    {
        /// <summary>
        /// Test for circular shape.
        /// </summary>
        [TestMethod]
        public void TestCircle()
        {
            IShape circle = new Circle(4);

            Assert.AreEqual(50.27, circle.GetArea(2));
        }

        /// <summary>
        /// Test for triangular shape.
        /// </summary>
        [TestMethod]
        public void TestTriangle()
        {
            IShape triangle = new Triangle(5, 2, 4);

            Assert.AreEqual(3.8, triangle.GetArea(2));
        }

        /// <summary>
        /// Test for equilateral triangular shape.
        /// </summary>
        [TestMethod]
        public void TestEquilateralCircle()
        {
            IShape triangle = new Triangle(4);

            Assert.AreEqual(6.93, triangle.GetArea(2));
        }

        /// <summary>
        /// Test for other shape types.
        /// </summary>
        [TestMethod]
        public void TestOtherShapeType()
        {
            IShape shape = new Square(2);

            Assert.AreEqual(4d, shape.GetArea(2));
        }
    }
}