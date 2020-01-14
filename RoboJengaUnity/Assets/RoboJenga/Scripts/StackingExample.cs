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

    ICamera _camera;
    int _count = 0;

    public StackingExample(Mode mode)
    {
        if (mode == Mode.Live)
            _camera = new MotiveCamera();
        else
            _camera = new VirtualCamera();
    }

    public PickAndPlaceData GetNextTargets()
    {
        var tiles = _camera.GetTiles(new Rect(0, 0, 1.4f, 0.8f));

        if (tiles == null)
        {
            Message = "Camera error.";
            return null;
        }

        if (tiles.Count == 0)
        {
            Message = "No tiles found.";
            return null;
        }

        var pick = tiles[0];
        var place = pick;
        place.position.x += 0.7f;
        place.position.y += 0.045f * _count;
        Display.Add(place);
        Message = $"Placing tile number {_count + 1 }";

        _count++;


        return new PickAndPlaceData() { Pick = pick, Place = place };
    }
}
