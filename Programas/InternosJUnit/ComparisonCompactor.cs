using System;

public class ComparisonCompactor {
    private readonly int length;
    private readonly string expected;
    private readonly string actual;

    //Esse objeto é apenas para exibir o sistema ComparisonCompactor do JUnit
    //O código foi traduzido de Java para C# e refatorado para ficar mais legível
    //O código original foi retirado do JUnit
    public ComparisonCompactor (int length, string expected, string actual) {
        this.length = length;
        this.expected = expected;
        this.actual = actual;
    }

    public string Compact () {
        if (expected == null || actual == null || expected.Equals(actual))
            return $"Esperado: <{expected}>\nRecebido: <{actual}>";

        int prefixLength = FindCommonPrefixLength();
        int suffixLength = FindCommonSuffixLength(prefixLength);

        string expectedDiff = expected.Substring(prefixLength, expected.Length - prefixLength - suffixLength);
        string actualDiff = actual.Substring(prefixLength, actual.Length - prefixLength - suffixLength);

        string expectedCompact = $"{GetPrefix(prefixLength)}[{expectedDiff}]{GetSuffix(suffixLength)}";
        string actualCompact = $"{GetPrefix(prefixLength)}[{actualDiff}]{GetSuffix(suffixLength)}";

        return $"Esperado: <{expectedCompact}>\nRecebido: <{actualCompact}>";
    }

    private int FindCommonPrefixLength () {
        int end = Math.Min(expected.Length, actual.Length);
        for (int i = 0; i < end; i++)
        {
            if (expected[i] != actual[i])
                return i;
        }
        return end;
    }

    private int FindCommonSuffixLength (int prefixLength) {
        int expectedIndex = expected.Length - 1;
        int actualIndex = actual.Length - 1;
        int count = 0;

        while (expectedIndex >= prefixLength && actualIndex >= prefixLength &&
               expected[expectedIndex] == actual[actualIndex])
        {
            expectedIndex--;
            actualIndex--;
            count++;
        }
        return count;
    }

    private string GetPrefix (int length) {
        int start = Math.Max(0, length - length);
        return (start > 0 ? "..." : "") + expected.Substring(start, length - start);
    }

    private string GetSuffix (int length) {
        int end = expected.Length - length;
        int shown = Math.Min(length, expected.Length - end);
        return expected.Substring(end, shown) + (shown < length ? "..." : "");
    }
}
