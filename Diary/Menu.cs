class Menu
{
    public const int CONTACTS = 1;
    public const int NOTES = 2;
    public const int REMINDERS = 3;
    public const int CALENDAR = 4;
    public const int SETTINGS = 5;
    public const int HELP = 6;
    public const int EXIT = 7;

    protected int actualOption;
    protected int optionSelected;

    public Menu()
    {
        actualOption = 0;
        optionSelected = 1;
    }

    public int GetOptionSelected ()
    {
        return optionSelected;
    }

    public void Run()
    {
        actualOption = 0;
        optionSelected = 1;

        /*do
        {
            SdlHardware.ClearScreen();

            SdlHardware.WriteHiddenText("Contacts",
                460, 400,
                (optionSelected == 1) ? (byte)0xFF : (byte)0x80, (optionSelected == 1) ? (byte)0xFF : (byte)0x80, (optionSelected == 1) ? (byte)0xFF : (byte)0x80,
                font24);
            SdlHardware.WriteHiddenText("Notes",
                489, 440,
                (optionSelected == 2) ? (byte)0xFF : (byte)0x80, (optionSelected == 2) ? (byte)0xFF : (byte)0x80, (optionSelected == 2) ? (byte)0xFF : (byte)0x80,
                font24);
            SdlHardware.WriteHiddenText("Reminders",
                452, 480,
                (optionSelected == 3) ? (byte)0xFF : (byte)0x80, (optionSelected == 3) ? (byte)0xFF : (byte)0x80, (optionSelected == 3) ? (byte)0xFF : (byte)0x80,
                font24);
            SdlHardware.WriteHiddenText("Calendar",
                459, 520,
                (optionSelected == 4) ? (byte)0xFF : (byte)0x80, (optionSelected == 4) ? (byte)0xFF : (byte)0x80, (optionSelected == 4) ? (byte)0xFF : (byte)0x80,
                font24);
            SdlHardware.WriteHiddenText("Settings",
                459, 560,
                (optionSelected == 5) ? (byte)0xFF : (byte)0x80, (optionSelected == 5) ? (byte)0xFF : (byte)0x80, (optionSelected == 5) ? (byte)0xFF : (byte)0x80,
                font24);
            SdlHardware.WriteHiddenText("Help",
                490, 600,
                (optionSelected == 6) ? (byte)0xFF : (byte)0x80, (optionSelected == 6) ? (byte)0xFF : (byte)0x80, (optionSelected == 6) ? (byte)0xFF : (byte)0x80,
                font24);
            SdlHardware.WriteHiddenText("Exit",
                490, 640,
                (optionSelected == 7) ? (byte)0xFF : (byte)0x80, (optionSelected == 7) ? (byte)0xFF : (byte)0x80, (optionSelected == 7) ? (byte)0xFF : (byte)0x80,
                font24);

            SdlHardware.ShowHiddenScreen();

            if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
            {
                if (optionSelected > 1)
                {
                    optionSelected--;
                }
                else
                {
                    optionSelected = 7;
                }
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
            {
                if (optionSelected < 7)
                {
                    optionSelected++;
                }
                else
                {
                    optionSelected = 1;
                }
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_RETURN))
            {
                actualOption = optionSelected;
            }
            SdlHardware.Pause(60);
        }
        while (actualOption == 0);*/
    }
}