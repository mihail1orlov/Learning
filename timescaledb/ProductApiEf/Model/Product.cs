namespace ProductApi.Model
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid();
            CreateOn = DateTime.Now;
            IsCompleted = false;
        }

        public Guid ProductId { get; }
        public DateTime CreateOn { get; }
        public bool IsCompleted { get; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
