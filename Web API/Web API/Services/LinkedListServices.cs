using System.Collections.Generic;
using Web_API.Code;

namespace Web_API.Services
{
    public class LinkedListService
    {
        private readonly LinkedList _linkedList = new LinkedList();

        public Guid AddNode(string value)
        {
            return _linkedList.Add(value);
        }

        public bool RemoveNode(Guid id)
        {
            return _linkedList.Remove(id);
        }

        public List<object> GetAllNodes()
        {
            return _linkedList.GetAllNodes();
        }
    }
}
