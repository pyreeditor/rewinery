namespace Rewinery.Shared.CellarGroup.Rental
{
#pragma warning disable CS8618
    public class UpdateCellarRentalDto : BaseDto
    {
        /// <summary>
        /// Number of wine bottle
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Rental term in months
        /// </summary>
        public int RentalTime { get; set; }
    }
}
