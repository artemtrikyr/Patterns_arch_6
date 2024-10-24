using System;
using Patterns_arch_6;

namespace Patterns_arch_6
{

    class Program
    {
        static List<Admin> admins = new List<Admin>();
        static List<Client> clients = new List<Client>();
        static List<Hairdresser> hairdressers = new List<Hairdresser>();
        static List<Service> services = new List<Service>();

        static void Main(string[] args)
        {
            InitializeData();
            bool running = true;

            while (running)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Вітаю до нашого Салону!");
                Console.WriteLine("1. Ввійти як адмін");
                Console.WriteLine("2. Ввійти як клієнт");
                Console.WriteLine("3. Реєстрація для клієнта");
                Console.WriteLine("4. Вихід");
                Console.Write("Оберіть опцію: ");
                Console.WriteLine("\n-------------------------------------------");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminLogin();
                        break;
                    case "2":
                        ClientLogin();
                        break;
                    case "3":
                        RegisterClient();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неправильне число. Введіть ще раз)");
                        break;
                }
            }
        }

        static void InitializeData()
        {
            // Ініціалізація тестових даних
            admins.Add(new Admin(1, "Artem Trikyr", "admin@example.com", "0996250751", "adminpassword"));
            hairdressers.Add(new Hairdresser(1, "John Haries", "Haircut"));
            hairdressers.Add(new Hairdresser(2, "Maria Jonifer", "Haircut"));
            hairdressers.Add(new Hairdresser(3, "Klara Lara", "Haircut"));
            hairdressers.Add(new Hairdresser(4, "Olena Golovach", "Haircut"));
            services.Add(new Service(1, "Стрижка", 30, 20.0));
            services.Add(new Service(2, "Миття голови", 15, 10.0));
            services.Add(new Service(3, "Стрижка + Борода", 60, 40.0));
            services.Add(new Service(4, "Покраска", 120, 60.0));
        }

        static void AdminLogin()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Введіть email адміна: ");
            string email = Console.ReadLine();

            Console.WriteLine("Введіть пароль: ");
            string password = Console.ReadLine();

            Admin admin = admins.Find(a => a.Email == email);

            if (admin != null && admin.Login(email, password))
            {
                Console.WriteLine("Успішно увійшли як адмін.");
                AdminPanel(admin);
            }
            else
            {
                Console.WriteLine("Неправильний пошта або пароль.");
            }
            Console.WriteLine("\n--------------------------------------------");
        }
        static void AdminPanel(Admin admin)
        {
            bool adminLoggedIn = true;

            while (adminLoggedIn)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\nПанель Адміна");
                Console.WriteLine("1. Перегляд клієнтів");
                Console.WriteLine("2. Перегляд бронювань");
                Console.WriteLine("3. Вийти");
                Console.Write("Виберіть опцію: ");
                string option = Console.ReadLine();
                Console.WriteLine("\n--------------------------------------------");

                switch (option)
                {
                    case "1":
                        foreach (var client in clients)
                        {
                            Console.WriteLine($"Клієнт: {client.Name}, Телефон: {client.Phone}, Пошта: {client.Email}");
                        }
                        break;
                    case "2":
                        foreach (var client in clients)
                        {
                            foreach (var booking in client.BookingHistory)
                            {
                                Console.WriteLine($"Бронювання для {booking.Service.ServiceName} з барбером {booking.Hairdresser.Name} на дату {booking.Date.ToShortDateString()} - {booking.Time}");
                            }
                        }
                        break;
                    case "3":
                        adminLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Неправильна опція.");
                        break;
                }
            }
        }

        static void ClientLogin()
        {
            Console.WriteLine("--------------------------------------------");
            Console.Write("Введіть телефон: ");
            string phone = Console.ReadLine();
            Console.Write("Введіть пошту: ");
            string email = Console.ReadLine();

            Client client = clients.Find(c => c.Phone == phone && c.Email == email);

            if (client != null)
            {
                Console.WriteLine($"Вітаю {client.Name}!");
                ClientPanel(client);
            }
            else
            {
                Console.WriteLine("Неправильний телефон чи пошта.");
            }
            Console.WriteLine("\n--------------------------------------------");
        }
        static void RegisterClient()
        {
            Console.WriteLine("--------------------------------------------");
            Console.Write("Введіть імʼя: ");
            string name = Console.ReadLine();
            Console.Write("Ваш телефон: ");
            string phone = Console.ReadLine();
            Console.Write("Ваша пошта: ");
            string email = Console.ReadLine();

            Client client = new Client(clients.Count + 1, name, phone, email);
            clients.Add(client);

            Console.WriteLine("Клієнт успішно зареєстрований!");
            Console.WriteLine("\n--------------------------------------------");
        }

        static void ClientPanel(Client client)
        {
            bool clientLoggedIn = true;

            while (clientLoggedIn)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\nПанель клієнта");
                Console.WriteLine("1. Створити бронювання");
                Console.WriteLine("2. Переглянути історію бронювання");
                Console.WriteLine("3. Відмінити бронювання");
                Console.WriteLine("4. Вийти");
                Console.Write("Виберіть опцію: ");
                string option = Console.ReadLine();
                Console.WriteLine("\n--------------------------------------------");

                switch (option)
                {
                    case "1":
                        CreateBooking(client);
                        break;
                    case "2":
                        foreach (var booking in client.BookingHistory)
                        {
                            Console.WriteLine($"Бронювання для {booking.Service.ServiceName} з {booking.Hairdresser.Name} на {booking.Date.ToShortDateString()} - {booking.Time}");
                        }
                        break;
                    case "3":
                        Console.Write("Введіть ID бронювання щоб відмінити: ");
                        int bookingID;
                        if (int.TryParse(Console.ReadLine(), out bookingID))
                        {
                            client.CancelBooking(bookingID);
                            Console.WriteLine("Бронювання відміненно.");
                        }
                        else
                        {
                            Console.WriteLine("Неправильне ID.");
                        }
                        break;
                    case "4":
                        clientLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Не правильна опція.");
                        break;
                }
            }
        }

        static void CreateBooking(Client client)
        {
            Console.WriteLine("Доступні послуги:");
            foreach (var service in services)
            {
                Console.WriteLine($"{service.ServiceID}. {service.ServiceName} - {service.Duration} mins - ${service.Price}");
            }

            Console.Write("Виберіть послугу за ID: ");
            int serviceID;
            if (int.TryParse(Console.ReadLine(), out serviceID))
            {
                Service selectedService = services.Find(s => s.ServiceID == serviceID);

                if (selectedService != null)
                {
                    Console.WriteLine("Доступні барбери:");
                    foreach (var hairdresser in hairdressers)
                    {
                        Console.WriteLine($"{hairdresser.HairdresserID}. {hairdresser.Name} - Спеціалізація: {hairdresser.Specialization}");
                    }

                    Console.Write("Виберіть барбера за ID: ");
                    int hairdresserID;
                    if (int.TryParse(Console.ReadLine(), out hairdresserID))
                    {
                        Hairdresser selectedHairdresser = hairdressers.Find(h => h.HairdresserID == hairdresserID);

                        if (selectedHairdresser != null)
                        {
                            Booking newBooking = new Booking(client.BookingHistory.Count + 1, DateTime.Now, new TimeSpan(10, 0, 0), client, selectedHairdresser, selectedService);
                            client.CreateBooking(newBooking);

                            Console.WriteLine($"Бронювання створено для {selectedService.ServiceName} з {selectedHairdresser.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("Невірно.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невірно.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірно.");
                }
            }
            else
            {
                Console.WriteLine("Невірно.");
            }
        }
    }

}