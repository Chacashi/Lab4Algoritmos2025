using UnityEngine;

public class CustomDoubleLinkedList<T> : DoubleLinkedList<Turn>
{
    Node<Turn> peak;
    int peakIndex;



    public override void Add(Turn value)
    {
        Node<Turn> newNode = new Node<Turn>(value);
        count++;

        if(head == null)
        {
            head = newNode;
            last = newNode;
            peak = last;
            peakIndex = 0;
            return;
        }
     
        if(peak != last)
        {
            Node<Turn> currentNode=last;
            while(peak != currentNode)
            {
                Remove(currentNode.Value);
                currentNode = last;
            }
            last.SetNext(newNode);
            newNode.SetPrev(last);
            last = newNode;
            peak = last;
            peakIndex = count - 1;
        }
        else
        {
            last.SetNext(newNode);
            newNode.SetPrev(last);
            last = newNode;
        }

    }

    public void PeakNext()
    {
        if (head == null)
            return;

        else
        {
            Node<Turn> currentNode  = peak;
            currentNode = SeekNext(currentNode.Value);
            if (currentNode != null)
            {
                peak = currentNode;
                peakIndex++;
            } 
            else
                return;
                
        }
            
            

    }

    public void PeakPrev()
    {
        if (head == null)
            return;

        else
        {
            Node<Turn> currentNode = peak;
            currentNode = SeekNext(currentNode.Value);
            if (currentNode != null)
            {
                peak = currentNode;
                peakIndex--;
            }
            else
                return;

        }
    }

    public Node<Turn> GetPeak()
    {
        if (peak == null)
            return null;
        else
            return peak;
    }

   public void ResetPeak()
    {
        if (peak == null)
            return;
        else
        {
            peak.Value.CurrentTurn = 0;
            peak.Value.ListEntities = null;
        }
            

    }
}
