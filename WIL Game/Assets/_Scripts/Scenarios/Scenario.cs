public struct Scenario
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Difficulty { get; set; }
    public int ControversialPoints { get; set; }
    public int CleanPoints { get; set; }

    public Scenario(int id, string text, int difficulty, int controversialPoints, int cleanPoints)
    {
        Id = id;
        Text = text;
        Difficulty = difficulty;
        ControversialPoints = controversialPoints;
        CleanPoints = cleanPoints;
    }

    /// <summary>
    /// Fluent builder pattern. To learn about it watch this video from git-amend: https://www.youtube.com/watch?v=Wud_ooJKdzU
    /// This can be used to instantiate a scenario instead of calling the constructor.
    /// It just helps with code readability, nothing else.
    /// </summary>
    public struct Builder
    {
        private int _id;
        private string _text;
        private int _difficulty;
        private int _controversialPoints;
        private int _cleanPoints;

        public Builder WithId(int id)
        {
            this._id = id;
            return this;
        }
        public Builder WithText(string text)
        {
            this._text = text;
            return this;
        }
        public Builder WithDifficulty(int difficulty)
        {
            this._difficulty = difficulty;
            return this;
        }
        public Builder WithControversialPoints(int controversialPoints)
        {
            this._controversialPoints = controversialPoints;
            return this;
        }
        public Builder WithCleanPoints(int cleanPoints)
        {
            this._cleanPoints = cleanPoints;
            return this;
        }
        
        public Scenario Build()
        {
            return new Scenario(_id, _text, _difficulty, _controversialPoints, _cleanPoints);
        }
    }
}

