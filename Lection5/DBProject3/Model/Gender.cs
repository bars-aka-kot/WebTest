namespace DBProject3.Model
{
    public partial class Gender
    {
        public GenderId GenderId { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}