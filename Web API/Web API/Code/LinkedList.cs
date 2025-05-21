namespace Web_API.Code
{
    public class LinkedList
    {
        private Node _head;  // Primer nodo de la lista
        private Node _tail;  // Último nodo de la lista

        public LinkedList()
        {
            _head = null;
            _tail = null;
        }

        // Agrega un nuevo nodo al final
        public Guid Add(string value)
        {
            var newNode = new Node(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            return newNode.Id;
        }

        // Elimina un nodo por su Id
        public bool Remove(Guid id)
        {
            if (_head == null) return false;

            // Caso especial: eliminar el primer nodo
            if (_head.Id == id)
            {
                _head = _head.Next;
                if (_head == null) _tail = null;
                return true;
            }

            // Buscar el nodo a eliminar
            Node current = _head;
            while (current.Next != null)
            {
                if (current.Next.Id == id)
                {
                    current.Next = current.Next.Next;

                    // Si eliminamos el último nodo, actualizamos _tail
                    if (current.Next == null)
                    {
                        _tail = current;
                    }

                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // Obtiene todos los nodos como lista de objetos
        public List<object> GetAllNodes()
        {
            var nodes = new List<object>();
            Node current = _head;

            while (current != null)
            {
                nodes.Add(new { Id = current.Id, Value = current.Value });
                current = current.Next;
            }

            return nodes;
        }
    }
}
