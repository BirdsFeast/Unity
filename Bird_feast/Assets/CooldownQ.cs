using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownQ : MonoBehaviour {

  public Image overlayImage;
  public static float fillPercentage;

  void Update() {
    overlayImage.fillAmount = fillPercentage;
  }
}
