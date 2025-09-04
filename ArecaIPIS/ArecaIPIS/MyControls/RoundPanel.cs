using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArecaIPIS.MyControls
{
    class RoundPanel : Panel
    {
        private int _cornerRadius = 20; // Default corner radius

        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                this.Invalidate(); // Redraw the panel when the radius changes
            }
        }

        public RoundPanel()
        {
            this.BackColor = Color.White; // Default background color
            this.ResizeRedraw = true; // Redraw when resized
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion(); // Update the region dynamically when the size changes
        }

        private void UpdateRegion()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = this.ClientRectangle;
                int radius = Math.Min(_cornerRadius, Math.Min(rect.Width, rect.Height) / 2);

                // Create rounded rectangle path
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
                path.CloseFigure();

                // Set the panel's region to the rounded rectangle
                this.Region = new Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Enable anti-aliasing for smoother edges
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Optional: Draw border
            using (Pen borderPen = new Pen(Color.Gray, 1))
            {
                Rectangle rect = this.ClientRectangle;
                int radius = Math.Min(_cornerRadius, Math.Min(rect.Width, rect.Height) / 2);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
                    path.CloseFigure();

                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }
    }
}
