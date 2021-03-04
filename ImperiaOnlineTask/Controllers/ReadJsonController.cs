using ImperiaOnlineTask.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ImperiaOnlineTask.Controllers
{
    public class ReadJsonController : Controller
    {
        [HttpGet("api/openChest/{id}")]
        public string GetQuery(string id)
        {
            string Json = System.IO.File.ReadAllText("config.json");
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Chest> chests = ser.Deserialize<List<Chest>>(Json);
            foreach(Chest ch in chests)
            {
                if(ch.ChestId == Int32.Parse(id))
                {
                    return Chest.MakeChest(ch);
                }
            }
            string json3 = JsonConvert.SerializeObject(new
            {
                Success = false
            });
            return json3;
        }
    }
}
