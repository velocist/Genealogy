using ExcelDataReader;
using ExcelDataReader.Log;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace velocist.WebApplication.Core {

    /// <summary>
    /// Excel helper class
    /// </summary>
    /// <typeparam name="T">The type encapsulating a T</typeparam>
    public static class ExcelHelper<T> where T : FileViewerModel {

        private static readonly ILog _log = LogManager.GetLogger(typeof(ExcelHelper<FileViewerModel>));

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="path">Path file to import</param>
        /// <param name="initRowHeader"></param>
        /// <returns></returns>
        public static List<FileViewerModel> Import(string path, int initRowHeader) {
            try {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                List<FileViewerModel> modelFileViewer = null;
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read)) {
                    DataSet dataSet = null;
                    if (Path.GetExtension(path).ToUpper() == ".CSV") {
                        using (var reader = ExcelReaderFactory.CreateCsvReader(stream)) {
                            if (initRowHeader >= 0) {
                                dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
                                        //UseHeaderRow = true, // To set First Row As Column Names                                
                                        FilterRow = rowReader => rowReader.Depth > initRowHeader,
                                        UseHeaderRow = true,
                                        ReadHeaderRow = (reader) => {
                                            if (initRowHeader > 0) {
                                                for (int i = 0; i < (initRowHeader - 1); i++)
                                                    reader.Read();
                                            }
                                        },
                                    }
                                });
                            } else if (initRowHeader == -1) {
                                dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
                                        UseHeaderRow = false
                                    }
                                });
                            }
                        }
                    } else if (Path.GetExtension(path).ToUpper() == ".XLS") {
                        //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
                        using (var reader = ExcelReaderFactory.CreateBinaryReader(stream)) {
                            if (initRowHeader >= 0) {
                                dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
                                        //UseHeaderRow = true, // To set First Row As Column Names                                
                                        FilterRow = rowReader => rowReader.Depth > initRowHeader,
                                        UseHeaderRow = true,
                                        ReadHeaderRow = (reader) => {
                                            if (initRowHeader > 0) {
                                                for (int i = 0; i < (initRowHeader - 1); i++)
                                                    reader.Read();
                                            }
                                        },
                                    }
                                });
                            } else if (initRowHeader == -1) {
                                dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
                                        UseHeaderRow = false
                                    }
                                });
                            }
                        }
                    } else if (Path.GetExtension(path).ToUpper() == ".XLSX") {
                        //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream)) {
                            if (initRowHeader >= 0) {
                                dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
                                        //UseHeaderRow = true, // To set First Row As Column Names                                
                                        FilterRow = rowReader => rowReader.Depth > initRowHeader,
                                        UseHeaderRow = true,
                                        ReadHeaderRow = (reader) => {
                                            if (initRowHeader > 0) {
                                                for (int i = 0; i < (initRowHeader - 1); i++)
                                                    reader.Read();
                                            }
                                        },
                                    }
                                });
                            } else if (initRowHeader == -1) {
                                dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
                                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
                                        UseHeaderRow = false
                                    }
                                });
                            }

                        }
                    }

                    modelFileViewer = new List<FileViewerModel>();
                    if (dataSet.Tables.Count > 0) {
                        foreach (DataTable data in dataSet.Tables) {
                            FileViewerModel model = new FileViewerModel();
                            model.PathFile = path;
                            model = GetData(model, data);
                            modelFileViewer.Add(model);
                        }
                    }

                }
                return modelFileViewer;
            } catch (Exception ex) {
                _log.Error(ex.Message);
            }
            return null;
        }

        private static FileViewerModel GetData(FileViewerModel model, DataTable dataSet) {
            var dataTable = dataSet;// dataSet.Tables[0];

            model.TableName = dataTable.TableName;

            model.TableColumnsListString = new List<string>();
            model.TableColumnsListString.Add("FilaId");
            int columnsCount = dataTable.Columns.Count;
            for (int i = 0; i < columnsCount; i++) {
                model.TableColumnsListString.Add(dataTable.Columns[i].ColumnName);
            }
            bool addRow = false;
            List<object> _rows = new List<object>();

            int indexRow = 1;
            for (int _row = 0; _row < dataTable.Rows.Count; _row++) {
                //_log.Debug($"_row: {_row}");
                //object[] row = dataTable.Rows[_row].ItemArray;
                object[] row = new object[columnsCount + 1];
                row[0] = indexRow;
                int indexColumn = 1;
                for (int i = 0; i < columnsCount; i++) {
                    //_log.Debug($"row[{indexColumn}] = dataTable.Rows[{_row}].ItemArray[{i}]");
                    row[indexColumn] = dataTable.Rows[_row].ItemArray[i];
                    indexColumn++;
                }
                for (int columnCheck = 1; columnCheck < row.Length - 1; columnCheck++) {
                    if (row[columnCheck] == null || row[columnCheck].ToString().Equals(string.Empty)) {
                        addRow = false;
                    } else {
                        addRow = true;
                    }
                }
                if (addRow) {
                    _rows.Add(row);
                    indexRow++;
                }
            }
            model.Rows = _rows;
            return model;
        }

        //public static DataTable ImportToDataTable(string path) {
        //    try {
        //        List<T> list = new List<T>();
        //        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //        using (var stream = File.Open(path, FileMode.Open, FileAccess.Read)) {
        //            using (var reader = ExcelReaderFactory.CreateCsvReader(stream)) {
        //                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration {
        //                    ConfigureDataTable = _ => new ExcelDataTableConfiguration {
        //                        UseHeaderRow = true // To set First Row As Column Names    
        //                    }
        //                });

        //                if (dataSet.Tables.Count > 0) {
        //                    var dataTable = dataSet.Tables[0];
        //                    return dataTable;
        //                }

        //            }
        //        }
        //    } catch (Exception ex) {
        //        _log.Error(ex.Message);
        //    }
        //    return null;
        //}

    }
}
