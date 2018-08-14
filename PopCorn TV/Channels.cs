using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PopCorn_TV
{
    public struct ChannelInfo
    {
        public string name;
        public string urlLogo;
        public string country;
        public string urlStream;
    }

    public class Channels
    {
        const string nameFile = "TVList.m3u";
        public static List<ChannelInfo> tvChannels;

        public static bool importError = false;
        public static int channelError;

        public static void Load()
        {
            // Reset Channels Errors
            channelError = 0;

            try
            {    
                if (!File.Exists(nameFile))
                    MessageBox.Show("Channels was not found. " +
                        "Restart the application.", "Error!");
                else
                {
                    tvChannels = new List<ChannelInfo>();

                    StreamReader reader = new StreamReader(nameFile);

                    string line = reader.ReadLine();

                    

                    while (line != null)
                    {
                        ChannelInfo channel = new ChannelInfo();

                        // Get Info from Channel

                        if (line.Length > 0)
                        {
                            var matches = Regex.Matches(line, "\".*?\"");

                            // Verify data

                            channel.name = SaveChannel(matches[1].Value);
                            
                            channel.urlLogo = SaveChannel(matches[2].Value);

                            channel.country = SaveChannel(matches[3].Value);
                        }
                        else
                        {
                            channelError++;
                            importError = true;
                        }

                        // Get URL for Streaming

                        line = reader.ReadLine();
                        if ((line != null && line.Length > 0) && !importError)
                        {
                            channel.urlStream = line.ToLower();
                            tvChannels.Add(channel);

                            MessageBox.Show(channel.name + " " + channel.country
                                + " " + channel.urlStream);
                        }
                        else if (!importError)
                            channelError++;

                        importError = false;
                        line = reader.ReadLine();
                    }

                    MessageBox.Show("Import error in " + channelError + 
                        " channels.", "Error!");

                    reader.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Error in Data Server. Contact us. " +
                    "More Info: " + e.Message, "Error!");
            }
            catch (IOException e)
            {
                MessageBox.Show("Error in data import. Contact us. " +
                    "More Info: " + e.Message, "Error!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Channels could not be preloaded. " +
                    "Restart the application. More Info: " + e.Message, "Error!");
            }
        }

        private static string SaveChannel(string data)
        {
            if (data.Replace("\"", "").Length > 0)
                return data.Replace("\"", "").ToUpper();
            else
            {
                importError = true;
                channelError++;
                return null;
            }
        }
    }
}
