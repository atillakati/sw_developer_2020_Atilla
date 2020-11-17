using System;

namespace ArticleExample
{
    public class Artikel
    {
        private string _bezeichnung;
        private Guid _code;
        private decimal _preis;
        private ArtikelStatus _status;

        public Artikel(string bezeichnung, decimal preis)
        {
            _bezeichnung = bezeichnung;
            _preis = preis;

            _status = ArtikelStatus.Available;
            _code = Guid.NewGuid();
        }

        public string Bezeichnung
        {
            get { return _bezeichnung; }
            set { _bezeichnung = value; }
        }

        public Guid Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public decimal Preis
        {
            get { return _preis; }
            set { _preis = value; }
        }
        public ArtikelStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string GetInfoString()
        {
            string tmp = $"{_bezeichnung}\nArtNr: {_code} - [{_status}]\n";
            return tmp;
        }
    }
}