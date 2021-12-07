using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WordDoc : IDisposable
    {
        Application _word = null;

        public WordDoc()
        {
            _word = new Application() { Visible = false };
        }

        public void CreateDocument()
        {
            var doc = _word.Documents.Add();
            doc.Activate();
        }

        public void AppendText(string text, bool bold, bool italic)
        {
            var location = _word.ActiveDocument.Range(_word.ActiveDocument.Content.End - 1);

            location.Bold = bold ? 1 : 0;
            location.Italic = italic ? 1 : 0;
            location.InsertAfter(text);
        }

        public void SaveAs(string location)
        {
            var document = _word.ActiveDocument;
            document.SaveAs2(location);
            document.Close();
        }

        public void Dispose()
        {
            if(_word != null)
            {
                _word.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_word);
                _word = null;
                GC.SuppressFinalize(this);
            }
        }
    }
}
