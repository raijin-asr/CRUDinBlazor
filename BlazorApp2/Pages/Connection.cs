using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeoSYSTEM
{
    public class Connection
    {
        public static NpgsqlConnection connect = null;
        public void Connect()
        {
            
            connect = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=raijin180; Database=postgres;");
            //connect = new NpgsqlConnection(@"Server=10.255.0.16;Port=5432;User Id=postgres;Password=NeoBiz; Database=postgres;");

            try
            {
                connect.Open();
            }
            catch (Exception)
            {
                //nothing 
            }
        }
        public void Close()
        {

            try
            {
                connect.Close();
            }
            catch (Exception)
            {
                //nothing 
            }
        }

    }
}