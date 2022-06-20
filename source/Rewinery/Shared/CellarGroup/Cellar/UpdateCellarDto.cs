namespace Rewinery.Shared.CellarGroup.Cellar
{
#pragma warning disable CS8618
    public class UpdateCellarDto : BaseDto
    {
        /// <summary>
        /// Cellar name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Cellar capacity
        /// </summary>
        public int Capacity { get; set; }
    }
}
