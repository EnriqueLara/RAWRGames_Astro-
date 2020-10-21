using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
     Transform target;
    [SerializeField] HealthManager health;
    [SerializeField] Image fillimage;
    [SerializeField] Image fillImageTransition;
    // Start is called before the first frame update

    void Start()
    {
        target = FindObjectOfType<CameraFollow>().gameObject.transform;
        fillimage.gameObject.SetActive(false);
        fillImageTransition.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!health) Debug.LogError("no hay health");

        if (health.GetHealth() == health.GetMaxHealth()) return;

        fillimage.gameObject.SetActive(true);
        fillImageTransition.gameObject.SetActive(true);
        LookAt(target.transform);
        ScaleImage();
        scaleTransitionImage();
    }

    private void LookAt(Transform _target)
    {
        var lookPos = _target.position - transform.position;
        lookPos.x = 0;
        lookPos.z = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);
    }

    private float CalculateImageScale(float _healt, float _maxhealth)
    {
        return _healt / _maxhealth;

    }
    private void ScaleImage()
    {
        //fillimage.transform.localScale = new Vector3(CalculateImageScale(stats.GetHealth(),stats.GetmaxHealth()), 1, 1);
        fillimage.fillAmount = CalculateImageScale(health.GetHealth(), health.GetMaxHealth());
        
    }
    private void scaleTransitionImage()
    {
        //fillImageTransition.transform.localScale = Vector3.Lerp(fillImageTransition.transform.localScale, fillimage.transform.localScale, Time.deltaTime * 10);
        fillImageTransition.fillAmount = Mathf.Lerp(fillImageTransition.fillAmount, fillimage.fillAmount, Time.deltaTime * 10);
    }
}
