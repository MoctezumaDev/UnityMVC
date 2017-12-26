/* UnityMVC
 *
 * Copyright (C) 2016 Leon Moctezuma <leon.moctezuma@gmail.com>
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 */

using UnityEngine;
using System.Collections.Generic;
using System;

namespace UnityMVC
{ 
    public abstract class Mapper: MonoBehaviour {

        private static Dictionary<IModelView, Action<GameObject, Model>> _dictionary;
        private static Mapper _instance = null;

        static Mapper()
        {
            _dictionary = new Dictionary<IModelView, Action<GameObject, Model>>();
        }

        void Awake()
        {
            StartMapping();
            if (_instance == null)
            {
                _instance = this;
            }
        }

        protected abstract void StartMapping();

	    public static void Map<M,V,C>()
            where M : Model
            where V : View
            where C : Controller<V,M>
        {
            _dictionary.Add( new ModelView<M,V>(), (GameObject go, Model model) =>
            {
                V view = go.GetComponent<V>();
                if (view != null)
                {
                    C controller = view.gameObject.GetComponent<C>();
                    if(controller == null)
                    {
                        controller = view.gameObject.AddComponent<C>();
                    }
                    controller.SetModelView((M)model, view);
                }
            });
        }

        public static void OnModelEnabled(Model model)
        {
            foreach(IModelView key in _dictionary.Keys)
            {
                System.Type modelType = model.GetType();
                if(key.ModelType.IsAssignableFrom(modelType))
                {
                    _dictionary[key](model.gameObject, model);
                }
            }
        }

        public static void OnModelDiasbled(Model model)
        {

        }

    }
}
