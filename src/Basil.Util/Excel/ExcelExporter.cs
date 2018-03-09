using ExcelExtentions.Core.Argument;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Basil.Util.Excel {
    public class ExcelExporter {
        public void Get(DataTable dt, ExcelArgument arg) {
            new ExcelExtentions.Core.ExcelHelp().Get(dt, arg);
        }
        public void Get(DataSet ds, ExcelArgument arg) {
            new ExcelExtentions.Core.ExcelHelp().Get(ds, arg);
        }
        public void Get(dynamic list, ExcelArgument arg) {
            new ExcelExtentions.Core.ExcelHelp().Get(list, arg);
        }
        public void Get(List<dynamic> lists, ExcelArgument arg) {
            new ExcelExtentions.Core.ExcelHelp().Get(lists, arg);
        }
        public void Get<T>(List<T> list, ExcelArgument arg) {
            new ExcelExtentions.Core.ExcelHelp().Get(list, arg);
        }
        public void Get<T>(List<List<T>> lists, ExcelArgument arg) {
            new ExcelExtentions.Core.ExcelHelp().Get(lists, arg);
        }
        public void GetFromTemplate(DataTable dt, string tempPath, string outPutPath) {
            new ExcelExtentions.Core.ExcelHelp().GetFromTemplate(dt, tempPath, outPutPath);
        }
        public void GetFromTemplate(DataSet ds, string tempPath, string outPutPath) {
            new ExcelExtentions.Core.ExcelHelp().GetFromTemplate(ds, tempPath, outPutPath);
        }
        public void GetFromTemplate(dynamic list, string tempPath, string outPutPath) {
            new ExcelExtentions.Core.ExcelHelp().GetFromTemplate(list, tempPath, outPutPath);
        }
        public void GetFromTemplate(List<dynamic> lists, string tempPath, string outPutPath) {
            new ExcelExtentions.Core.ExcelHelp().GetFromTemplate(lists, tempPath, outPutPath);
        }
        public void GetFromTemplate<T>(List<T> list, string tempPath, string outPutPath) {
            new ExcelExtentions.Core.ExcelHelp().GetFromTemplate(list, tempPath, outPutPath);
        }
        public void GetFromTemplate<T>(List<List<T>> lists, string tempPath, string outPutPath) {
            new ExcelExtentions.Core.ExcelHelp().GetFromTemplate(lists, tempPath, outPutPath);
        }
    }
}
