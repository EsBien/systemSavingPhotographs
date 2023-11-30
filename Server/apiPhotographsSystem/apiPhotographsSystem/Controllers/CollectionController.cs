using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using apiPhotographsSystem.Models;
using System.Reflection.Metadata;
using System.Text;
using BL;
using Entities;

namespace apiPhotographsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        IcollectionBL _collectionBL;
        public CollectionController(IcollectionBL collectionBL)
        {
            _collectionBL = collectionBL;
        }
        
        [HttpGet("{collectionNumber}")]
        public async Task<ActionResult<Collection>> GetCollectionName(string collectionNumber)
        {
            // Simulate data retrieval from the server
            Collection collection = _collectionBL.GetCollectionName(collectionNumber).Result;
   
            if(collection == null)
            {
                return NotFound("no collectionNumber in Db");
            }

            return Ok(collection);
        }
        [HttpPost()]//"saveCollection"
        public IActionResult SaveCollection([FromBody] Collection collectionData)
        {
            if(collectionData==null)
            {
                BadRequest("bad request collection empty!");
            }
            try
            {
                _collectionBL.SaveCollection(collectionData);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          

            
        }

       
    }
    

}
