using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CustomDoubleLinkedList<Turn> ListTurns =new CustomDoubleLinkedList<Turn>();
    private Entity entity1;
    private Entity entity2;
  

    
    
    private void Start()
    {
        entity1.EntityName = "Jorge";
        entity1.Position = new Vector2(Random.Range(0,10), Random.Range(0,10));


        print(entity1.EntityName);
    }


 

 


}
