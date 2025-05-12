public class Program {
    public static void Main () {
        var compactor = new ComparisonCompactor(2, "ABCDE", "ABXDE");
        Console.WriteLine(compactor.Compact());
    }
}
