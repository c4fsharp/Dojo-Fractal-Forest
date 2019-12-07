open System

let path = __SOURCE_DIRECTORY__ + "/trees.html"

let width = 500
let height = 500

let inTemplate' width height content =
    sprintf """
<html>
<body>
    <h1>Fractal Trees & F#!</h1>
    <svg width="%i" height="%i">
%s
    </svg>
</body>
</html>""" width height content

let inTemplate content = inTemplate' width height content

let svgLine (x1,y1,x2,y2,width) =
    sprintf
        """<line x1="%.1f" y1="%.1f" x2="%.1f" y2="%.1f" stroke="black" stroke-width="%.1f" />"""
        x1 y1 x2 y2 width

// Compute the endpoint of a line
// starting at x, y, going at a certain angle
// for a certain length.
let endpoint x y angle length =
    x + length * cos angle,
    y + length * sin angle

let flip x = (float)height - x

let drawLine (x : float) (y : float)
             (angle : float) (length : float) (width : float) =
    let x_end, y_end = endpoint x y angle length
    let xo,yo = (single)x, (single)(y |> flip)
    let xd,yd = (single)x_end, (single)(y_end |> flip)
    svgLine(xo, yo, xd, yd, (single)width)


let draw x y angle length width =
    drawLine x y angle length width

let pi = Math.PI

// Now... your turn to draw

let maxDepth = 7

let branch (curDepth:int)
               (x : float) (y : float)
               (ang : float) (len : float) (wid : float) =
    let rec branch' lines (curDepth:int)
               (x : float) (y : float)
               (ang : float) (len : float) (wid : float) =
       // we draw the current segment
       let lines' = draw x y ang len wid::lines
       // if max depth hasn't been reached yet,
       // we create 2 branches and keep going
       if (curDepth > maxDepth)
       then lines'
       else
           // compute end coordinates of current segment
           let x',y' = endpoint x y ang len
           // go left
           branch' lines' (curDepth + 1) x' y' (ang + 0.3) (len * 0.8) (wid * 0.7)
           // go right
           @ branch' lines' (curDepth + 1) x' y' (ang - 0.3) (len * 0.8) (wid * 0.7)

    branch' [] curDepth x y ang len wid
let lines = branch 0 250. 50. (pi*(0.5)) 90.0 10.

let betterTree =
    lines
    |> String.concat "\n"
    |> inTemplate
System.IO.File.WriteAllText(path,betterTree)