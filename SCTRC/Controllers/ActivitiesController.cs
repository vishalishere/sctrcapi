using SCTRC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SCTRC.Controllers
{
    [Authorize]
    public class ActivitiesController : ApiController
    {
        private SctrcContainer db = new SctrcContainer();

        // GET: api/Activities
        //TODO: It cannot get all activities, but can get some specific activities
        //TODO: Create get acitivites for event, given event id
        [AllowAnonymous]
        public IQueryable<Activity> GetActivities()
        {
            return db.Activities;
        }

        // GET: api/Activities/5
        [AllowAnonymous]
        public HttpResponseMessage GetActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpRequestException("Event not found"));
            }
            return Request.CreateResponse<Activity>(HttpStatusCode.OK, activity);
        }

        // PUT: api/Activities/5
        public HttpResponseMessage PutActivity(int id, Activity activity)
        {
            activity.UpdatedAt = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpRequestException("Event update fail"));
            }

            if (id != activity.Id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpRequestException("Event update fail"));
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpRequestException("Event not found"));

                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse<Activity>(HttpStatusCode.OK, activity);
        }

        // POST: api/Activities
        public HttpResponseMessage PostActivity(Activity activity)
        {
            activity.UpdatedAt = DateTime.Now;
            activity.CreatedAt = activity.UpdatedAt;
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpRequestException("Event update fail"));
            }

            db.Activities.Add(activity);
            db.SaveChanges();

            return Request.CreateResponse<Activity>(HttpStatusCode.Created, activity);
        }

        // DELETE: api/Activities/5
        public HttpResponseMessage DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpRequestException("Event not found"));
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Request.CreateResponse<Activity>(HttpStatusCode.OK, activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.Id == id) > 0;
        }
    }
}