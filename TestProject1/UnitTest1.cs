
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void AddLast_AddsItemToList()
        {
            
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void Remove_RemovesItemFromList()
        {
            
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            
            Node<int> node = list.FindByName("2");
            list.Remove(node);

            
            Assert.AreEqual(2, list.Count);
            Assert.IsNull(list.FindByName("2"));
        }

    }
}