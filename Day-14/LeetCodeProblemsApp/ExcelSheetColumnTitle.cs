namespace LeetCodeProblemsApp
{
    // Method to convert a column number to an Excel sheet column title.
    public class ExcelSheetColumnTitle
    {
        public async Task<string> ConvertToTitle(int columnNumber)
        {
            string result = "";

            await Task.Run(() =>
            {
                while (columnNumber > 0)
                {
                    columnNumber--;
                    result = (char)('A' + columnNumber % 26) + result;
                    columnNumber /= 26;
                }
            });

            return result;
        }

        static async Task Main(string[] args)
        {
            ExcelSheetColumnTitle excelSheetColumnTitle = new ExcelSheetColumnTitle();
            Console.Write("Enter column number: ");

            int columnNumber;
            while (!int.TryParse(Console.ReadLine(), out columnNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid column number.");
            }

            string result = await excelSheetColumnTitle.ConvertToTitle(columnNumber);
            Console.WriteLine($"The column title is: {result}");
        }
    }
}
