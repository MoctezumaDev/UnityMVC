using UnityEngine;
using System.Collections;

namespace UnityMVC
{
    class MockupMapper : Mapper
    {
        protected override void StartMapping()
        {
            Map<MockupModel, MockupView, MockupController>();
        }
    }
}
