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
    public abstract class Model : MonoBehaviour {

        protected virtual void OnEnable()
        {
            Mapper.OnModelEnabled(this);
        }

        protected virtual void Start()
        {
            Mapper.OnModelEnabled(this);
        }

        protected virtual void OnDisable()
        {
            Mapper.OnModelDiasbled(this);
        }

    }
}
