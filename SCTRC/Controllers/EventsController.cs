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
using System.Web.Security;

namespace SCTRC.Controllers
{
    [Authorize]
    public class EventsController : ApiController
    {
        private SctrcContainer db = new SctrcContainer();

        // GET: api/Events
        [AllowAnonymous]
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        [HttpGet]
        [Route("api/eventsforuser")]
        public IQueryable<Event> EventsForUser()
        {
            var events = db.Events.Where(x => x.UserId == User.Identity.Name);
            return events;
        }

        // GET: api/Events/5
        [AllowAnonymous]
        public HttpResponseMessage GetEvent(int id)
        {
            db.Database.Log = Console.WriteLine;
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpRequestException("Event not found"));
            }
            var activities = db.Activities.Where(x => x.EventId == id);
            @event.Activities = activities.ToList();
            return Request.CreateResponse<Event>(HttpStatusCode.OK, @event);
        }

        // PUT: api/Events/5
        public HttpResponseMessage PutEvent(int id, Event @event)
        {
            @event.UpdatedAt = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpRequestException("Event update fail"));
            }

            if (id != @event.Id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpRequestException("Event update fail"));
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpRequestException("Event not found"));
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse<Event>(HttpStatusCode.OK, @event);
        }

        // POST: api/Events
        public HttpResponseMessage PostEvent(Event @event)
        {
            @event.CreatedAt = DateTime.Now;
            @event.UpdatedAt = @event.CreatedAt;
            @event.StartDate = DateTime.Parse(@event.StartDate.ToString());
            @event.EndDate = DateTime.Parse(@event.EndDate.ToString());
            @event.UserId = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpRequestException("Event create fail"));
            }

            db.Events.Add(@event);
            db.SaveChanges();

            return Request.CreateResponse<Event>(HttpStatusCode.Created, @event);
        }

        // DELETE: api/Events/5
        public HttpResponseMessage DeleteEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpRequestException("Event not found"));
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Request.CreateResponse<Event>(HttpStatusCode.OK, @event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}