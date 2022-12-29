using SweetCollections.Trees;
using System.Collections;

namespace SweetCollections.Tests
{
    public class BinarySearchTreeTests
    {
        private static readonly BinarySearchTree<Int64> testTree = new()
        {
            20, 15, 25, 10, 30, 5, 35, 16, 24, 17, 23
        };

        [Fact]
        public void Cannot_Find_Max()
        {
            Assert.False(true);
        }

        [Fact]
        public void Can_Find_Max()
        {
            BinarySearchTree<Int64> tree = testTree;

            Int64 max = tree.FindMax();

            Assert.Equal(expected: 35, max);
        }

        [Fact]
        public void Cannot_Find_Min()
        {
            Assert.False(true);
        }

        [Fact]
        public void Can_Find_Min()
        {
            BinarySearchTree<Int64> tree = testTree;

            Int64 min = tree.FindMin();

            Assert.Equal(expected: 5, min);
        }

        [Fact]
        public void Test_Invariant()
        {            
            Assert.True(testTree.LessGreaterInvariant);
        }

        [Fact]
        public void Can_Remove_Item()
        {
            Assert.False(true);
        }

        [Fact]
        public void Not_Contains_Item()
        {
            BinarySearchTree<Int64> tree = testTree;

            Boolean found = tree.Contains(100);
            Assert.False(found);
        }

        [Fact]
        public void Contains_Item()
        {
            BinarySearchTree<Int64> tree = testTree;


            foreach (Int64 item in tree)
            {
                Boolean found = tree.Contains(item);
                Assert.True(found);
            }                                      
        }

        [Fact]
        public void IsEmpty_True()
        {
            BinarySearchTree<Int64> tree = new();

            Assert.True(tree.IsEmpty);
        }

        [Fact]
        public void IsEmpty_False()
        {
            BinarySearchTree<Int64> tree = testTree;

            Assert.False(tree.IsEmpty);
        }

        [Fact]
        public void Can_Create_Tree()
        {
            BinarySearchTree<Int64> tree = new();
                        
            Assert.True(tree.IsEmpty);
        }
        [Fact]
        public void Can_Create_Tree_From_Collection()
        {
            Int64[] arr =  new Int64[]
            {
                10, 5, 15, 0, 20, 12, 14
            };
            ICollection<Int64> collection = arr;


            BinarySearchTree<Int64> tree = new(collection);


            Assert.Equal(expected: collection.Count, tree.Count);          
            for (Int32 i = 0; i < arr.Length; i++)
            {
                Assert.Contains(arr[i], tree);
            }

        }
        [Fact]
        public void Can_Clear()
        {
            BinarySearchTree<Int64> tree = MakeRandomTreeWithInt64();

            tree.Clear();

            Assert.True(tree.IsEmpty);
        }
        [Fact]
        public void Can_Iterate()
        {          
            BinarySearchTree<Int64> tree = new() 
            {
                15, 10, 20, 5, 0, 25
            };
            Int32 counter = 0;
            IEnumerable elems = tree;


            foreach (var item in elems)
            {
                counter++;
            }


            Assert.Equal(6, counter);
        }
        [Fact]
        public void Can_Iterate_Generic()
        {
            BinarySearchTree<Int64> tree = new()
            {
                15, 10, 20, 5, 0, 25
            };
            Int32 counter = 0;
            IEnumerable<Int64> elems = tree;


            foreach (Int64 number in elems)
            {
                counter++;
            }


            Assert.Equal(6, counter);
        }
        [Fact]
        public void Can_Count_Nodes()
        {
            BinarySearchTree<Int64> tree = new()
            {
                20, 10, 30, 0, 40, 15, 25, 35
            };

            Assert.Equal(expected: 8, tree.Count);
        }
        [Fact]
        public void Not_Read_Only()
        {
            BinarySearchTree<Int64> tree = new();

            Assert.False(tree.IsReadOnly);
        }
        [Fact]
        public void Can_Add_Node()
        {
            BinarySearchTree<Int32> tree = new();

            tree.Add(1);

            Assert.True(tree.Count == 1);
            Assert.False(tree.IsEmpty);
            Assert.Contains<Int32>(1, tree);
        }

        [Fact]
        public void Can_Add_Nodes()
        {
            BinarySearchTree<Int32> tree = new();

            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);

            Assert.True(tree.Count == 4);
            Assert.False(tree.IsEmpty);
            for (Int32 i = 1; i <= 4; i++)
            {
                Assert.Contains(i, tree);
            }
        }
        private BinarySearchTree<Int64> MakeRandomTreeWithInt64(Int64 timesToAdd = 8)
        {
            BinarySearchTree<Int64> tree = new();
            Random random = new();
            
            for (int i = 0; i < timesToAdd; i++)
            {
                tree.Add(random.NextInt64(100));
            }

            return tree;
        }
    }
}