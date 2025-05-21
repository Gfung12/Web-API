namespace Web_API.Code
{
    public class Node
    {
        public Guid Id { get; }  // Identificador único
        public string Value { get; set; }
        public Node Next { get; set; }  // Referencia al siguiente nodo

        public Node(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
            Next = null;
        }
    }
}
