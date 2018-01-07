//  UnityMVC
//  
//  Copyright (C) 2016-2018 Leon Moctezuma <leon.moctezuma@gmail.com>
//  
//  This software may be modified and distributed under the terms
//  of the MIT license.  See the LICENSE file for details.

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace UnityMVC
{
    public class TestAddController
    {
        GameObject _mapper;
        GameObject _view;

        [OneTimeTearDown]
        public void CleanUp()
        {
            Object.Destroy(_mapper);
        }

        [OneTimeSetUp]
        public void Init()
        {
            _mapper = new GameObject();
            _mapper.AddComponent<MockupMapper>();
        }

        [SetUp]
        public void SetUp()
        {
            _view = new GameObject();
            _view.AddComponent<MockupView>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_view);
        }

        [UnityTest]
        public IEnumerator TestControllerInstance()
        {
            _view.AddComponent<MockupModel>();

            yield return new WaitForEndOfFrame();

            MockupController controllerComponent = _view.GetComponent<MockupController>();
            Assert.IsNotNull(controllerComponent);
        }

        [UnityTest]
        public IEnumerator TestModelToViewAssignation()
        {
            MockupModel modelComponent = _view.AddComponent<MockupModel>();
            modelComponent.foostg = "foostg";

            yield return new WaitForEndOfFrame();

            MockupView viewComponent = _view.GetComponent<MockupView>();

            Assert.AreEqual(viewComponent.text, "foostg");
        }
    }
}