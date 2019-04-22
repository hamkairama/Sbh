using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sbh.Fr.CommonFunction
{
    public class UploadImage
    {
        public string UploadFile(string path, HttpPostedFileBase file)
        {
            string _path = string.Empty, res = string.Empty;
            try
            {
                if (file.ContentLength > 0)
                {
                    /*
                    string _FileName = Path.GetFileName(file.FileName);
                    _path = Path.Combine(path, _FileName);
                    file.SaveAs(_path);
                    */
                    string _FileName = Path.GetFileName(file.FileName);
                    string ext = Path.GetExtension(_FileName);
                    string filenm = _FileName.Split(new string[] { ext }, StringSplitOptions.None)[0];
                    _path = Path.Combine(path, _FileName);
                    file.SaveAs(_path);
                    res = RenameFileUpload(_path, filenm + " " + DateTime.Now.ToString("yyyyMMdd HHmmss") + ext);
                }
            }
            catch { }
            return res;
        }

        public string RenameFileUpload(string FileNameAndPath, string NewName)
        {
            string ret = string.Empty;
            FileInfo fi = new FileInfo(FileNameAndPath);
            if (!fi.Exists)
                return FileNameAndPath;
            try
            {
                string NewFilePathName = Path.Combine(Path.GetDirectoryName(FileNameAndPath), NewName);
                FileInfo f2 = new FileInfo(NewFilePathName);

                if (f2.Exists)
                {
                    f2.Attributes = FileAttributes.Normal;
                    f2.Delete();
                }

                fi.CopyTo(NewFilePathName);
                fi.Delete();
                ret = NewFilePathName;
            }
            catch (Exception e) { }
            return ret;
        }

        public void DeleteFileUpload(string FileNameAndPath)
        {
            string ret = string.Empty;
            if (FileNameAndPath != null)
            {
                FileInfo fi = new FileInfo(FileNameAndPath);
                try
                {
                    fi.Delete();
                }
                catch (Exception e) { }
            }
        }
    }
}
