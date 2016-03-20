using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public abstract class GeometricFigures
    {
        protected double[] Sides;
        protected const double eps = 0.00001;
        protected GeometricFigures(params double[] sides)
        {
            for (int i=0; i < sides.Length; i++)
                if (sides[i]<=0)
                    throw new ArgumentException("All sides must be positive");
            Sides = sides;
        }

        protected GeometricFigures()
        {
        }

        public abstract double FindSquare();

        public abstract double FindPerimeter();
    }


    public class Ellipse : GeometricFigures
    {
        public double Radius { get ; }
        public double HigherRadius { get; }

        public Ellipse(double radius)
        {
            if (radius > 0)
            {
                Radius = radius;
                HigherRadius = radius;
            }
            else 
                throw new ArgumentException("Radius must be positive");
        }

        public Ellipse(double radius1, double radius2)
        {
            if (radius1 > 0 && radius2 > 0)
            {
                Radius = radius1;
                HigherRadius = radius2;
            }
            else
                throw  new ArgumentException("Radius must be positive");
        }

        public bool IsCircle()
        {
            return Math.Abs(Radius - HigherRadius) < eps;
        }

        public override double FindSquare()
        {
            return Math.PI*Radius*HigherRadius;
        }

        public override double FindPerimeter()
        { 
            return 4*(Math.PI*HigherRadius*Radius + (Math.Pow(HigherRadius - Radius, 2)))/(HigherRadius + Radius);
        }
    }


    public class Triangle : GeometricFigures
    {
        public Triangle(params double[] sides) :base (sides)
        {
            if (sides.Length!=3)
                throw new ArgumentException("Triangle has only 3 sides");            
        }

        public override double FindSquare()
        {
            double p = FindPerimeter()/2;
            return Math.Sqrt(p*(p - Sides[0])*(p - Sides[1])*(p - Sides[2]));
        }

        public override double FindPerimeter()
        {
            return Sides.Sum();
        }
    }

    public abstract class Quadrangle : GeometricFigures
    {
        protected Quadrangle(params double[] sides) : base(sides)
        {            
        }

        public override double FindPerimeter()
        {
            return Sides.Sum();
        }

        public override double FindSquare()
        {
            return Sides[0]*Sides[1];
        }
    }

    public class Square : Quadrangle
    {
        public double Side { get; }
        public Square(double side) : base(side, side, side, side)
        {
            Side = side;
        }
    }

    public class Rectangle : Quadrangle
    {
        public double LowerSide { get; }
        public double HigherSide { get; }
        public Rectangle(double lowerSide, double higherSide) : base(lowerSide, higherSide, lowerSide, higherSide)
        {
            LowerSide = lowerSide;
            HigherSide = higherSide;
        }

        public bool IsSquare()
        {
            return Math.Abs(Sides[0] - Sides[1]) < eps;
        }

    }


}
