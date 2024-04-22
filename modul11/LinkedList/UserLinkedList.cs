namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }

        public User RemoveFirst()
        {
            if (first == null) return null; // Håndterer tilfælde, hvor listen er tom.

            User removedUser = first.Data; // Gemmer data fra det første element.
            first = first.Next; // Opdaterer 'first' til at pege på det næste element i listen.

            return removedUser; // Returnerer brugerdataene fra det fjernede element.
        }

        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            if (first == null) return null; // Håndterer tilfælde, hvor listen er tom.

            Node current = first;
            while (current.Next != null)
            {
                current = current.Next; // Går gennem listen, indtil vi når det sidste element.
            }

            return current.Data; // Returnerer data fra det sidste element.
        }

        public int CountUsers()
        {
            int count = 0;
            Node current = first;

            while (current != null)
            {
                count++; // Tæller for hvert element i listen.
                current = current.Next; // Går til det næste element.
            }

            return count; // Returnerer det samlede antal elementer.
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }
    }
}