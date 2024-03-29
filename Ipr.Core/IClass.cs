using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipr.Core
{
    public interface IClass
    {
        string Name { get; set; }

        string LastName { get; set; }
    }

    public interface IBigClass: IClass
    {
        DateTime LastModified { get; set; }

        string SomeString { get; set; }
    }

    public record MyClass : IClass
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }

    public record MyBigClass: IBigClass
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime LastModified { get; set; }

        public string SomeString { get; set; }
    }
}
