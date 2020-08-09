using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Villix.CacheIn.Core;
using Villix.CacheIn.Core.Writer.Helpers;

namespace Villix.CacheIn.Testing
{
    class Program
    { 
        static void Main(string[] args)
        {
            var person = new Person { Name = "Dominic", Age = 14 };
            ICacheObject obj = new CacheObject(person, nameof(person));
        }

    }
}
