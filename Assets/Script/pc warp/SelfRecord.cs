using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRecord{
    private Queue<Vector3> recordedPosition;
    public Queue<Vector3> RecordedPosition { get { return recordedPosition; } }

    public Vector3 currentPos { get; set; }

    private Queue<Quaternion> recordedRotation;
    public Queue<Quaternion> RecordedRotation { get { return recordedRotation; } }

    // Use this for initialization
    public SelfRecord () {
        recordedPosition = new Queue<Vector3>();
        recordedRotation = new Queue<Quaternion>();
	}

    public void Record(Vector3 pos, Quaternion rotation)
    {
        recordedPosition.Enqueue(pos);
        recordedRotation.Enqueue(rotation);
    }

    public bool Reappear(ref Vector3 position, ref Quaternion rotation)
    {
        if (recordedPosition.Count < 1)
            return false;
        position = recordedPosition.Dequeue();
        currentPos = position;
        rotation = recordedRotation.Dequeue();
        return true;
    }

    public void ClearAll()
    {
        currentPos = Vector3.zero;
        recordedPosition.Clear();
    }
}
