namespace ConsoleApp; 

public static class Utility {
    public static void Print(this object obj) {
        var props = obj.GetType().GetProperties();

        //Print header
        var headers = props.Select(prop => prop.Name);
        var header = string.Join('\t', headers);
        Console.WriteLine(header);
        var separator = string.Join(string.Empty, Enumerable.Repeat("-", header.Length));
        Console.WriteLine(separator);

        //Print Items
        var allItems = props.Select(prop => prop.GetValue(obj));
        foreach (var rowItems in allItems) {
            Console.WriteLine(string.Join('\t', rowItems));
        }
    }
}