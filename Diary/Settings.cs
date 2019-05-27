using System.Collections.Generic;

class Settings
{
    protected int languaje;
    protected Dictionary<string, string> dictionary;

    public Settings()
    {
        languaje = 0;
        loadSettings();
        //Console.Write(dictionaries["Espanish"].Add();
    }

    protected void loadSettings()
    {
        foreach (KeyValuePair<string, string> entry in dictionary)
        {
            
        }
    }

    protected void save()
    {

    }

    protected void loadDictionary(int lang)
    {

    }

    public int GetLanguaje() { return languaje; }
    public string GetTranslate()
    {
        return "";
    }
}