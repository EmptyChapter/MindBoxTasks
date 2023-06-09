﻿namespace AreaCalculator.Models
{
    /// <summary>
    /// Represents a triangle shape.
    /// </summary>
    public class Triangle : IShape
    {
        #region Auto Properties

        /// <summary>
        /// Gets or sets the first side of the triangle.
        /// </summary>
        public double Side1 { get; set; }

        /// <summary>
        /// Gets or sets the second side of the triangle.
        /// </summary>
        public double Side2 { get; set; }

        /// <summary>
        /// Gets or sets the third side of the triangle.
        /// </summary>
        public double Side3 { get; set; }

        /// <summary>
        /// Gets indication of whether or not triangle is equilateral
        /// </summary>
        public bool IsEquilateral =>
            Side1 == Side2 && Side2 == Side3;

        /// <summary>
        /// Gets indication of whether or not triangle is right.
        /// </summary>
        public bool IsRight
        {
            get
            {
                var legs = GetLegs();
                var hyp  = GetHypotenuse();

                var sum  = legs.Select(s => Math.Pow(s, 2)).Sum();

                // Pythagorean theorem
                return hyp == Math.Sqrt(sum);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of equilateral <see cref="Triangle"/>.
        /// </summary>
        /// <param name="length">Side length.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Triangle(double length)
        {
            if (length <= .0) throw new ArgumentOutOfRangeException(
                nameof(length), "Side length cannot be less or equal zero.");

            Side1 = Side2 = Side3 = length;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Triangle"/>.
        /// </summary>
        /// <param name="side1">First side length.</param>
        /// <param name="side2">Second side length.</param>
        /// <param name="side3">Third side length.</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double side1, double side2, double side3)
        {
            if (side1 <= .0 || side2 <= .0 || side3 <= .0)
                throw new ArgumentException(
                    "Side length cannot be less or equal zero.");

            if (side1 + side2 <= side3 ||
                side1 + side3 <= side2 ||
                side2 + side3 <= side1)
                throw new ArgumentException(
                    "Impossible to build triangle with given sides.");

            (Side1, Side2, Side3) = (side1, side2, side3);
        }

        #endregion

        #region Private Methods

        // Returns list of sides.
        private double[] ToList() =>
            new[] { Side1, Side2, Side3 }.Order().ToArray();

        // Returns legs of right triangle.
        private double[] GetLegs() =>
            ToList().Take(2).ToArray();

        // Returns hypotenuse of right triangle.
        private double GetHypotenuse() =>
            ToList().Last();

        #endregion

        #region Public Methods

        public double GetArea()
        {
            if (IsRight)
            {
                var mult = 1d;
                foreach (var leg in GetLegs()) mult *= leg;

                return mult * .5;
            }

            if (IsEquilateral)
            {
                var result = Math.Pow(Side1, 2) * Math.Sqrt(3) / 4;
                return Math.Round(result, 2);
            }

            // Heron`s formula
            double semip = (Side1 + Side2 + Side3) / 2;

            var part1 = semip - Side1;
            var part2 = semip - Side2;
            var part3 = semip - Side3;

            return Math.Sqrt(semip * part1 * part2 * part3);
        }

        #endregion
    }
}
