using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine("   Welcome to Request Tracker Application!   ");
                Console.WriteLine("******************************************");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await Login();
                        break;
                    case "2":
                        await Register();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please Choose Correct Option!");
                        break;
                }
            }
        }

        static async Task Login()
        {
            Console.Clear();
            Console.Write("Enter your ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            var employeeLoginBL = new EmployeeLoginBL();
            var employee = new Employee { Id = id, Password = password };

            Employee emp = await employeeLoginBL.Login(employee);
            if (emp != null)
            {
                Console.WriteLine("Login successful!");

                if (emp.Role == "Admin")
                {
                    await AdminMenu(emp);
                }
                else
                {
                    await UserMenu(emp);
                }
            }
            else
            {
                Console.WriteLine("Login failed. Invalid ID or password.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task Register()
        {
            Console.Clear();
            Console.WriteLine("Registration:");
            Console.Write("Enter your ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                return;
            }

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your role (Admin/User): ");
            string role = Console.ReadLine();

            var employee = new Employee
            {
                Id = id,
                Name = name,
                Password = password,
                Role = role
            };

            var auth = new EmployeeLoginBL();
            var registeredEmployee = await auth.Register(employee);

            if (registeredEmployee != null)
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed. Please try again.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task UserMenu(Employee user)
        {
            bool exitUserMenu = false;

            while (!exitUserMenu)
            {
                Console.Clear();
                Console.WriteLine("User Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Respond to Solution");
                Console.WriteLine("5. Give Feedback");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RaiseRequest(user);
                        break;
                    case "2":
                        await ViewRequestStatus(user);
                        break;
                    case "3":
                        await ViewSolutions(user);
                        break;
                    case "4":
                        await RespondToSolution(user);
                        break;
                    case "5":
                        await GiveFeedback(user);
                        break;
                    case "6":
                        exitUserMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static async Task AdminMenu(Employee admin)
        {
            bool exitAdminMenu = false;

            while (!exitAdminMenu)
            {
                Console.Clear();
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status (All Requests)");
                Console.WriteLine("3. View Solutions (All Solutions)");
                Console.WriteLine("4. Provide Solution");
                Console.WriteLine("5. Mark Request as Closed");
                Console.WriteLine("6. View Feedbacks (Only feedbacks given to you)");
                Console.WriteLine("7. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RaiseRequest(admin);
                        break;
                    case "2":
                        await ViewRequestStatus(admin);
                        break;
                    case "3":
                        await ViewSolutions(admin);
                        break;
                    case "4":
                        await AddSolutions(admin);
                        break;
                    case "5":
                        await MarkRequestAsClosed();
                        break;
                    case "6":
                        await ViewAdminFeedbacks(admin);
                        break;
                    case "7":
                        exitAdminMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static async Task RaiseRequest(Employee user)
        {
            Console.Clear();
            Console.WriteLine("Raise Request:");
            Console.Write("Enter your request message: ");
            string requestMessage = Console.ReadLine();

            var request = new Request
            {
                RequestMessage = requestMessage,
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RequestRaisedBy = user.Id
            };

            var requestBl = new RequestBL();
            var addedRequest = await requestBl.RaiseRequest(request);

            if (addedRequest != null)
            {
                Console.WriteLine("Request raised successfully!");
            }
            else
            {
                Console.WriteLine("Failed to raise the request. Please try again.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task ViewRequestStatus(Employee user)
        {
            var requestBl = new RequestBL();
            var userRequests = await requestBl.ViewRequestStatus(user);

            if (userRequests.Count > 0)
            {
                Console.WriteLine("Your Requests:");
                foreach (var request in userRequests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}, Status: {request.RequestStatus}");
                }
            }
            else
            {
                Console.WriteLine("You have no requests.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task ViewSolutions(Employee user)
        {
            await ViewRequestStatus(user);
            Console.WriteLine("Enter the request ID to view solutions:");
            if (!int.TryParse(Console.ReadLine(), out int requestId))
            {
                Console.WriteLine("Invalid request ID. Please try again.");
                return;
            }

            var requestService = new RequestBL();
            var userSolutions = await requestService.ViewSolutions(requestId);

            if (userSolutions.Count > 0)
            {
                Console.WriteLine("Solutions for the Request:");
                foreach (var solution in userSolutions)
                {
                    Console.WriteLine($"Solution ID: {solution.SolutionId}, Description: {solution.SolutionDescription}");
                }
            }
            else
            {
                Console.WriteLine("No solutions found for the request.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task RespondToSolution(Employee user)
        {
            var requestService = new RequestBL();
            var userRequests = await requestService.ViewRequestStatus(user);

            if (userRequests.Count > 0)
            {
                Console.WriteLine("Select a request to respond to:");
                foreach (var request in userRequests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}");
                }

                Console.Write("Enter the request number: ");
                if (!int.TryParse(Console.ReadLine(), out int requestNumber))
                {
                    Console.WriteLine("Invalid request number. Please try again.");
                    return;
                }

                var selectedRequest = userRequests.FirstOrDefault(r => r.RequestNumber == requestNumber);

                if (selectedRequest != null)
                {
                    Console.WriteLine($"Enter your response for request {selectedRequest.RequestNumber}:");
                    string response = Console.ReadLine();

                    var solutionBl = new RequestSolutionBL();
                    bool responseResult = await solutionBl.RespondToSolution(selectedRequest.RequestNumber, response);

                    if (responseResult)
                    {
                        Console.WriteLine("Response submitted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to submit the response. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Request not found.");
                }
            }
            else
            {
                Console.WriteLine("You have no requests to respond to.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task GiveFeedback(Employee user)
        {
            Console.WriteLine("Enter the solution ID to give feedback:");
            if (!int.TryParse(Console.ReadLine(), out int solutionId))
            {
                Console.WriteLine("Invalid solution ID. Please try again.");
                return;
            }

            Console.WriteLine("Enter your rating (1-5):");
            if (!float.TryParse(Console.ReadLine(), out float rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                return;
            }

            Console.WriteLine("Enter your remarks (optional):");
            string remarks = Console.ReadLine();

            var feedback = new SolutionFeedback
            {
                Rating = rating,
                Remarks = remarks,
                SolutionId = solutionId,
                FeedbackBy = user.Id,
                FeedbackDate = DateTime.Now
            };
            var feedbackBl = new SolutionFeedbackBL();
            var addedFeedback = await feedbackBl.GiveFeedback(feedback);

            if (addedFeedback != null)
            {
                Console.WriteLine("Feedback submitted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to submit the feedback. Please try again.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task AddSolutions(Employee admin)
        {
            Console.WriteLine("Enter the request ID to add solutions:");
            if (!int.TryParse(Console.ReadLine(), out int requestId))
            {
                Console.WriteLine("Invalid request ID. Please try again.");
                return;
            }

            Console.WriteLine("Enter the solution ID to add solutions:");
            if (!int.TryParse(Console.ReadLine(), out int solutionId))
            {
                Console.WriteLine("Invalid solution ID. Please try again.");
                return;
            }

            Console.WriteLine("Enter the solution:");
            string solution = Console.ReadLine();

            var requestSolutionBL = new RequestSolutionBL();
            var requestSolution = new RequestSolution
            {
                SolutionId = solutionId,
                RequestId = requestId,
                SolutionDescription = solution,
                SolvedBy = admin.Id,
                SolvedDate = DateTime.Now
            };
            var requestedSolution = await requestSolutionBL.ProvideSolution(requestSolution);

            if (requestedSolution != null)
            {
                Console.WriteLine("Solution Added Successfully");
            }
            else
            {
                Console.WriteLine("Failed to add a solution");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task MarkRequestAsClosed()
        {
            Console.WriteLine("Enter the request ID to mark as closed:");
            if (!int.TryParse(Console.ReadLine(), out int closeRequestId))
            {
                Console.WriteLine("Invalid request ID. Please try again.");
                return;
            }
            var adminBL = new AdminBL();
            await adminBL.MarkRequestAsClosed(closeRequestId);
            Console.WriteLine("Request marked as closed successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task ViewAdminFeedbacks(Employee admin)
        {
            var adminBl = new AdminBL();
            var adminFeedbacks = await adminBl.ViewFeedbacks(admin);
            if (adminFeedbacks.Count > 0)
            {
                Console.WriteLine("Feedbacks given to you:");
                foreach (var feedback in adminFeedbacks)
                {
                    Console.WriteLine($"Feedback ID: {feedback.FeedbackBy}, Rating: {feedback.Rating}, Remarks: {feedback.Remarks}");
                }
            }
            else
            {
                Console.WriteLine("No feedbacks found.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
