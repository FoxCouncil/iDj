using FontAwesome.Sharp;
using Timer = System.Windows.Forms.Timer;

namespace iDj;

public class iDjSpinner : Control
{
    private readonly IconPictureBox pictureBox;
    private readonly Timer timer;

    private float angle = 0.0F;

    public iDjSpinner()
    {
        DoubleBuffered = true;

        pictureBox = new IconPictureBox
        {
            UseGdi = true,
            SizeMode = PictureBoxSizeMode.AutoSize,
            BackColor = Color.Transparent,
            ForeColor = Color.White,
            IconChar = IconChar.CompactDisc,
            IconSize = 200,
        };

        Controls.Add(pictureBox);

        timer = new Timer
        {
            Interval = 16 // Set interval in milliseconds
        };

        timer.Tick += TimerTick;
        timer.Start();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        angle += 10.5f;

        if (angle >= 360)
        {
            angle = 0;
        }

        pictureBox.Rotation = angle;// Forces a repaint to apply rotation
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        // Recalculate the center
        pictureBox.Location = new Point((Width - pictureBox.Width) / 2, (Height - pictureBox.Height) / 2);
    }
}

