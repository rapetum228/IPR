using BenchmarkDotNet.Attributes;

namespace BenchmarkNet7
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ReadOnlyString
    {
        List<string> strings = new List<string>
        {
            "lKJEFajefaekf;lekfslkenflaskefa;efma;fmma;eefa;efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesf   sefaelnnesvwefsefsfsesfs",
            "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesv wefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs",
            "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnne   svwefsefsfsesfsefaelnnesvw efsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs",
            "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwe    fsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs",
                "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnne   svwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnn       esvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs",
                "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnne   svwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnn       esvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs",
                "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaeqlnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfqsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsqefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs",
            "efaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvw    efsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnccnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfsefaelnnesvwefsefsfsesfs"
        };

        public int SpanLength(ReadOnlySpan<char> str)
        {
            return str.Length;
        }

        public int StrLength(string str)
        {
            return str.Length;
        }

        [Benchmark]
        public void StringLength()
        {
            ulong count = 0;
            for (int i = 0; i < strings.Count; i++)
            {
                var a = StrLength(strings[i]);
                count += (ulong)a;
            }
        }

        [Benchmark(Baseline = true)]
        public void Span()
        {
            ulong count = 0;
            for (int i = 0; i < strings.Count; i++)
            {
                var a = SpanLength(strings[i]);

                count += (ulong)a;
            }
        }
    }


}
