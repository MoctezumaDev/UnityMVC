using UnityEngine;
using System.Collections;

namespace UnityMVC
{
    class MockupModel : Model
    {
        public string foostg;

        public MockupModel(string foo)
        {
            foostg = foo;
        }
    }
}