using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTestsGenerator
{
    class Client
    {
        private static TestDimensionsForm testDimensionsForm;
        
        static void Main(string[] args)
        {
            testDimensionsForm = new TestDimensionsForm();
            testDimensionsForm.ShowDialog();
        }
    }
}
