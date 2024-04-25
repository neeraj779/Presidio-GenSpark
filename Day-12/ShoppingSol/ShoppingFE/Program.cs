namespace ShoppingFE
{
    internal class Program
    {

        //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        //public delegate float calcDelFloat(float n1, float n2);//creating a type that refferes to a method
        //public delegate T calcDel<T>(T n1, T n2);//creating a generic  type that refferes to a method
        //void Calculate(calcDel<int> cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}
        void Calculate(Func<int, int, int> cal)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }
        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            //calcDel c1 = new calcDel(program.Add);
            //calcDel<int> c1 = new calcDel<int>(program.Add);//Generic type instantiation
            //calcDel<int> c1 = delegate (int num1, int num2)//You can do if you are alwayts going to use teh ref to use the method
            //{
            //    return (num1 + num2);
            //};
            //calcDel<int> c1 = (int num1, int num2)=>(num1 + num2);
            //Func<int,int,int> c1 = (num1,num2)=> (num1 + num2);
            //program.Calculate(c1);
            //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            //int[] another = new int[numbers.Length];
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (numbers[i] > 80)
            //        another[i] = numbers[i];
            //}
            //for (int i = 0;i < another.Length; i++)
            //{
            //    Console.WriteLine(another[i]);
            //}
            //int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            ////select * from numbers where num>80
            //// var another = from n in numbers where n > 80 select n;
            ////var another = numbers.Where(n => n > 80);
            //var another = numbers.OrderBy(n => n);
            //foreach(int n in another)
            //    Console.WriteLine(n);
            //IRepository<int,Customer> customerRepo = new CustomerRepository();
            //customerRepo.Add(new Customer { Id = 1, Name = "Ramu", Age = 23 });
            //customerRepo.Add(new Customer { Id = 2, Name = "Ramu", Age = 31 });
            //customerRepo.Add(new Customer { Id = 3, Name = "Komu", Age = 27 });
            //var customers = customerRepo.GetAll().ToList();
            //customers = customers.OrderByDescending(cust => cust.Name).ThenByDescending(cust => cust.Age).ToList();
            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

            int[] evenNumebrs = numbers.EvenCatch();
            foreach (int n in evenNumebrs)
                Console.WriteLine(n);
            //string message = "Hello World";
            //message = message.Reverse();
            //Console.WriteLine(message);
        }
    }

    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> evens = new List<int>();
            foreach (int n in nums)
            {
                if ((n & 1) == 0)
                    evens.Add(n);
            }
            return evens.ToArray(); 
        }
    }

}
