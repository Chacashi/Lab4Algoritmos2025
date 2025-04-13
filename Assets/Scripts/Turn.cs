using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private int currentTurn;
    DoubleLinkedList<Entity> ListEntitys = new DoubleLinkedList<Entity>();

    public int CurrentTurn {set; get;}
    public DoubleLinkedList<Entity> ListEntities { set; get;}
    
}
