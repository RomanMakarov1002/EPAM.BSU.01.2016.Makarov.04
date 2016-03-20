using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassHierarchy;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class GeometricFiguresTest
    {
        [TestCase(-1,ExpectedException = typeof(ArgumentException))]
        public void Ellipse_Exception_Test(double radius)
        {
            Ellipse ellipse = new Ellipse(radius);
        }

        [TestCase(0, 1, 2, ExpectedException = typeof (ArgumentException))]
        [TestCase(0, 1, 2, 3, ExpectedException = typeof(ArgumentException))]
        [TestCase(0, 1, ExpectedException = typeof(ArgumentException))]
        public void Triangle_Exception_Test(params double[] sides)
        {
            Triangle triangle = new Triangle(sides);
        }

        [TestCase(0, 1, ExpectedException = typeof (ArgumentException))]
        [TestCase(3, -1, ExpectedException = typeof (ArgumentException))]
        public void Quadrangle_Exception_Test(double a, double b)
        {
            Rectangle rectangle = new Rectangle(a,b);
        }

        [Test]
        public void Ellipse_Test()
        {
            Ellipse ellipse1 = new Ellipse(5);
            Ellipse ellipse2 = new Ellipse(5,8);
            Ellipse ellipse3 = new Ellipse(5,5);
            
            double eps = 0.1;
            List<Ellipse> ellipse = new List<Ellipse> {ellipse1, ellipse2, ellipse3};
            double[] expectedPerimeters = new double[3] {31.416, 41.435, 31.416};
            double[] expectedSquares = new double[3] { 78.539, 125.664, 78.539};
            //foreach (var item in ellipse)
            for (int i=0; i<ellipse.Count; i++)
            {
                Assert.That(ellipse[i].FindPerimeter(),Is.InRange(expectedPerimeters[i]-eps,expectedPerimeters[i]+eps));
                Assert.That(ellipse[i].FindSquare(),Is.InRange(expectedSquares[i]-eps,expectedSquares[i]+eps));
            }
            Assert.AreEqual(true,ellipse3.IsCircle());
               
        }

        [Test]
        public void Triangle_Test()
        {
            Triangle triangle = new Triangle(3,4,5);
            Assert.AreEqual(triangle.FindPerimeter(),12);
            Assert.AreEqual(triangle.FindSquare(), 6);
        }

        [Test]
        public void Quadrangle_Test()
        {
            Square square = new Square(5);
            Assert.AreEqual(25,square.FindSquare());
            Assert.AreEqual(20,square.FindPerimeter());
            Rectangle rectangle1  = new Rectangle(5,5);
            Assert.AreEqual(true,rectangle1.IsSquare());
            Assert.AreEqual(25, rectangle1.FindSquare());
            Assert.AreEqual(20, rectangle1.FindPerimeter());
            Rectangle rectangle = new Rectangle(2,8);
            Assert.AreEqual(20,rectangle.FindPerimeter());
            Assert.AreEqual(16, rectangle.FindSquare());
        }
    }
}
