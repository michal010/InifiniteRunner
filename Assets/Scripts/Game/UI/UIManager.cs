using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager
{

}

[FromFactory("UIManager")]
public class UIManager : MonoBehaviour, IUIManager
{

}
