using System;
using System.Drawing;
using System.Windows.Forms;

public class DrawableRectangle : Panel
{
    private Color borderColor = Color.Black; // Default border color
    private int borderWidth = 1; // Default border width

    public DrawableRectangle()
    {
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.SupportsTransparentBackColor, true);

        this.BackColor = Color.Transparent; // Ensure background is transparent
        this.Size = new Size(100, 100);     // Default rectangle size
        this.Cursor = Cursors.Default;      // Default cursor (no drag behavior)
    }

    // Property to change the border color
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            this.Invalidate(); // Redraw the control
        }
    }

    // Property to set border width
    public int BorderWidth
    {
        get => borderWidth;
        set
        {
            borderWidth = Math.Max(1, value); // Ensure border width is at least 1
            this.Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (Pen pen = new Pen(borderColor, borderWidth))
        {
            // Draw the rectangle border
            e.Graphics.DrawRectangle(pen, borderWidth / 2, borderWidth / 2,
                this.Width - borderWidth, this.Height - borderWidth);
        }
    }

    // Prevent movement or dragging by overriding mouse events without logic
    protected override void OnMouseDown(MouseEventArgs e)
    {
        // No drag logic
        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        // No drag logic
        base.OnMouseMove(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        // No drag logic
        base.OnMouseUp(e);
    }
}
