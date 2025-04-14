using NUnit.Framework;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using System.Collections.Generic;
using System;

public class CustomDoubleLinkedList<T> : DoubleLinkedList<Turn>
{
    Node<Turn> peak;
    int peakIndex;



    public override void Add(Turn value)
    {
        Node<Turn> newNode = new Node<Turn>(value);

        if (head == null)
        {
            head = newNode;
            last = newNode;
            peak = last;
            peakIndex = 0;
            count = 1;
            return;
        }


        if (peak == last)
        {
            last.SetNext(newNode);
            newNode.SetPrev(last);
            last = newNode;
            peak = last;
            count++;
        }
        else
        {

            Node<Turn> current = peak.Next;
            while (current != null)
            {
                Node<Turn> toDelete = current;
                current = current.Next;

                toDelete.SetPrev(null);
                toDelete.SetNext(null);
                count--;
            }

            peak.SetNext(newNode);
            newNode.SetPrev(peak);
            last = newNode;
            peak = last;
            count++;


            peakIndex = count - 1;
            newNode.Value.CurrentTurn = count;
        }
    }




    public void PeakNext()
    {
        if (head == null)
            return;

        Node<Turn> currentNode = SeekNext(peak.Value);
        if(currentNode != null ) 
        {
            peak = currentNode;
            peakIndex++;


        }
            
            

    }

    public void PeakPrev()
    {
        if (head == null) return;

        Node<Turn> currentNode = SeekPrev(peak.Value);
        if (currentNode != null)
        {
            peak = currentNode;
            peakIndex--;
        }
    }
    

    public string GetPeak()
    {
        string data = "La informaciond del turno es: " + "Posicion del Turno: " + peak.Value.CurrentTurn;
        for (int i = 0; i < peak.Value.ListEntities.count; i++)
        {
            Node<Entity> currentEntity = peak.Value.ListEntities.head;
           data += "Posicion de entidad: "+  currentEntity.Value.Position;
            data += " Vida de la entidad: " + currentEntity.Value.Life;
            currentEntity = currentEntity.Next;
        }
        return data;
    }

   public void ResetPeak()
    {
        if (peak == null) return;

        peak.Value.CurrentTurn = 0;
        peak.Value.ListEntities = null;


    }
}
