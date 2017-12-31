using UnityEngine;
using System.Collections;

public class BasicController : UnityMVC.Controller<BasicView,BasicModel> {
    public override void Ready()
    {
        this._view.text.text = this._model.Name;
    }
}
