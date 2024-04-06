public struct Scenario
{
    public int ID { get; set; }
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public int ControversialPoints { get; set; }
    public int CleanPoints { get; set; }

    public Scenario(int id, string text, int difficulty, int controversialPoints, int cleanPoints)
    {
        ID = id;
        Text = text;
        Difficulty = difficulty;
        ControversialPoints = controversialPoints;
        CleanPoints = cleanPoints;
    }
}