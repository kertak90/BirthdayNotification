using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BirthdayNotification
{
    public class User
    {
        public Guid Id;
        public string Name;        
        public DateTime BirthDay;
    }
    class Program
    {        
        static async Task Main(string[] args)
        {
            NotifyAboutBirthday();
            // Tests();
        } 
        static void NotifyAboutBirthday()
        { 
            var userList = GetUsers();
            //Дата для проверки с концом года
            var nowTime = new DateTime(2020, 12, 31);
            //Обычная Дата
            // var nowTime = new DateTime(2020, 11, 24);
            var groupedlist = userList
                .Select(p => {
                        var daysBeforeBirthDay = ((new DateTime(1000, p.BirthDay.Month, p.BirthDay.Day)).Subtract(new DateTime(1000, nowTime.Month, nowTime.Day)).Days < -334 
                                ? new DateTime(1001, p.BirthDay.Month, p.BirthDay.Day)
                                : new DateTime(1000, p.BirthDay.Month, p.BirthDay.Day))
                            .Subtract(new DateTime(1000, nowTime.Month, nowTime.Day))
                            .Days;
                        return new {user = p, daysBeforeBirthDay = daysBeforeBirthDay};
                    })
                .Where(p => p.daysBeforeBirthDay <= 3
                    && p.daysBeforeBirthDay >= 1)
                .GroupBy(p => p.daysBeforeBirthDay)
                .OrderBy(g => g.Key)
                .ToList();
                
            foreach(var group in groupedlist)
            {
                System.Console.WriteLine($"days before birthday: {group.Key}");
                foreach(var item in group.OrderBy(p => p.user.Name))
                {
                    System.Console.WriteLine($"{JsonConvert.SerializeObject(item.user)}");
                }
                System.Console.WriteLine();
            }
        }
        static void Tests()
        {            
            var userLists = GetUsers();
            // var nowTime = new DateTime(2020, 12, 31);
            var nowTime = new DateTime(2020, 11, 24);
            var groupedlist = userLists
                .Select(p => new {
                    user = p,
                    daysBeforeBirthDay = DaysBeforeBirthday(nowTime, p)})
                .Where(p => p.daysBeforeBirthDay <= 3
                    && p.daysBeforeBirthDay >= 1)
                .GroupBy(p => p.daysBeforeBirthDay)
                .OrderBy(g => g.Key)
                .ToList();
            foreach(var group in groupedlist)
            {
                System.Console.WriteLine($"days before birthday: {group.Key}");
                foreach(var item in group)
                {
                    System.Console.WriteLine($"{JsonConvert.SerializeObject(item.user)}");
                }
                System.Console.WriteLine();
            }
        }        
        private static int DaysBeforeBirthday(DateTime nowTime, User user)
        {
            var days = IncreaseYear(
                new DateTime(1000, user.BirthDay.Month, user.BirthDay.Day), 
                new DateTime(1000, nowTime.Month, nowTime.Day))
            .Subtract(new DateTime(1000, nowTime.Month, nowTime.Day)).Days;
            System.Console.WriteLine($"{user.BirthDay.Date.ToString()}  {days}");
            return days;
        }
        private static DateTime IncreaseYear(DateTime userTime, DateTime curentTime)
        {
            if(userTime.Subtract(curentTime).Days < -335)
                return new DateTime(userTime.Year + 1, userTime.Month, userTime.Day);
            else
                return userTime;
        }
        private static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pol",
                    BirthDay = new DateTime(1966, 11, 20)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mike",
                    BirthDay = new DateTime(1988, 11, 21)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice",
                    BirthDay = new DateTime(1990, 11, 22)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob",
                    BirthDay = new DateTime(1985, 11, 23)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Chack",
                    BirthDay = new DateTime(1982, 11, 24)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dmitriy",
                    BirthDay = new DateTime(1992, 11, 24)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Alex",
                    BirthDay = new DateTime(1998, 11, 25)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ruslan",
                    BirthDay = new DateTime(2000, 11, 26)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Chack",
                    BirthDay = new DateTime(1981, 11, 26)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kim",
                    BirthDay = new DateTime(1966, 11, 26)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Andrey",
                    BirthDay = new DateTime(1966, 11, 27)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Max",
                    BirthDay = new DateTime(1966, 11, 24)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Svetlana",
                    BirthDay = new DateTime(1966, 12, 27)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mery",
                    BirthDay = new DateTime(1966, 12, 28)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Igor",
                    BirthDay = new DateTime(1966, 12, 29)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mariya",
                    BirthDay = new DateTime(1966, 12, 30)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nikita",
                    BirthDay = new DateTime(1966, 12, 31)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sergio",
                    BirthDay = new DateTime(1966, 01, 01)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Oleg",
                    BirthDay = new DateTime(1966, 01, 01)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Natalya",
                    BirthDay = new DateTime(1966, 01, 01)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Petro",
                    BirthDay = new DateTime(1966, 01, 02)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Xihuan",
                    BirthDay = new DateTime(1966, 01, 02)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sergio",
                    BirthDay = new DateTime(1966, 01, 03)
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kirill",
                    BirthDay = new DateTime(1966, 01, 04)
                }
            };
        }
    }  
}
