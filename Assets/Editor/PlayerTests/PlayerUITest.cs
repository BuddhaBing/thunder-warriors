using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using NUnit.Framework;

public class PlayerUITest
{
    public GameObject gameObject;
    public PlayerUI model;

    [SetUp]
    public void Init()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<PlayerUI>();
        model = gameObject.GetComponent<PlayerUI>();
        //model.moneyDisplay = new UnityEngine.UI.Text;
    }

    //[Test]
    //public void UpdateMoneyTest()
    //{
    //    var money = 10;
    //    model.UpdateMoney(money);
    //    string moneyDisplayText = "Money: 10";
    //    Assert.AreEqual(moneyDisplayText, model.moneyDisplay.text);
    //}

    // TODO Not currently testable via unit test
}