using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      TestClearLinkedList();
      TestRemoveElement();
      TestFindElement();
      TestFindElements();
      TestInsertAfter();

      Console.ReadKey();
    }

    static void TestClearLinkedList()
    {
      LinkedList list = new LinkedList();
      list.AddInTail(new Node(20));
      list.AddInTail(new Node(24));
      list.AddInTail(new Node(12));
      list.AddInTail(new Node(77));
      list.AddInTail(new Node(24));

      Console.WriteLine("test clear");

      Console.WriteLine("count before clear " + list.Count());
      Console.WriteLine("head before clear " + list.head.value);
      Console.WriteLine("tail before clear " + list.tail.value);
      list.Clear();
      Console.WriteLine("count after clear " + list.Count());
      Console.WriteLine("head after clear " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail after clear " + (list.head == null ? "null" : list.head.value.ToString()));

      Console.WriteLine(new string('=', 30));
    }

    static void TestRemoveElement()
    {

      LinkedList list = new LinkedList();
      list.AddInTail(new Node(20));
      list.AddInTail(new Node(24));
      list.AddInTail(new Node(12));
      list.AddInTail(new Node(77));
      list.AddInTail(new Node(24));

      Console.WriteLine("test remove");

      Console.WriteLine("delete 12");
      Console.WriteLine(string.Format("count before delete {0}", list.Count()));
      list.Remove(12);
      Console.WriteLine(string.Format("count after delete {0}", list.Count()));

      Console.WriteLine("delete 24");
      Console.WriteLine(string.Format("count before delete {0}", list.Count()));
      list.RemoveAll(24);
      Console.WriteLine(string.Format("count after delete {0}", list.Count()));
      Console.WriteLine("head = " + list.head.value);
      Console.WriteLine("tail = " + list.tail.value);

      Console.WriteLine("delete 20");
      Console.WriteLine(string.Format("count before delete {0}", list.Count()));
      list.Remove(20);
      Console.WriteLine(string.Format("count after delete {0}", list.Count()));
      Console.WriteLine("head = " + list.head.value);
      Console.WriteLine("tail = " + list.tail.value);

      Console.WriteLine("delete 20");
      Console.WriteLine(string.Format("count before delete {0}", list.Count()));
      list.Remove(77);
      Console.WriteLine(string.Format("count after delete {0}", list.Count()));
      Console.WriteLine("head = " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail = " + (list.tail == null ? "null" : list.tail.value.ToString()));

      Console.WriteLine(new string('=', 30));
    }

    static void TestFindElement()
    {
      LinkedList list = new LinkedList();
      list.AddInTail(new Node(20));
      list.AddInTail(new Node(24));
      list.AddInTail(new Node(12));
      list.AddInTail(new Node(77));
      list.AddInTail(new Node(24));

      Console.WriteLine("test find");

      Console.WriteLine("find 20");
      var result = list.Find(20);
      Console.WriteLine("result " + result.value);

      Console.WriteLine();

      Console.WriteLine("find 12");
      result = list.Find(12);
      Console.WriteLine("result " + result.value);

      Console.WriteLine();

      Console.WriteLine("find 24");
      result = list.Find(24);
      Console.WriteLine("result " + result.value);

      Console.WriteLine("find 100");
      result = list.Find(100);
      Console.WriteLine("result " + (result == null ? "null" : result.value.ToString()));

      Console.WriteLine(new string('=', 30));
    }

    static void TestFindElements()
    {
      LinkedList list = new LinkedList();
      list.AddInTail(new Node(20));
      list.AddInTail(new Node(24));
      list.AddInTail(new Node(12));
      list.AddInTail(new Node(77));
      list.AddInTail(new Node(24));

      Console.WriteLine("test find all");

      Console.WriteLine("find 20");
      var result = list.FindAll(20);
      foreach (var item in result)
        Console.WriteLine(item.value);

      Console.WriteLine("find 24");
      result = list.FindAll(24);
      foreach (var item in result)
        Console.WriteLine(item.value);

      Console.WriteLine(new string('=', 30));

    }

    static void TestInsertAfter()
    {
      Console.WriteLine("test insert after");
      var list = new LinkedList();
      Console.WriteLine("insert 10");
      Console.WriteLine("count before insert = " + list.Count());
      Console.WriteLine("head before insert =  "  + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail before insert =  " + (list.tail == null ? "null" : list.tail.value.ToString()));
      list.InsertAfter(null, new Node(10));
      Console.WriteLine("count after insert = " + list.Count());
      Console.WriteLine("head after insert =  " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail after insert =  " + (list.tail == null ? "null" : list.tail.value.ToString()));

      Console.WriteLine();

      Console.WriteLine("insert 20 after 10");
      Console.WriteLine("count before insert = " + list.Count());
      Console.WriteLine("head before insert =  " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail before insert =  " + (list.tail == null ? "null" : list.tail.value.ToString()));
      list.InsertAfter(list.head, new Node(20));
      Console.WriteLine("count after insert = " + list.Count());
      Console.WriteLine("head after insert =  " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail after insert =  " + (list.tail == null ? "null" : list.tail.value.ToString()));

      Console.WriteLine();

      Console.WriteLine("insert 30 before head");
      Console.WriteLine("count before insert = " + list.Count());
      Console.WriteLine("head before insert =  " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail before insert =  " + (list.tail == null ? "null" : list.tail.value.ToString()));
      list.InsertAfter(null, new Node(30));
      Console.WriteLine("count after insert = " + list.Count());
      Console.WriteLine("head after insert =  " + (list.head == null ? "null" : list.head.value.ToString()));
      Console.WriteLine("tail after insert =  " + (list.tail == null ? "null" : list.tail.value.ToString()));

      Console.WriteLine(new string('=', 30));
      
    }

    static LinkedList UnionLinkedLists(LinkedList firstLink, LinkedList secondList)
    {
      if (firstLink.Count() != secondList.Count())
        return null;

      Node nodeFirstList = firstLink.head;
      Node nodeSecondList = secondList.head;
      LinkedList newList = new LinkedList();

      while (nodeFirstList != null && nodeSecondList != null)
      {
        int newNodeValue = nodeSecondList.value + nodeSecondList.value;
        newList.AddInTail(new Node(newNodeValue));
        nodeFirstList = nodeFirstList.next;
        nodeSecondList = nodeSecondList.next;
      }

      return newList;
    }
  }
}
