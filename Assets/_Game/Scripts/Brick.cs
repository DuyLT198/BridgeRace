using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private ColorTypeSO colorTypeS0;
    [SerializeField] private BoxCollider hitbox;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] ColorType colorType;
    int indexColor;

    private void Start()
    {
        OnInit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ColorType>().IndexColorType() == indexColor)
        {
            OnDespawn();
        } else
        {
            return;
        }
    }
    //Hàm tắt brick
    void OnDespawn()
    {
        //Tắt obj
        gameObject.SetActive(false);
        //Tắt hitbox
        hitbox.enabled = false;
        //Bật lại
        Invoke(nameof(OnInit), 10f);
    }
    //Hàm khởi tạo
    void OnInit()
    {
        colorType.SetRandomColorIndex();
        indexColor = colorType.IndexColorType();
        mesh.material = colorTypeS0.Materials[colorType.IndexColorType()];
        gameObject.SetActive(true);
        hitbox.enabled = true;
        Debug.Log("BrickColorType" + indexColor);
    }
}
