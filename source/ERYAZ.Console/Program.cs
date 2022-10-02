
using System.Collections;
using System.Text;

var numbers = GetNumbers();

for (int i = 0; i < numbers.Count; i++)
{
    Console.WriteLine(numbers[i]);
}



ArrayList GetNumbers()
{

    var items = new ArrayList();

    for (int i = 1; i <= 100; i++)
    {
        var item = new StringBuilder();

        if (i % 4 == 0)
        {
            item.Append("ER");
        }

        if (i % 7 == 0)
        {
            item.Append("YAZ");
        }

        if (item.Length == 0)
        {
            items.Add(i);
        }
        else
        {
            items.Add(item);
        }

    }

    return items;
}
