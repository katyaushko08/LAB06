namespace LAB06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(10, 8, 6);
            Box box2 = new Box(3, 2, 1);
            Box box3 = new Box(4);

            Console.WriteLine($"box 1 = {box1}");
            Console.WriteLine($"box 2 = {box2}");
            Console.WriteLine($"box 3 = {box3})");

            box1.Length = 12;
            Console.WriteLine($"Измененая коробка: {box1}");
            Console.WriteLine();

            Box sum = box1 + box2;
            Console.WriteLine($"box1 + box2: {sum}");

            try
            {
                Box diff = box1 - box2;
                Console.WriteLine($"box1 - box2: {diff}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message );
            }

            Console.WriteLine($"box1 == box3: {box1 == box3}"); 
            Console.WriteLine($"box1 != box3: {box1 != box3}");
            Console.WriteLine();

            try
            {
                box2.Width = -5;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message );
            }
        }
    }
}
