namespace ProductionPlannerAPI.Services
{
    /// <summary>
    /// This is a snapshot of current capacity of given powerplant.
    /// </summary>
    public class PowerplantCapacity
    {
        public float PMin { get; set; }
        public float PMax { get; set; }
        public float UnitPrice { get; set; }
        public string Name { get; set; }
    }
}
