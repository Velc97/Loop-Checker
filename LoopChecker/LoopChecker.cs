

namespace LoopChecker
{

    public static class LoopChecker
    {
        public static void Main(String[] args)
        {
            try 
            {
                CustomLinkedList<int> llist = new CustomLinkedList<int>();
                Console.WriteLine(llist);

                llist.AddFirst(2);
                llist.AddFirst(4);
                llist.AddFirst(15);
                llist.AddFirst(10);
                llist.AddLast(45);
                llist.AddFirst(55);
                llist.AddLast(65);

                Console.WriteLine(llist);
                Console.WriteLine(llist.has_cycle(ref llist.node));


                llist.AddFirst(65);
                Console.WriteLine(llist);
                Console.WriteLine(llist.has_cycle(ref llist.node));

                llist.AddFirst(55);
                llist.node.nextNode.nextNode = llist.node;

                llist.AddFirst(20);
                llist.AddFirst(4);
                llist.AddFirst(15);
                llist.AddFirst(10);

                /*Creazione di un loop per testing */
                llist.node.nextNode.nextNode = llist.node;

                //Console.WriteLine(llist);
                Console.WriteLine(llist.has_cycle(ref llist.node));
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
          
        }
    }




}
