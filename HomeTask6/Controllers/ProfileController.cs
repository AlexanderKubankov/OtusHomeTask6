using HomeTask6.Infrastructure;
using HomeTask6.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeTask6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly DataContext context;

        public ProfileController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public DtoProfile Get()
        {
            if (!TryGetUserId(out var id))
            {
                return default;
            }

            var profile = context.Profiles.FirstOrDefault(x => x.Id == id);
            return new DtoProfile { Resume = profile?.Resume };
        }

        [HttpPut]
        public DtoProfile Put( DtoProfile request)
        {
            if (!TryGetUserId(out var id))
            {
                return default;
            }

            var profile = context.Profiles.FirstOrDefault(x => x.Id == id);
            if (profile == null)
            {
                profile = new Profile() { Id = id, };
                context.Profiles.Add(profile);
            }

            profile.Resume = request.Resume;
            context.SaveChanges();
            return request;
        }

        private bool TryGetUserId(out Guid id)
        {
            var header = this.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "X-User");
            return Guid.TryParse(header.Value, out id);
        }
    }
}
