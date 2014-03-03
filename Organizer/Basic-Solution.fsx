open System
open System.Drawing
open System.Windows.Forms

// Create a form to display the graphics
let width, height = 500, 500         
let form = new Form(Width = width, Height = height)
let box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let image = new Bitmap(width, height)
let graphics = Graphics.FromImage(image)
graphics.SmoothingMode <- System.Drawing.Drawing2D.SmoothingMode.HighQuality
let brush = new SolidBrush(Color.FromArgb(0, 0, 0))

box.Image <- image
form.Controls.Add(box) 

// Compute the endpoint of a line
// starting at x, y, going at a certain angle
// for a certain length. 
let endpoint x y angle length =
    x + length * cos angle,
    y + length * sin angle

let flip x = (float)height - x

// Utility function: draw a line of given width, 
// starting from x, y
// going at a certain angle, for a certain length.
let drawLine (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (angle : float) (length : float) (width : float) =
    let x_end, y_end = endpoint x y angle length
    let origin = new PointF((single)x, (single)(y |> flip))
    let destination = new PointF((single)x_end, (single)(y_end |> flip))
    let pen = new Pen(brush, (single)width)
    target.DrawLine(pen, origin, destination)

let draw x y angle length width = 
    drawLine graphics brush x y angle length width

let pi = Math.PI

// Now... your turn to draw

let maxDepth = 7

let rec branch (curDepth:int)
               (x : float) (y : float) 
               (ang : float) (len : float) (wid : float) =
                   // we draw the current segment
                   draw x y ang len wid
                   // if max depth hasn't been reached yet,
                   // we create 2 branches and keep going
                   if (curDepth > maxDepth)
                   then ignore ()
                   else
                       // compute end coordinates of current segment
                       let x',y' = endpoint x y ang len
                       // go left
                       branch (curDepth + 1) x' y' (ang + 0.3) (len * 0.8) (wid * 0.7)
                       // go right
                       branch (curDepth + 1) x' y' (ang - 0.3) (len * 0.8) (wid * 0.7)

branch 0 250. 50. (pi*(0.5)) 90.0 10.
form.ShowDialog()