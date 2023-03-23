namespace AreaCalculator.Models
{
    /// <summary>
    /// Represents a circle shape.
    /// </summary>
    public class Circle : IShape
    {
        #region Auto Properties

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the diameter of the circle.
        /// </summary>
        public double Diameter
        {
            get => Radius * 2;
            set => Radius = value / 2;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Circle"/>.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Circle(double radius)
        {
            if (radius <= .0) throw new ArgumentOutOfRangeException(
                nameof(radius), "Radius cannot be less or equal zero.");

            Radius = radius;
        }

        #endregion

        #region Public Methods

        public double GetArea() => Math.PI * Math.Pow(Radius, 2);

        #endregion
    }
}
