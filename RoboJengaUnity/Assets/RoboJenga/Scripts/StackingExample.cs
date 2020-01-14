using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class StackingExample : IStackable
{
    public string Message { get; set; }
    public ICollection<Pose> Display { get; set; } = new List<Pose>();

    // board size: 1400 x 800 // mid: 700 x 400
    // block size: 180 x 45 x 60

    int _count = 0;

    public StackingExample(Mode mode)
    {

    }

    public PickAndPlaceData GetNextTargets()
    {
        var pick = new Pose(new Vector3(0.35f, 0.045f, 0.4f), Quaternion.Euler(0, 45, 0));
        var place = pick;
        place.position.x += 0.7f;
        place.position.y += 0.045f * _count;
        Display.Add(place);
        Message = $"Placing tile number {_count +1 }";

        _count++;
        return new PickAndPlaceData() { Pick = pick, Place = place };
    }
}
