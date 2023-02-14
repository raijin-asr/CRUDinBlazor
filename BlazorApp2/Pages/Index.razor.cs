using BlazorApp2.Data;
using Microsoft.AspNetCore.Components;
using Npgsql;
using System.Data;
using NeoSYSTEM;
using System.Net;

namespace BlazorApp2.Pages
{
    public class IndexBase : ComponentBase
    {
        public class ItemDetail
        {
            public string id { get; set; }
            public string name { get; set; }
            public string college { get; set; }
        }
        protected List<ItemDetail> items = new();
     

        protected override void OnInitialized()
        {
            items=selectData();
        }

        public  List<ItemDetail> selectData(){

                Connection connect = new Connection();
                connect.Connect();
           
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;
                cmd.CommandText = "SELECT * FROM public.\"tblTest\" ORDER BY id ASC";

                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                adp.Fill(dtbl);
                items.Clear();
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    ItemDetail itDtl = new();
                    itDtl.id = dtbl.Rows[i]["id"].ToString();
                    itDtl.name = dtbl.Rows[i]["name"].ToString();
                    itDtl.college = dtbl.Rows[i]["college"].ToString();
                    items.Add(itDtl);
                }
                connect.Close();
            return items;
         }

        //for insert,delete
        public string id { get; set; }
        public string name { get; set; }
        public string college { get; set; }

        public void forInsert()
        {

            insertData(id, name, college);
            OnInitializedAsync();

        }

        private void insertData(String id, String name, String college)
        {
            Connection connect = new Connection();
            connect.Connect();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                cmd.CommandText = "INSERT INTO public.\"tblTest\" (id,name,college ) VALUES ('" + id + "', '" + name + "', '" + college + "')";
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception)
            {
          
            }
        }

        public void deleteData(String id)
        {
            
            Connection connect = new Connection();
            connect.Connect();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                cmd.CommandText = "DELETE FROM public.\"tblTest\" where id='" + id + "'";

                cmd.ExecuteNonQuery();
                connect.Close();
               
            }
            catch (Exception)
            {
            
            }
            OnInitializedAsync();
        }

 
        public void updateItem(String id, String name,String college)
        {
                Connection connect = new Connection();
                connect.Connect();
           
            String naam = name;
            String colz = college;
            try
            {
                
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connection.connect;

                string query = "UPDATE public.\"tblTest\" SET name ='" + naam + "',college ='" + colz + "' where id='" + id + "'";
                Console.WriteLine(query);
                cmd.CommandText = query;
                int exe=cmd.ExecuteNonQuery();

                connect.Close();
                
            }
            catch (Exception)
            {

            }
            
        }

    } //end of class
}//end of namespace