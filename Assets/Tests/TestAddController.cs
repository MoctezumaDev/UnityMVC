using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace UnityMVC
{
    public class TestAddController
    {
        GameObject mapper;
        GameObject view;

        [OneTimeSetUp]
        public void Init()
        {
            mapper = new GameObject();
            mapper.AddComponent<MockupMapper>();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            GameObject.Destroy(mapper);
        }

        [SetUp]
        public void SetUp()
        {
            view = new GameObject();
            view.AddComponent<MockupView>();
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(view);
        }

        [UnityTest]
        public IEnumerator TestControllerInstance()
        {
            view.AddComponent<MockupModel>();

            yield return new WaitForEndOfFrame();

            MockupController controllerComponent = view.GetComponent<MockupController>();
            Assert.IsNotNull(controllerComponent);
        }

        [UnityTest]
        public IEnumerator TestModelToViewAssignation()
        {
            MockupModel modelComponent = view.AddComponent<MockupModel>();
            modelComponent.foostg = "foostg";

            yield return new WaitForEndOfFrame();

            MockupView viewComponent = view.GetComponent<MockupView>();

            Assert.AreEqual(viewComponent.text, "foostg");
        }
    }
}
