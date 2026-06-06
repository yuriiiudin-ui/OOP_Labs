using System;

namespace Lab1_2
{
    public class RList
    {
        public int info;
        public RList next;

        // 1. Конструктор з одним параметром
        public RList(int i)
        {
            info = i;
            next = null;
        }

        // 2. Конструктор з двома параметрами
        public RList(int i, RList n)
        {
            info = i;
            next = n;
        }

        // 6. Рекурсивний метод додавання нового елемента останнім у список
        public void AddLastRecursive(int value)
        {
            if (next == null)
            {
                next = new RList(value);
            }
            else
            {
                next.AddLastRecursive(value);
            }
        }

        // 9. Метод додавання нового елементу у список перед елементом із заданим значенням
        public void AddBeforeValue(int targetValue, int newValue)
        {
            if (this.info == targetValue)
            {
                RList newNode = new RList(this.info, this.next);
                this.info = newValue;
                this.next = newNode;
                return;
            }

            RList current = this;
            while (current.next != null)
            {
                if (current.next.info == targetValue)
                {
                    RList newNode = new RList(newValue, current.next);
                    current.next = newNode;
                    return;
                }
                current = current.next;
            }
        }

        // 15. Рекурсивний метод видалення останнього в списку елемента
        public void RemoveLastRecursive()
        {
            if (this.next == null)
            {
                return;
            }

            if (this.next.next == null)
            {
                this.next = null;
            }
            else
            {
                this.next.RemoveLastRecursive();
            }
        }

        // 17. Не рекурсивний метод видалення n-ного за рахунком елемента (нумерація з 0)
        public void RemoveNthNonRecursive(int n)
        {
            if (n < 0) return;

            if (n == 0)
            {
                if (this.next != null)
                {
                    this.info = this.next.info;
                    this.next = this.next.next;
                }
                return;
            }

            RList current = this;
            int currentIndex = 0;

            while (current.next != null)
            {
                if (currentIndex == n - 1)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
                currentIndex++;
            }
        }

        // 29. Не рекурсивний метод друку елементів списку у зворотному порядку у стовпець
        public void PrintReverseColumnNonRecursive()
        {
            int length = this.Length;
            int[] arr = new int[length];
            RList current = this;
            int i = 0;
            while (current != null)
            {
                arr[i++] = current.info;
                current = current.next;
            }

            for (int j = length - 1; j >= 0; j--)
            {
                Console.WriteLine(arr[j]);
            }
        }

        // 43. Метод підрахунку кількості елементів у списку
        public int CountElements()
        {
            int count = 0;
            RList current = this;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        // 49. Властивість Length - довжина списку (тільки на зчитування - повернути довжину списку)
        public int Length
        {
            get
            {
                return CountElements();
            }
        }

        // 73. Перевизначити для списку операцію !=
        public static bool operator !=(RList a, RList b)
        {
            return !(a == b);
        }

        // 79. Перевизначити для списку будь-яку операцію (==)
        public static bool operator ==(RList a, RList b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            if (a.Length != b.Length) return false;

            RList currA = a;
            RList currB = b;
            while (currA != null)
            {
                if (currA.info != currB.info) return false;
                currA = currA.next;
                currB = currB.next;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is RList list)
            {
                return this == list;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            RList curr = this;
            while (curr != null)
            {
                hash = hash * 31 + curr.info.GetHashCode();
                curr = curr.next;
            }
            return hash;
        }
        
        // Допоміжний метод для друку в прямому порядку
        public void Print()
        {
            RList curr = this;
            while (curr != null)
            {
                Console.Write(curr.info + (curr.next != null ? " -> " : ""));
                curr = curr.next;
            }
            Console.WriteLine();
        }
    }
}
