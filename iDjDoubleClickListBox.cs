namespace iDj;

public class iDjDoubleClickListBox : ListBox
{
    private const int WM_LBUTTONDOWN = 0x201;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_LBUTTONDOWN)
        {
            return; // Ignore single left-clicks but allow other messages to be processed
        }

        base.WndProc(ref m);
    }
}

