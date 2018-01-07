//  UnityMVC
//  
//  Copyright (C) 2016-2018 Leon Moctezuma <leon.moctezuma@gmail.com>
//  
//  This software may be modified and distributed under the terms
//  of the MIT license.  See the LICENSE file for details.

namespace UnityMVC
{
    public interface IModelView
    {
        System.Type ModelType { get; }
        System.Type ViewType { get; }
    }

    public class ModelView<M, V> : IModelView
        where M : Model
        where V : View
    {
        readonly System.Type _modelType = typeof(M);
        readonly System.Type _viewType = typeof(V);

        public System.Type ModelType
        {
            get { return _modelType; }
        }

        public System.Type ViewType
        {
            get { return _viewType; }
        }
    }
}