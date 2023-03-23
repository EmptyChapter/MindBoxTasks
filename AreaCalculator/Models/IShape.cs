namespace AreaCalculator.Models
{
    /// <summary>
    /// Defines a common shape properties and methods.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Calculates the area of a shape.
        /// </summary>
        /// <returns>The area of a shape.</returns>
        double GetArea();

        /// <summary>
        /// Calculates the area of a shape.
        /// </summary>
        /// <param name="accuracy">Rounding accuracy</param>
        /// <returns>The area of a shape with given accuracy.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        double GetArea(int accuracy)
        {
            if (accuracy < 0) throw new ArgumentOutOfRangeException(
                nameof(accuracy), "Accuracy cannot be less than zero");

            return Math.Round(GetArea(), accuracy);
        }
    }
}
