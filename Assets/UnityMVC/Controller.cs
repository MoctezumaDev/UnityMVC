//  UnityMVC
//  
//  Copyright (C) 2016-2018 Leon Moctezuma <leon.moctezuma@gmail.com>
//  
//  This software may be modified and distributed under the terms
//  of the MIT license.  See the LICENSE file for details.

using UnityEngine;

namespace UnityMVC
{
    public abstract class Controller<TView, TModel> : MonoBehaviour
        where TView : View
        where TModel : Model
    {
        protected TModel model;
        protected TView view;

        public abstract void Ready();

        public void SetModelView(TModel modelInstance, TView viewInstance)
        {
            if (modelInstance == null) throw new System.ArgumentException("The view was not set");
            if (viewInstance == null) throw new System.ArgumentException("The model was not set");
            view = viewInstance;
            model = modelInstance;
            Ready();
        }
    }
}