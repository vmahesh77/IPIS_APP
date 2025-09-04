using System;
using System.Drawing;
using System.Windows.Forms;

public class MovablePanel : Panel
{
    private bool isDragging = false;  // Tracks if the panel is being dragged
    private Point dragStartPoint;    // Starting point of the drag operation

    private Color borderColor = Color.Black; // Default border color
    private int borderWidth = 2;             // Default border width

    public MovablePanel()
    {
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.SupportsTransparentBackColor, true);

        this.BackColor = Color.LightGray; // Default background color
        this.Size = new Size(100, 100);   // Default panel size
        this.Cursor = Cursors.Hand;      // Cursor indicates the panel is draggable
    }

    // Property to customize the border color
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            this.Invalidate(); // Trigger a repaint
        }
    }

    // Property to customize the border width
    public int BorderWidth
    {
        get => borderWidth;
        set
        {
            borderWidth = Math.Max(1, value); // Ensure the border width is at least 1
            this.Invalidate(); // Trigger a repaint
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (Pen pen = new Pen(borderColor, borderWidth))
        {
            // Draw the border inside the panel
            e.Graphics.DrawRectangle(pen, borderWidth / 2, borderWidth / 2,
                this.Width - borderWidth, this.Height - borderWidth);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;            // Start dragging
            dragStartPoint = e.Location; // Record the starting mouse position
            this.Capture = true;         // Capture mouse events
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (isDragging)
        {
            // Calculate new position
            int newX = this.Left + e.X - dragStartPoint.X;
            int newY = this.Top + e.Y - dragStartPoint.Y;

            // Update the panel's position
            this.Location = new Point(newX, newY);
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;  // Stop dragging
            this.Capture = false; // Release mouse capture
        }
    }
}
