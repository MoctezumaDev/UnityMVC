/* UnityMVC
 *
 * Copyright (C) 2016 Leon Moctezuma <leon.moctezuma@gmail.com>
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 */

using UnityEngine;
using System.Collections;

namespace UnityMVC
{
    public abstract class Controller<V, M> : MonoBehaviour
        where V : View
        where M : Model
    {
        protected V _view;
        protected M _model;

        public void SetModelView(M model, V view)
        {
            if (view == null) throw new System.ArgumentException("The view was not set");
            if (model == null) throw new System.ArgumentException("The model was not set");
            _view = view;
            _model = model;
            Ready();            
        }

        public abstract void Ready();
    }
}
