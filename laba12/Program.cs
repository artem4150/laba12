using лаба10;

namespace laba12
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
        }

        public void Print()
        {
            Node<T> current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data.ToString());
                current = current.Next;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                Node<T> current = Head;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public Node<T> FindByName(string name)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.ToString() == name)
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void Remove(Node<T> node)
        {
            if (node == null)
                return;

            if (node.Previous != null)
                node.Previous.Next = node.Next;
            else
                Head = node.Next;

            if (node.Next != null)
                node.Next.Previous = node.Previous;
            else
                Tail = node.Previous;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int pointsCaseMenu = 9;

                Console.WriteLine("\nМеню работы с обобщенной коллекцией:");
                Console.WriteLine("1 задание");
                Console.WriteLine("2 задание");
                Console.WriteLine("3 задание");
                Console.WriteLine("4 задание");
                
                Console.WriteLine("0 - Выход из меню");

                int choiceCaseMenu = InputInt(0, pointsCaseMenu);

                if (choiceCaseMenu == 0)
                {
                    Console.WriteLine("\n0 - Выход из меню");
                    break;
                }

                switch (choiceCaseMenu)
                {
                    case 1:
                        {
                            tusk1();
                        }
                        break;
                    case 2:
                        {
                            
                        }
                        break;
                    case 3:
                        {
                           
                        }
                        break;
                    case 4:
                        {
                           
                        }
                        break;

                }
            }
        }
        private static int InputInt(int min, int max)
        {
            int number;
            bool inputCheck;
            do
            {
                Console.Write("Ввод: ");
                inputCheck = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
                if (!inputCheck) Console.WriteLine("Ошибка ввода! Введите целое число в пределах от {0} до {1} (включительно)", min, max);
            } while (!inputCheck);
            return number;
        }
        static void tusk1()
        {
            // Создание списка и добавление объектов
            DoublyLinkedList<MusicalInstrument> instrumentsList = new DoublyLinkedList<MusicalInstrument>();
            instrumentsList.AddLast(new ElectricGuitar("батарейки", "Fender Stratocaster", 6, 1));
            instrumentsList.AddLast(new Piano(88, "Yamaha Grand Piano", "октавная", 2));
            // Добавьте сюда другие объекты из иерархии классов

            // Распечатка списка
            Console.WriteLine("Список музыкальных инструментов:");
            instrumentsList.Print();

            // Добавление элементов с номерами 1, 3, 5 и т.д.
            Random rnd = new Random();
            for (int i = 1; i <= instrumentsList.Count; i += 2)
            {
                // Создание объекта для добавления в список
                MusicalInstrument newItem;
                if (i % 2 == 0)
                {
                    newItem = new ElectricGuitar("USB", $"Custom Guitar {i}", rnd.Next(6, 12), i + 1);
                }
                else
                {
                    newItem = new Piano(76, $"Digital Piano {i}", "шкальная", i + 1);
                }
                instrumentsList.AddLast(newItem);
            }

            // Удаление из списка всех элементов, начиная с элемента с заданным именем, и до конца списка
            string startName = "Custom Guitar 3"; // Имя, с которого начинается удаление

            Node<MusicalInstrument> current = instrumentsList.FindByName(startName);
            while (current != null)
            {
                Node<MusicalInstrument> next = current.Next;
                instrumentsList.Remove(current);
                current = next;
            }

            // Распечатка списка после удаления
            Console.WriteLine("\nСписок музыкальных инструментов после обработки:");
            instrumentsList.Print();

            // Глубокое клонирование списка
            DoublyLinkedList<MusicalInstrument> clonedList = new DoublyLinkedList<MusicalInstrument>();
            Node<MusicalInstrument> currentCloned = instrumentsList.Head;
            while (currentCloned != null)
            {
                MusicalInstrument clonedItem = (MusicalInstrument)currentCloned.Data.Clone();
                clonedList.AddLast(clonedItem);
                currentCloned = currentCloned.Next;
            }
            Console.WriteLine("\nВывод клонированного списка:");
            clonedList.Print();

            // Очистка памяти, освобождение ресурсов
            instrumentsList.Clear();
            Console.WriteLine("\nВывод удаленного списка:");
            instrumentsList.Print();
        }
    }
}
