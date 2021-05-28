using System;
using System.Collections.Generic;
using System.Linq;

public partial class Program
{
    // Необходимо:
    // 1. Сформировать группы юзеров по их имени, предварительно отсортировав их по возрасту в убывающем порядке (от большего к меньшему).
    // 2. Отфильтровать группы: оставить в группах только тех пользователей, чей возраст строго больше 10.
    // 3. Из каждой группы взять m пользователей, предварительно отсортировав по Id, и вывести на экран сумму возрастов таких пользователей.
    private static IEnumerable<IGrouping<string, User>> GetGroups(List<User> users)
    {
       return users.OrderByDescending(x => x.Age)
            .GroupBy(x => x.Name);
    }

    private static List<int> GetQueryResult(IEnumerable<IGrouping<string, User>> groups, int m)
    {
        return groups.Select(x => x.Where(y => y.Age > 10).OrderBy(y => y.Id).Take(m).Sum(x => x.Age)).ToList();
    }
}