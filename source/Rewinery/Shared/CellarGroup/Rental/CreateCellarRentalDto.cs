namespace Rewinery.Shared.CellarGroup.Rental
{
#pragma warning disable CS8618
    public class CreateCellarRentalDto
    {
        /// <summary>
        /// Wine owner
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ID of cellar where wine is stored
        /// </summary>
        public int CellarId { get; set; }

        /// <summary>
        /// Number of wine bottle
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Information about wine which is stored
        /// </summary>
        public int WineId { get; set; }

        /// <summary>
        /// Rental term in months
        /// </summary>
        public int RentalTime { get; set; }
    }
}
