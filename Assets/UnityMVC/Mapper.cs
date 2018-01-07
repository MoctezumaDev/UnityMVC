//  UnityMVC
//  
//  Copyright (C) 2016-2018 Leon Moctezuma <leon.moctezuma@gmail.com>
//  
//  This software may be modified and distributed under the terms
//  of the MIT license.  See the LICENSE file for details.

using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMVC
{
    public abstract class Mapper : MonoBehaviour
    {
        private static Dictionary<IModelView, Action<GameObject, Model>> _dictionary;
        private static Mapper _instance;

        static Mapper() { _dictionary = new Dictionary<IModelView, Action<GameObject, Model>>(); }

        public static void Map<TModel, TView, TController>()
            where TModel : Model
            where TView : View
            where TController : Controller<TView, TModel>
        {
            _dictionary.Add(new ModelView<TModel, TView>(), (go, model) =>
            {
                TView view = go.GetComponent<TView>();
                if (view != null)
                {
                    TController controller = view.gameObject.GetComponent<TController>();
                    if (controller == null)
                    {
                        controller = view.gameObject.AddComponent<TController>();
                    }
                    controller.SetModelView((TModel) model, view);
                }
            });
        }

        public static void OnModelDiasbled(Model model) { }

        public static void OnModelEnabled(Model model)
        {
            foreach (IModelView key in _dictionary.Keys)
            {
                Type modelType = model.GetType();
                if (key.ModelType.IsAssignableFrom(modelType))
                {
                    _dictionary[key](model.gameObject, model);
                }
            }
        }

        protected abstract void StartMapping();

        void Awake()
        {
            StartMapping();
            if (_instance == null)
            {
                _instance = this;
            }
        }
    }
}