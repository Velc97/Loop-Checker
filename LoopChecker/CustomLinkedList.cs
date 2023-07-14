using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace LoopChecker
{
    class CustomLinkedList<T>
    {
        private const uint MaxListElement = 1000; //Specifica il numero massimo di elementi della lista linkata
        private uint nodeCount; //Contatore del numero di nodi figli della lista
        public Node<T> node; //elemento della lista linkata



        public class Node<K>
        {
            public K value; //Valore del nodo
            public Node<K>? nextNode; //Nodo figlio collegato

            public Node(K value)
            {
                this.value = value;
                nextNode = null;
            }
        }


        public void AddFirst(T valueToAdd) //Aggiunge un nuovo nodo all'inizio della lista
        {
            if (CheckIfHasFreeNode())
            {
                if (!CheckIfHasFirstNode()) //Caso di lista vuota
                {
                    AddFirstNode(valueToAdd);
                }
                else //caso di lista con almeno un elemento
                {
                    Node<T> nodeToAdd = new Node<T>(valueToAdd);
                    nodeToAdd.nextNode = node;
                    node = nodeToAdd;
                }

                IncrementNodeCount();
            }
            else
            {
                throw new InvalidOperationException(String.Format("Maximum element number of the linked list reached: {0}", GetCount()));
            }
        }


        public void AddLast(T valueToAdd) //Aggiunge un nuovo nodo alla fine della lista
        {
            if (CheckIfHasFreeNode())
            {
                if (!CheckIfHasFirstNode()) //Caso di lista vuota
                {
                    AddFirstNode(valueToAdd);
                }
                else //Caso di lista con almeno un elemento
                {
                    GetLast().nextNode = new Node<T>(valueToAdd);
                }

                IncrementNodeCount();
            }
            else
            {
                throw new InvalidOperationException(String.Format("Maximum element number of the linked list reached: {0}", GetCount()));
            }

        }


        private void AddFirstNode(T valueToAdd) //Aggiunge il primo nodo in assoluto alla lista linkata
        {
            node = new Node<T>(valueToAdd);
        }


        public Node<T> GetFirst() //Restituiscce il primo nodo della lista
        {
            return node;
        }

        public Node<T> GetLast() //Restituisce l'ultimo nodo della lista
        {
            Node<T> lastNode = node;
            while (lastNode.nextNode != null) //Loop per cercare l'ultimo nodo della lista
            {
                lastNode = lastNode.nextNode;
            }
            return lastNode;
        }


        private void IncrementNodeCount() //Incrementa il contatore del numero dei nodi dellla lista
        {
            nodeCount++;
        }


        public uint GetCount() //Restituisce il numero di elementi attuali della lista
        {
            return nodeCount;
        }


        public bool CheckIfHasFreeNode() //Controlla che che gli elementi attualmente contenuti nella lista siano in numero minore del massimo specificato
        {
            if (GetCount() < MaxListElement)
                return true;
            return false;
        }


        public bool CheckIfHasFirstNode() //Controlla che la lista abbia almeno un nodo
        {
            if (node != null)
                return true;
            return false;
        }


        public override string ToString() //Restituisce la stringa contente il valore degli elementi della lista
        {
            if (!CheckIfHasFirstNode()) //Caso di lista senza alcun elemento
                return "Empty";

            Node<T> head = GetFirst();
            if (has_cycle(ref head))
                throw new InvalidOperationException("Can't execute ToString(): linked list has a cycle.");

            StringBuilder stringBuilder = new StringBuilder();
            Node<T> lastNode = node;
            while (lastNode != null)
            {
                stringBuilder.Append(lastNode.value + " ");
                lastNode = lastNode.nextNode;
            }
            stringBuilder.Length--;
            return stringBuilder.ToString();
        }


        public bool has_cycle(ref Node<T> SinglyLinkedListNode) //Determina se c'è un ciclo nella lista data la testa della lista stessa
        {
            HashSet<Node<T>> set = new HashSet<Node<T>>();
            while (SinglyLinkedListNode != null)
            {
                if (set.Contains(SinglyLinkedListNode))
                    return true;
                set.Add(SinglyLinkedListNode);
                if(SinglyLinkedListNode.nextNode != null)
                    SinglyLinkedListNode = SinglyLinkedListNode.nextNode;
            }
            return false;
        }

    }
}
