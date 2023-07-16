using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class PerformanceMetricsStringConcat
{
    private const int Iterations = 10000;

    private static readonly string String1 = "hello";
    private static readonly string String2 = "world";

    [Benchmark]
    public string StringConcatMethod()
    {
        string result = String1;

        for (int i = 0; i < Iterations; i++)
        {
            result = String.Concat(result, String2);
        }

        return result;
    }

    [Benchmark]
    public string PlusOperator()
    {
        string result = String1;

        for (int i = 0; i < Iterations; i++)
        {
            result += String2;
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderClass()
    {
        StringBuilder sb = new StringBuilder(String1, String1.Length + String2.Length * Iterations);

        for (int i = 0; i < Iterations; i++)
        {
            sb.Append(String2);
        }

        return sb.ToString();
    }

    [Benchmark]
    public string StringInterpolation()
    {
        string result = $"{String1}";

        for (int i = 0; i < Iterations; i++)
        {

            result = $"{result}{String2}";
        }

        return result;
    }

    [Benchmark]
    public string StringJoinMethod()
    {
        string result = String1;

        for (int i = 0; i < Iterations; i++)
        {
            result = String.Join("", result, String2);
        }

        return result;
    }
    
    [Benchmark]
    public string StringFormatMethod()
    {
        string result = String1;

        for (int i = 0; i < Iterations; i++)
        {
            result = String.Format(result, String2);
        }

        return result;
    }
}