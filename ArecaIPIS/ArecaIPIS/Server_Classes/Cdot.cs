using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using ArecaIPIS.Forms.HomeForms;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ArecaIPIS.Server_Classes
{
    class Cdot
    {



        public async static Task<string> CDotWebRequest()
        {
            string responsestr = string.Empty;

            try
            {
                DataSet dscdotconfg = frmInterface.dscdotconfg;
                string cdotstationcode = dscdotconfg.Tables[0].Rows[0]["StationCode"].ToString();
                string userpwd = dscdotconfg.Tables[0].Rows[0]["userPass"].ToString();

                for (int i = 0; i < dscdotconfg.Tables[1].Rows.Count; i++)
                {
                    string WEBSERVICE_URL = dscdotconfg.Tables[1].Rows[i]["CdotUrl"].ToString();
                    string username = dscdotconfg.Tables[1].Rows[i]["Username"].ToString();
                    string password = dscdotconfg.Tables[1].Rows[i]["Password"].ToString();
                    int pkeyAlert = Convert.ToInt32(dscdotconfg.Tables[1].Rows[0]["Pkey"].ToString());

                    try
                    {
                        // Create the web request
                        byte[] data = Encoding.UTF8.GetBytes("");
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(WEBSERVICE_URL);

                        // Basic authentication
                        string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
                        httpWebRequest.Headers["Authorization"] = "Basic " + base64Credentials;
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("station_code", cdotstationcode);
                        httpWebRequest.Headers.Add("user_key", userpwd);

                        using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                        {
                            string dataString = Encoding.UTF8.GetString(data); // Convert byte[] to string
                            await streamWriter.WriteAsync(dataString);
                        }


                        // Handle the response
                        using (var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())

                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string responseContent = await streamReader.ReadToEndAsync();
                            if (!string.IsNullOrEmpty(responseContent))
                            {
                                XmlDocument xmldoc = new XmlDocument();
                                xmldoc.LoadXml(responseContent);

                                string xmstryy = xmldoc.InnerXml;
                                // string filePath = @"D:\TruecolorFTP\Receive\CAP.xml";
                                // xmldoc.Save(filePath);

                                DataSet dstables = stam(xmstryy);
                                string response = await InsertCapXmltoDBbydataset(dstables, xmstryy, pkeyAlert);

                                if (!response.Equals("true"))
                                {
                                    responsestr += "<br/><br/>" + response;
                                }
                            }
                        }
                    }
                    catch (Exception innerEx)
                    {
                        Server.LogError(innerEx.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }

            return responsestr;
        }

        public async static Task<string> CdotDisseminationStatistics()
        {
            try
            {
                StringBuilder jsonResponseBuilder = new StringBuilder();
                DataSet DTcdot = InterfaceDb.GetCdotInfodata(null);

                foreach (DataRow row in DTcdot.Tables[0].Rows)
                {
                    string identifier = row["identifier"].ToString();

                    if (!InterfaceDb.CheckCdotdissmentation(identifier))
                    {
                        continue; // Skip if dissemination is not required
                    }

                    DataSet dscdotconfg = InterfaceDb.GetCdotInfo();
                    DataSet dscdotidentifierData = InterfaceDb.GetCdotInfodata(identifier);
                    DataSet dscdotAlerturls = InterfaceDb.GetCdoturl(identifier);

                    if (dscdotAlerturls.Tables[0].Rows.Count == 0)
                    {
                        InterfaceDb.DeleteCdotAlertData(identifier);
                        continue; // No URL configuration found, skip processing
                    }

                    string cdotstationcode = dscdotconfg.Tables[0].Rows[0]["StationCode"].ToString();
                    string userpwd = dscdotconfg.Tables[0].Rows[0]["userPass"].ToString();
                    string username = dscdotconfg.Tables[0].Rows[0]["Username"].ToString();
                    string password = dscdotconfg.Tables[0].Rows[0]["Password"].ToString();
                    string WEBSERVICE_URL = dscdotAlerturls.Tables[0].Rows[0]["Dissemenationurl"].ToString();

                    // Setup HTTP request
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(WEBSERVICE_URL);
                    string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
                    httpWebRequest.Headers["Authorization"] = "Basic " + base64Credentials;
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Headers.Add("station_code", cdotstationcode);
                    httpWebRequest.Headers.Add("user_key", userpwd);

                    string capxmlStatus = dscdotidentifierData.Tables[0].Rows[0]["CapXmlStatus"].ToString().ToLower();

                    DataSet dscdotDataAudiocount = InterfaceDb.UpdateCdotDataAudiocount(3, identifier);
                    string startime = dscdotDataAudiocount.Tables[0].Rows[0]["Starttime"].ToString();
                    string formattedStartTime = !string.IsNullOrEmpty(startime) ? Convert.ToDateTime(startime).ToString("yyyy-MM-dd HH:mm:ss.fff") : "";
                    string end_time = dscdotidentifierData.Tables[0].Rows[0]["expires"].ToString();
                    string message_display_count = dscdotDataAudiocount.Tables[0].Rows[0]["Datacount"].ToString();
                    string audio_announcemt_count = dscdotDataAudiocount.Tables[0].Rows[0]["Audiocount"].ToString();

                    var data = new
                    {
                        alert_identifier = identifier,
                        station_code = cdotstationcode,
                        start_time = formattedStartTime,
                        end_time = end_time,
                        message_display_count = message_display_count,
                        audio_announcement_count = audio_announcemt_count,
                        status = capxmlStatus,
                        failure_reason = ""
                    };

                    string json = JsonConvert.SerializeObject(data);

                    using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                    {
                        await streamWriter.WriteAsync(json);
                    }

                    using (HttpWebResponse httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = await streamReader.ReadToEndAsync();
                            jsonResponseBuilder.Append($"Dissemination Status: <br/>Alert Identifier: {identifier}<br/>Station Code: {cdotstationcode}<br/>Start Time: {startime}<br/>End Time: {end_time}<br/>Message Display Count: {message_display_count}<br/>Audio Announcement Count: {audio_announcemt_count}<br/>Status: {capxmlStatus}<br/>Result: {result}<br/><br/>");
                        }
                    }

                    InterfaceDb.DeleteCdotAlertData(identifier);
                }

                return jsonResponseBuilder.ToString();
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return "";
            }
        }

       
        public static DataSet stam(string xmlData)
        {
            StringReader theReader = new StringReader(xmlData);
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(theReader);

            return theDataSet;
        }
        private async static Task<string> InsertCapXmltoDBbydataset(DataSet dataSet, string xmlString, int pkAlertUrl)
        {

            try
            {


                string Xxmlstatus = "";
                // Load XML data

                XmlDocument xmlResponse = null;
                string identifier = "";
                bool capxmlexits = false;
                string retrnstr = "";
                string Exptime = "";
                //string 


                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    identifier = dataSet.Tables[0].Rows[0][0].ToString();
                    DataSet ds = InterfaceDb.GetCdotIdentifierStr(identifier);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        capxmlexits = true;
                        return "true";
                    }
                    else
                    {
                        //string xmlFilePath = @"D:\TruecolorFTP\Receive\" + identifier + ".xml";

                        //File.WriteAllText(xmlFilePath, xmlString);

                        string directoryPath = @"E:\Audio\CdotReceiveXml";
                        string xmlFilePath = Path.Combine(directoryPath, identifier + ".xml");

                        // Ensure the directory exists
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        // Write the file
                        File.WriteAllText(xmlFilePath, xmlString);


                    }



                }

                if (capxmlexits == false)
                {
                    retrnstr = "Received Alert" + "<br/>";
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        string strcolname = "";
                        string strcoltext = "";
                        string finalcolname = "";
                        int index = 0;
                        string[] strcolumntext = new string[row.Table.Columns.Count - 1];

                        foreach (DataColumn column in row.Table.Columns)
                        {

                            strcolname = column.ColumnName;
                            if (strcolname == "identifier")
                            {
                                if (row[strcolname].ToString() == "" || row[strcolname].ToString() == null)
                                {
                                    Xxmlstatus = "null_identifier";
                                }
                                else
                                {
                                    if (ContainsNonNumericCharacters(row[strcolname].ToString()) == true)
                                    {
                                        Xxmlstatus = "wrong_identifier_code";
                                    }
                                }
                            }


                            if (strcolname == "status")
                            {

                                if (row[strcolname].ToString() == "Actual" || row[strcolname].ToString() == "Test")
                                {

                                }
                                else
                                {
                                    Xxmlstatus = "wrong_Status_code";
                                }


                            }

                            if (strcolname == "language")
                            {

                                if (row[strcolname].ToString() != "")
                                {
                                    Xxmlstatus = "null_language_code";
                                }
                            }

                            if (strcolname != "references")
                            {
                                strcoltext = "'" + row[strcolname].ToString() + "'";
                                finalcolname = column.ColumnName;

                                strcolumntext[index] = row[strcolname].ToString();
                                index++;
                                if (strcolname == "sent")
                                {
                                    retrnstr = retrnstr + "Identifier : " + identifier + "<br/>";
                                    retrnstr = retrnstr + "Sent : " + strcoltext + "<br/>";
                                }

                            }

                        }

                        InterfaceDb.InsertCdotAlert(strcolumntext[0], strcolumntext[1], strcolumntext[2], strcolumntext[3], strcolumntext[4], strcolumntext[5], strcolumntext[6], strcolumntext[7], strcolumntext[7], strcolumntext[9], strcolumntext[10], strcolumntext[11]);

                    }


                    foreach (DataRow row in dataSet.Tables[1].Rows)
                    {
                        string[] ColumnNameArr = new string[row.Table.Columns.Count];
                        string strcolname = "";
                        string strcoltext = "";
                        string finalcolname = "";
                        int index = 0;

                        foreach (DataColumn column in row.Table.Columns)
                        {

                            strcolname = column.ColumnName;
                            strcoltext = "" + row[strcolname].ToString() + "";
                            finalcolname = column.ColumnName;
                            ColumnNameArr[index] = row[strcolname].ToString();
                            index++;
                            // retrnstr = retrnstr + strcolname + ":" + strcoltext + Environment.NewLine;
                            if (strcolname == "effective")
                            {
                                retrnstr = retrnstr + "Effective : " + strcoltext + "<br/>";
                            }
                            if (strcolname == "expires")
                            {
                                //retrnstr += "Expires : " + strcoltext + "<br/>";

                                DateTime originalDateTime;
                                bool isValidDate = DateTime.TryParseExact(
                                    strcoltext,
                                    "yyyy-MM-dd HH:mm:ss.fff",
                                    null,
                                    System.Globalization.DateTimeStyles.None,
                                    out originalDateTime);

                                if (isValidDate)
                                {
                                    // Adding 1 minute to the parsed date
                                    DateTime newDateTime = originalDateTime.AddMinutes(1);
                                    Exptime = newDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                                    // Optionally add to the return string to display the new expiration time
                                    retrnstr += "Expires : " + Exptime + "<br/>";
                                }
                                else
                                {
                                    // Handle the case where the date is invalid
                                    retrnstr += "Invalid date format in 'expires' field.<br/>";
                                }
                            }

                            if (strcolname == "headline")
                            {
                                retrnstr = retrnstr + "Headline : " + strcoltext + "<br/>";
                            }
                            if (strcolname == "headline")
                            {

                                if (row[strcolname].ToString() == "")
                                {
                                    Xxmlstatus = "null_headline";
                                }

                                if (ContainsSpecialCharacters(row[strcolname].ToString()))
                                {
                                    //Xxmlstatus = "wrong_headline_character";
                                }

                            }



                        }

                        InterfaceDb.InsertCdotInfo(identifier, pkAlertUrl, ColumnNameArr[0], ColumnNameArr[1], ColumnNameArr[2], ColumnNameArr[3], ColumnNameArr[4], ColumnNameArr[5], ColumnNameArr[6], ColumnNameArr[7], ColumnNameArr[8], Exptime, ColumnNameArr[10], ColumnNameArr[11], ColumnNameArr[12], ColumnNameArr[13], ColumnNameArr[14], ColumnNameArr[15], ColumnNameArr[16]);
                        //BusinessLogicLayer.UpdateCdotmsgcctv(ColumnNameArr[10].ToString());
                    }


                    string urlaudio = "";
                    string[] ColumnNameArr3 = new string[0];
                    foreach (DataRow row in dataSet.Tables[3].Rows)
                    {
                        string strcolname = "";
                        string strcoltext = "";
                        string finalcolname = "";
                        int index = 0;

                        ColumnNameArr3 = new string[row.Table.Columns.Count];
                        foreach (DataColumn column in row.Table.Columns)
                        {


                            strcolname = column.ColumnName;
                            strcoltext = "'" + row[strcolname].ToString() + "'";

                            finalcolname = finalcolname + "," + column.ColumnName;
                            ColumnNameArr3[index] = row[strcolname].ToString();
                            index++;


                            if (strcolname == "uri")
                            {
                                if (row[strcolname].ToString() == "")
                                {
                                    Xxmlstatus = "null_uri";
                                }
                                strcoltext = "'" + row[strcolname].ToString() + "'";

                                string[] getfilename = row[strcolname].ToString().Split('?');

                                string[] getsubfilename = getfilename[1].Split('=');
                                string filenamestr = getsubfilename[1].ToString();

                                urlaudio = filenamestr;
                                finalcolname = finalcolname + "," + column.ColumnName;
                                if (filenamestr == "")
                                {
                                    Xxmlstatus = "unreahable_uri";
                                }
                            }



                        }



                    }


                    string arecdesc = "";

                    foreach (DataRow row in dataSet.Tables[4].Rows)
                    {
                        string strcolname = "";
                        string strcoltext = "";
                        string finalcolname = "";
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            strcolname = column.ColumnName;
                            if (strcolname == "areaDesc")
                            {
                                strcoltext = "'" + row[strcolname].ToString() + "'";
                                arecdesc = row[strcolname].ToString();
                                finalcolname = finalcolname + "," + column.ColumnName;
                                // retrnstr = retrnstr + strcolname + ":" + strcoltext + Environment.NewLine;
                            }





                        }



                    }
                    if (Xxmlstatus == "")
                    {
                        Xxmlstatus = "Success";
                    }
                    InterfaceDb.UpdateCdotInfo(identifier, ColumnNameArr3[0], ColumnNameArr3[1], Convert.ToInt32(ColumnNameArr3[2]), ColumnNameArr3[3], ColumnNameArr3[4], arecdesc, ColumnNameArr3[5], urlaudio, Xxmlstatus);

                    InterfaceDb.InsertCdotAlertReports(identifier);
                    InterfaceDb.CDotUpdate(identifier);
                    string Ackoledmstr = await Cdoturlresponse(identifier);

                    retrnstr = retrnstr + Ackoledmstr;
                    urldownload(identifier);
                    //BusinessLogicLayer.UpdateCdotvdcstatus(true, identifier);
                    // SendToAnn_Cdot(identifier);
                    if (BaseClass.IsCdotAutoMode())
                    {
                        if (!CdotController.pausecdot)
                        {
                            InterfaceDb.InsertintoSendMessages(identifier, null);
                            frmCdot fcdot = new frmCdot();
                            fcdot.SendToAnn_Cdot(identifier);
                        }

                    }

                    //downloadFile(urlaudio);
                    //BusinessLogicLayer.UpdateCdotInfo(identifier, ColumnNameArr[0], ColumnNameArr[1], Convert .ToInt32(ColumnNameArr[2]), ColumnNameArr[3], ColumnNameArr[4], arecdesc,ColumnNameArr[5]);
                }
                return JsonConvert.SerializeObject(retrnstr);
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return "false";

            }
        }
        public static string SendToAnn_Cdot(string Identifier)
        {
            try
            {
                var dt = "";
                DataTable UpdatedFile = new DataTable();
                // DataSet DTcdot = BusinessLogicLayer.GetCdotInfodata(Identifier);
                DataSet DTcdot = InterfaceDb.GetCdotInfodata(Identifier);
                string[] dotstr = new string[DTcdot.Tables[0].Rows.Count];
                string cdotpathstr = "";
                string Finalcdotpath = "";
                int newseq = 1;
                UpdatedFile.Columns.Add("LanguageID", typeof(int));
                UpdatedFile.Columns.Add("Sequence", typeof(int));
                UpdatedFile.Columns.Add("AudioFile", typeof(string));

                DataSet DTcdotsenddata = InterfaceDb.GetCdotsenddata(Identifier);


                bool cdotsenddata = Convert.ToBoolean(DTcdotsenddata.Tables[0].Rows[0]["CdotSendaData"].ToString());
                if (DTcdot.Tables[0].Rows.Count > 0 && cdotsenddata == true)
                {
                    for (int i = 0; i < DTcdot.Tables[0].Rows.Count; i++)
                    {
                        string Chimecdot = "E:\\Audio\\English\\Numbers\\chimes.wav";
                        UpdatedFile.Rows.Add(1, newseq, Chimecdot);
                        newseq = newseq + 1;
                        cdotpathstr = DTcdot.Tables[0].Rows[i]["AudioUrl"].ToString();
                        Finalcdotpath = "E:\\Audio\\CDOT\\" + cdotpathstr;
                        UpdatedFile.Rows.Add(1, newseq, Finalcdotpath);

                        newseq = newseq + 1;


                        UpdatedFile.Rows.Add(1, newseq, Chimecdot);

                        newseq = newseq + 1;
                    }
                    InterfaceDb.UpdateCdotDataAudiocount(2, "");

                }
                if (UpdatedFile != null && UpdatedFile.Rows.Count > 0)
                {


                    dt = JsonConvert.SerializeObject(InterfaceDb.PlayAnnouncemnet(UpdatedFile, 1, ""));

                    DirectoryInfo logDirInfos = null;
                    FileInfo logFileInfos;
                    string logFilePaths = "C:\\ShareToAll\\";
                    logFilePaths = logFilePaths + "Announcement.txt";
                    logFileInfos = new FileInfo(logFilePaths);
                    logDirInfos = new DirectoryInfo(logFileInfos.DirectoryName);
                    if (!logDirInfos.Exists) logDirInfos.Create();
                    if (!logFileInfos.Exists)
                    {
                        logFileInfos.Create();
                    }

                    File.WriteAllText(logFilePaths, String.Empty);
                    StreamWriter swExtLogFiles = new StreamWriter(logFilePaths, true);
                    for (var i = 0; i < UpdatedFile.Rows.Count; i++)
                    {
                        swExtLogFiles.Write(UpdatedFile.Rows[i]["AudioFile"].ToString());

                        swExtLogFiles.Write(Environment.NewLine);
                    }
                    swExtLogFiles.Flush();
                    swExtLogFiles.Close();


                }


                return dt;
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return null;
            }
        }

        public static void urldownload(string uri)
        {
            try
            {
                CdotAudiourl(uri);

            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }
        public static void CdotAudiourl(string uri)
        {
            try
            {
                // Fetch configuration data
                // DataSet dscdotconfg = InterfaceDb.GetCDotConfiguration();
                DataSet dscdotconfg = frmInterface.dscdotconfg;
                DataSet dscdotidentifierData = InterfaceDb.GetCdotInfodata(uri);

                string cdotstationcode = dscdotconfg.Tables[0].Rows[0]["StationCode"].ToString();
                string cdotIdentifier = dscdotidentifierData.Tables[0].Rows[0]["identifier"].ToString();
                string AudioFileName = dscdotidentifierData.Tables[0].Rows[0]["AudioUrl"].ToString();
                string userpwd = dscdotconfg.Tables[0].Rows[0]["userPass"].ToString();
                string WEBSERVICE_URL = dscdotidentifierData.Tables[0].Rows[0]["uri"].ToString().Trim();
                string username = dscdotconfg.Tables[0].Rows[0]["Username"].ToString();
                string password = dscdotconfg.Tables[0].Rows[0]["Password"].ToString();

                //valid for each identifier

                DataSet dscdotAlerturls = InterfaceDb.GetCdoturl(cdotIdentifier);
                username = dscdotAlerturls.Tables[0].Rows[0]["Username"].ToString(); //"IpisClient";
                password = dscdotAlerturls.Tables[0].Rows[0]["Password"].ToString(); //"Cdot@user1";
                // Set up the HTTP request
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(WEBSERVICE_URL);
                string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
                httpWebRequest.Headers["Authorization"] = "Basic " + base64Credentials;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("station_code", cdotstationcode);
                httpWebRequest.Headers.Add("user_key", userpwd);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var data = new
                    {
                        alert_identifier = cdotIdentifier
                    };

                    string json = JsonConvert.SerializeObject(data);
                    streamWriter.Write(json);
                }

                // Define the file path and create the directory if not exists
                string documentsPath = @"E:\\Audio\\CDOT";
                if (!Directory.Exists(documentsPath))
                {
                    Directory.CreateDirectory(documentsPath);
                }

                string localPath = Path.Combine(documentsPath, AudioFileName);

                // Handle response and save audio file
                using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var responseStream = httpResponse.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                responseStream.CopyTo(memoryStream);
                                byte[] responseData = memoryStream.ToArray();

                                // Save the audio file locally
                                File.WriteAllBytes(localPath, responseData);
                            }
                        }
                        else
                        {
                            throw new Exception("No response stream received from the server.");
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                // Handle web-related errors (e.g., network failure)
                Console.WriteLine("Web Exception: " + webEx.Message);
                if (webEx.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)webEx.Response)
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        //Console.WriteLine("Error response from server: " + error);
                    }
                }
            }
            catch (IOException ioEx)
            {
                ioEx.ToString();
                // Handle file IO related errors
                // Console.WriteLine("IO Exception: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                ex.ToString();
                // Log other exceptions
                //Console.WriteLine("General Exception: " + ex.Message);
            }
        }

     
        public static bool ContainsSpecialCharacters(string input)
        {



            string pattern = @"[^a-zA-Z0-9\s]";
            return Regex.IsMatch(input, pattern);
            //return false; // No special or escape characters found
        }
        public static bool ContainsNonNumericCharacters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return true; // Found a non-numeric character
                }
            }
            return false; // No non-numeric characters found
        }
        public async static Task<string> Cdoturlresponse(string identifier)
        {
            try
            {
                DataSet dscdotconfg = frmInterface.dscdotconfg;
                DataSet dscdotidentifierData = InterfaceDb.GetCdotInfodata(identifier);
                DataSet dscdotAlerturls = InterfaceDb.GetCdoturl(identifier);

                string cdotstationcode = dscdotconfg.Tables[0].Rows[0]["StationCode"].ToString();
                string cdotIdentifier = dscdotidentifierData.Tables[0].Rows[0]["identifier"].ToString();
                string userpwd = dscdotconfg.Tables[0].Rows[0]["userPass"].ToString();
                string WEBSERVICE_URL = dscdotAlerturls.Tables[0].Rows[0]["validationstatusurl"].ToString();
                string username = dscdotAlerturls.Tables[0].Rows[0]["Username"].ToString();
                string password = dscdotAlerturls.Tables[0].Rows[0]["Password"].ToString();

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // Create the web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WEBSERVICE_URL);
                string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

                string capxmlStatus = dscdotidentifierData.Tables[0].Rows[0]["CapXmlStatus"].ToString();

                httpWebRequest.Headers["Authorization"] = "Basic " + base64Credentials;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("station_code", cdotstationcode);
                httpWebRequest.Headers.Add("user_key", userpwd);

                // Prepare JSON data to send
                var data = new
                {
                    alert_identifier = cdotIdentifier,
                    validation_status = capxmlStatus
                };

                string json = JsonConvert.SerializeObject(data);

                // Write data to request stream asynchronously
                using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                {
                    await streamWriter.WriteAsync(json);
                }

                // Get the response asynchronously
                using (var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string JsonString = await streamReader.ReadToEndAsync();
                    InterfaceDb.UpdateCdotMsgTime(identifier, DateTime.Now, 1);
                    return JsonString;
                }
            }
            catch (Exception ex)
            {
                Server.LogError(ex.Message);
                return string.Empty;
            }
        }

     

    }
}
