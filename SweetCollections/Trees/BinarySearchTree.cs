using System.Collections;

namespace SweetCollections.Trees
{

    public class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        private Int32 totalItems;
        private Node root;

        public BinarySearchTree()
        {
            totalItems = 0;
            root = Node.Empty;
        }

        public BinarySearchTree(ICollection<T> items) : this()
        {
            BinarySearchTree<T> tree = this;
            foreach (T item in items)
            {               
                tree.Add(item);
            }
        }

        public Int32 Count => totalItems;

        public Boolean IsReadOnly => false;

        public Boolean LessGreaterInvariant 
        {
            get 
            {
                if (root == Node.Empty)
                {
                    return true;
                }
                Node currentNode = root;
                Queue<Node> queue = new(8);
                queue.Enqueue(currentNode);

                while (queue.Any())
                {
                    currentNode = queue.Dequeue();

                    Int32 valueOfCompareTo;

                    if (currentNode.leftChild != Node.Empty)
                    {
                        valueOfCompareTo = currentNode.item.CompareTo(currentNode.leftChild.item);
                        if (valueOfCompareTo <= 0)
                        {
                            return false;
                        }
                        queue.Enqueue(currentNode.leftChild);
                    }
                    if (currentNode.rightChild != Node.Empty)
                    {
                        valueOfCompareTo = currentNode.item.CompareTo(currentNode.rightChild.item);
                        if (valueOfCompareTo >= 0)
                        {
                            return false;
                        }
                        queue.Enqueue(currentNode.rightChild);
                    }

                }
                return true;
            }
        }

        public Boolean IsEmpty 
            => totalItems == 0 && root == Node.Empty;        

        public T FindMax()
        {
            BinarySearchTree<T> tree = this;
            if (tree.IsEmpty)
            {
                throw new FindInEmptyTreeException(
                    $"Add at least one item before calling {nameof(FindMax)}() method");
            }

            Node currentNode = root;
            while (currentNode.rightChild != Node.Empty)
            {
                currentNode = currentNode.rightChild;
            }

            return currentNode.item;
        }

        public T FindMin()
        {
            BinarySearchTree<T> tree = this;            
            if (tree.IsEmpty)
            {
                throw new FindInEmptyTreeException(
                    $"Add at least one item before calling {nameof(FindMin)}() method");
            }

            Node currentNode = root;
            while (currentNode.leftChild != Node.Empty)
            {
                currentNode = currentNode.leftChild;
            }

            return currentNode.item;
        }

        public void Add(T newItem)
        {
            if (root == Node.Empty)
            {
                root = new() { item = newItem };
            }
            else
            {
                Node currentNode = root;
                Node parentOfCurrent = root;
                Boolean isRightChild = false;
                while (currentNode != Node.Empty)
                {
                    parentOfCurrent = currentNode;
                    switch (newItem.CompareTo(currentNode.item))
                    {
                        case 0:
                            return;
                        case > 0:
                            currentNode = currentNode.rightChild;
                            isRightChild = true;
                            break;
                        case < 0:
                            currentNode = currentNode.leftChild;
                            isRightChild = false;
                            break;
                        default:
                            throw new Exception(
                                $"Check your {nameof(IComparable<T>.CompareTo)}() method for generick type {nameof(T)}");
                    }
                }
                if (isRightChild)
                {
                    parentOfCurrent.rightChild = new() { item = newItem };
                }
                else
                {
                    parentOfCurrent.leftChild = new() { item = newItem };
                }
            }
            totalItems++;
        }

        public void Clear()
        {
            root = Node.Empty;
            totalItems = 0;
        }

        public Boolean Contains(T findingItem)
        {
            Node current = root;
            while (current != Node.Empty)
            {
                Int32 result = findingItem.CompareTo(current.item);
                if (result == 0)
                {
                    return true;
                }
                else if (result > 0)
                {
                    current = current.rightChild;
                }
                else
                {
                    current = current.leftChild;
                }
            }
            return false;
        }        

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root == Node.Empty)
            {
                yield break;
            }
            
            Queue<Node> queue = new(8);
            queue.Enqueue(root);
            
            while (queue.Any())
            {
                Node currentNode = queue.Dequeue();
                
                yield return currentNode.item;
                
                if (currentNode.leftChild != Node.Empty)
                {
                    queue.Enqueue(currentNode.leftChild);
                }
                if (currentNode.rightChild != Node.Empty)
                {
                    queue.Enqueue(currentNode.rightChild);
                }
            }            
        }
        

        public Boolean Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class Node
        {
            public static readonly Node Empty = new();

            internal T item;
            internal Node leftChild;
            internal Node rightChild;

            public Node()
            {
                item = default!;
                leftChild = Node.Empty;
                rightChild = Node.Empty;
            }
        }
    }
}
