using UnityEngine;
using System.Collections;

namespace UnityMVC
{
    class MockupController : Controller<MockupView,MockupModel>
    {
        public override void Ready()
        {
            this._view.text = this._model.foostg;
        }
    }
}
