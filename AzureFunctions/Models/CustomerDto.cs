namespace Models
{
    public class CustomerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ToSerializedString()
        {
            return $"{{ \"FirstName\": \"{FirstName}\", \"LastName\": \"{LastName}\", \"Age\": {Age} }}";
        }
    }
}