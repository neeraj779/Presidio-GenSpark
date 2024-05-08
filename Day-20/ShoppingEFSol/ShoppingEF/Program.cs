using ShoppingEF.Model;

namespace ShoppingEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Area area = new Area();
            area.Area1 = "North";
            area.Zipcode = "12345";
            dbEmployeeTrackerContext db_pool = new dbEmployeeTrackerContext();
            //db_pool.Areas.Add(area);
            //db_pool.SaveChanges();

            var areas = db_pool.Areas.ToList();    
            foreach(var a in areas  )
            {
                System.Console.WriteLine($"Area: {a.Area1}, Zipcode: {a.Zipcode}");
            }
        }
    }
}
