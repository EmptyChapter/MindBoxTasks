namespace AreaCalculator.Models
{
    /// <summary>
    /// Represents a square shape.
    /// </summary>
    public class Square : IShape
    {
        #region Auto Properties

        /// <summary>
        /// Gets or sets the side length of the square.
        /// </summary>
        public double SideLength { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Square"/>.
        /// </summary>
        /// <param name="length">Side length.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Square(double length)
        {
            if (length <= .0) throw new ArgumentOutOfRangeException(
                nameof(length), "Side length cannot be less or equal zero.");

            SideLength = length;
        }

        #endregion

        #region Public Methods

        public double GetArea() => Math.Pow(SideLength, 2);

        #endregion
    }
}
