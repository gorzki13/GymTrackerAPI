namespace GymTrackerAPI.models
{
    public class Exercise
    {

        public int Id { get; set; }
        public int Trainingid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BodyPart { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Reps { get; set; }
    }
}
