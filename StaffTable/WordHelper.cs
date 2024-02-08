using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace StaffTable
{
    public class WordHelper
    {
        private FileInfo _fileInfo;
        public WordHelper(string filename) {
            if(File.Exists(filename))
            {
                   _fileInfo = new FileInfo(filename);
            }
            else
            {
                throw new ArgumentException("Файл не найден");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);
                foreach( var item in items )
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;
                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;
                    find.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false, MatchSoundsLike: missing, MatchAllWordForms: false, Forward: false, Wrap: wrap, Format: false, ReplaceWith: missing, Replace: replace);
                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, $"stafftable{items["<StNumber>"]}.docx");
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                
                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                if(app != null)
                app.Quit();
            }
        }
    }
}
