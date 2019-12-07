open System

let path = __SOURCE_DIRECTORY__ + "/trees.html"

let width = 500
let height = 500

let inTemplate' width height content =
    sprintf """
<html>
<body>
    <h1>Turtles & F#!</h1>
    <svg width="%i" height="%i">
%s
    </svg>
</body>
</html>""" width height content

let inTemplate content = inTemplate' width height content

let svgLine (x1,y1,x2,y2) =
    sprintf
        """<line x1="%.1f" y1="%.1f" x2="%.1f" y2="%.1f" stroke="black" />"""
        x1 y1 x2 y2

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
    svgLine(xo, yo, xd, yd)



let draw x y angle length width =
    drawLine x y angle length width

let pi = Math.PI

let x, y = endpoint 250. 50. (pi*(0.5)) 100.

let svgLines = [
    draw 250. 50. (pi*(0.5)) 100. 4.
// first and second branches
    draw x y (pi*(0.5 + 0.3)) 50. 2.
    draw x y (pi*(0.5 - 0.4)) 50. 2.
]
// Now... your turn to draw
// The trunk

let svgTree =
    svgLines
    |> String.concat "\n"
    |> inTemplate

System.IO.File.WriteAllText(path,svgTree)


(* To do a nice fractal tree, using recursion is
probably a good idea. The following link might
come in handy if you have never used recursion in F#:
http://en.wikibooks.org/wiki/F_Sharp_Programming/Recursion
*)