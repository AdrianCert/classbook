using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Business.DataService;
using Microsoft.AspNetCore.Mvc;

namespace class_book.Controllers.API
{
    public class BaseApiController<Entity, EntityViewModel, EntityCreateModel, EntityEditModel> : ApiController
        where Entity : class
        where EntityViewModel : class, new()
        where EntityCreateModel : class, new()
        where EntityEditModel : class, new()
    {
        private readonly IDataService<Entity> db = new DataService<Entity>();
        private readonly Func<EntityCreateModel, Entity> SievingCreateModel;
        private readonly Func<EntityEditModel, Entity> SievingEditModel;
        public BaseApiController(Func<EntityCreateModel, Entity> _SievingCreateModel, Func<EntityEditModel, Entity> _SievingEditModel)
        {
            this.SievingCreateModel = _SievingCreateModel;
            this.SievingEditModel = _SievingEditModel;
        }
/*
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<EntityViewModel> list = db.GetAll().ToList().Select(e =>
            {
                return (EntityViewModel)Activator.CreateInstance(
                    typeof(EntityViewModel),
                    new object[] { e }
                    );
            }).ToList();
            return Ok(list);
        }*/

        [HttpGet]
        public IHttpActionResult Get(object id)
        {
            try
            {
                if(id == null)
                {
                    List<EntityViewModel> list = db.GetAll().ToList().Select(e =>
                    {
                        return (EntityViewModel)Activator.CreateInstance(
                            typeof(EntityViewModel),
                            new object[] { e }
                            );
                    }).ToList();
                    return Ok(list);
                }
                Entity entity = db.GetById(id);
                return Ok(
                    (EntityViewModel)Activator.CreateInstance(
                        typeof(EntityViewModel),
                        new object[]{ entity }
                        ));
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            catch(System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]EntityEditModel editObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Update(SievingEditModel(editObject));
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]EntityCreateModel entity)
        {
            try
            {
                db.Insert(SievingCreateModel(entity));
                //string facultyDetailsLocation = $"{Request.RequestUri}/{entity}";
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                db.Delete(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
