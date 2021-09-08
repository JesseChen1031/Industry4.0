using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        public SqlCommand cmd = null;
        public SqlConnection conn = null;
        public string sql = null;

        [Route("GetOrders")]
        [HttpGet]
        public string GetOrders()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=1205afternoon;User ID=sa;Password=123456";
            sql = "select * from orders";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds);

        }

        public class Test
        {
            public string name { get; set; }
            public string pwd { get; set; }
        }

        [Route("test")]
        [HttpPost]

        public string getOrders(Test test)
        {
            return   "name:  "+test.name + "   pwd: " + test.pwd;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
