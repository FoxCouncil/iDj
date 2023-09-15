// Copyright (c) 2023 Fox Council - iDj - https://github.com/FoxCouncil/iDj

using FontAwesome.Sharp;
using Timer = System.Windows.Forms.Timer;

namespace iDj;

public class iDJToggleButton : IconButton
{
    private Color toggleOnColor = Color.Red;
    private Timer pulseTimer;
    private int alphaIncrement = 10;
    private int currentAlpha = 255;
    private bool isToggledOn;

    public Color ToggleOnColor
    {
        get => toggleOnColor;
        set => toggleOnColor = value;
    }

    public iDJToggleButton()
    {
        // Initialize pulse timer
        pulseTimer = new Timer();
        pulseTimer.Interval = 40;
        pulseTimer.Tick += PulseTimer_Tick;

        // Set FlatStyle to enable custom drawing
        FlatStyle = FlatStyle.Flat;
        BackColor = Color.Transparent;
    }

    private void PulseTimer_Tick(object? sender, EventArgs e)
    {
        currentAlpha += alphaIncrement;

        if (currentAlpha >= 255)
        {
            currentAlpha = 255;
            alphaIncrement = -alphaIncrement;
        }
        else if (currentAlpha <= 150)
        {
            currentAlpha = 150;
            alphaIncrement = -alphaIncrement;
        }

        int R = toggleOnColor.R;
        int G = toggleOnColor.G;
        int B = toggleOnColor.B;

        BackColor = Color.FromArgb(Math.Clamp(currentAlpha, 0, 255), R, G, B);
    }

    protected override void OnClick(EventArgs e)
    {
        isToggledOn = !isToggledOn;
        pulseTimer.Enabled = isToggledOn;

        if (!isToggledOn)
        {
            // Reset to default when toggled off
            BackColor = Color.Transparent;
        }

        base.OnClick(e);
    }
}