using UnityEngine;

public class Turn
{
    private int currentTurn;
    DoubleLinkedList<Entity> listEntitys;

    public int CurrentTurn { set { currentTurn = value; } get { return currentTurn; }  }
    public DoubleLinkedList<Entity> ListEntities { set { listEntitys = value; } get { return listEntitys; } }

    public Turn()
    {
        listEntitys = new DoubleLinkedList<Entity>();
        currentTurn = 0;
    }
    
}
