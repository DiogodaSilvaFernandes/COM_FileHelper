using System.IO;

namespace InOutLib
{
    public class CsvHelper : FileHelper
    {
        #region private attributs
        //TODO Private attributs - 2pts
        private char _separator;
        private List<char> _supportedSeparators = new List<char>();
        #endregion private attributs

        #region constructor
        public CsvHelper(string path, string fileName, char separator = ';') : base(path, fileName)
        {
            //TODO Constructor - 3pts
            //if(!IsCharSupported(separator))
                //throw new UnsupportedSeparatorException();

            _separator = separator;
        }
        #endregion constructor

        #region public methods 
        public override void ExtractFileContent()
        {
            //TODO ExtractFileContent - 6pts
            StreamReader streamReader = new StreamReader(_fullPath);

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line == "")
                    throw new StructureException();

                this.Lines.Add(line);
            }
            streamReader.Close();

            if (this.Lines.Count == 0)
            {
                throw new StructureException();
            }
        }
        #endregion public methods

        #region private methods
        private bool IsCharSupported(char separator)
        {
            //TODO IsCharSupported - 2pts
            if(!_supportedSeparators.Contains(separator))
                return false;

            return true;
        }
        #endregion privates methods

        #region nested classes
        public class CsvHelperException : FileHelperException{}
        public class UnsupportedSeparatorException : CsvHelperException { }
        public class StructureException : CsvHelperException { }
        #endregion nested classes
    }
}
