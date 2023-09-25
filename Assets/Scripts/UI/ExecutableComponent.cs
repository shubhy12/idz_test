using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecutableComponent : MonoBehaviour
{

    public Button removeBtn;
    public void OnClickRemove()
    {
        LevelController.Instance.executableContainer.DeleteCommandFromSequence(transform.parent, transform);
    }

}
