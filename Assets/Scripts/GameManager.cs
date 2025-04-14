using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CustomDoubleLinkedList<Turn> listTurns;
    private int turnValue;



    private void Start()
    {
       listTurns = setTurns( 10, 1);
        listTurns.PeakPrev();
        listTurns.PeakPrev();
        listTurns.PeakPrev();
        listTurns.Add(new Turn());
        print(listTurns.count);
        print(listTurns.GetPeak());
       
        
    }

    void SetEntitys(Turn turn, int numEntitys)
    {
        for (int i = 0; i < numEntitys; i++)
        {
            Entity entity = new Entity();
            entity.Position = new Vector2(Random.Range(0, 10f), Random.Range(0, 10f));
            entity.Life = Random.Range(0, 100);
            turn.ListEntities.Add(entity);
            
        }
        
    }
    CustomDoubleLinkedList<Turn> setTurns( int numTurns, int numEntitys)
    {

        CustomDoubleLinkedList<Turn> newList = new CustomDoubleLinkedList<Turn> ();
            for (int i = 0; i < numTurns; i++)
            {
                Turn turn = new Turn();
                SetEntitys(turn , numEntitys);
                newList.Add(turn);
                
            }

           
           return newList;
    }


}
