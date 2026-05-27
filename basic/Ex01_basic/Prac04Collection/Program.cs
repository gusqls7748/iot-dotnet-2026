using System.Collections;

namespace Prac04Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 배열 초기화
            int[] array1 = new int[5];
            array1[0] = 1;
            array1[1] = 2;
            array1[2] = 3;
            array1[3] = 4;
            array1[4] = 5;

            Console.WriteLine(array1);  // python => [1,2,3,4,5] , C# => Int32[]

            // 배열출력
            for (int i = 0; i < array1.Length; i++)
            {
                // for 문으로 배열의 인덱싱
                Console.Write(array1[i] + " ");
            }
            Console.WriteLine(); // 그냥 엔터

            // foreach 사용
            foreach (var item in array1)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            // 02 .컬렉션
            // 02-1. ArratList
            ArrayList al1 = new ArrayList(); // 컬렉션은 사이즈 지정 안해도됨

            // Add() 메서드로 데이터 추가
            al1.Add(1);
            al1.Add("Hello");
            al1.Add(3.14);
            al1.Add(true);

            foreach (var item in al1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n");

            al1.Remove("Hello");

            foreach (var item in al1)
            {
                Console.WriteLine(item);
            }

            // stack, Queue, Hasgtable, List...
            Hashtable ht1 = new Hashtable();
            ht1["apple"] = "사과";
            ht1["banana"] = "바나나";
            ht1["mango"] = "망고";

            Console.WriteLine(ht1["mango"]);

            Dictionary<string, string> ht2 = new Dictionary<string, string>();
            ht2["apple"] = "사과";

            Console.WriteLine(ht2["apple"]);
        }
    }
}
