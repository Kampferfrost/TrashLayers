namespace Pizza.Domain.Entities
{
    public class PizzaEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
