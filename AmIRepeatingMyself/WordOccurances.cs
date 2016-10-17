namespace AmIRepeatingMyself
{
    public class WordOccurances
    {
        public WordOccurances(int occurances, string word)
        {            
            Occurances = occurances;
            Word = word;
        }

        public string Word { get; private set; }
        public int Occurances { get; private set; }

        public override string ToString()
        {
            return $"{Occurances:d2} {Word}";
        }

        public override bool Equals(object obj)
        {
            var other = obj as WordOccurances;
            if (other == null)
                return false;
            return Word == other.Word && Occurances == other.Occurances;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
