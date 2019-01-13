using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AlgorithmsDataStructures
{

  public class Node
  {
    public int value;
    public Node next;
    public Node(int _value) { value = _value; }
  }

  public class LinkedList
  {
    public Node head;
    public Node tail;

    public LinkedList()
    {
      head = null;
      tail = null;
    }

    public void AddInTail(Node _item)
    {
      if (head == null) head = _item;
      else tail.next = _item;
      tail = _item;
    }

    public Node Find(int _value)
    {
      Node node = head;
      while (node != null)
      {
        if (node.value == _value) return node;
        node = node.next;
      }
      return null;
    }

    public List<Node> FindAll(int _value)
    {
      List<Node> nodes = new List<Node>();

      Node node = head;
      while (node != null)
      {
        if (node.value == _value)
          nodes.Add(node);

        node = node.next;
      }

      return nodes;
    }

    public bool Remove(int _value)
    {
      bool isDeleted = false;
      if (head == null)
        isDeleted = false;
      else
      {
        Node node = head;
        Node prevNode = null;
        while (node != null && !isDeleted)
        {
          if (node.value == _value)
          {
            if(prevNode!=null)
              prevNode.next = node.next;
            else
              head = node.next;

            isDeleted = true;
          }
          else
            prevNode = node;

          node = node.next;
        }

        if(node == null)
          tail = prevNode;
      }

      return isDeleted;
    }

    public void RemoveAll(int _value)
    {
      Node node = head;
      Node prevNode = null;
      while (node != null)
      {
        if (node.value == _value)
        {
          if(prevNode != null)
            prevNode.next = node.next;
          else
          {
            head = node.next;
          }
        }
        else
          prevNode = node;

        node = node.next;
      }

      tail = prevNode;
    }

    public void Clear()
    {
      Node node = head;
      head = null;
      tail = null;
      while (node != null)
      {
        Node nextNode = node.next;
        node = null;
        node = nextNode;
      }
    }

    public int Count()
    {
      int count = 0;
      var node = head;
      if (node != null)
      {
        while (node != null)
        {
          count++;
          node = node.next;
        }
      }

      return count;
    }

    public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
    {
      if (head == null)
        AddInTail(_nodeToInsert);
      else  if (_nodeAfter == null)
      {
        _nodeToInsert.next = head;
        head = _nodeToInsert;
      }
      else if (tail == _nodeAfter)
      {
        tail.next = _nodeToInsert;
        tail = _nodeToInsert;
      }
      else
      {
        _nodeToInsert.next = _nodeAfter.next;
        _nodeAfter.next = _nodeToInsert;
      }
    }

  }
}