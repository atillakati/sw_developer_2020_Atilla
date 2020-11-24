using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteKlassen
{
    public class TextFileRepository : DataRepository
    {
        private readonly string _fileName;
        private readonly string _name;
        private readonly int _maxSize;

        public TextFileRepository(string fileName, int maxSize)         
        {
            _fileName = fileName;
            _maxSize = maxSize;
            _name = "Text File Repository";
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override int MaxSize
        {
            get { return _maxSize; }
        }

        public override string Read()
        {
            if (string.IsNullOrWhiteSpace(_fileName) || !File.Exists(_fileName))
            {
                Debug.WriteLine($"Dateiname '{_fileName}' darf nicht leer sein oder Datei nicht gefunden.");
                return string.Empty;
            }

            using(StreamReader sr = new StreamReader(_fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public override void Write(string data)
        {
            //ToDo! Check maxSize of File!

            if (string.IsNullOrWhiteSpace(_fileName))
            {
                Debug.WriteLine($"Dateiname '{_fileName}' darf nicht leer sein.");
                return;
            }

            using(StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.WriteLine(data);
            }
        }
    }
}
