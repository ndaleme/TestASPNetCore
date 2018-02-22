using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestASPNetCore.Controllers
{
    public class HelloWorldController
    {

        private static Dictionary<string, string> _dico = new Dictionary<string, string>();

        [HttpGet("display/{val}")]
        public string HelloWorld(string val)
        {
            return val;
        }

        //[HttpGet("dico/add/{key}")]
        //public string Add(string key, string val)
        //{
        //    _dico[key] = val;

        //    return String.Format("{0} added to the dico!", key);
        //}

        [HttpPost("dico/{key}")]
        public string Post(string key, [FromBody] string val)
        {
            _dico[key] = val;

            return String.Format("{0} added to the dico!", key);
        }

        [HttpGet("dico/{key}")]
        public string Get(string key)
        {
            if (!_dico.ContainsKey(key))
            {
                return String.Format(" key {0} not found in the dico!", key);
            }
            return _dico[key];
        }


        [HttpPatch("dico/{key}")]
        public string Update(string key, [FromBody] string val)
        {
            if (!_dico.ContainsKey(key))
            {
                return String.Format(" key {0} not found in the dico!", key);
            }

            _dico[key] = val;

            return "dico updated.";
        }

        [HttpDelete("dico/{key}")]
        public string Delete(string key)
        {
            if (!_dico.ContainsKey(key))
            {
                return String.Format(" key {0} not found in the dico!", key);
            }

            _dico.Remove(key);

            return "key deleted.";
        }
    }
}
