using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class Program
{
    // Сортируем по возрастанию лексикографическому города и создаём на основе их группы.
    // Далее сортируем такие группы по количеству в них пользователей. Сортировка убавающая
    // Берём пять первых групп, не включая первую.
    // В каждой такой группе необходимо сгруппировать пользователей по имени, и уже каждую такую группу преобразовать в число, равное среднему возрасту этой группы.

    private static double GetAverage(IEnumerable<User> users)
    {
        return users.OrderBy(x => x.City).GroupBy(x => x.City).OrderByDescending(x => x.Count()).Skip(1).Take(5)
            .Select(x => x.GroupBy(x => x.Name).OrderBy(x => x.Key).Select(y => y.Sum(y => y.Age)).Max()).Reverse()
            .Distinct()
            .Average();
    }
}