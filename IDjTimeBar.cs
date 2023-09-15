// Copyright (c) 2023 Fox Council - iDj - https://github.com/FoxCouncil/iDj

using System.Drawing.Drawing2D;

namespace iDj;

public class IDjTimeBar : ProgressBar
{
    private string text = string.Empty;

    public new string Text
    {
        get { return text; }
        set { text = value; Invalidate(); }
    }

    public IDjTimeBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);

        Font = new Font("Consolas", 9);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var rect = ClientRectangle;
        var g = e.Graphics;

        using (var brush = new SolidBrush(Color.LightGray))
        {
            g.FillRectangle(brush, rect);
        }

        rect.Inflate(-1, -1);

        using (var brush = new SolidBrush(Color.Black))
        {
            g.FillRectangle(brush, rect);
        }

        if (Value > 0)
        {
            var clip = new Rectangle(rect.X, rect.Y, (int)Math.Round((float)Value / Maximum * rect.Width), rect.Height);

            g.FillRectangle(Brushes.DarkRed, clip);
        }

        using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        
        g.DrawString(text, Font, Brushes.White, rect, sf);
    }
}

