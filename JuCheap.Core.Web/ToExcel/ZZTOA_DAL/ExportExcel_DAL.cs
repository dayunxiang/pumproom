﻿using JuCheap.Core.Web.ToExcel.ZZTOA_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace JuCheap.Core.Web.ToExcel.ZZTOA_DAL
{
    public class ExportExcel_DAL
    {
        //将datatable导出到excel
        public static ReturnMsg ExportList(ref MemoryStream ms, IList list, int type = 0, string path = "")
        {
            DataTable dt;
            try
            {
                dt = ToDataTable(list);//将数据源转换为datatable类型
                //创建Excel文件的对象
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //添加一个sheet
                NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
                //给sheet1添加第一行的头部标题
                NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                int i = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    row1.CreateCell(i).SetCellValue(column.ColumnName);
                    i++;
                }
                int j = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i = 0;
                    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(j + 1);
                    for (; i < dt.Columns.Count; i++)
                    {
                        rowtemp.CreateCell(i).SetCellValue(dr[i].ToString());
                    }
                    j++;
                }
                if (type == 0)
                {
                    MemoryStream ms1 = new MemoryStream();
                    book.Write(ms1);
                    ms1.Seek(0, SeekOrigin.Begin);
                    ms = ms1;
                }
                else
                {
                    FileStream fs = new FileStream(path, FileMode.Create);
                    book.Write(fs);
                    fs.Close();
                    ms = null;
                }
                return new ReturnMsg() { code = 0, msg = "" };
            }
            catch (Exception ex)
            {
                ms = null;
                return new ReturnMsg() { code = 1, msg = "导出异常：" + ex.Message };
            }
        }
        public static ReturnMsg ExportDataTable(ref MemoryStream ms, DataTable dt, int type = 0, string path = "")
        {
            try
            {
                //创建excel文件的对象
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //添加一个sheet
                NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
                //给sheet1添加第一行的头标题
                NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                int i = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    row1.CreateCell(i).SetCellValue(column.ColumnName);
                    i++;
                }
                int j = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i = 0;
                    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(j + 1);
                    for (; i < dt.Columns.Count; i++)
                    {
                        rowtemp.CreateCell(i).SetCellValue(dr[i].ToString());
                    }
                    j++;
                }
                if (type == 0)
                {
                    MemoryStream ms1 = new MemoryStream();
                    book.Write(ms1);
                    ms1.Seek(0, SeekOrigin.Begin);
                    ms = ms1;
                }
                else
                {
                    FileStream fs = new FileStream(path, FileMode.Create);
                    book.Write(fs);
                    fs.Close();
                    ms = null;
                }
                return new ReturnMsg() { code = 0, msg = "" };
            }
            catch (Exception ex)
            {
                ms = null;
                return new ReturnMsg() { code = 1, msg = "导出异常：" + ex.Message };
            }
        }
        //将集合类转换成DataTable 
        private static DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                foreach (object t in list)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(t, null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
    }
}
