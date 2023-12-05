using ADO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AdoNetModuleConsole
{
    public class Program
    {
        static Manager manager = new Manager();        

        public static void Disconnect()
        {
            manager.Disconnect();
        }

        public static void Show()
        {
            manager.Connect();
            manager.ShowData();
        }

        public static void Add()
        {
            Console.WriteLine("Введите логин для добавления:");

            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для добавления:");

            var name = Console.ReadLine();

            manager.AddUser(login, name);

            manager.ShowData();
        }

        public static void Update()
        {
            Console.WriteLine("Введите логин записи для обновления имени:");

            var loginToUpdate = Console.ReadLine();

            Console.WriteLine("Введите новое имя:");

            var nameToUpdate = Console.ReadLine();

            manager.UpdateUser(loginToUpdate, nameToUpdate);

            manager.ShowData();

        }

        public static void Delete()
        {
            Console.WriteLine("Введите логин для удаления:");

            var count = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine($"Количество удаленных строк: {count}");

            manager.ShowData();

        }



        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.add + ": добавление данных");
            Console.WriteLine(Commands.delete + ": удаление данных");
            Console.WriteLine(Commands.update + ": обновление данных");
            Console.WriteLine(Commands.show + ": просмотр данных");

            string command;
            do
            {
                Console.WriteLine("Введите команду");
                command = Console.ReadLine();
                Console.WriteLine();

                switch (command)
                {                    

                    case nameof(Commands.add):
                        Add();
                        break;

                    case nameof(Commands.delete):
                        Delete();
                        break;

                    case nameof(Commands.update):
                        Update();
                        break;

                    case nameof(Commands.show):
                        Show();
                        break;

                    default:
                        Console.WriteLine("Неизвестная комманда");
                        break;
                }
            }
            while (command != nameof(Commands.stop));

            Add();

            Update();

            Delete();

            Disconnect();

            Console.ReadKey();

        }

        public enum Commands
        {
            stop,
            add,
            delete,
            update,
            show
        }
    }
}
