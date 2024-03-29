using BenchmarkDotNet.Attributes;
using DllLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkNet7
{
    public class TestDataSet
    {
        public TestDataSet(string first, string second, int lenMax)
        {
            First = first;
            Second = second;
            LenMax = lenMax;
        }

        public string First { get; set; }
        public string Second { get; set; }
        public int LenMax { get; set; }
    }


    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]

    public class BenchmarkPerformance
    {
        

        List<TestDataSet> data = new List<TestDataSet>
        {
            new TestDataSet("AnkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA alefftoxa", "AkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffnton", 12),
            new TestDataSet("Artem AnatokREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA alefflych", "AntkREVEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffKA INTO SERA aleffon Anatolych", 32),
            new TestDataSet("Vitaly Sergeich SergkREVETKA INTO SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffRA aleffeev", "Victor Ivanovich ChekREVETKA INTO SERA alkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffeffrgeev", 322),
            new TestDataSet("Antoxa GkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffokREVETKA kREVETKA INTO SERA aleffINTO SERA alefflenkkREVETKA INTO SERA aleffo", "Anton GkREVETKA kREVETKA INTO SERA aleffkREVETKA INTO SERA aleffINTO SERA akREVETKA INTO SERA aleffkREVETKA INTO SERA aleffleffolyi", 322),
            new TestDataSet("HuitorpkREVETKA INTO SERA aleffkREVETKkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA INTO SERA aleffj alef", "Haiporpj kREVETKA INTO SERA aleffkREVETKA INTO SERA aleffakREVETKA INTO SERA aleffkREVETKA INTO SERA aleffleraf", 322),
            new TestDataSet("kREVETKA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA aleffEA alef", "kREVEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffTKA INTO SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffERA aleff", 2232),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INTO kREVETKA INTO SERA aleffSERA aleffkREVETKA INTO SERkREVETKA INTO SERA aleffA aleff", "kREVETKA INTO SERA alef kREVETKA INTO SERkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA alefff", 132),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INkREVETKA INTO SERA aleffTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleff", "kREVETkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffKA INTO SERA aleff kREVETKA INTO SERA aleff", 222),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA al kREVETKA INTO SERA aleffeff", "kREkREVETKA INTO SERA aleff VE kREVETKA INTO SERA aleff TKA kREVETKA INTO SERA aleff INTO SERA aleff", 1232),
            new TestDataSet("kREVETKA IN SEA kREVETKA INT kREVETKA INTO SERA alkREVETKA INTO SERA aleffeffO SERA aleff alkREVETKA INTO SERA aleffef", "kREV kREVETKA INTO kREVETKA INTO SERA aleffSERA kREVETKA INTO SERA aleffaleff kREVETKA INTO SERA aleffETKA INTO SERA aleff", 2222),
            new TestDataSet("kREVETKA IN SEA kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleffalef", "kREVkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffETKA INTO SERA aleff", 13222),
            new TestDataSet("kREVETKA IN  kREVETKA INTO SERA aleffvkREVETKA INTO SERA aleff kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffSEA alef", "kREVETKA INTO S kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleffERA aleff", 2222),
            new TestDataSet("kREVkREVETKA INTkREVETKA INTO SERA aleffO SERA akREVETKA INTO SERA aleffleffETKA INkREVETKA INTO SERA aleff SEkREVETKA INTO SERA aleffA alef", "kREVETKA INTkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffO SERA aleff", 1232),
            new TestDataSet("kREVETKA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffEA alef", "kREVETKA INTO SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffRA aleff", 1322),
            new TestDataSet("kREVETkREVETKA INTO SEkREVETKA INTO SERA aleffRA alefkREVETKA INTO SERA alefffKA kREVETKA INTO SERA aleffIN SkREVETKA INTO SERA aleffEA alef", "kkREVETKA kREVETKA INTO SERA aleffINTO SERA aleffREVkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffETKA INTO SERA aleff", 1232),
            new TestDataSet("kREkREVETKA INTO SERA aleff VETKkREVETKA INTO SERA aleffA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffEA alef", "kREVETKA INkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffTO SERA aleff", 2132),
            new TestDataSet("kREVkREVETKA IkREVETKA INTO SERA aleffNTO SERA aleffkREVETKA INTO SERA aleffETKA INkREVETKA INTO SERA aleffkREVETKA INTO SERA aleff SEA alef", "kREVETKA INTO SkREVETKA INTO SERA aleffERA kREVETKA INTO SERA aleff aleffkkREVETKA INTO SERA aleffREVETKA INTO SERA aleffkREVETKA INTO SERA aleff", 13222),
            new TestDataSet("kREVETKkREVETkREVETKA INTO SERA aleffKA INTO SERA aleffA IN kREVETKA INTO SERA aleffSEA kREVETKA INTO SERA aleffalef", "kREVETKA INTkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffO SERA aleff", 13222),
           new TestDataSet ("kREVETKA IN SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA alef", "kREVETKA INkREVETKA kREVETKA kREVETKA INTO SEkREVETKA INTO SERA aleffRA aleffINTO SERA aleffINTO SERA aleffTO SERA kREVETKA INTO SERA aleffaleff", 12232),
           new TestDataSet("kREVETKA IN SEA alef kREVETKA INTO kREVETKA INTO SERA aleffSERA aleffkREVETKA INTO SERkREVETKA INTO SERA aleffA aleff", "kREVETKA INTO SERA alef kREVETKA INTO SERkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA alefff", 132),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INkREVETKA INTO SERA aleffTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleff", "kREVETkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffKA INTO SERA aleff kREVETKA INTO SERA aleff", 222),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA al kREVETKA INTO SERA aleffeff", "kREkREVETKA INTO SERA aleff VE kREVETKA INTO SERA aleff TKA kREVETKA INTO SERA aleff INTO SERA aleff", 1232),
            new TestDataSet("kREVETKA IN SEA kREVETKA INT kREVETKA INTO SERA alkREVETKA INTO SERA aleffeffO SERA aleff alkREVETKA INTO SERA aleffef", "kREV kREVETKA INTO kREVETKA INTO SERA aleffSERA kREVETKA INTO SERA aleffaleff kREVETKA INTO SERA aleffETKA INTO SERA aleff", 2222),
            new TestDataSet("kREVETKA IN SEA kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleffalef", "kREVkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffETKA INTO SERA aleff", 13222),
            new TestDataSet("kREVETKA IN  kREVETKA INTO SERA aleffvkREVETKA INTO SERA aleff kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffSEA alef", "kREVETKA INTO S kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleffERA aleff", 2222),
            new TestDataSet("kREVkREVETKA INTkREVETKA INTO SERA aleffO SERA akREVETKA INTO SERA aleffleffETKA INkREVETKA INTO SERA aleff SEkREVETKA INTO SERA aleffA alef", "kREVETKA INTkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffO SERA aleff", 1232),
            new TestDataSet("kREVETKA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffEA alef", "kREVETKA INTO SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffRA aleff", 1322),
            new TestDataSet("kREVETkREVETKA INTO SEkREVETKA INTO SERA aleffRA alefkREVETKA INTO SERA alefffKA kREVETKA INTO SERA aleffIN SkREVETKA INTO SERA aleffEA alef", "kkREVETKA kREVETKA INTO SERA aleffINTO SERA aleffREVkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffETKA INTO SERA aleff", 1232),
            new TestDataSet("kREkREVETKA INTO SERA aleff VETKkREVETKA INTO SERA aleffA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffEA alef", "kREVETKA INkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffTO SERA aleff", 2132),
            new TestDataSet("kREVkREVETKA IkREVETKA INTO SERA aleffNTO SERA aleffkREVETKA INTO SERA aleffETKA INkREVETKA INTO SERA aleffkREVETKA INTO SERA aleff SEA alef", "kREVETKA INTO SkREVETKA INTO SERA aleffERA kREVETKA INTO SERA aleff aleffkkREVETKA INTO SERA aleffREVETKA INTO SERA aleffkREVETKA INTO SERA aleff", 13222),
            new TestDataSet("kREVETKkREVETkREVETKA INTO SERA aleffKA INTO SERA aleffA IN kREVETKA INTO SERA aleffSEA kREVETKA INTO SERA aleffalef", "kREVETKA INTkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffO SERA aleff", 13222),
           new TestDataSet ("kREVETKA IN SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA alef", "kREVETKA INkREVETKA kREVETKA kREVETKA INTO SEkREVETKA INTO SERA aleffRA aleffINTO SERA aleffINTO SERA aleffTO SERA kREVETKA INTO SERA aleffaleff", 12232),
           new TestDataSet("kREVETKA IN SEA alef kREVETKA INTO kREVETKA INTO SERA aleffSERA aleffkREVETKA INTO SERkREVETKA INTO SERA aleffA aleff", "kREVETKA INTO SERA alef kREVETKA INTO SERkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA alefff", 132),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INkREVETKA INTO SERA aleffTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleff", "kREVETkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffKA INTO SERA aleff kREVETKA INTO SERA aleff", 222),
            new TestDataSet("kREVETKA IN SEA alef kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA al kREVETKA INTO SERA aleffeff", "kREkREVETKA INTO SERA aleff VE kREVETKA INTO SERA aleff TKA kREVETKA INTO SERA aleff INTO SERA aleff", 1232),
            new TestDataSet("kREVETKA IN SEA kREVETKA INT kREVETKA INTO SERA alkREVETKA INTO SERA aleffeffO SERA aleff alkREVETKA INTO SERA aleffef", "kREV kREVETKA INTO kREVETKA INTO SERA aleffSERA kREVETKA INTO SERA aleffaleff kREVETKA INTO SERA aleffETKA INTO SERA aleff", 2222),
            new TestDataSet("kREVETKA IN SEA kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleffalef", "kREVkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffETKA INTO SERA aleff", 13222),
            new TestDataSet("kREVETKA IN  kREVETKA INTO SERA aleffvkREVETKA INTO SERA aleff kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffSEA alef", "kREVETKA INTO S kREVETKA INTO SERA aleff kREVETKA INTO SERA aleffkREVETKA INTO SERA aleff kREVETKA INTO SERA aleffERA aleff", 2222),
            new TestDataSet("kREVkREVETKA INTkREVETKA INTO SERA aleffO SERA akREVETKA INTO SERA aleffleffETKA INkREVETKA INTO SERA aleff SEkREVETKA INTO SERA aleffA alef", "kREVETKA INTkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffO SERA aleff", 1232),
            new TestDataSet("kREVETKA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffEA alef", "kREVETKA INTO SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffRA aleff", 1322),
            new TestDataSet("kREVETkREVETKA INTO SEkREVETKA INTO SERA aleffRA alefkREVETKA INTO SERA alefffKA kREVETKA INTO SERA aleffIN SkREVETKA INTO SERA aleffEA alef", "kkREVETKA kREVETKA INTO SERA aleffINTO SERA aleffREVkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffETKA INTO SERA aleff", 1232),
            new TestDataSet("kREkREVETKA INTO SERA aleff VETKkREVETKA INTO SERA aleffA IN SkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffEA alef", "kREVETKA INkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffTO SERA aleff", 2132),
            new TestDataSet("kREVkREVETKA IkREVETKA INTO SERA aleffNTO SERA aleffkREVETKA INTO SERA aleffETKA INkREVETKA INTO SERA aleffkREVETKA INTO SERA aleff SEA alef", "kREVETKA INTO SkREVETKA INTO SERA aleffERA kREVETKA INTO SERA aleff aleffkkREVETKA INTO SERA aleffREVETKA INTO SERA aleffkREVETKA INTO SERA aleff", 13222),
            new TestDataSet("kREVETKkREVETkREVETKA INTO SERA aleffKA INTO SERA aleffA IN kREVETKA INTO SERA aleffSEA kREVETKA INTO SERA aleffalef", "kREVETKA INTkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffO SERA aleff", 13222),
           new TestDataSet ("kREVETKA IN SEkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffkREVETKA INTO SERA aleffA alef", "kREVETKA INkREVETKA kREVETKA kREVETKA INTO SEkREVETKA INTO SERA aleffRA aleffINTO SERA aleffINTO SERA aleffTO SERA kREVETKA INTO SERA aleffaleff", 12232)
        };

        [GlobalSetup]
        public void GlobalSetup()
        {

        }

        [Benchmark]
        public void Substring()
        {
            for (int i = 0; i < data.Count; i++)
            {
                var l = data[i].LenMax; var f = data[i].First; var s = data[i].Second;
                var a = IndistinctMatchingHelper.IndistinctMatching(l, f, s);
                //Console.WriteLine($"STR {f} && {s} = {a}");
            }
        }

        [Benchmark]
        public void ReadOnlySpan()
        {
            for (int i = 0; i < data.Count; i++)
            {
                var l = data[i].LenMax; var f = data[i].First; var s = data[i].Second;
                var a = IndistinctMatcher.FindIndistinctMatching(l, f, s);
                //Console.WriteLine($"SPAN {f} && {s} = {a}");
            }
        }

        //[Benchmark]
        //public void SpanClass()
        //{
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        var l = data[i].LenMax; var f = data[i].First; var s = data[i].Second;
        //        var a = IndistinctMatcherClass.FindIndistinctMatching(l, f, s);
        //        //Console.WriteLine($"SPAN {f} && {s} = {a}");
        //    }
        //}

        //[Benchmark]
        //public void SpanTuple()
        //{
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        var l = data[i].LenMax; var f = data[i].First; var s = data[i].Second;
        //        var a = IndistinctMatcherTuple.FindIndistinctMatching(l, f, s);
        //        //Console.WriteLine($"SPAN {f} && {s} = {a}");
        //    }
        //}
    }
}
