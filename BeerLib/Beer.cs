namespace BeerLib
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ABV { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {ABV}";
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException(nameof(Name), "Name cannot be null");
            }

            if (Name.Length < 3)
            {
                throw new ArgumentException(nameof(Name), "Name must be at least 3 characters");
            }
        }

        public void ValidateABV()
        {
            if (ABV < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(ABV), "ABV cannot be less than 0");
            }

            if (ABV > 67)
            {
                throw new ArgumentOutOfRangeException(nameof(ABV), "ABV cannot be higher than 67");
            }
        }

        public void Validate() 
        { 
            ValidateName();
            ValidateABV();
        }


    }
}
