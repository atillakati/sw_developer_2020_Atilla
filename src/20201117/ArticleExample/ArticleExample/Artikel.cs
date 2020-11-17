namespace ArticleExample
{
    public class Artikel
    {
        private string _bezeichnung;

        public Artikel()
        {

        }

        public string Bezeichnung
        {
            get
            {

                return _bezeichnung;
            }

            set
            {
                if(!string.IsNullOrEmpty(value) || value.Length > 7)
                {
                    _bezeichnung = value;
                }
            }
        }
    }
}